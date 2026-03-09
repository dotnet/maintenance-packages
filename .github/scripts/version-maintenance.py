#!/usr/bin/env python3
"""
Version maintenance script for the maintenance-packages repository.

Scans source projects under src/ (excluding test projects) and applies
post-servicing version updates:
  1. Update PackageValidationBaselineVersion to latest NuGet stable version.
  2. Reset IsPackable from true to false.
  3. Increment VersionPrefix patch version (X.X.Y -> X.X.(Y+1)).
  4. Increment AssemblyVersion third digit (X.X.Y.Z -> X.X.(Y+1).Z),
     skipping lines marked with NO-INCREMENT.
"""

import json
import os
import re
import urllib.request

REPO_ROOT = os.environ.get("GITHUB_WORKSPACE", os.getcwd())
SRC_DIR = os.path.join(REPO_ROOT, "src")
NO_INCREMENT_MARKER = "NO-INCREMENT"
PROJECT_EXTENSIONS = {".csproj", ".ilproj", ".props"}

# Cache for NuGet version lookups
_nuget_cache: dict[str, str | None] = {}


def get_latest_nuget_version(package_name: str) -> str | None:
    """Return the latest stable version of *package_name* on nuget.org."""
    if package_name in _nuget_cache:
        return _nuget_cache[package_name]

    url = (
        f"https://api.nuget.org/v3-flatcontainer/"
        f"{package_name.lower()}/index.json"
    )
    try:
        req = urllib.request.Request(url)
        with urllib.request.urlopen(req, timeout=30) as resp:
            data = json.loads(resp.read().decode("utf-8"))
        versions = data.get("versions", [])
        # Keep only stable versions (no prerelease dash).
        stable = [v for v in versions if "-" not in v]
        result = stable[-1] if stable else None
    except Exception as exc:
        print(f"  Warning: Could not query NuGet for '{package_name}': {exc}")
        result = None

    _nuget_cache[package_name] = result
    return result


def get_package_name(file_path: str) -> str | None:
    """Derive the NuGet package name from the file path.

    The convention is ``src/<PackageName>/...`` so the first directory
    component after *src/* is the package name.
    """
    rel = os.path.relpath(file_path, SRC_DIR)
    parts = rel.split(os.sep)
    return parts[0] if parts else None


def increment_patch(version: str) -> str:
    """Increment the third numeric component of a version string.

    ``"1.2.3"`` → ``"1.2.4"``
    ``"1.2.3.0"`` → ``"1.2.4.0"``
    """
    parts = version.split(".")
    if len(parts) >= 3:
        parts[2] = str(int(parts[2]) + 1)
    return ".".join(parts)


def find_project_files() -> list[str]:
    """Return project/props files under *src/* that are **not** inside a
    ``tests`` directory."""
    results: list[str] = []
    for root, _dirs, files in os.walk(SRC_DIR):
        # Skip any path that contains a 'tests' component.
        rel = os.path.relpath(root, SRC_DIR)
        if "tests" in rel.split(os.sep):
            continue
        for name in files:
            if os.path.splitext(name)[1].lower() in PROJECT_EXTENSIONS:
                results.append(os.path.join(root, name))
    return results


# ---------------------------------------------------------------------------
# Regex helpers – each captures (prefix)(value)(suffix) so the replacement
# can simply re-assemble the groups.
# ---------------------------------------------------------------------------

_RE_BASELINE = re.compile(
    r"^(?P<pre>\s*<PackageValidationBase[Ll]ineVersion>)"
    r"(?P<ver>[^<]+)"
    r"(?P<post></PackageValidationBase[Ll]ineVersion>.*)$"
)
_RE_PACKABLE = re.compile(
    r"^(?P<pre>\s*<IsPackable>)true(?P<post></IsPackable>.*)$"
)
_RE_VERSION_PREFIX = re.compile(
    r"^(?P<pre>\s*<VersionPrefix[^>]*>)"
    r"(?P<ver>\d+\.\d+\.\d+)"
    r"(?P<post></VersionPrefix>.*)$"
)
_RE_ASSEMBLY_VERSION = re.compile(
    r"^(?P<pre>\s*<AssemblyVersion[^>]*>)"
    r"(?P<ver>\d+\.\d+\.\d+\.\d+)"
    r"(?P<post></AssemblyVersion>.*)$"
)


def process_file(file_path: str) -> list[str]:
    """Apply version-maintenance rules to *file_path*.

    Returns a list of human-readable change descriptions (empty when the
    file was not modified).
    """
    # Read preserving encoding & line endings.
    with open(file_path, "rb") as fh:
        raw = fh.read()

    # Detect and strip BOM.
    bom = b""
    if raw.startswith(b"\xef\xbb\xbf"):
        bom = b"\xef\xbb\xbf"
        raw = raw[3:]

    # Detect line ending style.
    line_ending = "\r\n" if b"\r\n" in raw else "\n"

    text = raw.decode("utf-8")
    lines = text.split(line_ending)

    package_name = get_package_name(file_path)
    changes: list[str] = []
    new_lines: list[str] = []

    for line in lines:
        new_line = line
        has_no_increment = NO_INCREMENT_MARKER in line

        # 1. PackageValidationBaselineVersion → latest NuGet version
        m = _RE_BASELINE.match(line)
        if m and not has_no_increment:
            current = m.group("ver")
            latest = get_latest_nuget_version(package_name) if package_name else None
            if latest and latest != current:
                new_line = f"{m.group('pre')}{latest}{m.group('post')}"
                changes.append(
                    f"  PackageValidationBaselineVersion: {current} -> {latest}"
                )

        # 2. IsPackable true → false
        m = _RE_PACKABLE.match(line)
        if m:
            new_line = f"{m.group('pre')}false{m.group('post')}"
            changes.append("  IsPackable: true -> false")

        # 3. VersionPrefix – increment patch
        m = _RE_VERSION_PREFIX.match(line)
        if m and not has_no_increment:
            current = m.group("ver")
            bumped = increment_patch(current)
            new_line = f"{m.group('pre')}{bumped}{m.group('post')}"
            changes.append(f"  VersionPrefix: {current} -> {bumped}")

        # 4. AssemblyVersion – increment third digit (skip NO-INCREMENT)
        m = _RE_ASSEMBLY_VERSION.match(line)
        if m and not has_no_increment:
            current = m.group("ver")
            bumped = increment_patch(current)
            new_line = f"{m.group('pre')}{bumped}{m.group('post')}"
            changes.append(f"  AssemblyVersion: {current} -> {bumped}")

        new_lines.append(new_line)

    new_text = line_ending.join(new_lines)
    new_raw = bom + new_text.encode("utf-8")

    if new_raw != bom + text.encode("utf-8"):
        with open(file_path, "wb") as fh:
            fh.write(new_raw)

    return changes


def set_output(name: str, value: str) -> None:
    """Write a GitHub Actions output variable."""
    path = os.environ.get("GITHUB_OUTPUT")
    if path:
        with open(path, "a") as fh:
            fh.write(f"{name}={value}\n")


def main() -> None:
    print("Version Maintenance Script")
    print("=" * 60)

    files = find_project_files()
    print(f"Found {len(files)} project file(s) to scan.\n")

    total_changes = 0
    for file_path in sorted(files):
        rel = os.path.relpath(file_path, REPO_ROOT)
        changes = process_file(file_path)
        if changes:
            print(f"{rel}")
            for c in changes:
                print(c)
            total_changes += len(changes)

    print(f"\nTotal changes: {total_changes}")
    set_output("changes_made", "true" if total_changes > 0 else "false")


if __name__ == "__main__":
    main()
