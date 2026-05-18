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
#if DEBUG
    [SettingsUITabOrder(Actions, Hotkeys, About, Debug)]
    [SettingsUIGroupOrder(Achievements, Money, Milestone, SaveConversion, HotkeyActions, AboutInfo, AboutLinks, AboutUsage, Serialize)]
    [SettingsUIShowGroupName(Achievements, Money, Milestone, SaveConversion, HotkeyActions, AboutUsage, Serialize)]
#else
    [SettingsUITabOrder(Actions, Hotkeys, About)]
    [SettingsUIGroupOrder(Achievements, Money, Milestone, SaveConversion, HotkeyActions, AboutInfo, AboutLinks, AboutUsage)]
    [SettingsUIShowGroupName(Achievements, Money, Milestone, SaveConversion, HotkeyActions, AboutUsage)]
#endif
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

        // Group IDs.
        internal const string Achievements = nameof(Achievements);
        internal const string Money = nameof(Money);
        internal const string Milestone = nameof(Milestone);
        internal const string SaveConversion = nameof(SaveConversion);
        internal const string HotkeyActions = nameof(HotkeyActions);
        internal const string AboutInfo = nameof(AboutInfo);
        internal const string AboutLinks = nameof(AboutLinks);
        internal const string AboutUsage = nameof(AboutUsage);

        private const string AboutLinksRow = nameof(AboutLinksRow);
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

        internal const int TrendDisplayModeHourly = 0;
        internal const int TrendDisplayModeMonthly = 1;

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        // --------------------------------------------------------------------
        // Actions tab
        // --------------------------------------------------------------------

        [SettingsUISection(Actions, Achievements)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsAchievementEnablerIncluded))]
        [SettingsUISetter(typeof(Setting), nameof(OnAchievementsOptionChanged))]
        public bool AchievementsEnabled { get; set; }

        [SettingsUISection(Actions, Money)]
        [SettingsUISetter(typeof(Setting), nameof(OnTrendTrackerChanged))]
        public bool TrendTracker { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetTrendDisplayModeItems))]
        [SettingsUISection(Actions, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureTrendTrackerEnabled))]
        [SettingsUISetter(typeof(Setting), nameof(OnTrendDisplayModeChanged))]
        public int TrendDisplayMode { get; set; }

        [SettingsUISlider(min = 20000, max = 2000000, step = 20000, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(Actions, Money)]
        public int ManualMoneyAmount { get; set; }

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

                MoneyControllerSystem? moneyControllerSystem = GetMoneyControllerSystem();
                if (moneyControllerSystem?.CanConvertUnlimitedMoneySave() == true)
                {
                    moneyControllerSystem.SetUnlimitedMoneyToLimitedMoney();
                }
            }
        }

        // --------------------------------------------------------------------
        // Hotkeys tab
        // --------------------------------------------------------------------

        [SettingsUIKeyboardBinding(BindingKeyboard.N, ToggleNotificationsAction)]
        [SettingsUISection(Hotkeys, HotkeyActions)]
        public ProxyBinding ToggleNotificationsKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.LeftBracket, AddMoneyAction)]
        [SettingsUISection(Hotkeys, HotkeyActions)]
        public ProxyBinding AddMoneyKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.RightBracket, SubtractMoneyAction)]
        [SettingsUISection(Hotkeys, HotkeyActions)]
        public ProxyBinding SubtractMoneyKeyboardBinding { get; set; }

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

        [SettingsUISection(About, AboutUsage)]
        public bool ShowUsage { get; set; }

        [SettingsUIMultilineText]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideUsageText))]
        [SettingsUISection(About, AboutUsage)]
        public string UsageText => string.Empty;

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

        public bool EnsureTrendTrackerEnabled()
        {
            return !TrendTracker;
        }

        private bool HideUsageText()
        {
            return !ShowUsage;
        }

        private bool CannotConvertUnlimitedMoneySave()
        {
            return !ConfirmUnlimitedMoneySaveConversion ||
                   GetMoneyControllerSystem()?.CanConvertUnlimitedMoneySave() != true;
        }

        private static MoneyControllerSystem? GetMoneyControllerSystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<MoneyControllerSystem>();
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

        public DropdownItem<int>[] GetTrendDisplayModeItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = TrendDisplayModeHourly,
                    displayName = GetOptionLocaleID("TrendDisplayModeHourly"),
                },
                new DropdownItem<int>
                {
                    value = TrendDisplayModeMonthly,
                    displayName = GetOptionLocaleID("TrendDisplayModeMonthly"),
                },
            };
        }

        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }

        public override void SetDefaults()
        {
            AchievementsEnabled = true;

            TrendTracker = true;
            TrendDisplayMode = TrendDisplayModeHourly;
            ManualMoneyAmount = 20000;
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

        private bool IsAchievementEnablerIncluded()
        {
            return ModTools.IsAnyModEnabled("AchievementFixer");
        }

        private void OnAchievementsOptionChanged(bool value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetOrCreateSystemManaged<AchievementsControllerSystem>()?
                .SetAchievements(value);
        }

        private void OnTrendTrackerChanged(bool value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateTrendTrackerBinding(value);
        }

        private void OnTrendDisplayModeChanged(int value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityWatchdogUISystem>()?
                .UpdateTrendDisplayModeBinding(value);
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
