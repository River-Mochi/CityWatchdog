// File: src/Localization/LocalePL.cs
// Purpose: Polish (pl-PL) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePL(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Akcje" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Skróty" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "O modzie" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Widok pieniędzy" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Pieniądze" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Powiadomienia" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Kamień milowy" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Konwersja zapisu" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Skróty" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "INSTRUKCJE" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Widok pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Dodaje liczbowe trendy obok waniliowych strzałek pieniędzy i populacji na dolnym pasku.\n" +
                    "To tylko lekki wskaźnik na pasku; nie zmienia pieniędzy miasta ani populacji." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Częstotliwość widoku pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wybierz, czy trend na dolnym pasku pokazuje wartości godzinowe czy miesięczne dla pieniędzy i populacji.\n" +
                    "Miesięcznie używa dochodu budżetu minus wydatki dla pieniędzy oraz prognozy 24-godzinnej dla populacji." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Godzinowo (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Miesięcznie (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Styl dymka pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wybierz, ile szczegółów ma pokazywać dymek po najechaniu na pieniądze.\n" +
                    "Kompaktowy = domyślnie przy pierwszej instalacji.\n" +
                    "<Mini> pokazuje tylko 2 wartości Netto dla /mo i /h.\n" +
                    "<Kompaktowy> skraca duże wartości (15.21M zamiast 15,212,318).\n" +
                    "<Pełne dane> pokazuje długie wartości i pola Razem." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompaktowy" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Pełne dane" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Rozmiar tekstu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb w dymku Widoku pieniędzy.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na Pieniądze na dole ekranu.\n" +
                    "Dodane na prośbę graczy, którym trudniej odczytać małe dymki w grze."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Rozmiar tekstu populacji" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Zmienia <rozmiar tekstu> liczb w dymku populacji.\n" +
                    "Domyślnie w grze = 100%\n" +
                    "<Domyślnie w modzie = 120%>\n" +
                    "Najedź na Populację na dole ekranu."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Użyj tej kwoty ze skrótami Dodaj pieniądze i Odejmij pieniądze.\n" +
                    "<Domyślnie w modzie = 40,000>\n" +
                    "Nic nie robi, dopóki nie użyjesz skrótu do dodania/odjęcia pieniędzy w mieście.\n" +
                    "Dla automatycznych pieniędzy włącz opcję Automatyczne dodawanie pieniędzy."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Skrót do <Dodaj pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Dodaj pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Skrót do <Odejmij pieniądze> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Odejmij pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Gdy włączone [ ✓ ], City Watchdog sprawdza saldo miasta, gdy miasto jest załadowane.\n" +
                    "- Jeśli saldo jest <poniżej progu>, \n" +
                    "  dodaje wybraną automatyczną kwotę.\n" +
                    "- Zalecane jest ręczne używanie pieniędzy skrótem (<[> lub <]>) według potrzeby" +
                    "  zamiast automatyki, ale opcja jest tu, jeśli jej chcesz."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Jeśli Automatyczne dodawanie pieniędzy jest włączone i saldo miasta spadnie poniżej tej wartości,\n" +
                    "dodaje wybraną automatyczną kwotę." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatyczna kwota pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Kwota dodawana za każdym razem, gdy zadziała Automatyczne dodawanie pieniędzy.\n" +
                    "Wybierz wartość na tyle wysoką, żeby bezpiecznie podnieść saldo miasta ponad próg." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Początkowe pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Ustawia saldo startowe dla nowego miasta z <ograniczonymi pieniędzmi> albo pierwszego załadowanego miasta,\n" +
                    "potem resetuje się do domyślnej wartości gry po zastosowaniu.\n" +
                    "Jest wyszarzone, jeśli miasto jest już załadowane.\n" +
                    "Ustaw przed startem/wczytaniem miasta → zastosuje się raz → potem używaj <Kwota skrótu pieniędzy> albo <Automatyczne dodawanie pieniędzy>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Domyślnie w grze" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Przełącz ikony powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Skrót> dla tej samej akcji co przycisk ikony <[Przełącz wszystko]> w panelu gry.\n" +
                    "Natychmiast pokazuje albo ukrywa wszystkie wypisane ikony powiadomień miasta." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Natychmiast pokaż/ukryj wszystkie ikony powiadomień" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Otwórz/zamknij panel powiadomień" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Skrót> do otwierania albo zamykania\n" +
                    "<panelu powiadomień> w mieście.\n" +
                    "Działa tak samo jak kliknięcie ikony w lewym górnym rogu."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Otwórz/zamknij panel powiadomień" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Wybór kamienia milowego" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Włącz przed wczytaniem albo rozpoczęciem miasta, żeby od razu odblokować wybrany kamień milowy po załadowaniu.\n" +
                    "Nie można włączyć tej opcji, gdy miasto jest załadowane, ale można ją wyłączyć, jeśli została zostawiona przez pomyłkę.\n" +
                    "City Watchdog nie cofnie zmian kamieni milowych zapisanych już w mieście; użyj wcześniejszego zapisu, jeśli trzeba." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Kamień milowy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wybierz poziom kamienia milowego do odblokowania przy następnym wczytaniu miasta.\n" +
                    "Można to zmieniać tylko poza załadowanym miastem i tylko po włączeniu [Wybór kamienia milowego] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Konwerter nieograniczonych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób kopię zapisu miasta>.\n" +
                    "Konwertuje miasto rozpoczęte z Nieograniczonymi pieniędzmi na normalne miasto z wyzwaniami budżetowymi.\n" +
                    "Włączenie tego odblokowuje przycisk <[Konwertuj zapis z nieograniczonymi pieniędzmi]>, gdy załadowane miasto jest typu <Nieograniczone pieniądze>.\n" +
                    "City Watchdog nie może cofnąć tej konwersji.\n" +
                    "Jeśli masz normalne miasta, nie martw się tym; nie jest potrzebne." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Konwertuj miasto z nieograniczonymi pieniędzmi na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Dla miast rozpoczętych z <Nieograniczonymi pieniędzmi>.\n" +
                    "Gdy takie miasto jest załadowane, konwertuje zapis na normalny budżet z ograniczonymi pieniędzmi.\n" +
                    "Przycisk jest <wyłączony/wyszarzony>, chyba że załadowane miasto jest typu <Nieograniczone pieniądze>\n" +
                    "i <Konwerter nieograniczonych pieniędzy> jest WŁ. [ ✓ ].\n" +
                    "Zrób kopię zapisu i używaj na własne ryzyko; City Watchdog nie może cofnąć tej konwersji." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Konwertować to miasto z Nieograniczonych pieniędzy na normalne ograniczone pieniądze?\n" +
                    "NAJPIERW zapisz kopię; City Watchdog nie może tego cofnąć.\n" +
                    "Na pewno?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Wyświetlana nazwa tego moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktualna wersja moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Otwiera stronę autora na Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Pokaż instrukcje" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Pokaż albo ukryj instrukcje użycia poniżej." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Panel powiadomień>\n" +
                    "1. Kliknij przycisk City Watchdog w lewym górnym rogu albo naciśnij Shift+N, żeby otworzyć panel.\n" +
                    "2. Sortuj rosnąco/malejąco.\n" +
                    "3. Przełącz wszystko dla szybkiego wyłączenia/włączenia albo rozwiń sekcję, żeby zmienić konkretne ikony.\n" +
                    "4. Pokazuje albo ukrywa tylko ikony; nie naprawia problemu w mieście.\n\n" +
                    "<Pomoc z pieniędzmi>\n" +
                    "1. Dodaj albo odejmij pieniądze: użyj domyślnego <Kwota skrótu pieniędzy> [ albo ].\n" +
                    "2. Automatyczne dodawanie pieniędzy obserwuje budżet, gdy miasto jest załadowane, i dodaje pieniądze poniżej progu.\n" +
                    "3. Widok pieniędzy dodaje liczby do paska pieniędzy i populacji oraz do dymków po najechaniu myszą.\n" +
                    "4. Konwersja zapisu z Nieograniczonymi pieniędzmi jest tylko dla miast rozpoczętych z Nieograniczonymi pieniędzmi i jest <nieodwracalna>.\n\n" +
                    "<Własny kamień milowy>\n" +
                    "Ustaw Początkowe pieniądze i wybierz Kamienie milowe w menu Opcje przed wczytaniem albo rozpoczęciem miasta."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Otwórz panel ikon powiadomień." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Rozwiń wiersze; [✓] zaznacz, aby pokazać, odznacz, aby ukryć alerty.\n" +
                    "To nie naprawia problemów, tylko chowa bałagan z ikon." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Przełącz wszystko" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Rozwiń wszystko" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Zwiń wszystkie wiersze" },

                { m_Settings.GetUILocaleID("SortAscending"), "↑Sortuj rosnąco" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓Sortuj malejąco" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Pokaż/ukryj wszystkie ikony.\n" +
                    "Kolor: zielony = wszystko włączone; niebieski = mieszane; czerwony = wszystko wyłączone." },

                // Tooltip labels.
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Dochód:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Wydatki:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Netto:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Razem:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Obecny trend:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Urodzenia:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Zgony:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "Bezdomni:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Wprowadzili się:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Wyprowadzili się:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "PRĄD" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Za mało prądu" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Wąskie gardło prądu" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Słaby przepływ prądu" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Przeciążona elektrownia" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Przeciążony transformator" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Za mało podłączonych linii wyjściowych" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Bateria rozładowana" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Kabel elektryczny niepodłączony" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Linia energetyczna niepodłączona" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "RURY WODNE" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Za mało wody" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Pompa pobiera brudną wodę" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Ścieki cofają się" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Rura wodna niepodłączona" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Rura ściekowa niepodłączona" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Przeciążony zakład wodny" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Przeciążona kanalizacja" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Za niski poziom wód gruntowych" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Za niski poziom wody" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Pompa pobiera brudną wodę" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "BUDYNKI" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Zawalone" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Opuszczone" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Skazane do rozbiórki" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Wyłączone" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Wysoki czynsz" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "RUCH" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Korek" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Ślepa uliczka" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Wymagana droga" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Tor niepodłączony" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Brak dostępu autem" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Brak połączenia wodnego" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Brak połączenia torowego" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Brak dojścia pieszo" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "Brak dostępu rowerowego" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "FIRMY" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Wysokie koszty zasobów" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Za mało klientów" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "MIEJSCA PRACY" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Brak pracowników" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Brak wykwalifikowanych pracowników" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "KATASTROFY" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Uszkodzenia pogodowe" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Zniszczone przez pogodę" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Uszkodzenia od wody" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Zniszczone przez powódź" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Ten budynek został zniszczony" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "POŻAR" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Płonie" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Spalone" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "ŚMIECI" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Śmieci się piętrzą" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Placówka pełna" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "OPIEKA ZDROWOTNA" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Czeka na karetkę" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Czeka na karawan" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Placówka pełna" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLICJA" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Wypadek drogowy" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Miejsce przestępstwa" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "ZANIECZYSZCZENIE" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Zanieczyszczenie powietrza" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Hałas" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Zanieczyszczenie gruntu" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "ZUŻYCIE ZASOBÓW" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Za mało zasobów" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "POŁĄCZENIE ZASOBÓW" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "Linia zasobów niepodłączona" },
                { m_Settings.GetUILocaleID("Route"), "TRASA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Nie znaleziono trasy" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "LINIA TRANSPORTU" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Brak pojazdów" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
