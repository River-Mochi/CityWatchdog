// File: src/Mod.cs
// Purpose: Registers City Watchdog with the game and mod lifecycle.

namespace CityWatchdog
{
    using CityWatchdog.Settings;
    using CityWatchdog.Systems;
    using CS2Shared.Common;
    using CS2Shared.Tools;
    using Game;
    using Game.Modding;
    using System;

    public class Mod : ModBase, IMod {
        public override bool BetaVersion => true;
        public override DateTime VersionDate => new(2024, 12, 01);

        protected override void CreateSetting() {
            Setting = Settings.Setting.Instance = new Setting(this);
            LoadSetting(new Setting(this));
        }

        protected override void CreateSystem(UpdateSystem updateSystem) {
            base.CreateSystem(updateSystem);
            if (!ModTools.IsModInclusive("AchievementEnabler"))
                updateSystem.UpdateAfter<AchievementsControllerSystem>(SystemUpdatePhase.Deserialize);
            updateSystem.UpdateAt<MoneyControllerSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<UnlockMilestonesSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<CityWatchdogUISystem>(SystemUpdatePhase.UIUpdate);
            updateSystem.UpdateAt<NotificationControllerSystem>(SystemUpdatePhase.ModificationEnd);
        }
    }
}
