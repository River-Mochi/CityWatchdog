// File: DebugConsole/Localization/LocalizationUtils.cs
// Purpose: Contains debug-console support code for City Watchdog development.

namespace DebugConsole.Localization
{
    using System.Text.Json;

    internal static class LocalizationUtils {
        public static Dictionary<string, string>? DeserializeLocalization() => JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Localization", "EN.json")));
    }

}
