// File: src/Systems/AchievementsEnablerSystem.cs
// Purpose: Keeps achievements enabled after game load and exposes achievement actions.

namespace CityWatchdog.Systems
{
    using Colossal.PSI.Common;
    using Colossal.Serialization.Entities;
    using Game;

    public partial class AchievementsControllerSystem : GameSystemBaseExtension
    {
        private const int AssertFrames = 1800;
        private int framesLeft;

        protected override void OnCreate()
        {
            base.OnCreate();
            framesLeft = 0;
            Enabled = false;
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            LogUtils.Info(() => $"AchievementsControllerSystem OnGamePreload, game mode: {mode}, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (mode != GameMode.Game || !Setting.Instance.AchievementsEnabled)
            {
                Enabled = false;
                return;
            }

            framesLeft = AssertFrames;
            Enabled = true;
            ForceEnableIfNeeded("OnGameLoadingComplete");
            CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocale();
        }

        protected override void OnUpdate()
        {
            if (!Setting.Instance.AchievementsEnabled)
            {
                Enabled = false;
                return;
            }

            if (framesLeft <= 0)
            {
                CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocaleFinal();
                Enabled = false;
                return;
            }

            ForceEnableIfNeeded("OnUpdate");
            framesLeft--;
        }

        public void SetAchievements(bool enabled)
        {
            PlatformManager? platformManager = PlatformManager.instance;
            if (platformManager == null)
            {
                LogUtils.Warn(() => "SetAchievements skipped: PlatformManager.instance is null.");
                return;
            }

            if (platformManager.achievementsEnabled != enabled)
            {
                platformManager.achievementsEnabled = enabled;
                LogUtils.Info(() => $"Set achievements: {enabled}");
            }

            if (enabled && InGame)
            {
                framesLeft = AssertFrames;
                Enabled = true;
                CityWatchdog.Mod.ReapplyAchievementBannerForActiveLocale();
            }
            else if (!enabled)
            {
                Enabled = false;
            }
        }

        private static bool ForceEnableIfNeeded(string source)
        {
            PlatformManager? platformManager = PlatformManager.instance;
            if (platformManager == null)
            {
                return false;
            }

            if (platformManager.achievementsEnabled)
            {
                return false;
            }

            LogUtils.Info(() => $"{source}: detected achievementsEnabled == false; forcing true.");
            platformManager.achievementsEnabled = true;
            return true;
        }
    }
}
