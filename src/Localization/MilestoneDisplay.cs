// File: src/Localization/MilestoneDisplay.cs
// Purpose: Resolves game-localized milestone names for the City Watchdog milestone dropdown.

namespace CityWatchdog
{
    using Colossal.Localization;
    using Game.SceneFlow;
    using System.Text;

    internal static class MilestoneDisplay
    {
        public static string Get(int zeroBasedIndex, string fallbackInternalName)
        {
            int gameMilestoneNumber = zeroBasedIndex + 1;

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            LocalizationDictionary? dictionary = localizationManager?.activeDictionary;

            if (dictionary != null)
            {
                string? localized =
                    TryGet(dictionary, $"Progression.MILESTONE_NAME:{gameMilestoneNumber}") ??
                    TryGet(dictionary, $"PROGRESSION.MILESTONE_NAME:{gameMilestoneNumber}");

                if (localized is string text && !string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }
            }

            return ToFriendlyFallback(fallbackInternalName, gameMilestoneNumber);
        }

        private static string? TryGet(LocalizationDictionary dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out string value) &&
                !string.IsNullOrWhiteSpace(value) &&
                !value.Contains("MILESTONE_NAME"))
            {
                return value;
            }

            return null;
        }

        private static string ToFriendlyFallback(string fallbackInternalName, int gameMilestoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fallbackInternalName))
            {
                return $"Milestone {gameMilestoneNumber}";
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < fallbackInternalName.Length; i++)
            {
                char current = fallbackInternalName[i];

                if (i > 0 &&
                    char.IsUpper(current) &&
                    !char.IsWhiteSpace(fallbackInternalName[i - 1]))
                {
                    builder.Append(' ');
                }

                builder.Append(current);
            }

            return builder.ToString();
        }
    }
}
