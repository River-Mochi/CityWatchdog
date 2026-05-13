// File: src/Settings/Setting.cs
// Purpose: Defines City Watchdog settings, Options UI controls, and key bindings.

namespace CityWatchdog.Settings
{
    using CityWatchdog.Systems;
    using Colossal.IO.AssetDatabase;
    using CS2Shared.Settings;
    using CS2Shared.Tools;
    using Game.Input;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;
    using System.Collections.Generic;
    using Unity.Entities;

    [FileLocation("ModsSettings/CityWatchdog/CityWatchdog")]
#if DEBUG
    [SettingsUITabOrder(General, KeyBindings, Advanced, Debug)]
    [SettingsUIGroupOrder(ModInfo, Achievements, Money, Reset, Serialize)]
    [SettingsUIShowGroupName(ModInfo, Achievements, Money, Reset, Serialize)]
#else
    [SettingsUITabOrder(General, KeyBindings, Advanced)]
    [SettingsUIGroupOrder(ModInfo, Achievements, Money, Reset)]
    [SettingsUIShowGroupName(ModInfo, Achievements, Money, Reset)]
#endif
    public partial class Setting : ModSettingBase
    {
        internal static Setting Instance { get; set; } = null!;

        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);

        internal const string Achievements = nameof(Achievements);
        internal const string Money = nameof(Money);
        internal const string Milestone = nameof(Milestone);

        public Setting(IMod mod) : base(mod)
        {
        }

        [SettingsUISection(General, Achievements)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsAchievementEnablerIncluded))]
        [SettingsUISetter(typeof(Setting), nameof(OnAchievementsOptionChanged))]
        public bool AchievementsEnabled { get; set; }

        [SettingsUISlider(min = 10000, max = 5000000, step = 50000, scalarMultiplier = 1, unit = Unit.kInteger)]
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

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(General, Money)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(NotInGame))]
        public bool MoneyTransfer
        {
            set
            {
                if (NotInGame)
                {
                    return;
                }

                World.DefaultGameObjectInjectionWorld?
                    .GetOrCreateSystemManaged<MoneyControllerSystem>()?
                    .SetUnlimitedMoneyToLimitedMoney();
            }
        }

        [SettingsUISection(General, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsInGame))]
        public bool CustomMilestone { get; set; }

        [SettingsUIDropdown(typeof(Setting), nameof(GetMilestoneLevelItems))]
        [SettingsUISection(General, Milestone)]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(GetMilestoneLevelStatus))]
        public int MilestoneLevel { get; set; }

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

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
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
            base.SetDefaults();

            AchievementsEnabled = true;
            ManualMoneyAmount = 1000000;
            AutomaticAddMoney = false;
            AutomaticAddMoneyThreshold = 1000000;
            AutomaticAddMoneyAmount = 1000000;
            InitialMoney = 0;
            CustomMilestone = false;
            MilestoneLevel = 19;

            Notification.SetDefaults();
        }

        private bool IsAchievementEnablerIncluded()
        {
            return ModTools.IsModInclusive("AchievementEnabler");
        }

        private void OnAchievementsOptionChanged(bool value)
        {
            World.DefaultGameObjectInjectionWorld?
                .GetOrCreateSystemManaged<AchievementsControllerSystem>()?
                .SetAchievements(value);
        }

        private bool GetMilestoneLevelStatus()
        {
            return InGame || !CustomMilestone;
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
    }
}
