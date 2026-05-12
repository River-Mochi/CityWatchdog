
from pathlib import Path

import re



ROOTS = [Path("src"), Path("DebugConsole")]



FILE_SCOPED_NAMESPACE = re.compile(

    r"^\s*namespace\s+(CityWatchdog(?:\.[A-Za-z_][A-Za-z0-9_]*)?)\s*;\s*$"

)



USING_LINE = re.compile(r"^\s*using\s+[^;]+;\s*$")



def target_namespace(old_name: str) -> str:

    if old_name == "CityWatchdog":

        return "CityWatchdog"



    if old_name.startswith("CityWatchdog."):

        return "CityWatchdog" + old_name[len("CityWatchdog"):]



    return old_name



def purpose_for(path: Path) -> str:

    parts = {p.lower() for p in path.parts}



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



def add_header(lines: list[str], path: Path) -> list[str]:

    if lines and lines[0].startswith("// File:"):

        return lines



    return [

        f"// File: {path.as_posix()}\n",

        f"// Purpose: {purpose_for(path)}\n",

        "\n",

    ] + lines



def convert_file(path: Path) -> bool:

    original = path.read_text(encoding="utf-8-sig")

    text = original



    # Rename only namespace/usings roots. Do not rename class names yet.

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



    lines = text.splitlines(keepends=True)



    namespace_index = None

    namespace_name = None



    for index, line in enumerate(lines):

        match = FILE_SCOPED_NAMESPACE.match(line)

        if match:

            namespace_index = index

            namespace_name = target_namespace(match.group(1))

            break



    if namespace_index is not None and namespace_name is not None:

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

        lines = output



    lines = add_header(lines, path)

    new_text = "".join(lines)



    if new_text != original:

        path.write_text(new_text, encoding="utf-8", newline="\n")

        return True



    return False



changed = []



for root in ROOTS:

    if not root.exists():

        continue



    for path in root.rglob("*.cs"):

        parts = {part.lower() for part in path.parts}



        if "bin" in parts or "obj" in parts:

            continue



        if convert_file(path):

            changed.append(path.as_posix())



print(f"Changed {len(changed)} file(s).")

for path in changed:

    print(path)

