// File: src/Localization/LocaleEN.cs
// Purpose: English (en-US) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

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
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Hotkeys" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "About" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Achievements" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Money" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Milestone" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Save Conversion" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Hotkeys" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USAGE" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Enable Achievements" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Keeps achievements enabled [ ✓ ] when this mod is loaded.\n" +
                    "It's recommended to use <Achievement Fixer (AF)> mod as it is the most detailed and robust in this area.\n" +
                    "If <Achievement Fixer> is installed, City Watchdog leaves all achievement handling to AF and hides this option.\n" +
                    "FUTURE: I will merge AF mod into this mod; for now adding AF mod is the best option."
                 },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Trend Tracker" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "Adds numeric trend values beside the vanilla bottom-toolbar money and population arrows.\n" +
                    "This is a lightweight toolbar display only; it does not change city money or population." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "Trend Display Mode" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "Choose whether the bottom-toolbar trend text shows hourly or monthly values for money and population.\n" +
                    "Monthly uses budget income minus expenses for money, and a 24-hour projection for population." },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "Hourly (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "Monthly (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Money Hotkey Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use this amount with the Add Money and Subtract Money hotkeys.\n" +
                    "Default = 20,000.\n" +
                    "This does not set the current balance by itself." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "When enabled [ ✓ ], City Watchdog checks the city balance while a city is loaded.\n" +
                    "If the balance is below the threshold, it adds the selected automatic amount." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatic Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "If Automatic Add Money is enabled and the city balance falls below this value,\n" +
                    "City Watchdog adds the selected automatic amount." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatic Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Amount added each time Automatic Add Money triggers.\n" +
                    "Choose a value high enough to bring the city safely above the threshold." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Initial Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Sets the starting balance for a new <limited money> city or the first loaded city, then resets to Game Default after it applies.\n" +
                    "This is grayed out if a city is already loaded.\n" +
                    "Set before starting/loading a city → applies once → then use <Money Hotkey Amount> or <Automatic Add Money> afterward." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Milestone Selector" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Enable before loading or starting a city to unlock a chosen milestone immediately after the city loads.\n" +
                    "This cannot be turned ON while a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n" +
                    "City Watchdog cannot undo milestone changes already saved into a city; use an earlier save if needed." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Pick the milestone level to unlock on the next city load.\n" +
                    "This is only adjustable outside a loaded city, and only after [Milestone Selector] is enabled [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unlimited Money Converter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Make a Backup of city FIRST>.\n" +
                    "Converts a city that started as Unlimited Money to a normal city with regular money challenges.\n" +
                    "Enabling this unlocks the <[Convert Unlimited Money Save]> button when the loaded city is <Unlimited Money> type.\n" +
                    "City Watchdog cannot undo this conversion.\n" +
                    "If you have normal cities, do not worry about this; it is not needed." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save City to Normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "For cities started with <Unlimited Money>.\n" +
                    "While that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\n" +
                    "Button is <disabled/greyed-out> unless the loaded city is an <Unlimited Money> type and <Unlimited Money Converter> is ON [ ✓ ].\n" +
                    "Make a backup save, and use at your own risk; City Watchdog cannot undo this conversion." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money?\n" +
                    "Save a backup FIRST; City Watchdog cannot undo this.\n" +
                    "Are you sure?" },

                // --- Hotkeys ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Toggle Notification Icons" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Hotkey for the same action as the in-game [Toggle All] notification icon button.\n" +
                    "It shows or hides all City Watchdog notification icons at once." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Toggle Notification Icons" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey for adding money inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey for subtracting money inside the city." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtract Money" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Display name of this mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Current mod version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Open the author's Paradox Mods page." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Show Instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Show or hide the usage instructions below." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Notification panel>\n" +
                    "1. In-game, click the City Watchdog top-left button to open the panel.\n" +
                    "2. Use ASC/DESC to sort sections.\n" +
                    "3. Use Toggle All for quick setup, or expand a section to change individual notification icons.\n" +
                    "4. City Watchdog hides or shows icons only; it does not fix the underlying city problem.\n\n" +
                    "<Money helpers>\n" +
                    "1. Trend Tracker adds numeric /h or /mo values beside the bottom-toolbar money and population trend arrows.\n" +
                    "2. Add Money and Subtract Money use the Money Hotkey Amount value.\n" +
                    "3. Automatic Add Money watches the city balance while a city is loaded and adds money when below the threshold.\n" +
                    "4. Convert Unlimited Money Save is only for cities that were started with Unlimited Money and is <not reversible> by City Watchdog.\n\n" +
                    "<Custom milestone>\n" +
                    "Set Initial Money and select Milestones from the Options menu before loading or starting a city." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Open the notification icon panel." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Expand any row; [✓] check to show, uncheck to hide alerts.\n" +
                    "This does not fix city problems, it hides icon clutter." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Toggle All" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expand All" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Collapse All Rows" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Sort order" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "Show/hide all icons.\n" +
                "Color: green = all on; blue = mixed; red = all off." },

                // --- Electricity notifications ---
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

                // --- Water pipe notifications ---
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

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "BUILDING" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Collapsed" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandoned" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condemned" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Deactivated" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "High rent" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRAFFIC" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Traffic jam" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Dead end" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Road required" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Track not connected" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "No car access" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "No waterway connection" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "No track connection" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "No pedestrian access" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "COMPANY" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "High resource costs" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Not enough customers" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "WORK PROVIDER" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Lack of Labor" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Lack of high-skill labor" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DISASTER" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Weather damage" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destroyed by weather" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Water damage" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destroyed by flooding" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "This building has been destroyed" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "FIRE" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "On fire" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Burned down" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "GARBAGE" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Garbage piling up" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Facility full" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "HEALTHCARE" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Waiting for ambulance" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Waiting for a hearse" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Facility full" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLICE" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Traffic accident" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Crime scene" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "POLLUTION" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Air pollution" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Noise pollution" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Ground pollution" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "RESOURCE CONSUMER" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "No Emergency Shelter Supplies" },
                { m_Settings.GetUILocaleID("Route"), "ROUTE" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Pathfinding failed" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "TRANSPORT LINE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "No vehicles" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
