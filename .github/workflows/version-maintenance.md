---
description: >
  Daily scan of source projects under src/ to apply post-servicing version
  maintenance: update PackageValidationBaselineVersion to the latest NuGet
  release, reset IsPackable to false, and increment VersionPrefix and
  AssemblyVersion patch numbers.  Creates a pull request with any changes.

on:
  schedule: daily
  workflow_dispatch:

permissions:
  contents: read
  pull-requests: read

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
    labels: [automation, maintenance]
    max: 1
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

If the file defines a `<PackageValidationBaselineVersion>` (or the alternate
casing `<PackageValidationBaseLineVersion>`) property, compare its value to
the **latest stable version** of that package on nuget.org.

Derive the NuGet package name from the first directory component after `src/`
in the file path (e.g. `src/System.Buffers/…` → package `System.Buffers`).

Query the NuGet V3 flat-container API to find the latest version:

```bash
PACKAGE="system.buffers"  # lowercase
curl -s "https://api.nuget.org/v3-flatcontainer/${PACKAGE}/index.json" \
  | python3 -c "
import sys, json
versions = json.load(sys.stdin).get('versions', [])
stable = [v for v in versions if '-' not in v]
print(stable[-1] if stable else '')
"
```

If the latest stable version differs from the current value, update the
property value in the file.

### Rule 2 – Reset `IsPackable` to `false`

If the file contains `<IsPackable>true</IsPackable>`, change `true` to
`false`.  This property is only flipped to `true` during a servicing release
and must be switched back immediately afterward.

### Rule 3 – Increment `VersionPrefix`

For every `<VersionPrefix>` element (with or without an MSBuild `Condition`
attribute), increment the **third** numeric component (the patch number).

Example: `4.6.1` → `4.6.2`, `6.0.0` → `6.0.1`.

### Rule 4 – Increment `AssemblyVersion`

For every `<AssemblyVersion>` element (with or without a `Condition`
attribute), increment the **third** numeric component.

Example: `4.0.5.0` → `4.0.6.0`, `6.0.3.0` → `6.0.4.0`.

**Important:** skip any `<AssemblyVersion>` line that contains the
`NO-INCREMENT` marker comment.

## Implementation approach

Below is a recommended Python helper that applies the four rules to a single
file.  You may use it as-is or adapt it.

```python
#!/usr/bin/env python3
import json, os, re, urllib.request

NO_INCREMENT = "NO-INCREMENT"

def latest_nuget(pkg):
    url = f"https://api.nuget.org/v3-flatcontainer/{pkg.lower()}/index.json"
    try:
        with urllib.request.urlopen(url, timeout=30) as r:
            vers = json.loads(r.read()).get("versions", [])
        stable = [v for v in vers if "-" not in v]
        return stable[-1] if stable else None
    except Exception:
        return None

def bump_patch(v):
    p = v.split(".")
    if len(p) >= 3:
        p[2] = str(int(p[2]) + 1)
    return ".".join(p)

RE_BASELINE = re.compile(
    r"^(?P<pre>\s*<PackageValidationBase[Ll]ineVersion>)"
    r"(?P<ver>[^<]+)"
    r"(?P<post></PackageValidationBase[Ll]ineVersion>.*)$")
RE_PACKABLE = re.compile(
    r"^(?P<pre>\s*<IsPackable>)true(?P<post></IsPackable>.*)$")
RE_VERPREFIX = re.compile(
    r"^(?P<pre>\s*<VersionPrefix[^>]*>)"
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
        m = RE_VERPREFIX.match(line)
        if m and not skip:
            nl = m.group("pre") + bump_patch(m.group("ver")) + m.group("post")
        m = RE_ASMVER.match(line)
        if m and not skip:
            nl = m.group("pre") + bump_patch(m.group("ver")) + m.group("post")
        if nl != line:
            changed = True
        out.append(nl)
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

4. **Create a pull request** using the `create_pull_request` safe-output tool with:
   * Title: `Post-servicing version updates`
   * Body: a summary listing every file changed and what was updated.

## Important notes

* The `PackageValidationBaseLineVersion` property name has an alternate casing
  (`BaseLineVersion` with a capital L) in some project files – handle both.
* Some versioning properties live in a shared `Versioning.props` file rather
  than directly in the `.csproj` / `.ilproj` – make sure those are included in
  the scan.
* If **no files** need changes, do **not** create a pull request.
