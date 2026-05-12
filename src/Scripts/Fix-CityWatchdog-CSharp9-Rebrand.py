# File: Scripts/Fix-CityWatchdog-CSharp9-Rebrand.py
# Purpose: Repairs City Watchdog C# 9 namespace syntax and rebrand text without restoring old CityWatchdog files.

from __future__ import annotations

from pathlib import Path
import re
import os

REPO_ROOT = Path.cwd()
SRC_ROOT = REPO_ROOT / "src"
DEBUG_ROOT = REPO_ROOT / "DebugConsole"

EXCLUDED_DIRS = {
    ".git",
    ".vs",
    ".idea",
    "bin",
    "obj",
    "node_modules",
    "Library",
}

TEXT_EXTENSIONS = {
    ".cs",
    ".csproj",
    ".sln",
    ".xml",
    ".json",
    ".tsx",
    ".ts",
    ".scss",
    ".js",
    ".md",
    ".txt",
    ".ps1",
    ".py",
    ".props",
    ".targets",
}

FILE_SCOPED_NAMESPACE_RE = re.compile(
    r"^\s*namespace\s+(CityWatchdog(?:\.[A-Za-z_][A-Za-z0-9_]*)?)\s*;\s*$"
)

BLOCK_NAMESPACE_RE = re.compile(
    r"^\s*namespace\s+(CityWatchdog(?:\.[A-Za-z_][A-Za-z0-9_]*)?)\s*$"
)

USING_LINE_RE = re.compile(r"^\s*using\s+[^;]+;\s*$")

BAD_NAMESPACE_RE = re.compile(
    r"(?m)^\s*namespace\s*$\r?\n(?:\s*\r?\n)*\s*\.([A-Za-z_][A-Za-z0-9_.]*)\s*;"
)

BAD_USING_RE = re.compile(
    r"(?m)^\s*using\s*$\r?\n(?:\s*\r?\n)*\s*\.([A-Za-z_][A-Za-z0-9_.]*)\s*;"
)

FILE_LOCATION_RE = re.compile(
    r'\[FileLocation\(\$"ModsSettings/\{nameof\((?:CityWatchdog|CityWatchdog)\)\}/\{nameof\(Setting\)\}"\)\]'
)

FILE_LOCATION_QUOTED_RE = re.compile(
    r'\[FileLocation\(\$"ModsSettings/\{\s*"CityWatchdog"\s*\}/\{nameof\(Setting\)\}"\)\]'
)

def is_excluded(path: Path) -> bool:
    return any(part in EXCLUDED_DIRS for part in path.parts)

def detect_newline(text: str) -> str:
    return "\r\n" if "\r\n" in text else "\n"

def read_text(path: Path) -> str:
    return path.read_text(encoding="utf-8-sig")

def write_text(path: Path, text: str, newline: str) -> None:
    with path.open("w", encoding="utf-8", newline=newline) as handle:
        handle.write(text)

def purpose_for(path: Path) -> str:
    parts = {part.lower() for part in path.parts}

    if path.name == "Mod.cs":
        return "Registers City Watchdog with the game and mod lifecycle."

    if "data" in parts:
        return "Defines notification icon identifiers used by City Watchdog."

    if "settings" in parts:
        return "Contains City Watchdog settings and Options UI logic."

    if "systems" in parts:
        return "Contains a City Watchdog gameplay or UI system."

    if "debugconsole" in parts:
        return "Contains debug-console support code for City Watchdog development."

    return "Contains City Watchdog source code."

def add_header_if_missing(lines: list[str], path: Path) -> list[str]:
    if lines and lines[0].startswith("// File:"):
        return lines

    return [
        f"// File: {path.as_posix()}\n",
        f"// Purpose: {purpose_for(path)}\n",
        "\n",
    ] + lines

def split_prefix_usings(prefix_lines: list[str]) -> tuple[list[str], list[str]]:
    kept_prefix: list[str] = []
    using_lines: list[str] = []

    for line in prefix_lines:
        if USING_LINE_RE.match(line):
            using_lines.append(line.strip())
        else:
            kept_prefix.append(line)

    while kept_prefix and kept_prefix[-1].strip() == "":
        kept_prefix.pop()

    return kept_prefix, using_lines

def dedupe_preserve_order(items: list[str]) -> list[str]:
    seen: set[str] = set()
    output: list[str] = []

    for item in items:
        if item in seen:
            continue

        seen.add(item)
        output.append(item)

    return output

def convert_file_scoped_namespace(lines: list[str], path: Path) -> tuple[list[str], bool]:
    namespace_index = None
    namespace_name = None

    for index, line in enumerate(lines):
        match = FILE_SCOPED_NAMESPACE_RE.match(line)
        if match:
            namespace_index = index
            namespace_name = match.group(1)
            break

    if namespace_index is None or namespace_name is None:
        return lines, False

    prefix_lines, using_lines = split_prefix_usings(lines[:namespace_index])
    body_lines = lines[namespace_index + 1:]

    while body_lines and body_lines[0].strip() == "":
        body_lines.pop(0)

    output: list[str] = []
    output.extend(prefix_lines)

    if output:
        output.append("\n")

    output.append(f"namespace {namespace_name}\n")
    output.append("{\n")

    for using_line in dedupe_preserve_order(using_lines):
        output.append(f"    {using_line}\n")

    if using_lines and body_lines:
        output.append("\n")

    for line in body_lines:
        output.append("    " + line if line.strip() else line)

    if output and output[-1].strip():
        output.append("\n")

    output.append("}\n")
    return output, True

def move_file_level_usings_inside_block_namespace(lines: list[str]) -> tuple[list[str], bool]:
    namespace_index = None
    namespace_name = None

    for index, line in enumerate(lines):
        match = BLOCK_NAMESPACE_RE.match(line)
        if match:
            namespace_index = index
            namespace_name = match.group(1)
            break

    if namespace_index is None or namespace_name is None:
        return lines, False

    brace_index = namespace_index + 1

    while brace_index < len(lines) and lines[brace_index].strip() == "":
        brace_index += 1

    if brace_index >= len(lines) or lines[brace_index].strip() != "{":
        return lines, False

    prefix_lines, using_lines = split_prefix_usings(lines[:namespace_index])

    if not using_lines:
        return lines, False

    rest_after_brace = lines[brace_index + 1:]
    existing_inside_usings: list[str] = []

    for line in rest_after_brace:
        if line.strip() == "":
            continue

        if USING_LINE_RE.match(line):
            existing_inside_usings.append(line.strip())
            continue

        break

    usings_to_insert = [
        using_line for using_line in dedupe_preserve_order(using_lines)
        if using_line not in existing_inside_usings
    ]

    if not usings_to_insert:
        return lines, False

    output: list[str] = []
    output.extend(prefix_lines)

    if output:
        output.append("\n")

    output.extend(lines[namespace_index:brace_index + 1])

    for using_line in usings_to_insert:
        output.append(f"    {using_line}\n")

    if rest_after_brace and rest_after_brace[0].strip() != "":
        output.append("\n")

    output.extend(rest_after_brace)
    return output, True

def fix_csharp_text(path: Path, text: str) -> str:
    # Repair broken patterns created earlier, then apply the intended rebrand.
    text = BAD_NAMESPACE_RE.sub(r"namespace CityWatchdog.\1;", text)
    text = BAD_USING_RE.sub(r"using CityWatchdog.\1;", text)

    text = text.replace("CityWatchdog", "CityWatchdog")
    text = text.replace("City Watchdog", "City Watchdog")
    text = text.replace("city-watchdog", "city-watchdog")
    text = text.replace("citywatchdog", "citywatchdog")

    text = FILE_LOCATION_RE.sub('[FileLocation("ModsSettings/CityWatchdog/Setting")]', text)
    text = FILE_LOCATION_QUOTED_RE.sub('[FileLocation("ModsSettings/CityWatchdog/Setting")]', text)

    lines = text.splitlines(keepends=True)
    lines = add_header_if_missing(lines, path)

    lines, converted = convert_file_scoped_namespace(lines, path)
    if not converted:
        lines, _ = move_file_level_usings_inside_block_namespace(lines)

    return "".join(lines)

def fix_general_text(text: str) -> str:
    text = text.replace("CityWatchdog", "CityWatchdog")
    text = text.replace("City Watchdog", "City Watchdog")
    text = text.replace("city-watchdog", "city-watchdog")
    text = text.replace("citywatchdog", "citywatchdog")
    return text

def iter_text_files() -> list[Path]:
    paths: list[Path] = []

    for root in [SRC_ROOT, DEBUG_ROOT]:
        if not root.exists():
            continue

        for path in root.rglob("*"):
            if path.is_file() and not is_excluded(path) and path.suffix in TEXT_EXTENSIONS:
                paths.append(path)

    for path in [
        REPO_ROOT / "CityWatchdog.sln",
        REPO_ROOT / "README.md",
        REPO_ROOT / "src" / "CityWatchdog.csproj",
        REPO_ROOT / "DebugConsole" / "DebugConsole.csproj",
    ]:
        if path.exists() and path not in paths:
            paths.append(path)

    return sorted(paths)

def rename_paths_containing_old_name() -> list[tuple[str, str]]:
    renamed: list[tuple[str, str]] = []

    for root in [SRC_ROOT, DEBUG_ROOT]:
        if not root.exists():
            continue

        # Rename deepest paths first so children are handled before parents.
        paths = sorted(
            [path for path in root.rglob("*") if "CityWatchdog" in path.name and not is_excluded(path)],
            key=lambda value: len(value.parts),
            reverse=True,
        )

        for old_path in paths:
            new_path = old_path.with_name(old_path.name.replace("CityWatchdog", "CityWatchdog"))

            if new_path.exists():
                continue

            old_path.rename(new_path)
            renamed.append((old_path.as_posix(), new_path.as_posix()))

    return renamed

def scan_problem_lines() -> list[str]:
    problems: list[str] = []

    for path in sorted(list(SRC_ROOT.rglob("*.cs")) + list(DEBUG_ROOT.rglob("*.cs"))):
        if is_excluded(path):
            continue

        text = read_text(path)
        lines = text.splitlines()

        for number, line in enumerate(lines, start=1):
            stripped = line.strip()

            if stripped == "namespace" or stripped == "using":
                problems.append(f"{path.as_posix()}:{number}: {stripped}")

            if stripped.startswith("namespace ."):
                problems.append(f"{path.as_posix()}:{number}: {stripped}")

            if '[FileLocation($"' in stripped:
                problems.append(f"{path.as_posix()}:{number}: {stripped}")

            if "nameof(CityWatchdog)" in stripped:
                problems.append(f"{path.as_posix()}:{number}: {stripped}")

    return problems

def main() -> int:
    if not (REPO_ROOT / "CityWatchdog.sln").exists() or not (SRC_ROOT / "CityWatchdog.csproj").exists():
        print("Run this from the repo root: C:/Users/kldan/source/repos/CityWatchdog")
        return 1

    changed: list[str] = []

    for path in iter_text_files():
        original = read_text(path)
        newline = detect_newline(original)

        if path.suffix == ".cs":
            fixed = fix_csharp_text(path, original)
        else:
            fixed = fix_general_text(original)

        if fixed != original:
            write_text(path, fixed, newline)
            changed.append(path.as_posix())

    renamed = rename_paths_containing_old_name()
    problems = scan_problem_lines()

    print(f"Changed {len(changed)} text file(s).")
    for path in changed:
        print(f"  changed: {path}")

    print(f"Renamed {len(renamed)} path(s).")
    for old_path, new_path in renamed:
        print(f"  renamed: {old_path} -> {new_path}")

    if problems:
        print()
        print("Problems still found:")
        for problem in problems:
            print(f"  {problem}")
        return 2

    print()
    print("No broken namespace/using/FileLocation patterns found.")
    return 0

if __name__ == "__main__":
    raise SystemExit(main())
