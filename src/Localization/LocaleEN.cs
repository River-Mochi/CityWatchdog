// File: src/Localization/LocaleEN.cs
// Purpose: English (en-US) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using CityWatchdog.Settings;
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleEN(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { m_Settings.GetSettingsLocaleID(), title },

                { m_Settings.GetOptionTabLocaleID(Setting.General), "General" },
                { m_Settings.GetOptionTabLocaleID(Setting.KeyBindings), "Key Bindings" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "About" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Achievements" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Money" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Milestone" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Save Conversion" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USAGE" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Enable Achievements" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)), "Keeps achievements enabled when this mod is loaded. If AchievementFixer or another achievement mod is installed, City Watchdog hides this option and leaves achievement handling to that mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "When enabled, City Watchdog checks your city balance in-game and adds money when it drops below the selected threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Manual Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Amount used by the Add Money and Subtract Money hotkeys. It does not set your current balance by itself." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatic Add Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "If Automatic Add Money is enabled and your city balance falls below this value, City Watchdog adds the selected automatic amount." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatic Add Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Amount added each time Automatic Add Money triggers. Choose a value high enough to bring the city safely above the threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Custom Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable this before loading or starting a city to unlock a chosen milestone immediately after the city loads. This is grayed out while already in-game." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Pick the milestone level to unlock on the next city load. This is only editable outside a loaded city, and only after Custom Milestone is enabled." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Enable Unlimited Money Save Conversion" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "Turn this ON only after making a backup. This unlocks the Convert Unlimited Money Save button when the loaded city was started with Unlimited Money.\n" +
                    "City Watchdog cannot undo this conversion." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "For cities started with Unlimited Money. While that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenge again.\n" +
                    "Button is <disabled/ greyed-out> unless the loaded city is an Unlimited Money type and Enable Unlimited Money Save Conversion is ON." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money? Save a backup first; City Watchdog cannot undo this conversion." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey for adding money within the game." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey for subtracting money within the game." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtract Money" },

#if DEBUG
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DebugKeyboardBinding)), "Debug Action" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DebugKeyboardBinding)), "Developer-only debug keybinding. This only appears in Debug builds." },
                { m_Settings.GetBindingKeyLocaleID("DebugAction"), "Debug Action" },
#endif

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Open the author's Paradox Mods page." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Join the mod Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Show Instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Show or hide the usage instructions below." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Notification panel>\n" +
                    "1. In-game, click the City Watchdog top-left button to open the panel.\n" +
                    "2. Expand a section, then uncheck the notification icons you want to hide above buildings.\n" +
                    "3. Check an item again to show that notification icon again.\n" +
                    "4. City Watchdog hides or shows icons only; it does not fix the underlying city problem.\n\n" +
                    "<Money helpers>\n" +
                    "1. Add Money and Subtract Money use the Manual Money Amount value.\n" +
                    "2. Automatic Add Money watches your balance while a city is loaded and adds money below the threshold.\n" +
                    "3. Convert Unlimited Money Save is only for loaded cities that were started with Unlimited Money and is not reversible by City Watchdog.\n\n" +
                    "<Custom milestone>\n" +
                    "Set Initial Money and Custom Milestone from the main menu before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Initial Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Sets the starting balance for the next loaded or new limited-money city, then resets to Game Default after it applies. This is grayed out while already in-game." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "Expand a section, then choose which notification icons should be visible above buildings." },
                { m_Settings.GetUILocaleID("Electricity"), "ELECTRICITY" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Not enough electricity" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Electricity bottleneck" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Poor electricity flow" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Power station overload" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformer overload" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Not enough output lines connected" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Battery depleted" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Electric Cable not connected" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Power Line not connected" },

                { m_Settings.GetUILocaleID("WaterPipe"), "WATER PIPE" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Not enough water" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Water pump polluted" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Backed up sewer" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Water Pipe not connected" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Sewage Pipe not connected" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Water facility overload" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Sewage facility overload" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Groundwater level too low" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Water level too low" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Water pump polluted" },

                { m_Settings.GetUILocaleID("Building"), "BUILDING" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Collapsed" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandoned" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condemned" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Deactivated" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "High rent" },

                { m_Settings.GetUILocaleID("Traffic"), "TRAFFIC" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Traffic jam" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Dead end" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Road required" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Track not connected" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "No car access" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "No waterway connection" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "No track connection" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "No pedestrian access" },

                { m_Settings.GetUILocaleID("Company"), "COMPANY" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "High resource costs" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Not enough customers" },

                { m_Settings.GetUILocaleID("WorkProvider"), "WORK PROVIDER" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Lack of Labor" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Lack of high-skill labor" },

                { m_Settings.GetUILocaleID("Disaster"), "DISASTER" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Weather damage" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destroyed by weather" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Water damage" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destroyed by flooding" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "This building has been destroyed" },

                { m_Settings.GetUILocaleID("Fire"), "FIRE" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "On fire" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Burned down" },

                { m_Settings.GetUILocaleID("Garbage"), "GARBAGE" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Garbage piling up" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Facility full" },

                { m_Settings.GetUILocaleID("Healthcare"), "HEALTHCARE" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Waiting for ambulance" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Waiting for a hearse" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Facility full" },

                { m_Settings.GetUILocaleID("Police"), "POLICE" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Traffic accident" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Crime scene" },

                { m_Settings.GetUILocaleID("Pollution"), "POLLUTION" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Air pollution" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Noise pollution" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Ground pollution" },

                { m_Settings.GetUILocaleID("ResourceConsumer"), "RESOURCE CONSUMER" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "No Emergency Shelter Supplies" },

                { m_Settings.GetUILocaleID("Route"), "ROUTE" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Pathfinding failed" },

                { m_Settings.GetUILocaleID("TransportLine"), "TRANSPORT LINE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "No vehicles" },
            };

            foreach (string milestone in m_Settings.Milestones)
            {
                entries[m_Settings.GetOptionLocaleID(milestone)] = milestone;
            }

            return entries;
        }

        public void Unload()
        {
        }
    }
}
