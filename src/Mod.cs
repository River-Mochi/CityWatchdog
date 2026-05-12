// File: src/Mod.cs
// Purpose: Entry point for City Watchdog.

namespace CityWatchdog
{
    using CityWatchdog.Settings;
    using CityWatchdog.Systems;
    using Colossal.Logging;
    using CS2Shared.Common;
    using CS2Shared.Tools;
    using Game;
    using Game.Modding;
    using System;
    using System.Reflection;

    public sealed class Mod : ModBase, IMod
    {
        public const string ModName = "City Watchdog";
        public const string ModId = "CityWatchdog";
        public const string ModTag = "[CWD]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.5.0";

        // Register a dedicated CityWatchdog.log, then use LogUtils for popup-safe routine writes.
        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        // CreateSetting/CreateSystem can run more than once during mod reload tests; keep the banner once per process.
        private static bool s_BannerLogged;

        public override bool BetaVersion => true;

        public override DateTime VersionDate => new DateTime(2026, 5, 12);

        // DEBUG-only info log helper.
        // Keeps release logs free of routine chatter.
        internal static void DebugLog(string message)
        {
#if DEBUG
            LogUtils.Info(s_Log, () => message);
#else
            _ = message;
#endif
        }

        protected override void CreateSetting()
        {
            Setting setting = new Setting(this);
            Setting = Settings.Setting.Instance = setting;
            LoadSetting(new Setting(this));
        }

        protected override void CreateSystem(UpdateSystem updateSystem)
        {
            base.CreateSystem(updateSystem);

            LogStartupBanner();

            if (!ModTools.IsModInclusive("AchievementEnabler"))
            {
                updateSystem.UpdateAfter<AchievementsControllerSystem>(SystemUpdatePhase.Deserialize);
            }

            updateSystem.UpdateAt<MoneyControllerSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<UnlockMilestonesSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<NotificationControllerSystem>(SystemUpdatePhase.ModificationEnd);
        }

        private static void LogStartupBanner()
        {
            if (s_BannerLogged)
            {
                return;
            }

            s_BannerLogged = true;
            LogUtils.Info(s_Log, () => $"{ModName} v{ModVersion} {ModTag} loaded");
        }
    }
}
