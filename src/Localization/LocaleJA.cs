// File: src/Localization/LocaleJA.cs
// Purpose: Japanese (ja-JP) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleJA(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "アクション" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ホットキー" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "情報" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "デバッグ" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Trends), "トレンド表示" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "資金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "通知" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "マイルストーン" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ホットキー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },

                // --- Trend Tracker ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "トレンド表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "下部ツールバーの資金と人口のバニラ矢印の横に、数値の傾向を追加します。\n" +
                    "これは軽量な表示だけで、都市の資金や人口は変更しません。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "トレンド頻度" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "下部ツールバーの傾向テキストを、資金と人口について時間あたりまたは月あたりで表示するか選びます。\n" +
                    "月あたりの資金は予算収入から支出を引いた値、人口は24時間予測を使います。" },

                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "毎時 (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "月間 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "資金ツールチップのスタイル" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "資金ツールチップに表示する詳細量を選びます。\n" +
                    "<Mini> は /mo と /h の純額2つだけを表示します。\n" +
                    "<Compact> は大きな数値を短く表示します（15,212,318 ではなく 15.21M）。\n" +
                    "<Full size> は長い数値と合計欄を表示します。" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "ミニ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "コンパクト" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullSize"), "フルサイズ" },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "資金追加と資金減少のホットキーで使う金額です。\n" +
                    "既定値 = 40,000。\n" +
                    "都市内でホットキーを使って資金を追加/減少しない限り、これは何もしません。\n" +
                    "自動資金には、資金自動追加を有効にしてください。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "資金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内で資金を追加するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "資金を追加" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "資金を減らす" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内で資金を減らすホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "資金を減らす" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "資金自動追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "有効 [ ✓ ] の場合、都市が読み込まれている間に City Watchdog が都市の残高を確認します。\n" +
                    "残高がしきい値より低い場合、選択した自動金額を追加します。\n" +
                    "この自動オプションよりも、必要に応じてホットキー（<[> または <]>）で手動資金を使うことをおすすめします。ただし、使いたい場合のために残しています。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "資金自動追加が有効で、都市の残高がこの値を下回ると、\n" +
                    "City Watchdog が選択した自動金額を追加します。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "資金自動追加が発動するたびに追加される金額です。\n" +
                    "都市をしきい値より十分上に戻せる値を選んでください。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "新しい<資金制限あり>都市、または最初に読み込む都市の開始残高を設定し、適用後にゲーム既定値へ戻します。\n" +
                    "都市がすでに読み込まれている場合はグレーアウトします。\n" +
                    "都市の開始/読み込み前に設定 → 一度だけ適用 → その後は<資金ホットキー額>または<資金自動追加>を使ってください。" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム既定値" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコン切替" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "ゲーム内の <[Toggle All]> アイコンボタンと同じ動作の<ホットキー>です。\n" +
                    "一覧にある都市通知アイコンをすぐに表示/非表示にします。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "すべての通知アイコンを即時表示/非表示" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "通知パネルを開く/閉じる" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ホットキー>でゲーム内通知パネルを開閉します。\n" +
                    "左上アイコンをクリックして完全なパネルを開くのと同じ動作です。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "通知パネルを開く/閉じる" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "都市を読み込む前、または開始する前に有効にすると、都市読み込み直後に選択したマイルストーンを解除します。\n" +
                    "都市が読み込まれている間はONにできませんが、誤って有効のままならOFFにできます。\n" +
                    "City Watchdog は都市に保存済みのマイルストーン変更を元に戻せません。必要なら以前のセーブを使ってください。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "次回の都市読み込み時に解除するマイルストーンレベルを選びます。\n" +
                    "都市が読み込まれておらず、[マイルストーン選択] が有効 [ ✓ ] の場合だけ調整できます。" },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無制限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に都市のバックアップを作成してください>。\n" +
                    "無制限資金で開始した都市を、通常の資金チャレンジがある都市へ変換します。\n" +
                    "読み込まれた都市が<無制限資金>タイプの場合、この設定を有効にすると <[無制限資金セーブを変換]> ボタンが解除されます。\n" +
                    "City Watchdog はこの変換を元に戻せません。\n" +
                    "通常の都市では不要です。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無制限資金都市を通常都市へ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<無制限資金>で開始した都市用です。\n" +
                    "その都市が読み込まれている間に、セーブを通常の資金制限予算へ変換し、資金チャレンジを復活させます。\n" +
                    "読み込まれた都市が<無制限資金>タイプで、<無制限資金コンバーター>がON [ ✓ ] でない限り、ボタンは<無効/グレーアウト>されます。\n" +
                    "バックアップを作成し、自己責任で使用してください。City Watchdog はこの変換を元に戻せません。" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "この都市を無制限資金から通常の資金制限へ変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdog は元に戻せません。\n" +
                    "よろしいですか？" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "このModの表示名です。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在のModバージョンです。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "使い方を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使用説明を表示/非表示にします。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<通知パネル>\n" +
                    "1. City Watchdog ボタン（左上）をクリックしてパネルを開きます。\n" +
                    "2. ASC/DESC で並べ替えます。\n" +
                    "3. Toggle All で素早く設定するか、セクションを展開して個別の通知アイコンを変更します。\n" +
                    "4. City Watchdog はアイコンの表示/非表示だけを行います。都市の問題そのものは修正しません。\n\n" +
                    "<資金ヘルパー>\n" +
                    "1. トレンド表示は下部ツールバーの資金/人口の横に /h または /mo の数値を追加します。\n" +
                    "2. 資金追加と資金減少: <資金ホットキー額>を使います。\n" +
                    "3. 資金自動追加は都市が読み込まれている間に残高を監視し、しきい値未満なら資金を追加します。\n" +
                    "4. 無制限資金セーブ変換は無制限資金で開始した都市専用で、City Watchdog では<元に戻せません>。\n\n" +
                    "<カスタムマイルストーン>\n" +
                    "都市を読み込む前、または開始する前に、オプションメニューで初期資金とマイルストーンを設定してください。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "通知アイコンパネルを開きます。" },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "任意の行を展開します。[✓] チェックで表示、チェック解除でアラートを非表示にします。\n" +
                    "都市の問題は修正せず、アイコンの clutter を隠すだけです。" },
                { m_Settings.GetUILocaleID("ToggleAll"), "すべて切替" },
                { m_Settings.GetUILocaleID("ExpandAll"), "すべて展開" },
                { m_Settings.GetUILocaleID("CollapseAll"), "すべての行を折りたたむ" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "並び順" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "すべてのアイコンを表示/非表示にします。\n" +
                    "色: 緑 = すべてON、青 = 混在、赤 = すべてOFF。" },
                { m_Settings.GetUILocaleID("TrendTooltipIncome"), "収入：" },
                { m_Settings.GetUILocaleID("TrendTooltipExpenses"), "支出：" },
                { m_Settings.GetUILocaleID("TrendTooltipNet"), "純額：" },
                { m_Settings.GetUILocaleID("TrendTooltipTotal"), "合計：" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "電力" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "電力不足" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "電力ボトルネック" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "電力の流れが悪い" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "発電所過負荷" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "変圧器過負荷" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "接続済み出力線が不足" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "バッテリー切れ" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "電気ケーブル未接続" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "送電線未接続" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "水道管" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "水不足" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "取水ポンプ汚染" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "下水逆流" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "水道管未接続" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "下水管未接続" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "給水施設過負荷" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "下水施設過負荷" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "地下水位が低すぎる" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "水位が低すぎる" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "取水ポンプ汚染" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "建物" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "崩壊" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "放棄" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "使用禁止" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "停止中" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "家賃が高い" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "交通" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "渋滞" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "行き止まり" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "道路が必要" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "線路未接続" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "車両アクセスなし" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "水路接続なし" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "線路接続なし" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "歩行者アクセスなし" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "企業" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "資源コストが高い" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "顧客不足" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "職場" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "労働力不足" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "高技能労働者不足" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "災害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "気象被害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "天候で破壊" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "水害" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "洪水で破壊" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "この建物は破壊されました" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "火災" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "火災発生" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "全焼" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "ゴミ" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "ゴミが溜まっています" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "施設が満杯" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "医療" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "救急車待ち" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "霊柩車待ち" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "施設が満杯" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "警察" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "交通事故" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "犯罪現場" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "汚染" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "大気汚染" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "騒音公害" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "土壌汚染" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "資源消費者" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "緊急避難所の物資なし" },
                { m_Settings.GetUILocaleID("Route"), "ルート" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "経路探索失敗" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "交通路線" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "車両なし" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
