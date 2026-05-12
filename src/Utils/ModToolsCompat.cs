// File: src/Utils/ModToolsCompat.cs
// Purpose: Compatibility helper for legacy CS2Shared ModTools calls using the current CO mod manager API.

namespace CS2Shared.Tools
{
    using Game.Modding;
    using System;
    using System.Linq;

    public static class ModTools
    {
        public static bool IsModInclusive(string modName)
        {
            if (string.IsNullOrEmpty(modName))
            {
                return false;
            }

            string[]? enabledMods = ModManager.GetModsEnabled();
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
