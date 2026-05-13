// File: src/Settings/Setting.Hidden.cs
// Purpose: Contains City Watchdog settings and Options UI logic.

namespace CityWatchdog.Settings
{
    public partial class Setting {
        public SettingHidden Hidden { get; set; } = new();

        public class SettingHidden {
            public bool ControlPanelDraggable { get; set; }

            public void SetDefaults() {
                ControlPanelDraggable = false;
            }
        }
    }

}
