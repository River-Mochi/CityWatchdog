// File: src/Mod.cs
// Purpose: Mod entrypoint; registers settings, localization, systems, keybindings, and the dedicated mod log.

namespace CityWatchdog
{
    using CityWatchdog.Systems;
    using CS2Shared.RiverMochi;
    using Colossal;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using System;
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

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(string message)
        {
            LogUtils.Info(() => message);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(Func<string> messageFactory)
        {
            LogUtils.Info(messageFactory);
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);
            ShellOpen.Configure(s_Log, ModId, ModTag);
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
            AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_HANS(setting));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));
            AddLocaleSource("th-TH", new LocaleTH(setting));       // Thai
            AddLocaleSource("vi-VN", new LocaleVI(setting));       // Vietnamese
            AddLocaleSource("tr-TR", new LocaleTR(setting));       // Turkish
            AddLocaleSource("pt-PT", new LocalePT_PT(setting));    // European Portuguese

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
        }

        public void OnDispose()
        {
            DebugLog(() => "Mod Dispose");

            Setting? setting = Settings;
            if (setting != null)
            {
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

        private static void ScheduleSystems(UpdateSystem updateSystem)
        {
            updateSystem.UpdateAt<CityFinanceSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<MilestoneSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<AlertIconSystem>(SystemUpdatePhase.ModificationEnd);
        }


        private static void EnableKeybinds(Setting setting)
        {
            EnableAction(setting, Setting.AddMoneyAction);
            EnableAction(setting, Setting.SubtractMoneyAction);
            EnableAction(setting, Setting.ToggleNotificationsAction);
            EnableAction(setting, Setting.ToggleNotificationPanelAction);
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

        private static void LogStartupBanner()
        {
            if (s_BannerLogged)
            {
                return;
            }

            s_BannerLogged = true;
            LogUtils.Info(() => $"{ModName} v{ModVersion} {ModTag} loaded");
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
