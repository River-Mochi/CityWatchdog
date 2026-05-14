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
    [SettingsUITabOrder(General, KeyBindings, About, Debug)]
    [SettingsUIGroupOrder(Achievements, Money, Milestone, SaveConversion, AboutInfo, AboutLinks, AboutUsage, Serialize)]
    [SettingsUIShowGroupName(Achievements, Money, Milestone, SaveConversion, AboutUsage, Serialize)]
#else
    [SettingsUITabOrder(General, KeyBindings, About)]
    [SettingsUIGroupOrder(Achievements, Money, Milestone, SaveConversion, AboutInfo, AboutLinks, AboutUsage)]
    [SettingsUIShowGroupName(Achievements, Money, Milestone, SaveConversion, AboutUsage)]
#endif
    public partial class Setting : ModSetting
    {
        internal static Setting Instance { get; set; } = null!;

        internal const string General = nameof(General);
        internal const string KeyBindings = nameof(KeyBindings);
        internal const string About = nameof(About);
        internal const string Debug = nameof(Debug);
        internal const string Serialize = nameof(Serialize);

        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);

        internal const string Achievements = nameof(Achievements);
        internal const string Money = nameof(Money);
        internal const string Milestone = nameof(Milestone);
        internal const string SaveConversion = nameof(SaveConversion);
        internal const string AboutInfo = nameof(AboutInfo);
        internal const string AboutLinks = nameof(AboutLinks);
        internal const string AboutUsage = nameof(AboutUsage);

        private const string AboutLinksRow = nameof(AboutLinksRow);
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/HTav7ARPs2";

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        [SettingsUISection(General, Achievements)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsAchievementEnablerIncluded))]
        [SettingsUISetter(typeof(Setting), nameof(OnAchievementsOptionChanged))]
        public bool AchievementsEnabled { get; set; }

        [SettingsUISlider(min = 20000, max = 2000000, step = 20000, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(General, Money)]
        public int ManualMoneyAmount { get; set; }

        [SettingsUISection(General, Money)]
        public bool AutomaticAddMoney { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyThresholdItems))]
        [SettingsUISection(General, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyThreshold { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetAutomaticAddMoneyAmountItems))]
        [SettingsUISection(General, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyAmount { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetInitialMoneyItems))]
        [SettingsUISection(General, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsInGame))]
        public int InitialMoney { get; set; }

        [SettingsUISection(General, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsInGame))]
        public bool CustomMilestone { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMilestoneLevelItems))]
        [SettingsUISection(General, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(GetMilestoneLevelStatus))]
        public int MilestoneLevel { get; set; }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(General, SaveConversion)]
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

#if DEBUG
        [SettingsUIKeyboardBinding(BindingKeyboard.T, "DebugAction", ctrl: true, shift: true)]
        [SettingsUISection(KeyBindings, Money)]
        public ProxyBinding DebugKeyboardBinding { get; set; }
#endif

        [SettingsUIKeyboardBinding(BindingKeyboard.M, AddMoneyAction, ctrl: true, shift: true)]
        [SettingsUISection(KeyBindings, Money)]
        public ProxyBinding AddMoneyKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.N, SubtractMoneyAction, ctrl: true, shift: true)]
        [SettingsUISection(KeyBindings, Money)]
        public ProxyBinding SubtractMoneyKeyboardBinding { get; set; }

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

        [SettingsUIButtonGroup(AboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(About, AboutLinks)]
        public bool OpenDiscord
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(UrlDiscord);
                }
            }
        }

        [SettingsUISection(About, AboutUsage)]
        public bool ShowUsage { get; set; }

        [SettingsUIMultilineText]
        [SettingsUIHideByCondition(typeof(Setting), nameof(HideUsageText))]
        [SettingsUISection(About, AboutUsage)]
        public string UsageText => string.Empty;

        public string[] Milestones { get; } =
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

        private bool IsInGame()
        {
            return GameManager.instance != null && GameManager.instance.gameMode == GameMode.Game;
        }

        public bool NotInGame => !IsInGame();

        public bool InEditor => GameManager.instance != null && GameManager.instance.gameMode == GameMode.Editor;

        public bool InMainMenu => GameManager.instance != null && GameManager.instance.gameMode == GameMode.MainMenu;

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
        }

        private bool HideUsageText()
        {
            return !ShowUsage;
        }

        private bool CannotConvertUnlimitedMoneySave()
        {
            return GetMoneyControllerSystem()?.CanConvertUnlimitedMoneySave() != true;
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
                LogUtils.WarnOnce("open-url-" + url, () => $"Failed to open URL '{url}': {ex.GetType().Name}: {ex.Message}", ex);
            }
        }

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

        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }

        public override void SetDefaults()
        {
            AchievementsEnabled = true;
            ManualMoneyAmount = 20000;
            AutomaticAddMoney = false;
            AutomaticAddMoneyThreshold = 1000000;
            AutomaticAddMoneyAmount = 1000000;
            InitialMoney = 0;
            CustomMilestone = false;
            MilestoneLevel = 19;
            ShowUsage = false;

            Notification.SetDefaults();
            Hidden.SetDefaults();
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
                    displayName = GetOptionLocaleID(Milestones[i]),
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
