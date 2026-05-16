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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Allgemein" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Tastenkürzel" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Errungenschaften" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Geld" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Meilenstein" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Spielstand umwandeln" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "NUTZUNG" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Errungenschaften aktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Lässt Errungenschaften aktiviert [ ✓ ], wenn dieser Mod geladen ist.\\n" +
                    "Wenn AchievementFixer installiert ist, blendet City Watchdog diese Option aus und überlässt die Errungenschaften diesem Mod." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Geldbetrag für Hotkeys" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Diesen Betrag für die Hotkeys Geld hinzufügen und Geld abziehen verwenden.\\n" +
                    "Standard = 20.000.\\n" +
                    "Das ändert den aktuellen Kontostand nicht von selbst." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Wenn aktiviert [ ✓ ], prüft City Watchdog den Stadtkontostand, solange eine Stadt geladen ist.\\n" +
                    "Wenn Kontostand < Schwellenwert, wird der gewählte automatische Betrag hinzugefügt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Automatischer Geld-Schwellenwert" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Wenn Automatisch Geld hinzufügen aktiv ist und der Kontostand unter diesen Wert fällt,\\n" +
                    "fügt City Watchdog den gewählten automatischen Betrag hinzu." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Betrag, der bei jedem Auslösen hinzugefügt wird.\\n" +
                    "Wähle genug, damit die Stadt sicher über dem Schwellenwert liegt." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Legt den Startkontostand für eine neue Stadt mit <begrenztem Geld> oder die zuerst geladene Stadt fest und wird danach auf Spielstandard zurückgesetzt.\\n" +
                    "Ist ausgegraut, wenn bereits eine Stadt geladen ist.\\n" +
                    "Vor dem Starten/Laden setzen → wird einmal angewendet → danach <Geldbetrag für Hotkeys> oder <Automatisch Geld hinzufügen> verwenden." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Meilenstein-Auswahl" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Vor dem Laden oder Starten einer Stadt aktivieren, um den gewählten Meilenstein direkt nach dem Laden freizuschalten.\\n" +
                    "Ist ausgegraut, sobald eine Stadt geladen ist; starte das Spiel neu, um es sicher zu ändern." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Wähle den Meilenstein, der beim nächsten Laden der Stadt freigeschaltet wird.\\n" +
                    "Nur außerhalb einer geladenen Stadt änderbar und nur, wenn [Meilenstein-Auswahl] aktiviert ist [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenzt-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "Schalte dies <erst nach einem Backup> EIN.\\n" +
                    "Dadurch wird die Schaltfläche <[Unbegrenzt-Geld-Spielstand umwandeln]> freigeschaltet, wenn die geladene Stadt mit unbegrenztem Geld gestartet wurde.\\n" +
                    "City Watchdog kann dies nicht rückgängig machen." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Unbegrenzt-Geld-Spielstand zu normal umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit unbegrenztem Geld gestartet wurden.\\n" +
                    "Während diese Stadt geladen ist, wird der Spielstand auf normales begrenztes Budget umgestellt.\\n" +
                    "Die Schaltfläche ist <deaktiviert/ausgegraut>, außer die geladene Stadt nutzt <Unbegrenztes Geld> und <Unbegrenzt-Geld-Konverter> ist ON [ ✓ ]." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von unbegrenztem Geld auf normales begrenztes Geld umwandeln?\\n" +
                    "ZUERST ein Backup speichern; City Watchdog kann das nicht rückgängig machen.\\n" +
                    "Sicher?" },

                // --- Key bindings ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Hotkey zum Hinzufügen von Geld in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Geld hinzufügen" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Hotkey zum Abziehen von Geld in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Geld abziehen" },

#if DEBUG
                // --- Debug key binding ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DebugKeyboardBinding)), "Debug-Aktion" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DebugKeyboardBinding)), "Debug-Tastenkürzel nur für Entwickler. Erscheint nur in Debug-Builds." },
                { m_Settings.GetBindingKeyLocaleID("DebugAction"), "Debug-Aktion" },

#endif

                                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Modname" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Anzeigename dieses Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Aktuelle Modversion." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Öffnet die Paradox-Mods-Seite des Autors." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Anleitung anzeigen" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Blendet die Anleitung unten ein oder aus." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Benachrichtigungspanel>\\n" +
                    "1. Im Spiel oben links auf die City-Watchdog-Schaltfläche klicken, um das Panel zu öffnen.\\n" +
                    "2. ASC/DESC sortiert die Abschnitte.\\n" +
                    "3. Mit Alles umschalten schnell einstellen oder einen Abschnitt öffnen und einzelne Symbole ändern.\\n" +
                    "4. City Watchdog blendet nur Symbole ein/aus; das eigentliche Stadtproblem wird nicht behoben.\\n" +
                    "\\n" +
                    "<Geldhilfen>\\n" +
                    "1. Geld hinzufügen und Geld abziehen verwenden den Geldbetrag für Hotkeys.\\n" +
                    "2. Automatisch Geld hinzufügen überwacht den Stadtkontostand und fügt Geld hinzu, wenn er unter dem Schwellenwert liegt.\\n" +
                    "3. Unbegrenzt-Geld-Spielstand umwandeln ist nur für Städte mit unbegrenztem Geld und ist <durch City Watchdog nicht rückgängig zu machen>.\\n" +
                    "\\n" +
                    "<Eigener Meilenstein>\\n" +
                    "Startgeld und Meilensteine in den Optionen festlegen, bevor eine Stadt geladen oder gestartet wird." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Öffnet das Benachrichtigungssymbol-Panel." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "Abschnitt öffnen; ✓ markieren zum Anzeigen, abwählen zum Ausblenden von Warnsymbolen." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alles umschalten" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Alle öffnen" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Alle schließen" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Sortierung" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "Alle Symbole anzeigen oder ausblenden" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "STROM" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Nicht genug Strom" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Strom-Engpass" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Schlechter Stromfluss" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Kraftwerk überlastet" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformator überlastet" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Nicht genug Ausgangsleitungen verbunden" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batterie leer" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Stromkabel nicht verbunden" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Stromleitung nicht verbunden" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "WASSERROHRE" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Nicht genug Wasser" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Wasserpumpe verschmutzt" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Abwasserstau" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Wasserrohr nicht verbunden" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Abwasserrohr nicht verbunden" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Wasseranlage überlastet" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Abwasseranlage überlastet" },
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
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Keine Gleisverbindung" },
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
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Durch Flut zerstört" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Dieses Gebäude wurde zerstört" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "FEUER" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Brennt" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Abgebrannt" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "MÜLL" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Müll stapelt sich" },
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
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Keine Vorräte für Notunterkünfte" },
                { m_Settings.GetUILocaleID("Route"), "ROUTE" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Wegfindung fehlgeschlagen" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "TRANSPORTLINIE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Keine Fahrzeuge" },
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
