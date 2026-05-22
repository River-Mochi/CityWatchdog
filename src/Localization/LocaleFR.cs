// File: src/Localization/LocaleFR.cs
// Purpose: French (fr-FR) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocaleFR(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Actions" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Raccourcis" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Débogage" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Vue argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notifications" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Jalon" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversion de sauvegarde" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Raccourcis" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Ajoute des valeurs de tendance numériques à côté des flèches vanilla d'argent et de population dans la barre du bas.\n" +
                    "C'est seulement un affichage léger de la barre d'outils ; cela ne change ni l'argent ni la population." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Fréquence de la vue argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Choisis si le texte de tendance de la barre du bas affiche les valeurs horaires ou mensuelles pour l'argent et la population.\n" +
                    "Le mensuel utilise les revenus moins les dépenses du budget pour l'argent, et une projection sur 24 heures pour la population." },

                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Horaire (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Mensuel (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Style d'info-bulle d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Choisis le niveau de détail affiché dans l'info-bulle d'argent au survol.\n" +
                    "<Mini> affiche seulement les deux valeurs nettes /mo et /h.\n" +
                    "<Compact> raccourcit les grandes valeurs (15.21M au lieu de 15,212,318).\n" +
                    "<Full size> affiche les valeurs longues et les champs de total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compact" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullSize"), "Taille réelle" },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant des raccourcis d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Utilise ce montant avec les raccourcis Ajouter de l'argent et Retirer de l'argent.\n" +
                    "Par défaut = 40 000.\n" +
                    "Cela ne fait rien sauf si tu utilises le raccourci en ville pour ajouter/retirer de l'argent.\n" +
                    "Pour l'argent automatique, active l'option Ajout d'argent automatique." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour ajouter de l'argent dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l'argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour retirer de l'argent dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l'argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Si activé [ ✓ ], City Watchdog vérifie le solde de la ville lorsqu'une ville est chargée.\n" +
                    "Si le solde est sous le seuil, il ajoute le montant automatique choisi.\n" +
                    "Il est recommandé d'utiliser l'argent manuel avec le raccourci (<[> ou <]>) au besoin plutôt que cette option automatique, mais elle reste disponible si tu la veux." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si l'ajout d'argent automatique est activé et que le solde de la ville passe sous cette valeur,\n" +
                    "City Watchdog ajoute le montant automatique choisi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté chaque fois que l'ajout d'argent automatique se déclenche.\n" +
                    "Choisis une valeur assez élevée pour remettre la ville au-dessus du seuil." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit le solde de départ pour une nouvelle ville en <argent limité> ou la première ville chargée, puis revient au paramètre par défaut du jeu après application.\n" +
                    "Grisé si une ville est déjà chargée.\n" +
                    "Règle avant de démarrer/charger une ville → s'applique une fois → utilise ensuite <Montant des raccourcis d'argent> ou <Ajout d'argent automatique>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Par défaut du jeu" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Basculer les icônes de notification" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Raccourci> pour la même action que le bouton d'icône <[Toggle All]> dans le panneau du jeu.\n" +
                    "Affiche ou masque instantanément toutes les icônes de notification listées." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Afficher/masquer instantanément toutes les icônes de notification" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Ouvrir/fermer le panneau des notifications" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Raccourci> pour ouvrir ou fermer le panneau de notifications en jeu.\n" +
                    "Fonctionne comme un clic sur l'icône en haut à gauche pour ouvrir le panneau complet." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Ouvrir/fermer le panneau des notifications" },


                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Active-le avant de charger ou démarrer une ville pour débloquer le jalon choisi juste après le chargement.\n" +
                    "Impossible de l'activer pendant qu'une ville est chargée, mais il peut être désactivé s'il a été laissé actif par erreur.\n" +
                    "City Watchdog ne peut pas annuler les changements de jalon déjà sauvegardés dans une ville ; utilise une sauvegarde plus ancienne si besoin." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Jalon" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisis le niveau de jalon à débloquer au prochain chargement de ville.\n" +
                    "Réglable seulement hors ville chargée, et seulement après activation de [Sélecteur de jalon] [ ✓ ]." },


                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur d'argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fais d'abord une sauvegarde de la ville>.\n" +
                    "Convertit une ville commencée en Argent illimité en ville normale avec les défis d'argent habituels.\n" +
                    "Activer ceci déverrouille le bouton <[Convertir une sauvegarde Argent illimité]> si la ville chargée est de type <Argent illimité>.\n" +
                    "City Watchdog ne peut pas annuler cette conversion.\n" +
                    "Si tes villes sont normales, ne t'en fais pas ; ce n'est pas nécessaire." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir une ville Argent illimité en ville normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes commencées avec <Argent illimité>.\n" +
                    "Pendant que cette ville est chargée, convertit la sauvegarde en budget normal à argent limité pour retrouver les défis d'argent.\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité> et que <Convertisseur d'argent illimité> est ON [ ✓ ].\n" +
                    "Fais une sauvegarde et utilise à tes risques ; City Watchdog ne peut pas annuler cette conversion." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville de l'Argent illimité vers l'argent limité normal ?\n" +
                    "Sauvegarde d'abord une copie ; City Watchdog ne peut pas annuler cela.\n" +
                    "Confirmer ?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page de l'auteur sur Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Panneau de notifications>\n" +
                    "1. Clique sur le bouton City Watchdog (en haut à gauche) pour ouvrir le panneau.\n" +
                    "2. ASC/DESC pour trier.\n" +
                    "3. Utilise Toggle All pour un réglage rapide, ou ouvre une section pour changer les icônes une par une.\n" +
                    "4. City Watchdog masque ou affiche seulement les icônes ; il ne corrige pas le problème réel de la ville.\n\n" +
                    "<Aides d'argent>\n" +
                    "1. Vue argent ajoute des valeurs /h ou /mo à côté des flèches argent et population dans la barre du bas.\n" +
                    "2. Ajouter et retirer de l'argent : utilise le <Montant des raccourcis d'argent>.\n" +
                    "3. L'ajout d'argent automatique surveille le solde de la ville lorsqu'elle est chargée et ajoute de l'argent sous le seuil.\n" +
                    "4. Convertir une sauvegarde Argent illimité concerne seulement les villes commencées en Argent illimité et City Watchdog <ne peut pas l'annuler>.\n\n" +
                    "<Jalon personnalisé>\n" +
                    "Définis l'argent initial et choisis les jalons dans le menu Options avant de charger ou démarrer une ville." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Ouvrir le panneau des icônes de notification." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Ouvre une ligne ; coche [✓] pour afficher, décoche pour masquer les alertes.\n" +
                    "Cela ne corrige pas les problèmes de la ville, cela masque le fouillis d'icônes." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Tout basculer" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Tout ouvrir" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Tout fermer" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Ordre de tri" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Affiche/masque toutes les icônes.\n" +
                    "Couleur : vert = tout activé ; bleu = mixte ; rouge = tout désactivé." },
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Revenus :" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Dépenses :" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Net :" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Total :" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ÉLECTRICITÉ" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Pas assez d'électricité" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Goulot d'étranglement électrique" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Mauvais flux électrique" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Centrale surchargée" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformateur surchargé" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Pas assez de lignes de sortie connectées" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Batterie vide" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Câble électrique non connecté" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Ligne électrique non connectée" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "EAU / ÉGOUTS" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Pas assez d'eau" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Pompe à eau polluée" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Égouts refoulés" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Conduite d'eau non connectée" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Conduite d'égout non connectée" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Installation d'eau surchargée" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Installation d'égout surchargée" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Niveau des eaux souterraines trop bas" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Niveau d'eau trop bas" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Pompe à eau polluée" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "BÂTIMENT" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Effondré" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandonné" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condamné" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Désactivé" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Loyer élevé" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRAFIC" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Embouteillage" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Impasse" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Route requise" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Voie non connectée" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Pas d'accès voiture" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Pas de connexion maritime" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Pas de connexion ferroviaire" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Pas d'accès piéton" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "ENTREPRISE" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Coûts de ressources élevés" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Pas assez de clients" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "EMPLOIS" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Manque de main-d'œuvre" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Manque de main-d'œuvre qualifiée" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "CATASTROPHE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Dégâts météo" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Détruit par la météo" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Dégâts des eaux" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Détruit par inondation" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Ce bâtiment a été détruit" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCENDIE" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "En feu" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Brûlé" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "DÉCHETS" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Déchets qui s'accumulent" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Installation pleine" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SANTÉ" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "En attente d'ambulance" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "En attente d'un corbillard" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Installation pleine" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLICE" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Accident de la route" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Scène de crime" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "POLLUTION" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Pollution de l'air" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Pollution sonore" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Pollution du sol" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "CONSOMMATEUR DE RESSOURCES" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Pas de fournitures d'abri d'urgence" },
                { m_Settings.GetUILocaleID("Route"), "ITINÉRAIRE" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Calcul d'itinéraire échoué" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "LIGNE DE TRANSPORT" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Aucun véhicule" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
