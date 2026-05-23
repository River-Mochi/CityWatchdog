// File: src/Localization/LocaleDE.cs
// Purpose: German (de-DE) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleDE(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Aktionen" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Hotkeys" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Geldansicht" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Benachrichtigungen" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Meilenstein" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Speicherstand-Konvertierung" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Hotkeys" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Geldansicht" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Fügt numerische Trendwerte neben den Vanilla-Pfeilen für Geld und Bevölkerung in der unteren Leiste hinzu.\n" +
                    "Dies ist nur eine leichte Anzeige in der Werkzeugleiste; sie ändert weder Stadtgeld noch Bevölkerung." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Geldansicht-Häufigkeit" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Wählt, ob der Trendtext in der unteren Leiste stündliche oder monatliche Werte für Geld und Bevölkerung zeigt.\n" +
                    "Monatlich nutzt Budgeteinnahmen minus Ausgaben für Geld und eine 24-Stunden-Projektion für Bevölkerung." },

                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Stündlich (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Monatlich (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Geld-Tooltip-Stil" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Wähle, wie viele Details im Geld-Tooltip beim Überfahren angezeigt werden.\n" +
                    "<Mini> zeigt nur die zwei Netto-Werte für /mo und /h.\n" +
                    "<Compact> kürzt große Werte (15.21M statt 15,212,318).\n" +
                    "<Full size> zeigt lange Werte und Gesamtfelder." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Kompakt" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullSize"), "Volle Größe" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Geld-Tooltip-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Passt die Zahlen im Money-View-Tooltip an.\n" +
                    "Standard = 100%." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Bevölkerungs-Tooltip-Größe" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Passt die zusätzlichen Bevölkerungszahlen im Tooltip an.\n" +
                    "Standard = 100%." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geld-Hotkey-Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Diesen Betrag für die Hotkeys Geld hinzufügen und Geld abziehen verwenden.\n" +
                    "Standard = 40.000.\n" +
                    "Dies bewirkt nichts, solange der Hotkey in der Stadt nicht genutzt wird.\n" +
                    "Für automatisches Geld die Option Automatisch Geld hinzufügen aktivieren." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey zum Hinzufügen von Geld in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey zum Abziehen von Geld in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiviert [ ✓ ], prüft City Watchdog den Stadtkontostand, während eine Stadt geladen ist.\n" +
                    "Wenn der Kontostand unter dem Schwellenwert liegt, wird der gewählte automatische Betrag hinzugefügt.\n" +
                    "Empfohlen ist, bei Bedarf manuell Geld per Hotkey (<[> oder <]>) hinzuzufügen, statt diese automatische Option zu verwenden; sie bleibt aber verfügbar, wenn du sie möchtest." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Schwellenwert für Auto-Geld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn Automatisch Geld hinzufügen aktiviert ist und der Stadtkontostand unter diesen Wert fällt,\n" +
                    "fügt City Watchdog den gewählten automatischen Betrag hinzu." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Betrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag, der jedes Mal hinzugefügt wird, wenn Automatisch Geld hinzufügen auslöst.\n" +
                    "Wähle einen Wert, der die Stadt sicher über den Schwellenwert bringt." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Legt den Startkontostand für eine neue Stadt mit <begrenztem Geld> oder die zuerst geladene Stadt fest und setzt danach auf Spielstandard zurück.\n" +
                    "Ist ausgegraut, wenn bereits eine Stadt geladen ist.\n" +
                    "Vor dem Starten/Laden einer Stadt einstellen → wird einmal angewendet → danach <Geld-Hotkey-Betrag> oder <Automatisch Geld hinzufügen> verwenden." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Benachrichtigungssymbole umschalten" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Hotkey> für dieselbe Aktion wie die Symbolschaltfläche <[Toggle All]> im Spielpanel.\n" +
                    "Zeigt oder versteckt sofort alle aufgeführten Stadt-Benachrichtigungssymbole." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alle Benachrichtigungssymbole sofort anzeigen/verstecken" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Benachrichtigungsfenster öffnen/schließen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Hotkey> zum Öffnen oder Schließen des Benachrichtigungsfensters im Spiel.\n" +
                    "Funktioniert wie ein Klick auf das Symbol oben links, um das vollständige Fenster zu öffnen." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Benachrichtigungsfenster öffnen/schließen" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Vor dem Laden oder Starten einer Stadt aktivieren, um den gewählten Meilenstein direkt nach dem Laden freizuschalten.\n" +
                    "Kann nicht eingeschaltet werden, während eine Stadt geladen ist, kann aber ausgeschaltet werden, falls es versehentlich aktiv blieb.\n" +
                    "City Watchdog kann Meilensteinänderungen, die bereits in einer Stadt gespeichert wurden, nicht rückgängig machen; bei Bedarf einen älteren Spielstand verwenden." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein, der beim nächsten Laden einer Stadt freigeschaltet werden soll.\n" +
                    "Nur außerhalb einer geladenen Stadt einstellbar und erst, nachdem [Meilenstein-Auswahl] aktiviert ist [ ✓ ]." },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenztes-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Zuerst ein Backup der Stadt erstellen>.\n" +
                    "Konvertiert eine Stadt, die mit unbegrenztem Geld gestartet wurde, in eine normale Stadt mit regulären Geldherausforderungen.\n" +
                    "Aktivieren entsperrt die Schaltfläche <[Unbegrenztes-Geld-Spielstand konvertieren]>, wenn die geladene Stadt vom Typ <Unbegrenztes Geld> ist.\n" +
                    "City Watchdog kann diese Konvertierung nicht rückgängig machen.\n" +
                    "Bei normalen Städten ist dies nicht nötig." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenztes-Geld-Stadt in normale Stadt konvertieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenztem Geld> gestartet wurden.\n" +
                    "Während diese Stadt geladen ist, wird der Spielstand auf normales begrenztes Geldbudget konvertiert, damit Geldherausforderungen wieder gelten.\n" +
                    "Die Schaltfläche ist <deaktiviert/ausgegraut>, außer die geladene Stadt ist vom Typ <Unbegrenztes Geld> und <Unbegrenztes-Geld-Konverter> ist ON [ ✓ ].\n" +
                    "Backup erstellen und auf eigenes Risiko verwenden; City Watchdog kann diese Konvertierung nicht rückgängig machen." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von unbegrenztem Geld zu normalem begrenztem Geld konvertieren?\n" +
                    "ZUERST ein Backup speichern; City Watchdog kann dies nicht rückgängig machen.\n" +
                    "Sicher?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Modname" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Modversion." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Zeigt oder versteckt die Anleitung unten." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Benachrichtigungspanel>\n" +
                    "1. Den City-Watchdog-Button (oben links) anklicken, um das Panel zu öffnen.\n" +
                    "2. ASC/DESC sortiert.\n" +
                    "3. Toggle All für schnelles Setup verwenden oder einen Abschnitt öffnen, um einzelne Benachrichtigungssymbole zu ändern.\n" +
                    "4. City Watchdog versteckt oder zeigt nur Symbole; es behebt nicht das eigentliche Stadtproblem.\n\n" +
                    "<Geldhilfen>\n" +
                    "1. Geldansicht fügt /h- oder /mo-Werte neben Geld und Bevölkerung in der unteren Leiste hinzu.\n" +
                    "2. Geld hinzufügen und abziehen: nutzt den <Geld-Hotkey-Betrag>.\n" +
                    "3. Automatisch Geld hinzufügen überwacht den Stadtkontostand während eine Stadt geladen ist und fügt unter dem Schwellenwert Geld hinzu.\n" +
                    "4. Unbegrenztes-Geld-Spielstand konvertieren ist nur für Städte, die mit unbegrenztem Geld gestartet wurden, und City Watchdog kann es <nicht rückgängig machen>.\n\n" +
                    "<Benutzerdefinierter Meilenstein>\n" +
                    "Startgeld und Meilensteine im Optionsmenü einstellen, bevor eine Stadt geladen oder gestartet wird." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Benachrichtigungssymbol-Panel öffnen." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Eine Zeile öffnen; [✓] aktiviert zeigt Warnungen, deaktiviert versteckt sie.\n" +
                    "Dies behebt keine Stadtprobleme, sondern versteckt Symbol-Clutter." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alle umschalten" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Alle ausklappen" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Alle Zeilen einklappen" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Sortierreihenfolge" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Alle Symbole anzeigen/verstecken.\n" +
                    "Farbe: grün = alles an; blau = gemischt; rot = alles aus." },
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Einnahmen:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Ausgaben:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Netto:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Gesamt:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipCurrentTrend"), "Aktuelles Netto:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Aktueller Trend:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Geburten:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Todesfälle:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Zuzüge:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Wegzüge:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "STROM" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Nicht genug Strom" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Stromengpass" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Schlechter Stromfluss" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Kraftwerk überlastet" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformator überlastet" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Nicht genug Ausgangsleitungen verbunden" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batterie leer" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Stromkabel nicht verbunden" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Stromleitung nicht verbunden" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "WASSERROHR" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Nicht genug Wasser" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Wasserpumpe verschmutzt" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Abwasser staut sich" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Wasserrohr nicht verbunden" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Abwasserrohr nicht verbunden" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Wassereinrichtung überlastet" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Abwassereinrichtung überlastet" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Grundwasserstand zu niedrig" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Wasserstand zu niedrig" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Wasserpumpe verschmutzt" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "GEBÄUDE" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Eingestürzt" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Verlassen" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Verurteilt" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Deaktiviert" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Hohe Miete" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "VERKEHR" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Stau" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Sackgasse" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Straße erforderlich" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Gleis nicht verbunden" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Kein Autozugang" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Keine Wasserwegverbindung" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Keine Bahnverbindung" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Kein Fußgängerzugang" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "UNTERNEHMEN" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Hohe Ressourcenkosten" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Nicht genug Kunden" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "ARBEITSPLÄTZE" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Arbeitskräftemangel" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Mangel an Fachkräften" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "KATASTROPHE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Wetterschaden" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Durch Wetter zerstört" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Wasserschaden" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Durch Überschwemmung zerstört" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Dieses Gebäude wurde zerstört" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "FEUER" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Brennt" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Abgebrannt" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "MÜLL" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Müll häuft sich" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Einrichtung voll" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "GESUNDHEIT" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Wartet auf Krankenwagen" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Wartet auf Leichenwagen" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Einrichtung voll" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLIZEI" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Verkehrsunfall" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Tatort" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "VERSCHMUTZUNG" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Luftverschmutzung" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Lärmbelastung" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Bodenverschmutzung" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "RESSOURCENVERBRAUCHER" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Keine Notunterkunft-Vorräte" },
                { m_Settings.GetUILocaleID("Route"), "ROUTE" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Wegfindung fehlgeschlagen" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "VERKEHRSLINIE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Keine Fahrzeuge" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
