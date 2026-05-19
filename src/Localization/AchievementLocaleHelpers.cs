// File: src/Localization/AchievementLocaleHelpers.cs
// Purpose: Achievement display and banner localization helpers for City Watchdog.

namespace CityWatchdog
{
    using Colossal;
    using Colossal.Localization;
    using Game.SceneFlow;
    using System.Collections.Generic;

    internal static class AchievementDisplay
    {
        public static string Get(string internalName)
        {
            if (string.IsNullOrWhiteSpace(internalName))
            {
                return string.Empty;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            LocalizationDictionary? dictionary = localizationManager?.activeDictionary;
            if (dictionary == null)
            {
                return internalName;
            }

            string key = $"Achievements.TITLE[{internalName}]";
            if (dictionary.TryGetValue(key, out string localized) &&
                !string.IsNullOrWhiteSpace(localized))
            {
                return localized;
            }

            return internalName;
        }
    }

    internal sealed class LocaleOverrideSource : IDictionarySource
    {
        private readonly Dictionary<string, string> m_Entries;

        public LocaleOverrideSource(Dictionary<string, string> entries)
        {
            m_Entries = entries;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return m_Entries;
        }

        public void Unload()
        {
        }
    }

    internal static class AchievementBannerText
    {
        private static readonly Dictionary<string, string> TextByLocale = new Dictionary<string, string>
        {
            ["en-US"] = "Achievements enabled by City Watchdog.",
            ["de-DE"] = "Erfolge aktiviert durch City Watchdog.",
            ["es-ES"] = "Logros activados por City Watchdog.",
            ["fr-FR"] = "Succès activés par City Watchdog.",
            ["it-IT"] = "Obiettivi attivati da City Watchdog.",
            ["ja-JP"] = "実績は City Watchdog によって有効化されています。",
            ["ko-KR"] = "업적이 City Watchdog에 의해 활성화되었습니다.",
            ["pt-BR"] = "Conquistas ativadas por City Watchdog.",
            ["pl-PL"] = "Osiągnięcia włączone przez City Watchdog.",
            ["vi-VN"] = "Thành tựu được bật bởi City Watchdog.",
            ["zh-HANS"] = "成就已由 City Watchdog 启用。",
            ["zh-HANT"] = "成就已由 City Watchdog 啟用。"
        };

        public static string For(string localeId)
        {
            return TextByLocale.TryGetValue(localeId, out string text)
                ? text
                : TextByLocale["en-US"];
        }
    }
}
