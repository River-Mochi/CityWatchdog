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
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "実績" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "お金" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "マイルストーン" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ホットキー" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "セーブ変換" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "使い方" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "実績を有効化" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "このMODの読み込み中も実績を有効 [ ✓ ] に保ちます。\n" +
                    "AchievementFixer が入っている場合、City Watchdog はこの項目を非表示にし、実績処理はそちらに任せます。" },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "トレンドトラッカー" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "下部ツールバーの資金と人口の傾向矢印の横に数値を追加します。\n" +
                    "軽量な表示補助だけで、都市の資金や人口は変更しません。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "トレンド表示モード" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "下部ツールバーの傾向テキストを時間あたりまたは月あたりで表示するか選びます。\n" +
                    "月あたりは、資金では収入-支出、人口では24時間の予測を使います。" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "1時間あたり (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "1か月あたり (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "お金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "お金を追加 / 減らすホットキーで使う金額です。\n" +
                    "デフォルト = 20,000。\n" +
                    "これだけで現在の残高を変更するわけではありません。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "自動でお金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "有効 [ ✓ ] にすると、都市の読み込み中に City Watchdog が残高をチェックします。\n" +
                    "残高 < しきい値 の場合、選択した金額を自動で追加します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "自動追加のしきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "自動でお金を追加が有効で、都市の残高がこの値を下回ると、\n" +
                    "City Watchdog が選択した金額を追加します。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "自動追加額" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "自動追加が発動するたびに追加される金額です。\n" +
                    "都市の残高がしきい値を安全に超えるくらいの値を選んでください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "新しい<資金制限あり>の都市、または最初に読み込む都市の開始残高を設定し、適用後はゲーム標準に戻ります。\n" +
                    "都市がすでに読み込まれている場合はグレーアウトします。\n" +
                    "都市を開始/読み込み前に設定 → 1回だけ適用 → その後は<お金ホットキー額>または<自動でお金を追加>を使ってください。" },
                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム標準" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "マイルストーン選択" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "都市を読み込む/開始する前に有効にすると、読み込み直後に選択したマイルストーンを解除します。\n" +
                    "都市が読み込まれるとグレーアウトします。安全に変更するにはゲームを再起動してください。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "次回都市を読み込むときに解除するマイルストーンを選びます。\n" +
                    "都市が読み込まれていない時だけ、かつ [マイルストーン選択] が有効 [ ✓ ] の時だけ変更できます。" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "無限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<バックアップ作成後のみ>ON にしてください。\n" +
                    "読み込んだ都市が無限資金で開始された場合、<[無限資金セーブを変換]> ボタンを使えるようにします。\n" +
                    "City Watchdog はこの変換を元に戻せません。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "無限資金セーブを通常に変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "無限資金で開始した都市用です。\n" +
                    "その都市を読み込んでいる間に、通常の資金制限あり予算へ変換し、お金のチャレンジを戻します。\n" +
                    "読み込んだ都市が<無限資金>タイプで、<無限資金コンバーター>が ON [ ✓ ] でない限り、ボタンは<無効/グレーアウト>です。" },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "この都市を無限資金から通常の資金制限ありに変換しますか？\n" +
                    "先にバックアップを保存してください。City Watchdog は元に戻せません。\n" +
                    "よろしいですか？" },

                // --- Key bindings ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "通知アイコンを切り替え" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "すべての通知アイコンをまとめて表示/非表示にするホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "通知アイコンを切り替え" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "お金を追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "都市内でお金を追加するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "お金を追加" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "お金を減らす" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "都市内でお金を減らすホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "お金を減らす" },

                                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "MOD名" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "このMODの表示名です。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "現在のMODバージョンです。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "作者の Paradox Mods ページを開きます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "説明を表示" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "下の使い方説明を表示/非表示にします。" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<通知パネル>\n" +
                    "1. ゲーム内で左上の City Watchdog ボタンをクリックしてパネルを開きます。\n" +
                    "2. ASC/DESC でセクションを並べ替えます。\n" +
                    "3. Toggle All でまとめて設定、またはセクションを開いて個別の通知アイコンを変更します。\n" +
                    "4. City Watchdog はアイコンを表示/非表示にするだけで、都市の問題そのものは解決しません。\n" +
                    "\n" +
                    "<お金ヘルパー>\n" +
                    "1. トレンドトラッカーは、資金と人口の傾向矢印の横に /h または /mo の値を追加します。\n" +
                    "2. お金を追加 / 減らす は、お金ホットキー額を使います。\n" +
                    "3. 自動でお金を追加 は都市の残高を監視し、しきい値未満ならお金を追加します。\n" +
                    "4. 無限資金セーブの変換は、無限資金で開始した都市専用で、<City Watchdog では元に戻せません>。\n" +
                    "\n" +
                    "<カスタムマイルストーン>\n" +
                    "都市を読み込む/開始する前に、オプションで初期資金とマイルストーンを設定してください。" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "通知アイコンパネルを開きます。" },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "セクションを開き、表示するなら ✓、隠すならチェックを外します。" },
                { m_Settings.GetUILocaleID("ToggleAll"), "全切替" },
                { m_Settings.GetUILocaleID("ExpandAll"), "全展開" },
                { m_Settings.GetUILocaleID("CollapseAll"), "全折りたたみ" },
                { m_Settings.GetUILocaleID("SortAscending"), "昇順 ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "降順 ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "並び順" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "すべてのアイコンを表示/非表示" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "電力" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "電力不足" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "電力のボトルネック" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "電力の流れが悪い" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "発電所が過負荷" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "変圧器が過負荷" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "接続された出力線が不足" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "バッテリー切れ" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "電気ケーブル未接続" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "送電線未接続" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "上下水道" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "水不足" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "取水ポンプが汚染" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "下水が逆流" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "水道管未接続" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "下水管未接続" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "水道施設が過負荷" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "下水施設が過負荷" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "地下水位が低すぎる" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "水位が低すぎる" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "取水ポンプが汚染" },

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
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "車でアクセス不可" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "水路接続なし" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "線路接続なし" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "歩行者アクセスなし" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "企業" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "資源コストが高い" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "客不足" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "雇用" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "労働者不足" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "高技能労働者不足" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "災害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "天候被害" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "天候で破壊" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "水害" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "洪水で破壊" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "この建物は破壊されました" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "火災" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "火災発生" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "焼失" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "ごみ" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "ごみが溜まっている" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "施設が満杯" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "医療" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "救急車待ち" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "霊柩車待ち" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "施設が満杯" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "警察" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "交通事故" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "事件現場" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "公害" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "大気汚染" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "騒音公害" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "土壌汚染" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "資源消費施設" },
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
