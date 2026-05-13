// File: src/Utils/ModToolsCompat.cs
// Purpose: Provides small local mod-detection helpers.

namespace CityWatchdog
{
    using Game.Modding;
    using System;
    using System.Linq;

    public static class ModTools
    {
        public static bool IsAnyModEnabled(params string[] modNames)
        {
            if (modNames == null || modNames.Length == 0)
            {
                return false;
            }

            return modNames.Any(IsModInclusive);
        }

        public static bool IsModInclusive(string modName)
        {
            if (string.IsNullOrEmpty(modName))
            {
                return false;
            }

            string[] enabledMods = ModManager.GetModsEnabled();
            if (enabledMods == null || enabledMods.Length == 0)
            {
                return false;
            }

            return enabledMods.Any(name =>
                !string.IsNullOrEmpty(name) &&
                name.IndexOf(modName, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
