
from pathlib import Path

import re

import subprocess



ROOT = Path("src")



FILE_SCOPED_NAMESPACE = re.compile(

    r"^\s*namespace\s+([A-Za-z_][A-Za-z0-9_.]*)\s*;\s*$"

)



USING_LINE = re.compile(r"^\s*using\s+[^;]+;\s*$")



def git_show(path: str) -> str | None:

    result = subprocess.run(

        ["git", "show", f"backup/original-city-watchdog-master:{path}"],

        capture_output=True,

        check=False,

    )



    if result.returncode != 0:

        return None



    return result.stdout.decode("utf-8-sig")



def target_namespace(name: str) -> str:

    if name == "CityWatchdog":

        return "CityWatchdog"



    if name.startswith("CityWatchdog."):

        return "CityWatchdog" + name[len("CityWatchdog"):]



    return name



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



    return "Contains City Watchdog source code."



def add_header(lines: list[str], path: Path) -> list[str]:

    if lines and lines[0].startswith("// File:"):

        return lines



    return [

        f"// File: {path.as_posix()}\n",

        f"// Purpose: {purpose_for(path)}\n",

        "\n",

    ] + lines



def rebrand_source(text: str) -> str:

    text = re.sub(

        r"(?m)^(\s*using\s+)CityWatchdog(?=\.|;)",

        r"\1CityWatchdog",

        text,

    )



    text = re.sub(

        r"(?m)^(\s*namespace\s+)CityWatchdog(?=\.|;|\s*\{)",

        r"\1CityWatchdog",

        text,

    )



    return text



def convert_file_scoped_namespace(text: str) -> str:

    lines = text.splitlines(keepends=True)



    namespace_index = None

    namespace_name = None



    for index, line in enumerate(lines):

        match = FILE_SCOPED_NAMESPACE.match(line)

        if match:

            namespace_index = index

            namespace_name = target_namespace(match.group(1))

            break



    if namespace_index is None or namespace_name is None:

        return text



    before_namespace = lines[:namespace_index]

    after_namespace = lines[namespace_index + 1:]



    using_lines = []

    prefix_lines = []



    for line in before_namespace:

        if USING_LINE.match(line):

            using_lines.append(line.strip())

        else:

            prefix_lines.append(line)



    while prefix_lines and prefix_lines[-1].strip() == "":

        prefix_lines.pop()



    while after_namespace and after_namespace[0].strip() == "":

        after_namespace.pop(0)



    output = []

    output.extend(prefix_lines)



    if output:

        output.append("\n")



    output.append(f"namespace {namespace_name}\n")

    output.append("{\n")



    for using_line in using_lines:

        output.append(f"    {using_line}\n")



    if using_lines and after_namespace:

        output.append("\n")



    for line in after_namespace:

        if line.strip():

            output.append("    " + line)

        else:

            output.append(line)



    if output and output[-1].strip():

        output.append("\n")



    output.append("}\n")



    return "".join(output)



changed = []

missing = []



for path in sorted(ROOT.rglob("*.cs")):

    parts = {part.lower() for part in path.parts}



    if "bin" in parts or "obj" in parts:

        continue



    old_path = "CityWatchdog/" + path.relative_to(ROOT).as_posix()

    original = git_show(old_path)



    if original is None:

        missing.append((path.as_posix(), old_path))

        continue



    text = rebrand_source(original)

    text = convert_file_scoped_namespace(text)

    lines = text.splitlines(keepends=True)

    lines = add_header(lines, path)

    new_text = "".join(lines)



    path.write_text(new_text, encoding="utf-8", newline="\r\n")

    changed.append(path.as_posix())



print(f"Rebuilt {len(changed)} src C# file(s).")

for file in changed:

    print(file)



if missing:

    print()

    print("Missing old HEAD paths:")

    for current, old in missing:

        print(f"{current} <- {old}")

