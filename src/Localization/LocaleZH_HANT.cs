// File: src/Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese (zh-HANT) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleZH_HANT(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "快捷鍵" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "關於" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "除錯" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Trends), "趨勢追蹤" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "金錢" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "里程碑" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "存檔轉換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "快捷鍵" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使用方式" },

                // --- Trend Tracker ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "趨勢追蹤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "在底部工具列的原版金錢與人口箭頭旁顯示數字趨勢值。\n" +
                    "這只是輕量顯示，不會改變城市金錢或人口。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "趨勢頻率" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "選擇底部工具列的趨勢文字顯示金錢與人口的每小時值或每月值。\n" +
                    "每月金錢使用預算收入減去支出，人口使用 24 小時預測。" },

                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "每小時 (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "每月 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "金錢提示樣式" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "選擇滑鼠停在金錢列時提示中顯示的詳細程度。\n" +
                    "<Mini> 只顯示 /mo 和 /h 的兩個淨值。\n" +
                    "<Compact> 縮短大型數字（例如用 15.21M 代替 15,212,318）。\n" +
                    "<Full size> 顯示完整數值和總計欄位。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "迷你" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "精簡" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullSize"), "完整大小" },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "金錢快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "用於增加金錢和扣除金錢快捷鍵的金額。\n" +
                    "預設 = 40,000。\n" +
                    "除非在城市中使用快捷鍵增加/扣除金錢，否則此設定不會做任何事。\n" +
                    "如需自動金錢，請啟用自動增加金錢選項。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "增加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "在城市內增加金錢的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "增加金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "扣除金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "在城市內扣除金錢的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "扣除金錢" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動增加金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "啟用 [ ✓ ] 後，City Watchdog 會在城市載入期間檢查城市餘額。\n" +
                    "如果餘額低於門檻，就會加入所選的自動金額。\n" +
                    "建議視需要使用快捷鍵（<[> 或 <]>）手動加錢，而不是使用這個自動選項；不過如果你想用，它仍然保留。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動金錢門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "如果自動增加金錢已啟用，且城市餘額低於此數值，\n" +
                    "City Watchdog 會加入所選的自動金額。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動增加金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "每次自動增加金錢觸發時加入的金額。\n" +
                    "請選擇足以讓城市安全高於門檻的數值。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初始金錢" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "設定新的 <有限金錢> 城市或第一個載入城市的起始餘額，套用後會重設為遊戲預設值。\n" +
                    "如果城市已經載入，此選項會變成灰色不可用。\n" +
                    "在開始/載入城市前設定 → 套用一次 → 之後使用 <金錢快捷鍵金額> 或 <自動增加金錢>。" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "切換通知圖示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "與遊戲內 <[Toggle All]> 圖示按鈕相同功能的 <快捷鍵>。\n" +
                    "可立即顯示或隱藏所有列出的城市通知圖示。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "立即顯示/隱藏所有通知圖示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "開啟/關閉通知面板" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<快捷鍵>用於開啟或關閉遊戲內通知面板。\n" +
                    "效果與點擊左上角圖示開啟完整面板相同。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "開啟/關閉通知面板" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "里程碑選擇器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "在載入或開始城市前啟用，可在城市載入後立刻解鎖所選里程碑。\n" +
                    "城市已載入時不能打開，但如果不小心已經開啟，仍可關閉。\n" +
                    "City Watchdog 無法復原已經存入城市的里程碑變更；需要時請使用較早的存檔。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "選擇下次載入城市時要解鎖的里程碑等級。\n" +
                    "只能在沒有載入城市，且 [里程碑選擇器] 已啟用 [ ✓ ] 時調整。" },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<請先備份城市>。\n" +
                    "將以無限金錢開始的城市轉換為有一般金錢挑戰的普通城市。\n" +
                    "當載入的城市是 <無限金錢> 類型時，啟用此選項會解鎖 <[轉換無限金錢存檔]> 按鈕。\n" +
                    "City Watchdog 無法復原此轉換。\n" +
                    "如果是普通城市，不用擔心；不需要使用此功能。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "將無限金錢城市轉為普通城市" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "用於以 <無限金錢> 開始的城市。\n" +
                    "在該城市載入時，將存檔轉換為普通有限金錢預算，讓城市重新有一般金錢挑戰。\n" +
                    "除非載入的城市是 <無限金錢> 類型，且 <無限金錢轉換器> 為 ON [ ✓ ]，否則按鈕會 <停用/變灰>。\n" +
                    "請先備份存檔並自行承擔風險；City Watchdog 無法復原此轉換。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "要將此城市從無限金錢轉換為普通有限金錢嗎？\n" +
                    "請先備份；City Watchdog 無法復原此操作。\n" +
                    "確定嗎？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "模組名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "此模組的顯示名稱。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "目前模組版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "開啟作者的 Paradox Mods 頁面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "顯示說明" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "顯示或隱藏下方使用說明。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<通知面板>\n" +
                    "1. 點擊 City Watchdog 按鈕（左上角）開啟面板。\n" +
                    "2. 用 ASC/DESC 排序。\n" +
                    "3. 使用 Toggle All 快速設定，或展開分類逐一調整通知圖示。\n" +
                    "4. City Watchdog 只會隱藏或顯示圖示；不會修復圖示背後的城市問題。\n\n" +
                    "<金錢工具>\n" +
                    "1. 趨勢追蹤 會在底部工具列的金錢與人口趨勢箭頭旁顯示 /h 或 /mo 數值。\n" +
                    "2. 增加和扣除金錢：使用 <金錢快捷鍵金額>。\n" +
                    "3. 自動增加金錢會在城市載入期間監看餘額，低於門檻時增加金錢。\n" +
                    "4. 轉換無限金錢存檔只適用於以無限金錢開始的城市，City Watchdog <無法復原>。\n\n" +
                    "<自訂里程碑>\n" +
                    "請在載入或開始城市前，於選項選單設定初始金錢與里程碑。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "開啟通知圖示面板。" },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "展開任一列；勾選 [✓] 顯示，取消勾選則隱藏警示。\n" +
                    "這不會修復城市問題，只會隱藏圖示雜亂。" },
                { m_Settings.GetUILocaleID("ToggleAll"), "全部切換" },
                { m_Settings.GetUILocaleID("ExpandAll"), "全部展開" },
                { m_Settings.GetUILocaleID("CollapseAll"), "全部折疊" },
                { m_Settings.GetUILocaleID("SortAscending"), "升序 ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "降序 ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "排序方式" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "顯示/隱藏所有圖示。\n" +
                    "顏色：綠色 = 全部開啟；藍色 = 混合；紅色 = 全部關閉。" },
                { m_Settings.GetUILocaleID("TrendTooltipIncome"), "收入：" },
                { m_Settings.GetUILocaleID("TrendTooltipExpenses"), "支出：" },
                { m_Settings.GetUILocaleID("TrendTooltipNet"), "淨額：" },
                { m_Settings.GetUILocaleID("TrendTooltipTotal"), "總計：" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "電力" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "電力不足" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "電力瓶頸" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "電力流動不良" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "發電廠過載" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "變壓器過載" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "連接的輸出線不足" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "電池耗盡" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "電纜未連接" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "電力線未連接" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "水管" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "水量不足" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "抽水幫浦受污染" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "污水回堵" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "水管未連接" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "污水管未連接" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "供水設施過載" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "污水設施過載" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "地下水位太低" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "水位太低" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "抽水幫浦受污染" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "建築" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "倒塌" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "廢棄" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "危樓" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "已停用" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "租金過高" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "交通" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "交通堵塞" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "死路" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "需要道路" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "軌道未連接" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "無汽車通行" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "無水路連接" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "無軌道連接" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "無行人通行" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "公司" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "材料與資源成本過高" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "顧客不足" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "就業" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "缺乏勞工" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "缺乏高技能勞工" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "災害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "天氣損害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "被天氣摧毀" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "水災損害" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "被洪水摧毀" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "此建築已被摧毀" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "火災" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "著火" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "燒毀" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "垃圾" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "垃圾堆積" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "設施已滿" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "醫療" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "等待救護車" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "等待靈車" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "設施已滿" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "警察" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "交通事故" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "犯罪現場" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "污染" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "空氣污染" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "噪音污染" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "土壤污染" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "資源消耗者" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "沒有緊急避難所補給" },
                { m_Settings.GetUILocaleID("Route"), "路線" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "尋路失敗" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "交通線路" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "沒有車輛" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
