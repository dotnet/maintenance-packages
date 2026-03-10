---
description: >
  Daily scan of source projects under src/ to apply post-servicing version
  maintenance: update PackageValidationBaselineVersion to the latest NuGet
  release, reset IsPackable to false, and increment VersionPrefix and
  AssemblyVersion patch numbers.  Creates a pull request with any changes.

on:
  schedule: weekly
  workflow_dispatch:

permissions:
  contents: read
  pull-requests: read

runtimes:
  dotnet:
    version: "8.0"
  python:
    version: "3.x"

network:
  allowed:
    - defaults
    - dotnet

tools:
  github:
    toolsets: [repos, pull_requests]
  bash: true

safe-outputs:
  create-pull-request:
    title-prefix: "[Automated] "
    labels: [automation]
    max: 1
  noop:
    report-as-issue: false
---

# Post-Servicing Version Maintenance

You are a version-maintenance automation for the **dotnet/maintenance-packages**
repository.  Your job is to scan every source project under `src/`, apply the
four rules listed below, and open **one** pull request that contains all of the
resulting changes.  If no changes are needed, do nothing.

## Scope

Scan **all** MSBuild project files (`*.csproj`, `*.ilproj`) **and** property
files (`*.props`) that live under `src/`.

### Exclude

* Any file whose path contains a `tests` directory component
  (e.g. `src/System.Buffers/tests/…`).
* **Never** modify a line that contains the comment marker `NO-INCREMENT`
  anywhere on that line.

## Rules

Apply the following four rules **in order** to every in-scope file.

### Rule 1 – Update `PackageValidationBaselineVersion`

If the file defines a `<PackageValidationBaselineVersion>` property, compare
its value to the **latest stable version** of that package on nuget.org.

Derive the NuGet package name from the first directory component after `src/`
in the file path (e.g. `src/System.Buffers/…` → package `System.Buffers`).

Query the NuGet V3 flat-container API to find the latest version:

```bash
PACKAGE="system.buffers"  # lowercase
curl -sSL "https://api.nuget.org/v3-flatcontainer/${PACKAGE}/index.json" \
  | python3 -c "
import sys, json
versions = json.load(sys.stdin).get('versions', [])
stable = [v for v in versions if '-' not in v]
print(stable[-1] if stable else '')
"
```

> **Proxy note:** This workflow runs inside a sandboxed container where all
> HTTPS traffic is routed through a Squid proxy.  Use `curl` (which handles
> CONNECT-tunnel proxying and SSL natively) rather than Python's
> `urllib.request` for the NuGet HTTP calls.  The environment variables
> `HTTP_PROXY` / `HTTPS_PROXY` are pre-configured.

If the latest stable version differs from the current value, update the
property value in the file.

### Rule 2 – Reset `IsPackable` to `false`

If the file contains `<IsPackable>true</IsPackable>`, change `true` to
`false`.  This property is only flipped to `true` during a servicing release
and must be switched back immediately afterward.

### Rule 3 – Update `VersionPrefix`

There are two kinds of `<VersionPrefix>` element:

* **Unconditional** (no `Condition` attribute) – this records the **last
  published** version.  Set it to the **latest stable version** on nuget.org
  (the same value used for `PackageValidationBaselineVersion` in Rule 1).
* **Conditional** (has an MSBuild `Condition` attribute, typically
  `Condition="'$(IsPackable)' == 'true'"`) – this is the **next** version to
  ship.  Its value must be the unconditional version with the patch number
  incremented by one.  Only update it if it doesn't already have the correct
  value.

Examples (assuming latest NuGet version is `4.6.1`):

| Before | After | Notes |
|---|---|---|
| `<VersionPrefix>4.6.0</VersionPrefix>` | `<VersionPrefix>4.6.1</VersionPrefix>` | Set to latest NuGet |
| `<VersionPrefix Condition="…">4.6.1</VersionPrefix>` | `<VersionPrefix Condition="…">4.6.2</VersionPrefix>` | = unconditional + 1 |
| `<VersionPrefix Condition="…">4.6.2</VersionPrefix>` | *(no change)* | Already correct |

### Rule 4 – Increment `AssemblyVersion`

Only increment `<AssemblyVersion>` when the corresponding `<VersionPrefix>` in
the **same file** was actually changed by Rule 3.  If no `VersionPrefix` was
modified, leave all `AssemblyVersion` elements untouched.

When incrementing, bump the **third** numeric component.

Example: `4.0.5.0` → `4.0.6.0`, `6.0.3.0` → `6.0.4.0`.

**Important:** skip any `<AssemblyVersion>` line that contains the
`NO-INCREMENT` marker comment.

## Implementation approach

Below is a recommended Python helper that applies the four rules to a single
file.  You may use it as-is or adapt it.

```python
#!/usr/bin/env python3
import json, os, re, subprocess

NO_INCREMENT = "NO-INCREMENT"

def latest_nuget(pkg):
    """Fetch the latest stable version from NuGet using curl.

    Uses curl instead of urllib.request because the sandboxed container routes
    HTTPS through a Squid CONNECT-tunnel proxy.  curl handles this natively
    via HTTP_PROXY / HTTPS_PROXY, whereas Python's urllib.request may fail
    during the SSL handshake inside the tunnel.
    """
    url = f"https://api.nuget.org/v3-flatcontainer/{pkg.lower()}/index.json"
    try:
        result = subprocess.run(
            ["curl", "-sSL", "--max-time", "30", url],
            capture_output=True, text=True, timeout=35,
        )
        if result.returncode != 0:
            print(f"  WARNING: curl failed for {pkg}: {result.stderr.strip()}")
            return None
        vers = json.loads(result.stdout).get("versions", [])
        stable = [v for v in vers if "-" not in v]
        return stable[-1] if stable else None
    except Exception as e:
        print(f"  WARNING: Could not fetch NuGet version for {pkg}: {e}")
        return None

def bump_patch(v):
    p = v.split(".")
    if len(p) >= 3:
        p[2] = str(int(p[2]) + 1)
    return ".".join(p)

RE_BASELINE = re.compile(
    r"^(?P<pre>\s*<PackageValidationBaselineVersion>)"
    r"(?P<ver>[^<]+)"
    r"(?P<post></PackageValidationBaselineVersion>.*)$")
RE_PACKABLE = re.compile(
    r"^(?P<pre>\s*<IsPackable>)true(?P<post></IsPackable>.*)$")
RE_VERPREFIX_UNCOND = re.compile(
    r"^(?P<pre>\s*<VersionPrefix>)"
    r"(?P<ver>\d+\.\d+\.\d+)"
    r"(?P<post></VersionPrefix>.*)$")
RE_VERPREFIX_COND = re.compile(
    r"^(?P<pre>\s*<VersionPrefix\s+Condition[^>]*>)"
    r"(?P<ver>\d+\.\d+\.\d+)"
    r"(?P<post></VersionPrefix>.*)$")
RE_ASMVER = re.compile(
    r"^(?P<pre>\s*<AssemblyVersion[^>]*>)"
    r"(?P<ver>\d+\.\d+\.\d+\.\d+)"
    r"(?P<post></AssemblyVersion>.*)$")

def process(path, pkg):
    with open(path, "rb") as f:
        raw = f.read()
    bom = b""
    if raw.startswith(b"\xef\xbb\xbf"):
        bom, raw = raw[:3], raw[3:]
    le = "\r\n" if b"\r\n" in raw else "\n"
    text = raw.decode("utf-8")
    lines, out, changed = text.split(le), [], False
    nuget_ver = None
    ver_prefix_changed = False
    for line in lines:
        nl = line
        skip = NO_INCREMENT in line
        m = RE_BASELINE.match(line)
        if m and not skip:
            if nuget_ver is None:
                nuget_ver = latest_nuget(pkg)
            if nuget_ver and nuget_ver != m.group("ver"):
                nl = m.group("pre") + nuget_ver + m.group("post")
        m = RE_PACKABLE.match(line)
        if m:
            nl = m.group("pre") + "false" + m.group("post")
        m = RE_VERPREFIX_UNCOND.match(line)
        if m and not skip:
            if nuget_ver is None:
                nuget_ver = latest_nuget(pkg)
            if nuget_ver and nuget_ver != m.group("ver"):
                nl = m.group("pre") + nuget_ver + m.group("post")
                ver_prefix_changed = True
        m = RE_VERPREFIX_COND.match(line)
        if m and not skip:
            if nuget_ver is None:
                nuget_ver = latest_nuget(pkg)
            if nuget_ver:
                expected = bump_patch(nuget_ver)
                if m.group("ver") != expected:
                    nl = m.group("pre") + expected + m.group("post")
                    ver_prefix_changed = True
        if nl != line:
            changed = True
        out.append(nl)
    # Second pass: only bump AssemblyVersion if a VersionPrefix was changed
    if ver_prefix_changed:
        final = []
        for line in out:
            nl = line
            skip = NO_INCREMENT in line
            m = RE_ASMVER.match(line)
            if m and not skip:
                nl = m.group("pre") + bump_patch(m.group("ver")) + m.group("post")
            if nl != line:
                changed = True
            final.append(nl)
        out = final
    if changed:
        with open(path, "wb") as f:
            f.write(bom + le.join(out).encode("utf-8"))
    return changed
```

### Recommended workflow

1. **Find files** – use `find` to locate every `.csproj`, `.ilproj`, and
   `.props` file under `src/` whose path does **not** contain `/tests/`.

   ```bash
   find src -type f \( -name '*.csproj' -o -name '*.ilproj' -o -name '*.props' \) \
     | grep -v '/tests/'
   ```

2. **Run the helper** on each file, passing the NuGet package name derived
   from the path (first directory component after `src/`).

3. **Verify changes** – `git diff` to review that only the expected properties
   were touched and that `NO-INCREMENT` lines are untouched.

4. **Build and pack** – run the repository build script with the `-pack` switch
   to compile the solution and generate NuGet packages.  This ensures the
   version changes produce a valid build.

   ```bash
   ./build.sh -pack
   ```

5. **Create a pull request** using the `create_pull_request` safe-output tool with:
   * Title: `Post-servicing version updates`
   * Body: a summary table listing the **package name** (e.g. `Microsoft.IO.Redist`,
     not the full file path) and the changes applied to each package.

## Important notes

* Some versioning properties live in a shared `Versioning.props` file rather
  than directly in the `.csproj` / `.ilproj` – make sure those are included in
  the scan.
* If **no files** need changes, do **not** create a pull request.
