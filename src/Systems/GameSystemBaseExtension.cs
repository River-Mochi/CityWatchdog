// File: src/Systems/GameSystemBaseExtension.cs
// Purpose: Small local system base helper so CityWatchdog does not depend on Mbyron26 CS2Shared.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game;
    using System;

    public abstract partial class GameSystemBaseExtension : GameSystemBase
    {
        protected Type? SystemType { get; private set; }

        protected string SystemName => SystemType?.Name ?? string.Empty;

        protected GameMode Mode { get; private set; }

        protected bool InMainMenu => Mode == GameMode.MainMenu;

        protected bool InGame => Mode == GameMode.Game;

        protected bool NotInGame => !InGame;

        protected bool InEditor => Mode == GameMode.Editor;

        protected bool InGameOrEditor => Mode == GameMode.GameOrEditor;

        protected override void OnCreate()
        {
            base.OnCreate();
            SystemType = GetType();
            LogUtils.Info(() => $"System created: {SystemName}");
        }

        protected override void OnDestroy()
        {
            LogUtils.Info(() => $"System destroyed: {SystemName}");
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            Mode = mode;
        }
    }
}
