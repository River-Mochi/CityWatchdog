// File: src/Settings/Setting.cs
// Purpose: Defines City Watchdog settings, Options UI controls, and key bindings.

namespace CityWatchdog
{
    using CityWatchdog.Systems;
    using Colossal.IO.AssetDatabase;
    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;
    using System;
    using System.Collections.Generic;
    using Unity.Entities;
    using UnityEngine;

    [FileLocation("ModsSettings/CityWatchdog/CityWatchdog")]
    [SettingsUITabOrder(Actions, About, Debug)]
    [SettingsUIGroupOrder(Notifications, Money, MoneyViewGroup, Milestone, SaveConversion, AboutInfo, AboutLinks, AboutDiagnostics, AboutUsage, Serialize)]
    [SettingsUIShowGroupName(Notifications, Money, MoneyViewGroup, Milestone, SaveConversion, AboutDiagnostics, AboutUsage, Serialize)]
    public partial class Setting : ModSetting
    {
        internal static Setting Instance { get; set; } = null!;

        // Tab IDs.
        internal const string Actions = nameof(Actions);
        internal const string Hotkeys = nameof(Hotkeys);
        internal const string About = nameof(About);
        internal const string Debug = nameof(Debug);
        internal const string Serialize = nameof(Serialize);

        // Keybinding action IDs.
        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);
        public const string ToggleNotificationsAction = nameof(ToggleNotificationsAction);
        public const string ToggleNotificationPanelAction = nameof(ToggleNotificationPanelAction);

        // Group IDs.
        internal const string MoneyViewGroup = nameof(MoneyViewGroup);
        internal const string Money = nameof(Money);
        internal const string Notifications = nameof(Notifications);
        internal const string Milestone = nameof(Milestone);
        internal const string SaveConversion = nameof(SaveConversion);
        internal const string HotkeyActions = nameof(HotkeyActions);
        internal const string AboutInfo = nameof(AboutInfo);
        internal const string AboutLinks = nameof(AboutLinks);
        internal const string AboutDiagnostics = nameof(AboutDiagnostics);
        internal const string AboutUsage = nameof(AboutUsage);

        private const string AboutLinksRow = nameof(AboutLinksRow);
        private const string DebugButtonsRow = nameof(DebugButtonsRow);
        private const string UsageIconPath = "coui://ui-mods/images/CWDNotificationIcon_white02.svg";
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private static readonly string[] Milestones =
        {
            "TinyVillage",
            "SmallVillage",
            "LargeVillage",
            "GrandVillage",
            "TinyTown",
            "BoomTown",
            "BusyTown",
            "BigTown",
            "GreatTown",
            "SmallCity",
            "BigCity",
            "LargeCity",
            "HugeCity",
            "GrandCity",
            "Metropolis",
            "ThrivingMetropolis",
            "FlourishingMetropolis",
            "ExpansiveMetropolis",
            "MassiveMetropolis",
            "Megalopolis",
        };

        internal const int MoneyViewModeHourly = 0;
        internal const int MoneyViewModeMonthly = 1;
        internal const int MoneyTooltipModeFullData = 0;
        internal const int MoneyTooltipModeCompact = 1;
        internal const int MoneyTooltipModeMini = 2;

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------
        // Actions tab - Money View
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyViewChanged))]
        public bool MoneyView { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMoneyViewModeItems))]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyViewModeChanged))]
        public int MoneyViewMode { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMoneyTooltipModeItems))]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyTooltipModeChanged))]
        public int MoneyTooltipMode { get; set; }

        // UI converts 90..130 directly into 0.90em..1.30em for tooltip value text.
        [SettingsUISlider(min = 90, max = 130, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnMoneyTooltipFontScaleChanged))]
        public int MoneyTooltipFontScale { get; set; }

        [SettingsUISlider(min = 90, max = 130, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(Actions, MoneyViewGroup)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureMoneyViewEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnPopulationTooltipFontScaleChanged))]
        public int PopulationTooltipFontScale { get; set; }

        // --------------------------------------------------------------------
        // Actions tab - Money
        // --------------------------------------------------------------------

        [SettingsUISlider(min = 20000, max = 2000000, step = 20000, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(Actions, Money)]
        public int ManualMoneyAmount { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.LeftBracket, AddMoneyAction)]
        [SettingsUISection(Actions, Money)]
        public ProxyBinding AddMoneyKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.RightBracket, SubtractMoneyAction)]
        [SettingsUISection(Actions, Money)]
        public ProxyBinding SubtractMoneyKeyboardBinding { get; set; }

        [SettingsUISection(Actions, Money)]
        public bool AutomaticAddMoney { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyThresholdItems))]
        [SettingsUISection(Actions, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyThreshold { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyAmountItems))]
        [SettingsUISection(Actions, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyAmount { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetInitialMoneyItems))]
        [SettingsUISection(Actions, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsInGame))]
        public int InitialMoney { get; set; }

        // --------------------------------------------------------------------
        // Actions tab - Notifications
        // --------------------------------------------------------------------

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationsAction)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleNotificationsKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationPanelAction, shift: true)]
        [SettingsUISection(Actions, Notifications)]
        public ProxyBinding ToggleNotificationPanelKeyboardBinding { get; set; }

        // --------------------------------------------------------------------
        // Actions tab - Milestone
        // --------------------------------------------------------------------

        // Safety rule:
        // - OFF while a city is loaded stays disabled, so milestone injection cannot be enabled mid-city.
        // - ON while a city is loaded stays enabled, so it can be turned OFF without rebooting.
        [SettingsUISection(Actions, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(CannotEnableCustomMilestoneInGame))]
        public bool CustomMilestone { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMilestoneLevelItems))]
        [SettingsUISection(Actions, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(GetMilestoneLevelStatus))]
        public int MilestoneLevel { get; set; }

        // --------------------------------------------------------------------
        // Actions tab - Save conversion
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, SaveConversion)]
        public bool ConfirmUnlimitedMoneySaveConversion { get; set; }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(Actions, SaveConversion)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(CannotConvertUnlimitedMoneySave))]
        public bool ConvertUnlimitedMoneySave
        {
            set
            {
                if (!value)
                {
                    return;
                }

                CityFinanceSystem? cityFinanceSystem = GetCityFinanceSystem();
                if (cityFinanceSystem?.CanConvertUnlimitedMoneySave() == true)
                {
                    cityFinanceSystem.SetUnlimitedMoneyToLimitedMoney();
                }
            }
        }

        // --------------------------------------------------------------------
        // About tab
        // --------------------------------------------------------------------

        [SettingsUISection(About, AboutInfo)]
        public string NameText => Mod.ModName;

        [SettingsUISection(About, AboutInfo)]
        public string VersionText =>
#if DEBUG
            Mod.ModVersion + " (DEBUG)";
#else
            Mod.ModVersion;
#endif

        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(About, AboutLinks)]
        public bool OpenParadox
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(UrlParadox);
                }
            }
        }

        // --------------------------------------------------------------------
        // Actions tab - Usage
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, AboutUsage)]
        public bool ShowUsage { get; set; }

        [SettingsUIMultilineText(UsageIconPath)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideUsageText))]
        [SettingsUISection(Actions, AboutUsage)]
        public string UsageText => string.Empty;

        // --------------------------------------------------------------------
        // Debug tab
        // --------------------------------------------------------------------

        [SettingsUIButtonGroup(DebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(Debug, AboutDiagnostics)]
        public bool WriteNotificationAuditLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                AlertIconSystem? alertIconSystem = World.DefaultGameObjectInjectionWorld?
                    .GetExistingSystemManaged<AlertIconSystem>();

                if (alertIconSystem == null)
                {
                    Mod.DebugLog("Notification audit skipped: AlertIconSystem is not available.");
                    return;
                }

                alertIconSystem.WriteNotificationAuditLog();
            }
        }

        [SettingsUIButtonGroup(DebugButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(Debug, AboutDiagnostics)]
        public bool OpenLog
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ShellOpen.OpenModLogOrLogsFolder();
            }
        }

        // --------------------------------------------------------------------
        // Conditions and helpers
        // --------------------------------------------------------------------

        private bool IsInGame()
        {
            return GameManager.instance != null && GameManager.instance.gameMode == GameMode.Game;
        }

        private bool CannotEnableCustomMilestoneInGame()
        {
            return IsInGame() && !CustomMilestone;
        }

        public bool NotInGame => !IsInGame();

        public bool InEditor => GameManager.instance != null && GameManager.instance.gameMode == GameMode.Editor;

        public bool InMainMenu => GameManager.instance != null && GameManager.instance.gameMode == GameMode.MainMenu;

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
        }

        public bool EnsureMoneyViewEnabled()
        {
            return !MoneyView;
        }

        private bool HideUsageText()
        {
            return !ShowUsage;
        }

        private bool CannotConvertUnlimitedMoneySave()
        {
            return !ConfirmUnlimitedMoneySaveConversion ||
                   GetCityFinanceSystem()?.CanConvertUnlimitedMoneySave() != true;
        }

        private static CityFinanceSystem? GetCityFinanceSystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityFinanceSystem>();
        }

        private static void TryOpenUrl(string url)
        {
            try
            {
                Application.OpenURL(url);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "open-url-" + url,
                    () => $"Failed to open URL '{url}': {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        // --------------------------------------------------------------------
        // Dropdown data
        // --------------------------------------------------------------------

        public DropdownItem<int>[] GetAutomaticAddMoneyThresholdItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
            };
        }

        public DropdownItem<int>[] GetAutomaticAddMoneyAmountItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        public DropdownItem<int>[] GetInitialMoneyItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = 0,
                    displayName = GetOptionLocaleID("GameDefault"),
                },
                CreateDropdownItem(100000),
                CreateDropdownItem(500000),
                CreateDropdownItem(5000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        public DropdownItem<int>[] GetMoneyViewModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MoneyViewModeHourly,
                    displayName = GetOptionLocaleID("MoneyViewModeHourly"),
                },
                new DropdownItem<int>
                {
                    value = MoneyViewModeMonthly,
                    displayName = GetOptionLocaleID("MoneyViewModeMonthly"),
                },
            };
        }

        public DropdownItem<int>[] GetMoneyTooltipModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeMini,
                    displayName = GetOptionLocaleID("MoneyTooltipModeMini"),
                },
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeCompact,
                    displayName = GetOptionLocaleID("MoneyTooltipModeCompact"),
                },
                new DropdownItem<int>
                {
                    value = MoneyTooltipModeFullData,
                    displayName = GetOptionLocaleID("MoneyTooltipModeFullData"),
                },
            };
        }

        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }

        public override void SetDefaults()
        {
            MoneyView = true;
            MoneyViewMode = MoneyViewModeHourly;
            MoneyTooltipMode = MoneyTooltipModeCompact;
            // If defaults change, also update bindValue fallbacks /UI/src/mods/Bindings/Bindings.tsx
            MoneyTooltipFontScale = 120;
            PopulationTooltipFontScale = 120;

            ManualMoneyAmount = 40000;
            AutomaticAddMoney = false;
            AutomaticAddMoneyThreshold = 100000;
            AutomaticAddMoneyAmount = 10000;
            InitialMoney = 0;

            CustomMilestone = false;
            MilestoneLevel = 19;

            ConfirmUnlimitedMoneySaveConversion = false;
            ShowUsage = false;

            Notification.SetDefaults();
        }

        private void OnMoneyViewChanged(bool value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyViewBinding(value);
        }

        private void OnMoneyViewModeChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyViewModeBinding(value);
        }

        private void OnMoneyTooltipModeChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyTooltipModeBinding(value);
        }

        private void OnMoneyTooltipFontScaleChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateMoneyTooltipFontScaleBinding(value);
        }

        private void OnPopulationTooltipFontScaleChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdatePopulationTooltipFontScaleBinding(value);
        }

        private bool GetMilestoneLevelStatus()
        {
            return IsInGame() || !CustomMilestone;
        }

        private DropdownItem<int>[] GetMilestoneLevelItems()
        {
            List<DropdownItem<int>> items = new List<DropdownItem<int>>();
            for (int i = 0; i < Milestones.Length; i++)
            {
                items.Add(new DropdownItem<int>
                {
                    value = i,
                    displayName = MilestoneDisplay.Get(i, Milestones[i]),
                });
            }

            return items.ToArray();
        }

        private static DropdownItem<int> CreateDropdownItem(int value)
        {
            return new DropdownItem<int>
            {
                value = value,
                displayName = value.ToString("N0"),
            };
        }

        public string GetOptionLocaleID(string localeId)
        {
            return $"Options[{id}.{localeId}]";
        }

        public string GetUILocaleID(string entryId)
        {
            return $"{Mod.ModId}.UI[{entryId}]";
        }
    }
}
