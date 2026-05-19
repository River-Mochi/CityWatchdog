// File: src/Mod.cs
// Purpose: Mod entrypoint; registers settings, localization, systems, keybindings, and the dedicated mod log.

namespace CityWatchdog
{
    using CityWatchdog.Systems;
    using Colossal;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using Game;
    using Game.Achievements;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class Mod : IMod
    {
        public const string ModName = "City Watchdog";
        public const string ModId = "CityWatchdog";
        public const string ModTag = "[CWD]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.5.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        internal static Setting? Settings { get; private set; }

        private static bool s_BannerLogged;
        private static bool s_ReapplyingLocale;
        private static readonly HashSet<string> s_AchievementBannerLocales = new HashSet<string>();

#if DEBUG
        private static string? s_LastLocaleId;
#endif

        internal static void DebugLog(string message)
        {
#if DEBUG
            LogUtils.Info(() => message);
#else
            _ = message;
#endif
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);
            LogStartupBanner();

            if (GameManager.instance == null)
            {
                LogUtils.Warn(() => "GameManager.instance is null; City Watchdog cannot initialize.");
                return;
            }

            Setting setting = new Setting(this);
            Settings = Setting.Instance = setting;

            AddLocaleSource("en-US", new LocaleEN(setting));
            AddLocaleSource("fr-FR", new LocaleFR(setting));
            AddLocaleSource("es-ES", new LocaleES(setting));
            AddLocaleSource("de-DE", new LocaleDE(setting));
            // AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            // AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_HANS(setting));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));

            try
            {
                AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Settings load failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                setting.RegisterInOptionsUI();
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Options UI registration failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                setting.RegisterKeyBindings();
                EnableKeybinds(setting);
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"Keybinding registration failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            try
            {
                ScheduleSystems(updateSystem);
            }
            catch (Exception ex)
            {
                LogUtils.Error(() => $"System scheduling failed: {ex.GetType().Name}: {ex.Message}", ex);
            }

            LocalizationManager? localizationManager = GameManager.instance.localizationManager;
            if (localizationManager != null)
            {
                localizationManager.onActiveDictionaryChanged -= OnLocaleChanged;
                localizationManager.onActiveDictionaryChanged += OnLocaleChanged;
            }

            EnsureAchievementBannerForActiveLocale();
        }

        public void OnDispose()
        {
            LogUtils.Info(() => "Mod Dispose");

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager != null)
            {
                localizationManager.onActiveDictionaryChanged -= OnLocaleChanged;
            }

            Setting? setting = Settings;
            if (setting != null)
            {
                DisableMoneyKeybinds(setting);

                try
                {
                    setting.UnregisterInOptionsUI();
                }
                catch (Exception ex)
                {
                    LogUtils.Warn(() => $"UnregisterInOptionsUI failed: {ex.GetType().Name}: {ex.Message}", ex);
                }
            }

            Settings = null;
        }

        private static void OnLocaleChanged()
        {
            if (s_ReapplyingLocale)
            {
                return;
            }

            s_ReapplyingLocale = true;
            try
            {
#if DEBUG
                LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
                string activeLocaleId = localizationManager?.activeLocaleId ?? "(unknown)";
                if (!string.Equals(activeLocaleId, s_LastLocaleId, StringComparison.Ordinal))
                {
                    LogUtils.Info(() => $"Active locale = {activeLocaleId}");
                    s_LastLocaleId = activeLocaleId;
                }
#endif
                Settings?.RegisterInOptionsUI();
                EnsureAchievementBannerForActiveLocale();
            }
            finally
            {
                s_ReapplyingLocale = false;
            }
        }

        private static void ScheduleSystems(UpdateSystem updateSystem)
        {
            updateSystem.UpdateAfter<AchievementsControllerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);
            updateSystem.UpdateAt<MoneyControllerSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<UnlockMilestonesSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<NotificationControllerSystem>(SystemUpdatePhase.ModificationEnd);
        }


        private static void EnableKeybinds(Setting setting)
        {
            EnableAction(setting, Setting.AddMoneyAction);
            EnableAction(setting, Setting.SubtractMoneyAction);
            EnableAction(setting, Setting.ToggleNotificationsAction);
        }

     private static void DisableMoneyKeybinds(Setting setting)
        {
            DisableAction(setting, Setting.AddMoneyAction);
            DisableAction(setting, Setting.SubtractMoneyAction);
            DisableAction(setting, Setting.ToggleNotificationsAction);
        }


        private static void EnableAction(Setting setting, string actionName)
        {
            try
            {
                ProxyAction action = setting.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"Could not enable action '{actionName}': {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

        private static void DisableAction(Setting setting, string actionName)
        {
            try
            {
                ProxyAction action = setting.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = false;
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"Could not disable action '{actionName}': {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

        private static void LogStartupBanner()
        {
            if (s_BannerLogged)
            {
                return;
            }

            s_BannerLogged = true;
            LogUtils.Info(() => $"{ModName} v{ModVersion} {ModTag} loaded");
        }

        internal static void ReapplyAchievementBannerForActiveLocale()
        {
            AddAchievementBannerForActiveLocale(force: true, finalApply: false);
        }

        internal static void ReapplyAchievementBannerForActiveLocaleFinal()
        {
            AddAchievementBannerForActiveLocale(force: true, finalApply: true);
        }

        private static void EnsureAchievementBannerForActiveLocale()
        {
            AddAchievementBannerForActiveLocale(force: false, finalApply: false);
        }

        private static void AddAchievementBannerForActiveLocale(bool force, bool finalApply)
        {
            if (Settings?.AchievementsEnabled != true)
            {
                return;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager == null)
            {
                return;
            }

            string activeLocaleId = localizationManager.activeLocaleId ?? string.Empty;
            if (string.IsNullOrEmpty(activeLocaleId))
            {
                return;
            }

            if (!force && s_AchievementBannerLocales.Contains(activeLocaleId))
            {
                return;
            }

            const string warningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";
            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                [warningKey] = AchievementBannerText.For(activeLocaleId)
            };

            if (AddLocaleSource(activeLocaleId, new LocaleOverrideSource(entries)))
            {
                s_AchievementBannerLocales.Add(activeLocaleId);
                if (finalApply)
                {
                    LogUtils.Info(() => $"Achievement banner re-applied for locale '{activeLocaleId}'.");
                }
            }
        }

        private static bool AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return false;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            if (localizationManager == null)
            {
                LogUtils.Warn(() => $"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return false;
            }

            try
            {
                localizationManager.AddSource(localeId, source);
                return true;
            }
            catch (Exception ex)
            {
                LogUtils.Warn(() => $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}", ex);
                return false;
            }
        }
    }
}
