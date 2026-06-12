// File: src/Localization/LocaleVI.cs
// Purpose: Vietnamese (vi-VN) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleVI(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Hành động" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Phím tắt" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Giới thiệu" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Gỡ lỗi" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Xem tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Tiền" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Thông báo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Mốc" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Chuyển đổi lưu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Phím tắt" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "CÁCH DÙNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Xem tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Thêm số xu hướng cạnh mũi tên tiền và dân số ở thanh dưới mặc định.\\n" +
                    "Chỉ là hiển thị nhẹ trên thanh công cụ; không đổi tiền hay dân số." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Tần suất xem tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Chọn xu hướng ở thanh dưới hiển thị theo giờ hay theo tháng cho tiền và dân số.\\n" +
                    "Theo tháng dùng thu nhập trừ chi phí; dân số dùng dự báo 24 giờ." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Theo giờ (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Theo tháng (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Kiểu tooltip tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Chọn mức chi tiết khi rê chuột lên tiền.\\n" +
                    "Gọn = mặc định khi cài lần đầu.\\n"+
                    "<Mini> chỉ hiện 2 giá trị Ròng cho /mo và /h.\\n" +
                    "<Gọn> rút ngắn số lớn (15.21M thay vì 15,212,318).\\n" +
                    "<Đầy đủ> hiện số dài và mục Tổng." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Gọn" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Đầy đủ" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Cỡ chữ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong tooltip Xem tiền.\\n" +
                    "Mặc định game = 100%\\n" +
                    "<Mặc định mod = 120%>\\n" +
                    "Rê chuột lên Tiền ở cuối màn hình.\\n"+
                    "Thêm theo yêu cầu của người chơi khó nhìn tooltip nhỏ."

                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Cỡ chữ dân số" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Chỉnh <cỡ chữ> số trong tooltip dân số.\\n" +
                    "Mặc định game = 100%\\n" +
                    "<Mặc định mod = 120%>\\n" +
                    "Rê chuột lên Dân số ở cuối màn hình."   
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Dùng số tiền này với phím tắt Thêm tiền và Trừ tiền.\\n" +
                    "<Mặc định mod = 40,000>\\n" +
                    "Không làm gì nếu bạn chưa dùng phím tắt thêm/trừ tiền trong thành phố.\\n"+
                    "Muốn tự động thêm tiền thì bật Tự động thêm tiền."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Phím tắt <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Thêm tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Phím tắt <Trừ tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Trừ tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], City Watchdog kiểm tra số dư khi thành phố đang tải.\\n" +
                    "- Nếu số dư <dưới ngưỡng>, \\n" +
                    "  mod sẽ thêm số tiền tự động đã chọn.\\n" +
                    "- Nên dùng tiền thủ công bằng phím tắt (<[> hoặc <]>) khi cần" +
                    "  thay vì tự động, nhưng tùy chọn này vẫn có nếu bạn muốn."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Nếu Tự động thêm tiền bật và số dư thấp hơn giá trị này,\\n" +
                    "thêm số tiền tự động đã chọn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Số tiền được thêm mỗi lần tự động kích hoạt.\\n" +
                    "Chọn số đủ cao để kéo thành phố vượt ngưỡng an toàn." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Tiền ban đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Đặt số dư khởi đầu cho thành phố mới <tiền giới hạn> hoặc thành phố tải đầu tiên,\\n" +
                    "sau khi áp dụng sẽ về Mặc định game.\\n" +
                    "Sẽ bị mờ nếu thành phố đã tải.\\n" +
                    "Đặt trước khi bắt đầu/tải thành phố → áp dụng một lần → sau đó dùng <Số tiền phím tắt> hoặc <Tự động thêm tiền>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Bật/tắt biểu tượng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Phím tắt> cho cùng hành động với nút <[BẬT/TẮT HẾT]> trong game.\\n" +
                    "Hiện hoặc ẩn ngay tất cả biểu tượng thông báo trong danh sách." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Hiện/ẩn ngay tất cả biểu tượng" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Mở/đóng bảng thông báo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Phím tắt> để mở hoặc đóng\\n" +
                    "<bảng thông báo> trong thành phố.\\n" +
                    "Giống như bấm biểu tượng góc trên trái để mở bảng đầy đủ."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Mở/đóng bảng thông báo" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Chọn mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Bật trước khi tải/bắt đầu thành phố để mở khóa mốc đã chọn ngay sau khi tải.\\n" +
                    "Không thể bật khi thành phố đã tải, nhưng có thể tắt nếu lỡ để bật.\\n" +
                    "City Watchdog không thể hoàn tác mốc đã lưu vào thành phố; dùng bản lưu cũ nếu cần." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Chọn cấp mốc để mở khóa ở lần tải thành phố tiếp theo.\\n" +
                    "Chỉ chỉnh được ngoài thành phố đã tải và khi [Chọn mốc] bật [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Chuyển đổi tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<HÃY sao lưu thành phố trước>.\\n" +
                    "Chuyển thành phố bắt đầu bằng Tiền vô hạn sang thành phố thường có thử thách ngân sách.\\n" +
                    "Khi bật, nút <[Chuyển đổi lưu Tiền vô hạn]> sẽ mở nếu thành phố tải là kiểu <Tiền vô hạn>.\\n" +
                    "City Watchdog không thể hoàn tác chuyển đổi này.\\n" +
                    "Nếu bạn chơi thành phố thường thì khỏi lo; không cần dùng." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Đổi thành phố Tiền vô hạn về thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu với <Tiền vô hạn>.\\n" +
                    "Khi thành phố đang tải, mod chuyển bản lưu sang ngân sách tiền giới hạn bình thường.\\n" +
                    "Nút sẽ <tắt/bị mờ> trừ khi thành phố đang tải là kiểu <Tiền vô hạn>\\n" +
                    "và <Chuyển đổi tiền vô hạn> đang BẬT [ ✓ ].\\n" +
                    "Hãy sao lưu và tự chịu rủi ro; City Watchdog không thể hoàn tác." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Đổi thành phố này từ Tiền vô hạn sang tiền giới hạn thường?\\n" +
                    "Sao lưu TRƯỚC; City Watchdog không thể hoàn tác.\\n" +
                    "Bạn chắc chứ?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Tên hiển thị của mod này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Phiên bản hiện tại của mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Mở trang Paradox Mods của tác giả." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Hiện hướng dẫn" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Hiện hoặc ẩn hướng dẫn bên dưới." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Bảng thông báo>\\n" +
                    "1. Bấm nút City Watchdog (góc trên trái) hoặc Shift+N để mở bảng.\\n" +
                    "2. Sắp xếp tăng/giảm.\\n" +
                    "3. BẬT/TẮT HẾT để đổi nhanh, hoặc mở từng mục để chỉnh riêng.\\n" +
                    "4. Chỉ hiện/ẩn biểu tượng; không sửa vấn đề thật của thành phố.\\n\\n" +
                    "<Hỗ trợ tiền>\\n" +
                    "1. Thêm/Trừ tiền: dùng <Số tiền phím tắt> mặc định [ hoặc ].\\n" +
                    "2. Tự động thêm tiền theo dõi ngân sách và thêm tiền khi dưới ngưỡng.\\n" +
                    "3. Xem tiền thêm số vào thanh tiền/dân số và tooltip khi rê chuột.\\n" +
                    "4. Chuyển đổi lưu Tiền vô hạn chỉ dành cho thành phố Tiền vô hạn và <không hoàn tác>.\\n\\n" +
                    "<Mốc tùy chọn>\\n" +
                    "Đặt Tiền ban đầu và chọn Mốc trong Tùy chọn trước khi tải/bắt đầu thành phố."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Mở bảng biểu tượng thông báo." },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Mở hàng; có dấu là hiện, bỏ dấu là ẩn.\\n" +
                    "Phím mặc định: Shift+N bảng, N tất cả, [ thêm tiền, ] trừ tiền.\\n" +
                    "Không sửa vấn đề, chỉ dọn bớt biểu tượng." },


                { m_Settings.GetUILocaleID("ToggleAll"), "BẬT/TẮT HẾT" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Mở tất cả" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Thu tất cả" },

                { m_Settings.GetUILocaleID("SortAscending"), "↑Sắp xếp tăng" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓Sắp xếp giảm" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Hiện/ẩn mọi biểu tượng.\\n" +
                    "Màu: xanh lá = bật hết; xanh dương = lẫn; đỏ = tắt hết." },

                // Tooltip labels.
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Thu:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Chi:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Ròng:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Tổng:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Xu hướng:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Sinh:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Tử:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "Vô gia cư:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Chuyển vào:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Chuyển đi:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ĐIỆN" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Không đủ điện" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Nghẽn điện" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Dòng điện yếu" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Nhà máy điện quá tải" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Máy biến áp quá tải" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Chưa đủ đường ra được nối" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Pin cạn" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cáp điện chưa nối" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Đường điện chưa nối" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "ỐNG NƯỚC" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Không đủ nước" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Máy bơm nước ô nhiễm" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Cống bị nghẽn" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Ống nước chưa nối" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Ống thải chưa nối" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Cơ sở nước quá tải" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Xử lý nước thải quá tải" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Nước ngầm quá thấp" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Mực nước quá thấp" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Máy bơm nước ô nhiễm" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "CÔNG TRÌNH" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Sụp đổ" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Bị bỏ hoang" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Bị kết án tháo dỡ" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Đã tắt" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Tiền thuê cao" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "GIAO THÔNG" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Kẹt xe" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Đường cụt" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Cần đường" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Đường ray chưa nối" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Không có lối xe" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Không có kết nối đường thủy" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Không có kết nối đường ray" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Không có lối đi bộ" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "Không có lối xe đạp" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "CÔNG TY" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Chi phí tài nguyên cao" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Không đủ khách" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "NƠI LÀM VIỆC" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Thiếu lao động" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Thiếu lao động tay nghề cao" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "THẢM HỌA" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Thiệt hại thời tiết" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Bị thời tiết phá hủy" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Thiệt hại do nước" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Bị lũ phá hủy" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Công trình này đã bị phá hủy" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "CHÁY" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Đang cháy" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Cháy rụi" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "RÁC" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Rác tồn đọng" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Cơ sở đầy" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "Y TẾ" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Chờ xe cứu thương" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Chờ xe tang" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Cơ sở đầy" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "CẢNH SÁT" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Tai nạn giao thông" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Hiện trường tội phạm" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "Ô NHIỄM" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Ô nhiễm không khí" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Ô nhiễm tiếng ồn" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Ô nhiễm đất" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "TIÊU THỤ TÀI NGUYÊN" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Thiếu tài nguyên" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "KẾT NỐI TÀI NGUYÊN" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "Đường tài nguyên chưa kết nối" },
                { m_Settings.GetUILocaleID("Route"), "TUYẾN" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Không tìm được đường" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "TUYẾN VẬN TẢI" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Không có xe" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
