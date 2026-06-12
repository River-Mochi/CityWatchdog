// File: src/Localization/LocaleTH.cs
// Purpose: Thai (th-TH) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleTH : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleTH(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "การทำงาน" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "ปุ่มลัด" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "เกี่ยวกับ" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "ดีบัก" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "มุมมองเงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "เงิน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "แจ้งเตือน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "ไมล์สโตน" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "แปลงเซฟ" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "ปุ่มลัด" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "วิธีใช้" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "มุมมองเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "เพิ่มตัวเลขแนวโน้มข้างลูกศรเงินและประชากรบนแถบล่างของเกม\\n" +
                    "เป็นแค่ข้อมูลบนแถบเครื่องมือ ไม่เปลี่ยนเงินหรือประชากรเมือง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "ความถี่มุมมองเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "เลือกให้แนวโน้มแถบล่างแสดงเงิน/ประชากรแบบรายชั่วโมงหรือรายเดือน\\n" +
                    "รายเดือนใช้รายรับลบรายจ่าย และคาดการณ์ประชากร 24 ชม." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "รายชั่วโมง (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "รายเดือน (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "รูปแบบทูลทิปเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "เลือกระดับรายละเอียดในทูลทิปเงินเมื่อชี้เมาส์\\n" +
                    "กระชับ = ค่าเริ่มต้นตอนติดตั้งครั้งแรก\\n"+
                    "<Mini> แสดงเฉพาะค่า Net 2 ค่า สำหรับ /mo และ /h\\n" +
                    "<กระชับ> ย่อเลขใหญ่ (15.21M แทน 15,212,318)\\n" +
                    "<ข้อมูลเต็ม> แสดงเลขเต็มและช่องรวม" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "กระชับ" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "ข้อมูลเต็ม" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "ขนาดตัวเลขเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิปเงิน\\n" +
                    "ค่าเกม = 100%\\n" +
                    "<ค่า mod = 120%>\\n" +
                    "ชี้เมาส์ที่เงินด้านล่างจอ\\n"+
                    "เพิ่มตามคำขอของผู้เล่นที่อ่านทูลทิปเล็กยาก"

                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "ขนาดตัวเลขประชากร" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "ปรับ <ขนาดตัวอักษร> ของตัวเลขในทูลทิปประชากร\\n" +
                    "ค่าเกม = 100%\\n" +
                    "<ค่า mod = 120%>\\n" +
                    "ชี้เมาส์ที่ประชากรด้านล่างจอ"   
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "จำนวนเงินของปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "ใช้จำนวนนี้กับปุ่มลัดเพิ่มเงินและลดเงิน\\n" +
                    "<ค่า mod = 40,000>\\n" +
                    "จะไม่ทำอะไรจนกว่าจะกดปุ่มลัดเพิ่ม/ลดเงินในเมือง\\n"+
                    "ถ้าต้องการอัตโนมัติ ให้เปิดเพิ่มเงินอัตโนมัติ"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "ปุ่มลัด <เพิ่มเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "เพิ่มเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "ลดเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "ปุ่มลัด <ลดเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "ลดเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "เพิ่มเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ] City Watchdog จะตรวจเงินเมืองตอนโหลดเมืองอยู่\\n" +
                    "- ถ้าเงิน <ต่ำกว่าเกณฑ์> \\n" +
                    "  จะเพิ่มจำนวนอัตโนมัติที่เลือกไว้\\n" +
                    "- แนะนำให้ใช้เงินแบบกดเองด้วยปุ่มลัด (<[> หรือ <]>) ตามต้องการ" +
                    "  แทนอัตโนมัติ แต่มีตัวเลือกนี้ไว้ให้ถ้าต้องการ"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "เกณฑ์เงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิดเพิ่มเงินอัตโนมัติและเงินเมืองต่ำกว่าค่านี้\\n" +
                    "จะเพิ่มจำนวนอัตโนมัติที่เลือก" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "จำนวนเงินที่เพิ่มทุกครั้งเมื่ออัตโนมัติทำงาน\\n" +
                    "เลือกค่าสูงพอให้เงินเมืองกลับเหนือเกณฑ์" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "ตั้งเงินเริ่มต้นสำหรับเมืองใหม่แบบ <เงินจำกัด> หรือเมืองแรกที่โหลด\\n" +
                    "แล้วกลับเป็นค่าเกมหลังใช้แล้ว\\n" +
                    "จะเป็นสีเทาถ้าโหลดเมืองอยู่แล้ว\\n" +
                    "ตั้งก่อนเริ่ม/โหลดเมือง → ใช้ครั้งเดียว → หลังจากนั้นใช้ <จำนวนเงินของปุ่มลัด> หรือ <เพิ่มเงินอัตโนมัติ>" },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นเกม" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "เปิด/ปิดไอคอนแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับปุ่ม <[สลับทั้งหมด]> ในเกม\\n" +
                    "แสดงหรือซ่อนไอคอนแจ้งเตือนทั้งหมดในรายการทันที" },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "แสดง/ซ่อนไอคอนทั้งหมดทันที" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "เปิด/ปิดแผงแจ้งเตือน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<ปุ่มลัด> สำหรับเปิดหรือปิด\\n" +
                    "<แผงแจ้งเตือน> ในเมือง\\n" +
                    "เหมือนคลิกไอคอนซ้ายบนเพื่อเปิดแผงเต็ม"
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "เปิด/ปิดแผงแจ้งเตือน" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "เลือกไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "เปิดก่อนโหลดหรือเริ่มเมือง เพื่อปลดล็อกไมล์สโตนที่เลือกทันทีหลังโหลด\\n" +
                    "เปิดไม่ได้ขณะโหลดเมืองอยู่ แต่ปิดได้ถ้าเผลอเปิดไว้\\n" +
                    "City Watchdog ย้อนการเปลี่ยนไมล์สโตนที่เซฟแล้วไม่ได้ ใช้เซฟเก่าถ้าจำเป็น" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "ไมล์สโตน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "เลือกระดับไมล์สโตนที่จะปลดล็อกตอนโหลดเมืองครั้งถัดไป\\n" +
                    "ปรับได้เฉพาะตอนยังไม่ได้โหลดเมือง และเมื่อ [เลือกไมล์สโตน] เปิด [ ✓ ]" },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "แปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเมืองก่อน>.\\n" +
                    "แปลงเมืองที่เริ่มด้วยเงินไม่จำกัดให้เป็นเมืองปกติที่มีงบประมาณ\\n" +
                    "เมื่อเปิด จะปลดล็อกปุ่ม <[แปลงเซฟเงินไม่จำกัด]> ถ้าเมืองที่โหลดเป็นแบบ <เงินไม่จำกัด>\\n" +
                    "City Watchdog ย้อนการแปลงนี้ไม่ได้\\n" +
                    "ถ้าเมืองของคุณเป็นปกติ ไม่ต้องใช้ตัวนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\\n" +
                    "เมื่อเมืองนั้นโหลดอยู่ จะเปลี่ยนเซฟเป็นงบประมาณแบบเงินจำกัดปกติ\\n" +
                    "ปุ่มจะ <ปิด/สีเทา> เว้นแต่เมืองที่โหลดเป็นแบบ <เงินไม่จำกัด>\\n" +
                    "และ <แปลงเงินไม่จำกัด> เปิด [ ✓ ]\\n" +
                    "สำรองเซฟก่อนและใช้โดยยอมรับความเสี่ยง City Watchdog ย้อนให้ไม่ได้" },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติไหม?\\n" +
                    "สำรองก่อน City Watchdog ย้อนให้ไม่ได้\\n" +
                    "แน่ใจไหม?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "ชื่อ mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "ชื่อที่แสดงของ mod นี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "เวอร์ชันปัจจุบันของ mod" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "เปิดหน้า Paradox Mods ของผู้สร้าง" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "แสดงคำแนะนำ" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "แสดงหรือซ่อนคำแนะนำด้านล่าง" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<แผงแจ้งเตือน>\\n" +
                    "1. คลิกปุ่ม City Watchdog (ซ้ายบน) หรือกด Shift+N เพื่อเปิดแผง\\n" +
                    "2. เรียงขึ้น/ลง\\n" +
                    "3. สลับทั้งหมดเพื่อเปิด/ปิดเร็ว หรือขยายหมวดเพื่อเลือกเฉพาะรายการ\\n" +
                    "4. แสดง/ซ่อนไอคอนเท่านั้น ไม่ได้แก้ปัญหาในเมือง\\n\\n" +
                    "<ตัวช่วยเงิน>\\n" +
                    "1. เพิ่ม/ลดเงิน: ใช้ <จำนวนเงินของปุ่มลัด> ค่าเริ่มต้น [ หรือ ]\\n" +
                    "2. เพิ่มเงินอัตโนมัติจะดูงบขณะโหลดเมือง และเพิ่มเมื่อเงินต่ำกว่าเกณฑ์\\n" +
                    "3. มุมมองเงินเพิ่มตัวเลขให้แถบเงิน/ประชากรและทูลทิปเมื่อชี้เมาส์\\n" +
                    "4. แปลงเซฟเงินไม่จำกัดใช้ได้เฉพาะเมืองที่เริ่มด้วยเงินไม่จำกัด และ <ย้อนกลับไม่ได้>\\n\\n" +
                    "<ไมล์สโตนกำหนดเอง>\\n" +
                    "ตั้งเงินเริ่มต้นและเลือกไมล์สโตนจากเมนูตัวเลือกก่อนโหลดหรือเริ่มเมือง"
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "เปิดแผงไอคอนแจ้งเตือน" },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "ขยายแถว; ติ๊กเพื่อแสดง ไม่ติ๊กเพื่อซ่อน\\n" +
                    "ปุ่มลัด: Shift+N แผง, N ทั้งหมด, [ เพิ่มเงิน, ] ลดเงิน\\n" +
                    "ไม่แก้ปัญหา แค่ซ่อนไอคอนรก ๆ" },


                { m_Settings.GetUILocaleID("ToggleAll"), "สลับทั้งหมด" },
                { m_Settings.GetUILocaleID("ExpandAll"), "ขยายทั้งหมด" },
                { m_Settings.GetUILocaleID("CollapseAll"), "ย่อทั้งหมด" },

                { m_Settings.GetUILocaleID("SortAscending"), "↑เรียงขึ้น" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓เรียงลง" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "แสดง/ซ่อนไอคอนทั้งหมด\\n" +
                    "สี: เขียว=เปิดหมด น้ำเงิน=ผสม แดง=ปิดหมด" },

                // Tooltip labels.
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "รายรับ:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "รายจ่าย:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "สุทธิ:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "รวม:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "แนวโน้ม:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "เกิด:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "ตาย:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "ไร้บ้าน:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "ย้ายเข้า:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "ย้ายออก:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ไฟฟ้า" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "ไฟฟ้าไม่พอ" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "ไฟฟ้าคอขวด" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "ไฟฟ้าไหลไม่ดี" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "โรงไฟฟ้าเกินกำลัง" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "หม้อแปลงเกินกำลัง" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "ต่อสายออกไม่พอ" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "แบตหมด" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "สายไฟยังไม่ต่อ" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "สายส่งไฟยังไม่ต่อ" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "ท่อน้ำ" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "น้ำไม่พอ" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "ปั๊มน้ำปนเปื้อน" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "ท่อเสียอุดตัน" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "ท่อน้ำยังไม่ต่อ" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "ท่อระบายน้ำยังไม่ต่อ" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "ระบบน้ำเกินกำลัง" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "ระบบบำบัดเกินกำลัง" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "น้ำใต้ดินต่ำเกินไป" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "ระดับน้ำต่ำเกินไป" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "ปั๊มน้ำปนเปื้อน" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "อาคาร" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "พังถล่ม" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "ถูกทิ้งร้าง" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "ถูกสั่งรื้อ" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "ปิดใช้งาน" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "ค่าเช่าสูง" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "จราจร" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "รถติด" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "ทางตัน" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "ต้องมีถนน" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "รางยังไม่ต่อ" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "รถเข้าไม่ได้" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "ไม่มีทางน้ำเชื่อม" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "ไม่มีรางเชื่อม" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "คนเดินเข้าไม่ได้" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "จักรยานเข้าไม่ได้" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "บริษัท" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "ต้นทุนทรัพยากรสูง" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "ลูกค้าไม่พอ" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "แหล่งงาน" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "ขาดแรงงาน" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "ขาดแรงงานฝีมือ" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "ภัยพิบัติ" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "เสียหายจากอากาศ" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "ถูกอากาศทำลาย" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "เสียหายจากน้ำ" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "ถูกน้ำท่วมทำลาย" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "อาคารนี้ถูกทำลายแล้ว" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "ไฟไหม้" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "กำลังไหม้" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "ไหม้หมดแล้ว" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "ขยะ" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "ขยะกองพะเนิน" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "สถานที่เต็ม" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "สาธารณสุข" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "รอรถพยาบาล" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "รอรถศพ" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "สถานที่เต็ม" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "ตำรวจ" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "อุบัติเหตุจราจร" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "ที่เกิดเหตุ" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "มลพิษ" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "มลพิษอากาศ" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "มลพิษเสียง" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "มลพิษดิน" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "ใช้ทรัพยากร" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "ทรัพยากรไม่พอ" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "การเชื่อมต่อทรัพยากร" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "สายทรัพยากรไม่ได้เชื่อมต่อ" },
                { m_Settings.GetUILocaleID("Route"), "เส้นทาง" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "หาเส้นทางไม่ได้" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "สายขนส่ง" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "ไม่มียานพาหนะ" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
