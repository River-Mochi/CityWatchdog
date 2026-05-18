// File: src/Localization/LocaleES.cs
// Purpose: Spanish (es-ES) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleES : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleES(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Acciones" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Teclas rápidas" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuración" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Logros" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Hito" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Teclas rápidas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Convertir partida" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Activar logros" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Mantiene los logros activados [ ✓ ] cuando este mod está cargado.\n" +
                    "Si AchievementFixer está instalado, City Watchdog oculta esta opción y deja los logros en manos de ese mod." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Rastreador de tendencias" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "Añade valores numéricos junto a las flechas de tendencia de dinero y población de la barra inferior.\n" +
                    "Es solo una lectura visual ligera; no cambia el dinero ni la población." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "Modo de tendencia" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "Elige si el texto de tendencia de la barra inferior muestra valores por hora o mensuales.\n" +
                    "Mensual usa ingresos menos gastos para dinero y una proyección de 24 horas para población." },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "Por mes (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Cantidad del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa esta cantidad con los atajos de Añadir dinero y Restar dinero.\n" +
                    "Predeterminado = 20,000.\n" +
                    "Esto no cambia el saldo actual por sí solo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Añadir dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Cuando está activado [ ✓ ], City Watchdog revisa el saldo de la ciudad mientras hay una ciudad cargada.\n" +
                    "Si el saldo < umbral, añade la cantidad automática elegida." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si Añadir dinero automático está activado y el saldo baja de este valor,\n" +
                    "City Watchdog añade la cantidad automática elegida." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Cantidad automática de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Cantidad que se añade cada vez que se activa Añadir dinero automático.\n" +
                    "Elige un valor suficiente para dejar la ciudad por encima del umbral." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define el saldo inicial para una ciudad nueva con <dinero limitado> o la primera ciudad cargada, y luego vuelve a Predeterminado del juego.\n" +
                    "Se desactiva si ya hay una ciudad cargada.\n" +
                    "Configúralo antes de empezar/cargar una ciudad → se aplica una vez → luego usa <Cantidad del atajo de dinero> o <Añadir dinero automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Actívalo antes de cargar o iniciar una ciudad para desbloquear el hito elegido justo después de cargarla.\n" +
                    "Se desactiva cuando hay una ciudad cargada; reinicia el juego para cambiarlo con seguridad." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Elige el nivel de hito que se desbloqueará en la próxima carga de ciudad.\n" +
                    "Solo se puede cambiar sin una ciudad cargada y solo si [Selector de hito] está activado [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertidor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "Actívalo <solo después de hacer una copia de seguridad>.\n" +
                    "Esto desbloquea el botón <[Convertir partida de dinero ilimitado]> cuando la ciudad cargada se creó con Dinero ilimitado.\n" +
                    "City Watchdog no puede deshacer esta conversión." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir partida de dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para ciudades creadas con Dinero ilimitado.\n" +
                    "Con esa ciudad cargada, convierte la partida a presupuesto normal con dinero limitado, para recuperar el desafío económico.\n" +
                    "El botón está <desactivado/en gris> salvo que la ciudad cargada sea de <Dinero ilimitado> y <Convertidor de dinero ilimitado> esté ON [ ✓ ]." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia de seguridad PRIMERO; City Watchdog no puede deshacerlo.\n" +
                    "¿Seguro?" },

                // --- Key bindings ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Atajo para mostrar u ocultar todos los iconos de notificación a la vez." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alternar iconos de notificación" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para añadir dinero dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para restar dinero dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },

                                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre visible de este mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página del autor en Paradox Mods." },


                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de uso abajo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Panel de notificaciones>\n" +
                    "1. En la partida, haz clic en el botón superior izquierdo de City Watchdog para abrir el panel.\n" +
                    "2. Usa ASC/DESC para ordenar las secciones.\n" +
                    "3. Usa Alternar todo para una configuración rápida, o expande una sección para cambiar iconos individuales.\n" +
                    "4. City Watchdog solo oculta o muestra iconos; no arregla el problema de la ciudad.\n" +
                    "\n" +
                    "<Ayudas de dinero>\n" +
                    "1. Rastreador de tendencias añade valores /h o /mo junto a las flechas de dinero y población.\n" +
                    "2. Añadir dinero y Restar dinero usan la Cantidad del atajo de dinero.\n" +
                    "3. Añadir dinero automático vigila el saldo de la ciudad mientras está cargada y añade dinero si está bajo el umbral.\n" +
                    "4. Convertir partida de dinero ilimitado solo sirve para ciudades creadas con Dinero ilimitado y <City Watchdog no puede revertirlo>.\n" +
                    "\n" +
                    "<Hito personalizado>\n" +
                    "Configura Dinero inicial y elige Hitos en Opciones antes de cargar o iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Abre el panel de iconos de notificación." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "Expande cualquier sección; marca ✓ para mostrar y desmarca para ocultar iconos de alerta." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alternar todo" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expandir todo" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Contraer todo" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Orden" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "Mostrar u ocultar todos los iconos" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELECTRICIDAD" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "No hay suficiente electricidad" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Cuello de botella eléctrico" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Flujo eléctrico deficiente" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Central eléctrica sobrecargada" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformador sobrecargado" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "No hay suficientes líneas de salida conectadas" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batería agotada" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cable eléctrico no conectado" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Línea eléctrica no conectada" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "TUBERÍAS" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "No hay suficiente agua" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Bomba de agua contaminada" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Alcantarillado saturado" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Tubería de agua no conectada" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Tubería de aguas residuales no conectada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Instalación de agua sobrecargada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Instalación de aguas residuales sobrecargada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Nivel de agua subterránea demasiado bajo" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Nivel de agua demasiado bajo" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Bomba de agua contaminada" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "EDIFICIO" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Colapsado" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandonado" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condenado" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Desactivado" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Renta alta" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRÁFICO" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Atasco" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Calle sin salida" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Falta carretera" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Vía no conectada" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Sin acceso en coche" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Sin conexión fluvial" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Sin conexión ferroviaria" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Sin acceso peatonal" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "EMPRESA" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Costes de recursos altos" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "No hay suficientes clientes" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "EMPLEO" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Falta de mano de obra" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Falta de trabajadores cualificados" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DESASTRE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Daños meteorológicos" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destruido por el clima" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Daños por agua" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destruido por inundación" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Este edificio ha sido destruido" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCENDIO" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "En llamas" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Quemado" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "BASURA" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Basura acumulándose" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Instalación llena" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SANIDAD" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Esperando ambulancia" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Esperando coche fúnebre" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Instalación llena" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLICÍA" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Accidente de tráfico" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Escena del crimen" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "CONTAMINACIÓN" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Contaminación del aire" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Contaminación acústica" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Contaminación del suelo" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "CONSUMIDOR DE RECURSOS" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Sin suministros para refugio de emergencia" },
                { m_Settings.GetUILocaleID("Route"), "RUTA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Ruta fallida" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "LÍNEA DE TRANSPORTE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Sin vehículos" },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
