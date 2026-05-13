# File: src/Scripts/fix_notification_logutils.py
# Purpose: Replaces remaining NotificationControllerSystem LogUtils calls with C# 9-safe City Watchdog logger helpers.

from __future__ import annotations

from pathlib import Path


def find_repo_root() -> Path:
    cwd = Path.cwd().resolve()

    if (cwd / "src" / "Systems" / "NotificationControllerSystem.cs").is_file():
        return cwd

    if cwd.name.lower() == "src" and (cwd / "Systems" / "NotificationControllerSystem.cs").is_file():
        return cwd.parent

    raise RuntimeError("Run from the CityWatchdog repo root or from the src folder.")


def main() -> int:
    repo = find_repo_root()
    path = repo / "src" / "Systems" / "NotificationControllerSystem.cs"

    text = path.read_text(encoding="utf-8-sig")
    original = text

    replacements = {
        "LogUtils.Info(Mod.s_Log, () =>": "LogUtils.Info(() =>",
        "LogUtils.Warn(Mod.s_Log, () =>": "LogUtils.Warn(() =>",
        "LogUtils.Debug(Mod.s_Log, () =>": "LogUtils.Debug(() =>",
        "LogUtils.Error(Mod.s_Log, () =>": "LogUtils.Error(() =>",
        "}.ForEach(action => LogUtils.Info(Mod.s_Log, action));": "}.ForEach(action => LogUtils.Info(action));",
    }

    for old, new in replacements.items():
        text = text.replace(old, new)

    if text == original:
        print("NO CHANGE: NotificationControllerSystem.cs")
        return 0

    backup = path.with_name(path.name + ".phase8-logutils.bak")
    if not backup.exists():
        backup.write_text(original, encoding="utf-8")

    path.write_text(text, encoding="utf-8")
    print("UPDATED: src/Systems/NotificationControllerSystem.cs")
    print("Backup: src/Systems/NotificationControllerSystem.cs.phase8-logutils.bak")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
