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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "常规" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快捷键" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "关于" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "调试" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "成就" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金钱" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存档转换" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用说明" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "启用成就" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "加载此模组时保持成就启用 [ ✓ ]。\\n" +
                    "如果安装了 AchievementFixer，City Watchdog 会隐藏此选项，并让该模组处理成就。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金钱快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "添加金钱和扣除金钱快捷键会使用这个金额。\\n" +
                    "默认 = 20,000。\\n" +
                    "它不会单独修改当前余额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自动加钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "启用 [ ✓ ] 后，City Watchdog 会在城市加载时检查余额。\\n" +
                    "如果余额 < 阈值，就添加所选的自动金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自动金钱阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自动加钱已启用，且城市余额低于此值，\\n" +
                    "City Watchdog 会添加所选的自动金额。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自动加钱金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自动加钱触发时添加的金额。\\n" +
                    "请选择足够高的数值，让城市余额安全高于阈值。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "为新的<有限资金>城市或第一次加载的城市设置起始余额，应用后会重置为游戏默认。\\n" +
                    "如果城市已经加载，此项会变灰。\\n" +
                    "在开始/加载城市前设置 → 只应用一次 → 之后请使用<金钱快捷键金额>或<自动加钱>。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑选择器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在加载或开始城市前启用，可在城市加载后立即解锁所选里程碑。\\n" +
                    "城市加载后此项会变灰；如需安全更改，请重启游戏。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "选择下次加载城市时要解锁的里程碑等级。\\n" +
                    "只有在未加载城市时可调整，并且需要先启用 [里程碑选择器] [ ✓ ]。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份后>再开启此项。\\n" +
                    "当加载的城市是用无限金钱创建时，会解锁 <[转换无限金钱存档]> 按钮。\\n" +
                    "City Watchdog 无法撤销此转换。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "将无限金钱存档转换为普通" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用于以无限金钱开始的城市。\\n" +
                    "在该城市加载时，将存档转换为普通有限资金预算，让城市重新拥有正常金钱挑战。\\n" +
                    "除非加载的城市是<无限金钱>类型，并且<无限金钱转换器>为 ON [ ✓ ]，否则按钮会<禁用/变灰>。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要把此城市从无限金钱转换为普通有限资金吗？\\n" +
                    "请先保存备份；City Watchdog 无法撤销此操作。\\n" +
                    "确定吗？" },

                // --- Key bindings ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "添加金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市中添加金钱的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "添加金钱" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除金钱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市中扣除金钱的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除金钱" },

#if DEBUG
                // --- Debug key binding ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DebugKeyboardBinding)), "调试操作" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DebugKeyboardBinding)), "仅开发者使用的调试快捷键。只会在 Debug 构建中显示。" },
                { m_Settings.GetBindingKeyLocaleID("DebugAction"), "调试操作" },

#endif

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
                    "<通知面板>\\n" +
                    "1. 游戏中点击左上角 City Watchdog 按钮打开面板。\\n" +
                    "2. 使用 ASC/DESC 排序分组。\\n" +
                    "3. 使用全部切换快速设置，或展开分组单独修改通知图标。\\n" +
                    "4. City Watchdog 只隐藏或显示图标；不会修复城市问题本身。\\n" +
                    "\\n" +
                    "<金钱辅助>\\n" +
                    "1. 添加金钱和扣除金钱使用金钱快捷键金额。\\n" +
                    "2. 自动加钱会在城市加载时监控余额，低于阈值时加钱。\\n" +
                    "3. 转换无限金钱存档仅适用于以无限金钱开始的城市，且 <City Watchdog 无法撤销>。\\n" +
                    "\\n" +
                    "<自定义里程碑>\\n" +
                    "在加载或开始城市前，在选项中设置初始金钱并选择里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "打开通知图标面板。" },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "展开任意分组；勾选 ✓ 显示，取消勾选隐藏警告图标。" },
                { m_Settings.GetUILocaleID("ToggleAll"), "全部切换" },
                { m_Settings.GetUILocaleID("ExpandAll"), "全部展开" },
                { m_Settings.GetUILocaleID("CollapseAll"), "全部折叠" },
                { m_Settings.GetUILocaleID("SortAscending"), "升序 ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "降序 ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "排序方式" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "显示或隐藏全部图标" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "电力" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "电力不足" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "电力瓶颈" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "电力流通不畅" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "发电站过载" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "变压器过载" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "连接的输出线路不足" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "电池耗尽" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "电缆未连接" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "电力线未连接" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "水管" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "水量不足" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "水泵受污染" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "下水道堵塞" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "水管未连接" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "污水管未连接" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "供水设施过载" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "污水设施过载" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "地下水位过低" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "水位过低" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "水泵受污染" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "建筑" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "倒塌" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "废弃" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "被判定危险" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "已关闭" },
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
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "资源成本过高" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "顾客不足" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "就业" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "劳动力不足" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "高技能劳动力不足" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "灾害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "天气损坏" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "被天气摧毁" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "水灾损坏" },
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
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "土地污染" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "资源消耗者" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "没有应急避难所补给" },
                { m_Settings.GetUILocaleID("Route"), "路线" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "寻路失败" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "交通线路" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "没有车辆" },
            };

            // --- Hand-written milestone fallback names ---
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
