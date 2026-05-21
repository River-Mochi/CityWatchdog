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
                { m_Settings.GetOptionTabLocaleID(Setting.AchievementsTab), "Logros" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atajos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Acerca de" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuración" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Trends), "Seguimiento de tendencias" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinero" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificaciones" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Hito" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversión de guardado" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Logros" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementTools), "Herramientas avanzadas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementDanger), "Reiniciar logros" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atajos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Trend Tracker ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Seguimiento de tendencias" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "Añade valores numéricos de tendencia junto a las flechas vanilla de dinero y población de la barra inferior.\n" +
                    "Es solo una visualización ligera de la barra; no cambia el dinero ni la población de la ciudad." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "Frecuencia de tendencia" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "Elige si el texto de tendencia de la barra inferior muestra valores por hora o mensuales para dinero y población.\n" +
                    "Mensual usa ingresos menos gastos del presupuesto para dinero y una proyección de 24 horas para población." },

                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "Mensual (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo del tooltip de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Elige cuántos detalles aparecen en el tooltip de dinero al pasar el cursor.\n" +
                    "<Mini> muestra solo los dos valores netos de /mo y /h.\n" +
                    "<Compact> acorta valores grandes (15.21M en vez de 15,212,318).\n" +
                    "<Full size> muestra valores largos y campos de total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeDefault"), "Tamaño completo" },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Importe del atajo de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa este importe con los atajos de Añadir dinero y Restar dinero.\n" +
                    "Predeterminado = 40 000.\n" +
                    "Esto no hace nada a menos que uses el atajo en la ciudad para añadir/restar dinero.\n" +
                    "Para dinero automático, activa la opción Añadir dinero automático." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atajo para añadir dinero dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Añadir dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atajo para restar dinero dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Restar dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Añadir dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Cuando está activado [ ✓ ], City Watchdog comprueba el saldo de la ciudad mientras hay una ciudad cargada.\n" +
                    "Si el saldo está por debajo del umbral, añade el importe automático seleccionado." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Umbral de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si Añadir dinero automático está activado y el saldo de la ciudad cae por debajo de este valor,\n" +
                    "City Watchdog añade el importe automático seleccionado." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Importe automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Importe añadido cada vez que se activa Añadir dinero automático.\n" +
                    "Elige un valor suficiente para dejar la ciudad con seguridad por encima del umbral." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Establece el saldo inicial para una nueva ciudad con <dinero limitado> o la primera ciudad cargada, y luego vuelve a Predeterminado del juego después de aplicarse.\n" +
                    "Se desactiva si ya hay una ciudad cargada.\n" +
                    "Configura antes de iniciar/cargar una ciudad → se aplica una vez → después usa <Importe del atajo de dinero> o <Añadir dinero automático>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar iconos de notificación" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atajo> para la misma acción que el botón de icono <[Toggle All]> del panel del juego.\n" +
                    "Muestra u oculta al instante todos los iconos de notificación listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Instantáneamente mostrar/ocultar todos los iconos de notificación" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/cerrar panel de notificaciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atajo> para abrir o cerrar el panel de notificaciones del juego.\n" +
                    "Funciona igual que hacer clic en el icono superior izquierdo para abrir el panel completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/cerrar panel de notificaciones" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Selector de hitos" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Actívalo antes de cargar o iniciar una ciudad para desbloquear el hito elegido justo después de cargarla.\n" +
                    "No se puede activar mientras una ciudad está cargada, pero se puede desactivar si quedó activado por error.\n" +
                    "City Watchdog no puede deshacer cambios de hitos ya guardados en una ciudad; usa un guardado anterior si hace falta." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Hito" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Elige el nivel de hito que se desbloqueará al cargar la próxima ciudad.\n" +
                    "Solo se puede ajustar fuera de una ciudad cargada y después de activar [Selector de hitos] [ ✓ ]." },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Haz una copia de seguridad de la ciudad PRIMERO>.\n" +
                    "Convierte una ciudad creada con Dinero ilimitado en una ciudad normal con desafíos de dinero.\n" +
                    "Activar esto desbloquea el botón <[Convertir guardado de Dinero ilimitado]> cuando la ciudad cargada es de tipo <Dinero ilimitado>.\n" +
                    "City Watchdog no puede deshacer esta conversión.\n" +
                    "Si tus ciudades son normales, no te preocupes; esto no hace falta." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir ciudad de Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para ciudades iniciadas con <Dinero ilimitado>.\n" +
                    "Mientras esa ciudad está cargada, convierte el guardado a presupuesto normal de dinero limitado para recuperar el desafío de dinero.\n" +
                    "El botón está <desactivado/en gris> salvo que la ciudad cargada sea de tipo <Dinero ilimitado> y <Conversor de dinero ilimitado> esté ON [ ✓ ].\n" +
                    "Haz una copia de seguridad y úsalo bajo tu responsabilidad; City Watchdog no puede deshacer esta conversión." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia de seguridad PRIMERO; City Watchdog no puede deshacer esto.\n" +
                    "¿Seguro?" },


                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Activar logros" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Mantén esto **ON [ ✓ ]** para permitir logros mientras usas mods.\n" +
                    "El juego no cuenta tareas hechas en el pasado,\n" +
                    "así que déjalo activado y completa las tareas de forma natural." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementNotes)),
                    "• <Activado por defecto> sin usar los botones avanzados de abajo.\n" +
                    "• Solo mantenlo activado para completar logros de forma natural :)\n" +
                    "" },

                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementNotes)), "" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "Mostrar herramientas avanzadas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "**Opcional:** para probar, borrar o activar un logro." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SelectedAchievement)), "Logro seleccionado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SelectedAchievement)),
                    "Selecciona un logro para cambiar.\n" +
                    "<No hace falta para el progreso normal de logros.>\n" +
                    "Solo sirve si quieres resetear/borrar logros o desbloquearlos sin hacer las tareas." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UnlockSelectedAchievement)), "Desbloquear seleccionado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UnlockSelectedAchievement)), "**Desbloquea y completa** el logro seleccionado." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ClearSelectedAchievement)), "Borrar seleccionado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ClearSelectedAchievement)), "Marca el logro seleccionado como **no completado**." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ClearSelectedAchievement)),
                    "BORRAR / RESETEAR este logro.\n\n" +
                    "¿Continuar?" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementToolsAdvisory)),
                    "<Las herramientas avanzadas son opcionales>\n" +
                    "• Úsalas para pruebas, reparaciones o resetear todos los logros.\n" +
                    "• Pasa el cursor sobre cualquier botón para ver detalles en el panel derecho." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementToolsAdvisory)), "Prueba" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ResetAllAchievements)), "REINICIAR TODO" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ResetAllAchievements)),
                    "Esto borra todos tus logros completados y te permite empezar de nuevo.\n" +
                    "**TEN CUIDADO** al usar **[REINICIAR TODO]**.\n" +
                    "Si lo usas por accidente, puedes recuperar logros completados con el botón [Desbloquear seleccionado]." },

                // Confirmation modal Yes/No
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ResetAllAchievements)),
                    "ADVERTENCIA: RESETEAR/BORRAR todos los logros a estado NO completado.\n" +
                    "¿Continuar?" },


                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nombre visible de este mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versión actual del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre la página del autor en Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instrucciones" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Muestra u oculta las instrucciones de uso de abajo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Panel de notificaciones>\n" +
                    "1. Haz clic en el botón City Watchdog (arriba a la izquierda) para abrir el panel.\n" +
                    "2. ASC/DESC para ordenar.\n" +
                    "3. Usa Toggle All para configuración rápida, o expande una sección para cambiar iconos individuales.\n" +
                    "4. City Watchdog solo oculta o muestra iconos; no arregla el problema real de la ciudad.\n\n" +
                    "<Ayudas de dinero>\n" +
                    "1. Seguimiento de tendencias añade valores /h o /mo junto a las flechas de dinero y población de la barra inferior.\n" +
                    "2. Añadir y Restar dinero: usa el <Importe del atajo de dinero>.\n" +
                    "3. Añadir dinero automático vigila el saldo de la ciudad mientras está cargada y añade dinero si está bajo el umbral.\n" +
                    "4. Convertir guardado de Dinero ilimitado es solo para ciudades iniciadas con Dinero ilimitado y City Watchdog <no puede revertirlo>.\n\n" +
                    "<Hito personalizado>\n" +
                    "Configura Dinero inicial y selecciona Hitos en el menú de Opciones antes de cargar o iniciar una ciudad." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Abrir el panel de iconos de notificación." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Expande cualquier fila; marca [✓] para mostrar y desmarca para ocultar alertas.\n" +
                    "Esto no arregla problemas de la ciudad; oculta el desorden de iconos." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alternar todo" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expandir todo" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Contraer todas las filas" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Orden" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Muestra/oculta todos los iconos.\n" +
                    "Color: verde = todo activado; azul = mixto; rojo = todo desactivado." },
                { m_Settings.GetUILocaleID("TrendTooltipIncome"), "Ingresos:" },
                { m_Settings.GetUILocaleID("TrendTooltipExpenses"), "Gastos:" },
                { m_Settings.GetUILocaleID("TrendTooltipNet"), "Neto:" },
                { m_Settings.GetUILocaleID("TrendTooltipTotal"), "Total:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELECTRICIDAD" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "No hay suficiente electricidad" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Cuello de botella eléctrico" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Flujo eléctrico deficiente" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Central sobrecargada" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformador sobrecargado" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "No hay suficientes líneas de salida conectadas" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batería agotada" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cable eléctrico no conectado" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Línea eléctrica no conectada" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "TUBERÍAS" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "No hay suficiente agua" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Bomba de agua contaminada" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Alcantarillado atascado" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Tubería de agua no conectada" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Tubería de aguas residuales no conectada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Instalación de agua sobrecargada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Instalación de aguas residuales sobrecargada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Nivel de aguas subterráneas demasiado bajo" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Nivel de agua demasiado bajo" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Bomba de agua contaminada" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "EDIFICIO" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Derrumbado" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandonado" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condenado" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Desactivado" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Alquiler alto" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRÁFICO" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Atasco" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Calle sin salida" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Necesita carretera" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Vía no conectada" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Sin acceso para coches" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Sin conexión acuática" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Sin conexión ferroviaria" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Sin acceso peatonal" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "EMPRESA" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Costes de recursos altos" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "No hay suficientes clientes" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "EMPLEO" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Falta mano de obra" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Falta mano de obra cualificada" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DESASTRE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Daños meteorológicos" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destruido por el clima" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Daños por agua" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destruido por inundación" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Este edificio fue destruido" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCENDIO" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "En llamas" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Quemado" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "BASURA" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Basura acumulándose" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Instalación llena" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SALUD" },
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
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Sin suministros de refugio de emergencia" },
                { m_Settings.GetUILocaleID("Route"), "RUTA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Búsqueda de ruta fallida" },

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
