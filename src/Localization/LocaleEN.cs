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
                { m_Settings.GetOptionTabLocaleID(Setting.Advanced), "Advanced" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Achievements" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Money" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Milestone" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Enable Achievements" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)), "Allows achievements to remain enabled when mods, Unlock All, or Unlimited Money are enabled." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)), "Select to enable automatic add money mode." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Manual Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)), "Set this value to manually add/subtract money amounts." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatic Add Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Set this value to automatically add money when money falls below this set threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatic Add Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Set the amount of money that will be automatically added when money falls below the threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTransfer)), "Money Transfer" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTransfer)), "Allows you to switch Unlimited Money to Limited Money in the game. This option is only available in-game." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.MoneyTransfer)), "Are you sure you want to convert Unlimited Money to Limited Money? This operation is not reversible!" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Custom Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)), "Enable this option to customize the start milestone. Set it from the main menu before entering the game." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)), "Select any milestone level to unlock before starting game. Set this from the main menu before entering the game." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey for adding money within the game." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey for subtracting money within the game." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtract Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Initial Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)), "Set the game's initial money. This is valid for new/loaded games and only takes effect once. It can only be changed when not in-game." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "Notification icon show/hide" },
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
