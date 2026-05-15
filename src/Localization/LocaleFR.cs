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
                { m_Settings.GetOptionTabLocaleID(Setting.General), "Général" },
                { m_Settings.GetOptionTabLocaleID(Setting.KeyBindings), "Raccourcis" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "À propos" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Débogage" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Succès" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Argent" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Palier" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Conversion de sauvegarde" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILISATION" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Activer les succès" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Garde les succès activés [ ✓ ] quand ce mod est chargé.\\n" +
                    "Si AchievementFixer est installé, City Watchdog masque cette option et laisse ce mod gérer les succès." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Montant du raccourci d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Utilise ce montant avec les raccourcis Ajouter de l'argent et Retirer de l'argent.\\n" +
                    "Par défaut = 20 000.\\n" +
                    "Cela ne définit pas le solde actuel tout seul." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Ajout d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quand c'est activé [ ✓ ], City Watchdog vérifie le solde de la ville tant qu'une ville est chargée.\\n" +
                    "Si le solde < seuil, il ajoute le montant automatique choisi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Seuil d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Si l'ajout d'argent automatique est activé et que le solde passe sous cette valeur,\\n" +
                    "City Watchdog ajoute le montant automatique choisi." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Montant ajouté à chaque déclenchement de l'ajout automatique.\\n" +
                    "Choisis une valeur suffisante pour repasser au-dessus du seuil." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Argent initial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Définit le solde de départ d'une nouvelle ville en <argent limité> ou de la première ville chargée, puis revient à Valeur du jeu après application.\\n" +
                    "Cette option est grisée si une ville est déjà chargée.\\n" +
                    "À régler avant de créer/charger une ville → s'applique une fois → puis utilise <Montant du raccourci d'argent> ou <Ajout d'argent automatique>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Valeur du jeu" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Sélecteur de palier" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Active ceci avant de charger ou démarrer une ville pour débloquer le palier choisi juste après le chargement.\\n" +
                    "C'est grisé quand une ville est chargée ; redémarre le jeu pour le changer sans risque." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Palier" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Choisis le palier à débloquer au prochain chargement de ville.\\n" +
                    "Réglable seulement hors ville chargée, et seulement si [Sélecteur de palier] est activé [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur d'argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "Active ceci <seulement après avoir fait une sauvegarde>.\\n" +
                    "Cela déverrouille le bouton <[Convertir la sauvegarde Argent illimité]> si la ville chargée a été créée avec Argent illimité.\\n" +
                    "City Watchdog ne peut pas annuler cette conversion." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Convertir la sauvegarde Argent illimité en normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Pour les villes créées avec Argent illimité.\\n" +
                    "Quand cette ville est chargée, convertit la sauvegarde vers un budget normal en argent limité.\\n" +
                    "Le bouton est <désactivé/grisé> sauf si la ville chargée est de type <Argent illimité> et si <Convertisseur d'argent illimité> est ON [ ✓ ]." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d'Argent illimité vers argent limité normal ?\\n" +
                    "Fais une sauvegarde AVANT ; City Watchdog ne peut pas annuler cela.\\n" +
                    "Confirmer ?" },

                // --- Key bindings ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Ajouter de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Raccourci pour ajouter de l'argent dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Ajouter de l'argent" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Retirer de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Raccourci pour retirer de l'argent dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Retirer de l'argent" },

#if DEBUG
                // --- Debug key binding ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.DebugKeyboardBinding)), "Action de débogage" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.DebugKeyboardBinding)), "Raccourci de débogage réservé au développement. N'apparaît que dans les builds Debug." },
                { m_Settings.GetBindingKeyLocaleID("DebugAction"), "Action de débogage" },

#endif

                                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nom affiché de ce mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Version actuelle du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Ouvre la page Paradox Mods de l'auteur." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Rejoindre le Discord du mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Afficher les instructions" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Affiche ou masque les instructions ci-dessous." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Panneau de notifications>\\n" +
                    "1. En jeu, clique sur le bouton City Watchdog en haut à gauche pour ouvrir le panneau.\\n" +
                    "2. Utilise ASC/DESC pour trier les sections.\\n" +
                    "3. Utilise Tout basculer pour une configuration rapide, ou ouvre une section pour changer des icônes une par une.\\n" +
                    "4. City Watchdog masque ou affiche seulement les icônes ; il ne règle pas le problème de la ville.\\n" +
                    "\\n" +
                    "<Aides d'argent>\\n" +
                    "1. Ajouter et Retirer de l'argent utilisent le montant du raccourci d'argent.\\n" +
                    "2. L'ajout automatique surveille le solde de la ville et ajoute de l'argent sous le seuil.\\n" +
                    "3. Convertir la sauvegarde Argent illimité sert uniquement aux villes créées avec Argent illimité et <City Watchdog ne peut pas revenir en arrière>.\\n" +
                    "\\n" +
                    "<Palier personnalisé>\\n" +
                    "Règle l'argent initial et choisis les paliers dans les options avant de charger ou démarrer une ville." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Ouvre le panneau des icônes de notification." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"), "Ouvre une section ; coche ✓ pour afficher, décoche pour masquer les icônes d'alerte." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Tout basculer" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Tout ouvrir" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Tout fermer" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Ordre de tri" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "Afficher ou masquer toutes les icônes" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ÉLECTRICITÉ" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Pas assez d'électricité" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Goulot électrique" },
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
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Installation d'égouts surchargée" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Niveau de nappe trop bas" },
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
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Pas de voie navigable" },
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
