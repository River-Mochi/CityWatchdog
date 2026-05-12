// File: src/Settings/Setting.Hidden.cs
// Purpose: Contains City Watchdog settings and Options UI logic.

namespace CityWatchdog.Settings
{
    using CS2Shared.Settings;
    using System;

    public partial class Setting {
        public SettingHidden Hidden { get; set; } = new();

        public class SettingHidden : SettingChildClassBase {
            public bool ControlPanelDraggable { get; set; }

            public override void SetDefaults() {
                ControlPanelDraggable = false;
            }
        }
    }

}
