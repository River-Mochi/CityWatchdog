// File: src/Localization/LocaleTR.cs
// Purpose: Turkish (tr-TR) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleTR(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "İşlemler" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Kısayollar" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Hakkında" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Hata Ayıklama" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Para Görünümü" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Para" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Bildirimler" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Kilometre Taşı" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Kayıt Dönüştürme" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Kısayollar" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "KULLANIM" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Para Görünümü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Vanilla alt çubuktaki para ve nüfus oklarının yanına sayısal trend ekler.\\n" +
                    "Sadece hafif bir gösterimdir; şehir parasını veya nüfusu değiştirmez." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Para Görünümü Sıklığı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Alt çubuk trendinin para ve nüfus için saatlik mi aylık mı görüneceğini seç.\\n" +
                    "Aylık para için bütçe geliri eksi giderleri, nüfus için 24 saatlik tahmini kullanır." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Saatlik (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Aylık (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Para İpucu Stili" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Para üstüne gelince kaç detay gösterileceğini seç.\\n" +
                    "Kompakt = ilk kurulum varsayılanı.\\n"+
                    "<Mini> yalnızca /mo ve /h için 2 Net değeri gösterir.\\n" +
                    "<Kompakt> büyük sayıları kısaltır (15.212.318 yerine 15.21M).\\n" +
                    "<Tam veri> uzun sayıları ve Toplam alanlarını gösterir." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Tam veri" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Para yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Para Görünümü ipucu sayılarının <yazı boyutunu> ayarlar.\\n" +
                    "Oyun varsayılanı = 100%\\n" +
                    "<Mod varsayılanı = 120%>\\n" +
                    "Ekranın altındaki Paranın üstüne gel.\\n"+
                    "Oyundaki küçük ipuçlarını zor gören oyuncular için eklendi."

                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Nüfus yazı boyutu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Nüfus ipucu sayılarının <yazı boyutunu> ayarlar.\\n" +
                    "Oyun varsayılanı = 100%\\n" +
                    "<Mod varsayılanı = 120%>\\n" +
                    "Ekranın altındaki Nüfusun üstüne gel."   
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Para Kısayolu Miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Para Ekle ve Para Çıkar kısayollarında bu miktarı kullanır.\\n" +
                    "<Mod varsayılanı = 40.000>\\n" +
                    "Şehirde para ekle/çıkar kısayolunu kullanmazsan bir şey yapmaz.\\n"+
                    "Otomatik para için Otomatik Para Ekle seçeneğini aç."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Para Ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Şehirde <Para Ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Para Ekle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Para Çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Şehirde <Para Çıkar> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Para Çıkar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Otomatik Para Ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Açıkken [ ✓ ], şehir yüklüyken City Watchdog şehir bakiyesini kontrol eder.\\n" +
                    "- Bakiye <eşik altında> ise, \\n" +
                    "  seçilen otomatik miktarı ekler.\\n" +
                    "- Gerektikçe kısayolla (<[> veya <]>) manuel para kullanmanı öneririm" +
                    "  ama otomatik seçenek istersen burada."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Otomatik Para Eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Otomatik Para Ekle açıksa ve şehir bakiyesi bu değerin altına düşerse,\\n" +
                    "Seçilen otomatik miktarı ekler." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Otomatik Para Miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Otomatik Para Ekle her çalıştığında eklenecek miktar.\\n" +
                    "Şehri güvenle eşik üstüne çıkaracak kadar yüksek bir değer seç." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Başlangıç Parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Yeni <sınırlı para> şehri veya ilk yüklenen şehir için başlangıç bakiyesini ayarlar,\\n" +
                    "uygulandıktan sonra Oyun Varsayılanına döner.\\n" +
                    "Şehir zaten yüklüyse bu seçenek pasif olur.\\n" +
                    "Şehir başlatmadan/yüklemeden önce ayarla → bir kez uygulanır → sonra <Para Kısayolu Miktarı> veya <Otomatik Para Ekle> kullan." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun Varsayılanı" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bildirim Simgelerini Değiştir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Oyun içindeki <[TÜMÜNÜ DEĞİŞTİR]> düğmesiyle aynı işi yapan <kısayol>.\\n" +
                    "Listedeki tüm şehir bildirim simgelerini anında gösterir veya gizler." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Tüm bildirim simgelerini anında göster/gizle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Bildirim Panelini Aç/Kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "Şehirdeki\\n" +
                    "<bildirim panelini> açıp kapatma <kısayolu>.\\n" +
                    "Sol üst simgeye tıklayıp tam paneli açmakla aynı çalışır."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Bildirim panelini aç/kapat" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Kilometre Taşı Seçici" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Şehir yüklenmeden/başlamadan önce aç; şehir yüklenince seçilen kilometre taşı hemen açılır.\\n" +
                    "Şehir yüklüyken AÇILAMAZ, ama yanlışlıkla açık kaldıysa KAPATILABİLİR.\\n" +
                    "City Watchdog kayda geçmiş kilometre taşı değişikliklerini geri alamaz; gerekirse eski kayıt kullan." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kilometre Taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Bir sonraki şehir yüklemesinde açılacak kilometre taşı seviyesini seç.\\n" +
                    "Sadece şehir yüklü değilken ve [Kilometre Taşı Seçici] açıkken [ ✓ ] ayarlanabilir." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız Para Dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehrin yedeğini al>.\\n" +
                    "Sınırsız Para ile başlayan şehri normal para zorluğu olan şehre dönüştürür.\\n" +
                    "Açıldığında, yüklü şehir <Sınırsız Para> türündeyse <[Sınırsız Para Kaydını Dönüştür]> düğmesini açar.\\n" +
                    "City Watchdog bu dönüşümü geri alamaz.\\n" +
                    "Normal şehirlerin varsa bunu dert etme; gerekmez." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Sınırsız Para Şehrini Normale Çevir" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler için.\\n" +
                    "Şehir yüklüyken kaydı normal sınırlı para bütçesine çevirir; şehirde para zorluğu geri gelir.\\n" +
                    "Yüklü şehir <Sınırsız Para> türü değilse düğme <pasif/gri> kalır\\n" +
                    "ve <Sınırsız Para Dönüştürücü> AÇIK [ ✓ ] olmalıdır.\\n" +
                    "Yedek kayıt al ve riski bilerek kullan; City Watchdog bunu geri alamaz." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Bu şehir Sınırsız Paradan normal sınırlı paraya çevrilsin mi?\\n" +
                    "ÖNCE yedek al; City Watchdog bunu geri alamaz.\\n" +
                    "Emin misin?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Bu modun görünen adı." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Geçerli mod sürümü." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Yazarın Paradox Mods sayfasını aç." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Talimatları Göster" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Aşağıdaki kullanım talimatlarını göster/gizle." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Bildirim paneli>\\n" +
                    "1. Paneli açmak için City Watchdog düğmesine (sol üst) tıkla veya Shift+N bas.\\n" +
                    "2. Artan/Azalan sırala.\\n" +
                    "3. Tümünü hızlı aç/kapat için TOGGLE ALL kullan veya bölüm açıp tek tek değiştir.\\n" +
                    "4. Sadece simgeleri gösterir/gizler; şehir sorununu çözmez.\\n\\n" +
                    "<Para yardımcıları>\\n" +
                    "1. Para ekle/çıkar: <Para Kısayolu Miktarı> ile varsayılan [ veya ] tuşlarını kullan.\\n" +
                    "2. Otomatik para, şehir yüklüyken bütçeyi izler ve eşik altına düşünce para ekler.\\n" +
                    "3. Para Görünümü, para/nüfus alt çubuğuna ve hover ipuçlarına sayılar ekler.\\n" +
                    "4. Sınırsız Para Kaydını Dönüştür yalnızca Sınırsız Para ile başlayan şehirler içindir ve <geri alınamaz>.\\n\\n" +
                    "<Özel kilometre taşı>\\n" +
                    "Şehir yüklemeden/başlatmadan önce Seçeneklerden Başlangıç Parası ve Kilometre Taşlarını ayarla."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Bildirim simgesi panelini aç." },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Satırları aç; işaretli gösterir, boşsa gizler.\\n" +
                    "Varsayılan kısayollar: Shift+N panel, N tümü, [ para ekle, ] para çıkar.\\n" +
                    "Sorunları çözmez, simge kalabalığını gizler." },


                { m_Settings.GetUILocaleID("ToggleAll"), "TÜMÜ" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Tümünü Aç" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Tümünü Kapat" },

                { m_Settings.GetUILocaleID("SortAscending"), "↑Artan sırala" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓Azalan sırala" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Tüm simgeleri göster/gizle.\\n" +
                    "Renk: yeşil = hepsi açık; mavi = karışık; kırmızı = hepsi kapalı." },

                // Tooltip labels.
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Gelir:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Gider:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Net:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Toplam:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Mevcut trend:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Doğum:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Ölüm:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "Evsiz:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Gelen:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Giden:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELEKTRİK" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Yetersiz elektrik" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Elektrik darboğazı" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Zayıf elektrik akışı" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Santral aşırı yüklü" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Trafo aşırı yüklü" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Yeterli çıkış hattı bağlı değil" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batarya boş" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Elektrik kablosu bağlı değil" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Güç hattı bağlı değil" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "SU BORUSU" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Yetersiz su" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Su pompası kirli" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Kanalizasyon tıkandı" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Su borusu bağlı değil" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Kanalizasyon borusu bağlı değil" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Su tesisi aşırı yüklü" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Kanalizasyon tesisi aşırı yüklü" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Yeraltı suyu çok düşük" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Su seviyesi çok düşük" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Su pompası kirli" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "BİNA" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Çökmüş" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Terk edilmiş" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Yıkım kararlı" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Devre dışı" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Yüksek kira" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRAFİK" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Trafik sıkışıklığı" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Çıkmaz sokak" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Yol gerekli" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Ray bağlı değil" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Araç erişimi yok" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Su yolu bağlantısı yok" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Ray bağlantısı yok" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Yaya erişimi yok" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "Bisiklet erişimi yok" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "ŞİRKET" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Yüksek kaynak maliyeti" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Yeterli müşteri yok" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "İŞ SAĞLAYICI" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "İşçi eksik" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Nitelikli işçi eksik" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "AFET" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Hava hasarı" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Havadan yıkıldı" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Su hasarı" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Selden yıkıldı" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Bu bina yıkılmış" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "YANGIN" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Yanıyor" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Yanıp kül oldu" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "ÇÖP" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Çöp birikiyor" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Tesis dolu" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SAĞLIK" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Ambulans bekliyor" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Cenaze aracı bekliyor" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Tesis dolu" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLİS" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Trafik kazası" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Suç mahalli" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "KİRLİLİK" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Hava kirliliği" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Gürültü kirliliği" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Zemin kirliliği" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "KAYNAK TÜKETİCİ" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Yetersiz kaynak" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "KAYNAK BAĞLANTISI" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "Kaynak hattı bağlı değil" },
                { m_Settings.GetUILocaleID("Route"), "ROTA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Rota bulunamadı" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "ULAŞIM HATTI" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Araç yok" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
