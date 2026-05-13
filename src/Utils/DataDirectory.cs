// File: src/Utils/DataDirectory.cs
// Purpose: Provides CS2 user-data path helpers for legacy CS2Shared callers.

namespace CS2Shared.Extension
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Colossal.PSI.Environment;
    using CS2Shared.Tools;
    using System;
    using System.IO;

    public static class DataDirectory
    {
        public static string UserDataDirectory { get; } = EnvPath.kUserDataPath;

        public static string ModsDataDirectory { get; } =
            Path.Combine(UserDataDirectory, "ModsData");

        public static string CurrentModDataDirectory { get; } =
            Path.Combine(ModsDataDirectory, AssemblyTools.CurrentAssemblyName);

        public static string ModsSettingsDirectory { get; } =
            Path.Combine(UserDataDirectory, "ModsSettings");

        public static string CurrentModSettingsDirectory { get; } =
            Path.Combine(ModsSettingsDirectory, AssemblyTools.CurrentAssemblyName);

        public static string LocalModsDirectory { get; } =
            Path.Combine(UserDataDirectory, "Mods");

        public static string LogsDirectory { get; } = LogManager.kDefaultLogPath;

        public static string GetModPath(ExecutableAsset executableAsset)
        {
            if (executableAsset == null || string.IsNullOrEmpty(executableAsset.path))
            {
                return string.Empty;
            }

            string directory = Path.GetDirectoryName(executableAsset.path);
            if (string.IsNullOrEmpty(directory))
            {
                return string.Empty;
            }

            return directory.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        public static string GetModDirectoryCreationTime(ExecutableAsset executableAsset)
        {
            string modPath = GetModPath(executableAsset);
            if (!string.IsNullOrEmpty(modPath) && Directory.Exists(modPath))
            {
                return new DirectoryInfo(modPath).CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
