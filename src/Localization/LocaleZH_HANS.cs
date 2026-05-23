// File: src/Localization/LocaleZH_HANS.cs
// Purpose: Simplified Chinese (zh-HANS) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleZH_HANS : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleZH_HANS(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "操作" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快捷键" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "调试" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "金钱视图" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存档转换" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "快捷键" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "金钱视图" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "在底部工具栏的原版金钱和人口箭头旁显示数字趋势值。\n" +
                    "这只是轻量工具栏显示，不会改变城市金钱或人口。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "金钱视图频率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "选择底部工具栏的趋势文字显示金钱和人口的每小时值或每月值。\n" +
                    "每月金钱使用预算收入减去支出，人口使用 24 小时预测。" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "每小时 (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金钱提示样式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "选择鼠标悬停在金钱栏时提示中显示的详细程度。\n" +
                    "紧凑 = 首次安装时的默认值。\n" +
                    "<迷你> 只显示 /mo 和 /h 的两个净值。\n" +
                    "<紧凑> 缩短大数字（例如用 15.21M 代替 15,212,318）。\n" +
                    "<完整数据> 显示完整数值和总计字段。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "紧凑" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "完整数据" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "金钱文字大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "调整金钱视图提示中数字的<文字大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的金钱上。\n" +
                    "给觉得游戏小提示难看清的玩家使用。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "人口文字大小" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "调整人口提示中数字的<文字大小>。\n" +
                    "游戏默认 = 100%\n" +
                    "<模组默认 = 120%>\n" +
                    "将鼠标悬停在屏幕底部的人口上。"
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "用于增加金钱和减少金钱快捷键的金额。\n" +
                    "默认值 = 40,000。\n" +
                    "除非在城市中使用快捷键增加/减少金钱，否则此设置不会做任何事。\n" +
                    "如需自动金钱，请启用自动增加金钱选项。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中增加金钱的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "减少金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中减少金钱的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "减少金钱" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动增加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会在城市载入期间检查城市余额。\n" +
                    "如果余额低于阈值，就会加入所选的自动金额。\n" +
                    "建议按需使用快捷键（<[> 或 <]>）手动加钱，而不是使用这个自动选项；不过如果你想用，它仍然保留。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动增加金钱已启用，且城市余额低于此数值，\n" +
                    "City Watchdog 会加入所选的自动金额。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动增加金钱触发时加入的金额。\n" +
                    "请选择足以让城市安全高于阈值的数值。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "设置新的 <有限金钱> 城市或第一个载入城市的起始余额，应用后会重置为游戏默认值。\n" +
                    "如果城市已经载入，此项会变成灰色不可用。\n" +
                    "在开始/载入城市前设置 → 应用一次 → 之后使用 <金钱快捷键金额> 或 <自动增加金钱>。" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切换通知图标" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "与游戏内 <[Toggle All]> 图标按钮相同功能的 <快捷键>。\n" +
                    "可立即显示或隐藏所有列出的城市通知图标。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即显示/隐藏所有通知图标" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "打开/关闭通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷键>用于打开或关闭游戏内通知面板。\n" +
                    "效果与点击左上角图标打开完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "打开/关闭通知面板" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在载入或开始城市前启用，可在城市载入后立刻解锁所选里程碑。\n" +
                    "城市已载入时不能打开，但如果不小心已启用，仍可关闭。\n" +
                    "City Watchdog 无法复原已经存入城市的里程碑变更；需要时请使用较早的存档。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次载入城市时要解锁的里程碑等级。\n" +
                    "只能在没有载入城市，且 [里程碑选择器] 已启用 [ ✓ ] 时调整。" },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份城市>。\n" +
                    "将以无限金钱开始的城市转换为有正常金钱挑战的普通城市。\n" +
                    "当载入的城市是 <无限金钱> 类型时，启用此项会解锁 <[转换无限金钱存档]> 按钮。\n" +
                    "City Watchdog 无法复原此转换。\n" +
                    "如果是普通城市，不用担心；不需要使用此功能。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱城市转为普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以 <无限金钱> 开始的城市。\n" +
                    "在该城市载入时，将存档转换为普通有限金钱预算，让城市重新有正常金钱挑战。\n" +
                    "除非载入的城市是 <无限金钱> 类型，且 <无限金钱转换器> 为 ON [ ✓ ]，否则按钮会 <停用/变灰>。\n" +
                    "请先备份存档并自行承担风险；City Watchdog 无法复原此转换。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要将此城市从无限金钱转换为普通有限金钱吗？\n" +
                    "请先备份；City Watchdog 无法复原此操作。\n" +
                    "确定吗？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模组的显示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "当前模组版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "打开作者的 Paradox Mods 页面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "显示说明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "显示或隐藏下方使用说明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<通知面板>\n" +
                    "1. 点击 City Watchdog 按钮（左上角）打开面板。\n" +
                    "2. 用 ASC/DESC 排序。\n" +
                    "3. 使用 Toggle All 快速设置，或展开分类逐一调整通知图标。\n" +
                    "4. City Watchdog 只会隐藏或显示图标；不会修复图标背后的城市问题。\n\n" +
                    "<金钱工具>\n" +
                    "1. 金钱视图 会在底部工具栏的金钱和人口趋势箭头旁显示 /h 或 /mo 数值。\n" +
                    "2. 增加和减少金钱：使用 <金钱快捷键金额>。\n" +
                    "3. 自动增加金钱会在城市载入期间监看余额，低于阈值时增加金钱。\n" +
                    "4. 转换无限金钱存档只适用于以无限金钱开始的城市，City Watchdog <无法复原>。\n\n" +
                    "<自定义里程碑>\n" +
                    "请在载入或开始城市前，在选项菜单设置初始金钱与里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "打开通知图标面板。" },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "展开行；[✓] 显示，取消勾选隐藏警报。\n" +
                    "不修复问题，只整理图标。" },
                { m_Settings.GetUILocaleID("ToggleAll"), "全部切换" },
                { m_Settings.GetUILocaleID("ExpandAll"), "全部展开" },
                { m_Settings.GetUILocaleID("CollapseAll"), "折叠所有行" },
                { m_Settings.GetUILocaleID("SortAscending"), "升序 ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "降序 ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "排序方式" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "显示/隐藏所有图标。\n" +
                    "颜色：绿色 = 全部开启；蓝色 = 混合；红色 = 全部关闭。" },

                // --- Tooltip labels ---
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "收入：" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "支出：" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "净额：" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "总计：" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "当前趋势：" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "出生：" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "死亡：" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "迁入：" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "迁出：" },  

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "电力" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "电力不足" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "电力瓶颈" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "电力流动不良" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "发电厂过载" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "变压器过载" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "连接的输出线路不足" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "电池耗尽" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "电缆未连接" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "电力线未连接" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "水管" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "水量不足" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "抽水泵受污染" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "污水回堵" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "水管未连接" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "污水管未连接" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "供水设施过载" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "污水设施过载" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "地下水位太低" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "水位太低" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "抽水泵受污染" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "建筑" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "倒塌" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "废弃" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "危楼" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "已停用" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "租金过高" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "交通" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "交通堵塞" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "死路" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "需要道路" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "轨道未连接" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "无汽车通行" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "无水路连接" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "无轨道连接" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "无行人通行" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "公司" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "材料与资源成本过高" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "顾客不足" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "就业" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "缺乏劳工" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "缺乏高技能劳工" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "灾害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "天气损害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "被天气摧毁" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "水灾损害" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "被洪水摧毁" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "此建筑已被摧毁" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "火灾" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "着火" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "烧毁" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "垃圾" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "垃圾堆积" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "设施已满" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "医疗" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "等待救护车" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "等待灵车" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "设施已满" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "警察" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "交通事故" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "犯罪现场" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "污染" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "空气污染" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "噪音污染" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "土壤污染" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "资源消耗者" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "没有紧急避难所补给" },
                { m_Settings.GetUILocaleID("Route"), "路线" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "寻路失败" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "交通线路" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "没有车辆" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
