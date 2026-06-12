// File: src/Localization/LocaleIT.cs
// Purpose: Italian (it-IT) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleIT(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Azioni" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Tasti rapidi" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Info" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Money View" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Denaro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifiche" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Traguardo" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversione salvataggio" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Tasti rapidi" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Aggiunge valori numerici di tendenza accanto alle frecce vanilla di denaro e popolazione nella barra inferiore.\n" +
                    "È solo una visualizzazione leggera nella barra strumenti; non cambia denaro o popolazione della città." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequenza Money View" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Scegli se il testo della tendenza nella barra inferiore mostra valori orari o mensili per denaro e popolazione.\n" +
                    "Il mensile usa entrate di bilancio meno spese per il denaro, e una proiezione di 24 ore per la popolazione." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Orario (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensile (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Stile tooltip denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Scegli quanti dettagli appaiono nel tooltip del denaro al passaggio del mouse.\n" +
                    "Compatto = predefinito alla prima installazione.\n" +
                    "<Mini> mostra solo 2 valori netti per /mo e /h.\n" +
                    "<Compatto> abbrevia i valori grandi (15.21M invece di 15,212,318).\n" +
                    "<Dati completi> mostra valori lunghi e campi Totale." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compatto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dati completi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Dimensione testo denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri nel tooltip Money View.\n" +
                    "Predefinito del gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Denaro in basso nello schermo.\n" +
                    "Richiesto da giocatori che fanno fatica a leggere i tooltip piccoli del gioco."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Dimensione testo popolazione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Regola la <dimensione testo> dei numeri nel tooltip popolazione.\n" +
                    "Predefinito del gioco = 100%\n" +
                    "<Predefinito mod = 120%>\n" +
                    "Passa il mouse su Popolazione in basso nello schermo."
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importo tasto rapido denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa questo importo con i tasti rapidi Aggiungi denaro e Sottrai denaro.\n" +
                    "<Predefinito mod = 40,000>\n" +
                    "Non fa nulla se non usi il tasto rapido per aggiungere/sottrarre denaro nella città.\n" +
                    "Per denaro automatico, abilita l'opzione Aggiungi denaro automaticamente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Tasto rapido per <Aggiungi denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Aggiungi denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Tasto rapido per <Sottrai denaro> dentro la città." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Sottrai denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Aggiungi denaro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando abilitato [ ✓ ], City Watchdog controlla il saldo della città mentre una città è caricata.\n" +
                    "- Se il saldo è <sotto la soglia>, \n" +
                    "  aggiunge l'importo automatico selezionato.\n" +
                    "- Si consiglia di usare il denaro manuale con il tasto rapido (<[> o <]>) quando serve" +
                    "  invece di questa opzione automatica, ma è disponibile se la vuoi usare."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Soglia denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se Aggiungi denaro automaticamente è abilitato e il saldo della città scende sotto questo valore,\n" +
                    "aggiunge l'importo automatico selezionato." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importo denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importo aggiunto ogni volta che Aggiungi denaro automaticamente si attiva.\n" +
                    "Scegli un valore abbastanza alto da riportare la città sopra la soglia in sicurezza." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Imposta il saldo iniziale per una nuova città con <denaro limitato> o per la prima città caricata,\n" +
                    "poi torna a Predefinito del gioco dopo l'applicazione.\n" +
                    "È disattivato se una città è già caricata.\n" +
                    "Imposta prima di avviare/caricare una città → si applica una volta → poi usa <Importo tasto rapido denaro> o <Aggiungi denaro automaticamente>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito del gioco" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Attiva/disattiva icone notifica" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Tasto rapido> per la stessa azione del pulsante icona <[Toggle All]> nel pannello di gioco.\n" +
                    "Mostra o nasconde subito tutte le icone di notifica della città elencate." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostra/Nascondi subito tutte le icone di notifica" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Apri/Chiudi pannello notifiche" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Tasto rapido> per aprire o chiudere il\n" +
                    "<pannello notifiche> nella città.\n" +
                    "Funziona come cliccare l'icona in alto a sinistra per aprire il pannello completo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Apri/Chiudi pannello notifiche" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selettore traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Abilita prima di caricare o iniziare una città per sbloccare il traguardo scelto subito dopo il caricamento.\n" +
                    "Non può essere attivato mentre una città è caricata, ma può essere disattivato se è rimasto attivo per errore.\n" +
                    "City Watchdog non può annullare modifiche ai traguardi già salvate in una città; usa un salvataggio precedente se necessario." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Traguardo" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Scegli il livello di traguardo da sbloccare al prossimo caricamento della città.\n" +
                    "È modificabile solo fuori da una città caricata, e solo dopo aver abilitato [Selettore traguardo] [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertitore denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA un backup della città>.\n" +
                    "Converte una città iniziata con Denaro illimitato in una città normale con le sfide economiche regolari.\n" +
                    "Abilitare questa opzione sblocca il pulsante <[Converti salvataggio Denaro illimitato]> quando la città caricata è di tipo <Denaro illimitato>.\n" +
                    "City Watchdog non può annullare questa conversione.\n" +
                    "Se hai città normali, non preoccuparti; non serve." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converti città con Denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Denaro illimitato>.\n" +
                    "Mentre quella città è caricata, converte il salvataggio a normale budget con denaro limitato, così la città avrà di nuovo le normali sfide economiche.\n" +
                    "Il pulsante è <disabilitato/grigio> a meno che la città caricata sia di tipo <Denaro illimitato>\n" +
                    "e <Convertitore denaro illimitato> sia ON [ ✓ ].\n" +
                    "Fai un salvataggio di backup e usa a tuo rischio; City Watchdog non può annullare questa conversione." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Denaro illimitato a normale denaro limitato?\n" +
                    "Salva PRIMA un backup; City Watchdog non può annullare questa operazione.\n" +
                    "Confermi?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome visualizzato di questa mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versione attuale della mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Apre la pagina Paradox Mods dell'autore." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostra istruzioni" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra o nasconde le istruzioni qui sotto." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Pannello notifiche>\n" +
                    "1. Clicca il pulsante City Watchdog (in alto a sinistra), o premi Shift+N, per aprire il pannello.\n" +
                    "2. ASC/DESC per ordinare.\n" +
                    "3. Usa Toggle All per una configurazione rapida, oppure espandi una sezione per cambiare singole icone di notifica.\n" +
                    "4. City Watchdog nasconde o mostra solo le icone; non risolve il problema della città.\n\n" +
                    "<Aiuti denaro>\n" +
                    "1. Money View aggiunge valori numerici /h o /mo accanto alle frecce di tendenza di denaro e popolazione nella barra inferiore.\n" +
                    "2. Aggiungi e Sottrai denaro: usa <Importo tasto rapido denaro>.\n" +
                    "3. Aggiungi denaro automaticamente controlla il saldo della città mentre una città è caricata e aggiunge denaro quando è sotto la soglia.\n" +
                    "4. Converti salvataggio Denaro illimitato è solo per città iniziate con Denaro illimitato e <non è reversibile> da City Watchdog.\n\n" +
                    "<Traguardo personalizzato>\n" +
                    "Imposta Denaro iniziale e seleziona Traguardi dal menu Opzioni prima di caricare o iniziare una città." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Apri il pannello delle icone di notifica." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Espandi le righe; [✓] mostra gli avvisi, senza spunta li nasconde.\n" +
                    "Non risolve problemi, pulisce solo le icone." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Attiva/disattiva tutto" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Espandi tutto" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Comprimi tutte le righe" },
                { m_Settings.GetUILocaleID("SortAscending"), "↑Ordina Crescente" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓Ordina Decrescente" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Mostra/nasconde tutte le icone.\n" +
                    "Colore: verde = tutto attivo; blu = misto; rosso = tutto disattivo." },

                // --- Tooltip labels ---
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Entrate:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Spese:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Netto:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Totale:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Tendenza attuale:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Nascite:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Decessi:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "Senza casa:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Trasferiti in città:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Trasferiti fuori:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELETTRICITÀ" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Elettricità insufficiente" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Collo di bottiglia elettrico" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Flusso elettrico scarso" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Centrale sovraccarica" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Trasformatore sovraccarico" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Linee di uscita collegate insufficienti" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batteria scarica" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cavo elettrico non collegato" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Linea elettrica non collegata" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "TUBAZIONI" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Acqua insufficiente" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Pompa dell'acqua inquinata" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Fognature intasate" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Tubo dell'acqua non collegato" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Tubo fognario non collegato" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Impianto idrico sovraccarico" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Impianto fognario sovraccarico" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Livello delle acque sotterranee troppo basso" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Livello dell'acqua troppo basso" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Pompa dell'acqua inquinata" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "EDIFICIO" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Crollato" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abbandonato" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condannato" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Disattivato" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Affitto alto" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRAFFICO" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Ingorgo" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Strada chiusa" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Strada richiesta" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Binario non collegato" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Nessun accesso auto" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Nessun collegamento via acqua" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Nessun collegamento ferroviario" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Nessun accesso pedonale" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "Nessun accesso bici" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "AZIENDA" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Costi risorse alti" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Clienti insufficienti" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "POSTI DI LAVORO" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Mancanza di manodopera" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Mancanza di manodopera qualificata" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DISASTRO" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Danni meteo" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Distrutto dal meteo" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Danni da acqua" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Distrutto da allagamento" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Questo edificio è stato distrutto" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCENDIO" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "In fiamme" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Bruciato" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "RIFIUTI" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Rifiuti accumulati" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Struttura piena" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SANITÀ" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "In attesa di ambulanza" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "In attesa di carro funebre" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Struttura piena" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLIZIA" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Incidente stradale" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Scena del crimine" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "INQUINAMENTO" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Inquinamento dell'aria" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Inquinamento acustico" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Inquinamento del suolo" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "CONSUMATORE RISORSE" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Risorse insufficienti" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "CONNESSIONE RISORSE" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "Linea risorse non collegata" },
                { m_Settings.GetUILocaleID("Route"), "PERCORSO" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Calcolo percorso fallito" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "LINEA DI TRASPORTO" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Nessun veicolo" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
