// File: src/Localization/LocaleKO.cs
// Purpose: Korean (ko-KR) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleKO(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "작업" },
                { m_Settings.GetOptionTabLocaleID(Setting.AchievementsTab), "도전 과제" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "단축키" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "정보" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "디버그" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Trends), "Trend Tracker" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "돈" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "알림" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "마일스톤" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "저장 변환" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "도전 과제" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementTools), "고급 도구" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementDanger), "도전 과제 초기화" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "단축키" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "사용법" },

                // --- Trend Tracker ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Trend Tracker" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "하단 툴바의 바닐라 돈/인구 화살표 옆에 숫자 추세 값을 추가합니다.\n" +
                    "가벼운 툴바 표시 기능일 뿐이며 도시 자금이나 인구를 변경하지 않습니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "추세 표시 주기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "하단 툴바의 추세 텍스트를 돈과 인구에 대해 시간당 또는 월간 값으로 표시할지 선택합니다.\n" +
                    "월간 돈은 예산 수입에서 지출을 뺀 값이며, 인구는 24시간 예측을 사용합니다." },

                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "시간당 (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "월간 (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CompactMoneyTooltip)), "간단 돈 툴팁" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CompactMoneyTooltip)),
                    "21.24M/mo 같은 짧은 돈 값을 사용하고 총액 행을 숨깁니다.\n" +
                    "더 큰 상세 돈 툴팁을 사용하려면 OFF로 끄세요." },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "돈 추가와 돈 차감 단축키에 사용할 금액입니다.\n" +
                    "기본값 = 40,000.\n" +
                    "도시 안에서 단축키로 돈을 추가/차감하지 않는 한 아무 작업도 하지 않습니다.\n" +
                    "자동 돈 기능은 자동 돈 추가 옵션을 켜세요." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "도시 안에서 돈을 추가하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "돈 추가" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "돈 차감" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "도시 안에서 돈을 차감하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "돈 차감" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "자동 돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "켜져 있으면 [ ✓ ], City Watchdog이 도시가 로드된 동안 도시 잔액을 확인합니다.\n" +
                    "잔액이 기준값보다 낮으면 선택한 자동 금액을 추가합니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "자동 돈 기준값" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "자동 돈 추가가 켜져 있고 도시 잔액이 이 값보다 낮아지면,\n" +
                    "City Watchdog이 선택한 자동 금액을 추가합니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "자동 추가 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "자동 돈 추가가 실행될 때마다 추가되는 금액입니다.\n" +
                    "도시 잔액이 기준값보다 충분히 높아지도록 값을 선택하세요." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "초기 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "새 <제한된 돈> 도시 또는 처음 로드되는 도시의 시작 잔액을 설정한 뒤, 적용 후 게임 기본값으로 되돌립니다.\n" +
                    "도시가 이미 로드되어 있으면 회색으로 비활성화됩니다.\n" +
                    "도시 시작/로드 전에 설정 → 한 번 적용 → 이후에는 <돈 단축키 금액> 또는 <자동 돈 추가>를 사용하세요." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "알림 아이콘 전환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "게임 내 <[Toggle All]> 아이콘 버튼과 같은 기능의 <단축키>입니다.\n" +
                    "목록에 있는 모든 도시 알림 아이콘을 즉시 표시하거나 숨깁니다." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "모든 알림 아이콘 즉시 표시/숨기기" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "마일스톤 선택기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "도시를 로드하거나 시작하기 전에 켜면, 도시 로드 직후 선택한 마일스톤을 잠금 해제합니다.\n" +
                    "도시가 로드된 상태에서는 ON으로 켤 수 없지만, 실수로 켜 둔 경우 OFF로 끌 수는 있습니다.\n" +
                    "이미 도시에 저장된 마일스톤 변경은 City Watchdog이 되돌릴 수 없습니다. 필요하면 이전 저장을 사용하세요." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "다음 도시 로드 때 잠금 해제할 마일스톤 레벨을 선택합니다.\n" +
                    "도시가 로드되지 않았고 [마일스톤 선택기]가 켜져 있을 때만 [ ✓ ] 조정할 수 있습니다." },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<먼저 도시 백업을 만드세요>.\n" +
                    "무제한 돈으로 시작한 도시를 일반 돈 제한 도시로 변환합니다.\n" +
                    "로드된 도시가 <무제한 돈> 유형일 때, 이 옵션을 켜면 <[무제한 돈 저장 변환]> 버튼이 잠금 해제됩니다.\n" +
                    "City Watchdog은 이 변환을 되돌릴 수 없습니다.\n" +
                    "일반 도시는 걱정하지 않아도 됩니다. 이 기능이 필요하지 않습니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "무제한 돈 도시를 일반 도시로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "<무제한 돈>으로 시작한 도시용입니다.\n" +
                    "해당 도시가 로드된 동안 저장을 일반 제한 돈 예산으로 변환하여 다시 일반 돈 도전이 생기게 합니다.\n" +
                    "로드된 도시가 <무제한 돈> 유형이고 <무제한 돈 변환기>가 ON [ ✓ ] 상태가 아니면 버튼은 <비활성화/회색>입니다.\n" +
                    "백업 저장을 만들고, 본인 책임하에 사용하세요. City Watchdog은 이 변환을 되돌릴 수 없습니다." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "이 도시를 무제한 돈에서 일반 제한 돈으로 변환할까요?\n" +
                    "먼저 백업을 저장하세요. City Watchdog은 이 작업을 되돌릴 수 없습니다.\n" +
                    "확실한가요?" },


                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "도전 과제 켜기" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "모드를 사용하는 동안 도전 과제를 허용하려면 **ON [ ✓ ]** 상태로 두세요.\n" +
                    "게임은 과거에 이미 한 작업을 나중에 계산하지 않습니다.\n" +
                    "그냥 켜 둔 상태로 조건을 자연스럽게 완료하세요." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementNotes)),
                    "• 아래 고급 버튼을 사용하지 않아도 <기본으로 켜져 있음>.\n" +
                    "• 그냥 켜 둔 상태로 자연스럽게 도전 과제를 완료하세요 :)\n" +
                    "" },

                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementNotes)), "" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "고급 도구 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "**선택 사항:** 도전 과제 테스트, 초기화, 활성화용입니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SelectedAchievement)), "선택한 도전 과제" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SelectedAchievement)),
                    "변경할 도전 과제를 하나 선택합니다.\n" +
                    "<일반적인 도전 과제 진행에는 필요하지 않습니다.>\n" +
                    "도전 과제를 초기화/삭제하거나 조건을 하지 않고 잠금 해제할 때만 사용하세요." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UnlockSelectedAchievement)), "선택 항목 잠금 해제" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UnlockSelectedAchievement)), "선택한 도전 과제를 **잠금 해제하고 완료**합니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ClearSelectedAchievement)), "선택 항목 초기화" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ClearSelectedAchievement)), "선택한 도전 과제를 **미완료**로 표시합니다." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ClearSelectedAchievement)),
                    "이 도전 과제를 삭제/초기화합니다.\n\n" +
                    "계속할까요?" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementToolsAdvisory)),
                    "<고급 도구는 선택 사항입니다>\n" +
                    "• 테스트, 복구, 모든 도전 과제 초기화에 사용합니다.\n" +
                    "• 버튼에 마우스를 올리면 오른쪽 패널에 자세한 설명이 표시됩니다." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementToolsAdvisory)), "테스트" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ResetAllAchievements)), "모두 초기화" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ResetAllAchievements)),
                    "완료한 모든 도전 과제를 지우고 처음부터 다시 시작할 수 있게 합니다.\n" +
                    "**[모두 초기화]** 사용 시 **주의**하세요.\n" +
                    "실수로 사용했다면 [선택 항목 잠금 해제] 버튼으로 완료한 도전 과제를 복구할 수 있습니다." },

                // Confirmation modal Yes/No
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ResetAllAchievements)),
                    "경고: 모든 도전 과제를 미완료 상태로 초기화/삭제합니다.\n" +
                    "계속할까요?" },


                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "이 모드의 표시 이름입니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "현재 모드 버전입니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "작성자의 Paradox Mods 페이지를 엽니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "사용법 표시" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "아래 사용법 설명을 표시하거나 숨깁니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<알림 패널>\n" +
                    "1. City Watchdog 버튼(왼쪽 위)을 눌러 패널을 엽니다.\n" +
                    "2. ASC/DESC로 정렬합니다.\n" +
                    "3. Toggle All로 빠르게 설정하거나, 섹션을 펼쳐 개별 알림 아이콘을 변경합니다.\n" +
                    "4. City Watchdog은 아이콘만 숨기거나 표시합니다. 도시 문제 자체를 해결하지는 않습니다.\n\n" +
                    "<돈 도우미>\n" +
                    "1. Trend Tracker는 하단 툴바 돈/인구 추세 화살표 옆에 /h 또는 /mo 값을 추가합니다.\n" +
                    "2. 돈 추가와 돈 차감: <돈 단축키 금액>을 사용합니다.\n" +
                    "3. 자동 돈 추가는 도시가 로드된 동안 잔액을 확인하고 기준값보다 낮으면 돈을 추가합니다.\n" +
                    "4. 무제한 돈 저장 변환은 무제한 돈으로 시작한 도시만 대상으로 하며, City Watchdog은 <되돌릴 수 없습니다>.\n\n" +
                    "<커스텀 마일스톤>\n" +
                    "도시를 로드하거나 시작하기 전에 옵션 메뉴에서 초기 자금과 마일스톤을 설정하세요." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "알림 아이콘 패널을 엽니다." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "아무 행이나 펼치세요. [✓] 체크하면 표시, 체크 해제하면 알림을 숨깁니다.\n" +
                    "도시 문제를 해결하지는 않고, 아이콘 clutter만 줄입니다." },
                { m_Settings.GetUILocaleID("ToggleAll"), "모두 전환" },
                { m_Settings.GetUILocaleID("ExpandAll"), "모두 펼치기" },
                { m_Settings.GetUILocaleID("CollapseAll"), "모든 행 접기" },
                { m_Settings.GetUILocaleID("SortAscending"), "오름차순 ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "내림차순 ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "정렬 순서" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "모든 아이콘을 표시/숨깁니다.\n" +
                    "색상: 초록 = 모두 켜짐, 파랑 = 혼합, 빨강 = 모두 꺼짐." },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "전기" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "전기가 부족함" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "전기 병목" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "전기 흐름 부족" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "발전소 과부하" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "변압기 과부하" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "연결된 출력선 부족" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "배터리 방전" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "전기 케이블 연결 안 됨" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "전력선 연결 안 됨" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "수도관" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "물이 부족함" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "취수 펌프 오염" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "하수 역류" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "수도관 연결 안 됨" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "하수관 연결 안 됨" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "수도 시설 과부하" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "하수 시설 과부하" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "지하수 수위 너무 낮음" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "수위가 너무 낮음" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "취수 펌프 오염" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "건물" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "붕괴됨" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "버려짐" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "철거 대상" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "비활성화됨" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "임대료 높음" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "교통" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "교통 정체" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "막다른 길" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "도로 필요" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "선로 연결 안 됨" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "차량 접근 불가" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "수로 연결 없음" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "철도 연결 없음" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "보행자 접근 불가" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "회사" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "자원 비용이 너무 높음" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "고객 부족" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "일자리" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "노동력 부족" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "고숙련 노동력 부족" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "재난" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "기상 피해" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "기상으로 파괴됨" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "침수 피해" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "홍수로 파괴됨" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "이 건물이 파괴됨" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "화재" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "불이 남" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "전소됨" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "쓰레기" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "쓰레기 쌓임" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "시설 가득 참" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "의료" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "구급차 대기 중" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "영구차 대기 중" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "시설 가득 참" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "경찰" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "교통사고" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "범죄 현장" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "오염" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "대기 오염" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "소음 공해" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "토양 오염" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "자원 소비자" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "긴급 대피소 물자 없음" },
                { m_Settings.GetUILocaleID("Route"), "경로" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "경로 찾기 실패" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "교통 노선" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "차량 없음" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
