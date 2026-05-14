// File: src/Systems/AchievementsEnablerSystem.cs
// Purpose: Applies the City Watchdog achievements setting when a game is loaded.

namespace CityWatchdog.Systems
{

    using Colossal.PSI.Common;
    using Colossal.Serialization.Entities;
    using Game;

    public partial class AchievementsControllerSystem : GameSystemBaseExtension
    {
        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            LogUtils.Info(() => $"AchievementsControllerSystem OnGamePreload, game mode: {mode}, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);
            LogUtils.Info(() => $"AchievementsControllerSystem OnGameLoaded, game/mod achievements status: {PlatformManager.instance.achievementsEnabled} {Setting.Instance.AchievementsEnabled} ");
            SetAchievements(Setting.Instance.AchievementsEnabled);
        }

        public void SetAchievements(bool enabled)
        {
            if (PlatformManager.instance.achievementsEnabled == enabled)
            {
                return;
            }

            PlatformManager.instance.achievementsEnabled = enabled;
            LogUtils.Info(() => $"Set achievements: {enabled}");
        }
    }
}
