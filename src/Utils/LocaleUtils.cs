// File: src/Utils/LocaleUtils.cs
// Purpose: Provides safe localization lookup and formatting helpers for City Watchdog UI text.

namespace CityWatchdog
{
    using Colossal.Localization;
    using Game.SceneFlow;
    using System;
    using System.Globalization;

    internal static class LocaleUtils
    {
        internal static string Localize(string entryId, string fallback)
        {
            if (string.IsNullOrEmpty(entryId))
            {
                return fallback;
            }

            try
            {
                LocalizationDictionary dictionary = GameManager.instance.localizationManager.activeDictionary;
                if (dictionary != null &&
                    dictionary.TryGetValue(entryId, out string value) &&
                    !string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }
            catch
            {
            }

            return fallback;
        }

        internal static string SafeFormat(string entryId, string fallbackFormat, params object[] args)
        {
            string format = Localize(entryId, fallbackFormat);

            try
            {
                return string.Format(CultureInfo.CurrentCulture, format, args);
            }
            catch (FormatException)
            {
                try
                {
                    return string.Format(CultureInfo.CurrentCulture, fallbackFormat, args);
                }
                catch
                {
                    return fallbackFormat;
                }
            }
            catch
            {
                return fallbackFormat;
            }
        }

        internal static string FormatN0(long value)
        {
            return value.ToString("N0", CultureInfo.CurrentCulture);
        }
    }
}
