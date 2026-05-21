// File: src/Systems/NotificationControllerSystem.Debug.cs
// Purpose: Keeps NotificationControllerSystem debug-only prefab/icon inspection helpers out of the release-facing system file.

namespace CityWatchdog.Systems
{
    using CityWatchdog.Extensions;
    using Game.Prefabs;
    using Game.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class NotificationControllerSystem
    {
    #if DEBUG
        public void Debug() => new List<Func<string>> {
            //LogElectricityNotificationSvgSources,
            //LogElectricityNotificationPrefabName,
            //LogWaterPipeNotificationSvgSources,
            //LogWaterPipeNotificationPrefabName,
            //LogBuildingNotificationSvgSources,
            //LogBuildingNotificationPrefabName,
            //LogTrafficNotificationSvgSources,
            //LogTrafficNotificationPrefabName,
            //LogCompanyNotificationSvgSources,
            //LogCompanyNotificationPrefabName,
            //LogWorkProviderNotificationSvgSources,
            //LogWorkProviderNotificationPrefabName
            //LogDisasterNotificationSvgSources,
            //LogDisasterNotificationPrefabName,
            //LogFireNotificationSvgSources,
            //LogFireNotificationPrefabName,
            //LogGarbageNotificationSvgSources,
            //LogGarbageNotificationPrefabName,
            //LogHealthcareNotificationSvgSources,
            //LogHealthcareNotificationPrefabName,
            //LogPoliceNotificationSvgSources,
            //LogPoliceNotificationPrefabName,
            //LogPollutionNotificationSvgSources,
            //LogPollutionNotificationPrefabName,
            //LogResourceConsumerNotificationSvgSources,
            //LogResourceConsumerNotificationPrefabName,
            //LogRouteNotificationSvgSources,
            //LogRouteNotificationPrefabName,
            //LogTransportLineNotificationSvgSources,
            //LogTransportLineNotificationPrefabName,
        }.ForEach(action => CityWatchdog.Mod.DebugLog(action));

        private List<NotificationIconPrefab> GetTransportLineNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            TransportLineData singleton = transportLineNotificationParameterQuery.GetSingleton<TransportLineData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_VehicleNotification));
            return result;
        }

        private List<string> GetTransportLineNotificationSvg() => GetTransportLineNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogTransportLineNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogTransportLineNotificationSvgSources")).ToString(_ => GetTransportLineNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetTransportLineNotificationPrefabName() {
            List<string> result = new();
            TransportLineData singleton = transportLineNotificationParameterQuery.GetSingleton<TransportLineData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_VehicleNotification).name);
            return result;
        }

        private string LogTransportLineNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogTransportLineNotificationPrefabName")).ToString(_ => GetTransportLineNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetRouteNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            RouteConfigurationData singleton = routeNotificationParameterQuery.GetSingleton<RouteConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_PathfindNotification));
            return result;
        }

        private List<string> GetRouteNotificationSvg() => GetRouteNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogRouteNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogRouteNotificationSvgSources")).ToString(_ => GetRouteNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetRouteNotificationPrefabName() {
            List<string> result = new();
            RouteConfigurationData singleton = routeNotificationParameterQuery.GetSingleton<Game.Prefabs.RouteConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_PathfindNotification).name);
            return result;
        }

        private string LogRouteNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogRouteNotificationPrefabName")).ToString(_ => GetRouteNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetResourceConsumerNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            ResourceConsumerData singleton = resourceConsumerNotificationParameterQuery.GetSingleton<ResourceConsumerData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoResourceNotificationPrefab));
            return result;
        }

        private List<string> GetResourceConsumerNotificationSvg() => GetResourceConsumerNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogResourceConsumerNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogResourceConsumerNotificationSvgSources")).ToString(_ => GetResourceConsumerNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetResourceConsumerNotificationPrefabName() {
            List<string> result = new();
            ResourceConsumerData singleton = resourceConsumerNotificationParameterQuery.GetSingleton<Game.Prefabs.ResourceConsumerData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoResourceNotificationPrefab).name);
            return result;
        }

        private string LogResourceConsumerNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogResourceConsumerNotificationPrefabName")).ToString(_ => GetResourceConsumerNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetPollutionNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            PollutionParameterData singleton = pollutionNotificationParameterQuery.GetSingleton<PollutionParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AirPollutionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoisePollutionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_GroundPollutionNotification));
            return result;
        }

        private List<string> GetPollutionNotificationSvg() => GetPollutionNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogPollutionNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogPollutionNotificationSvgSources")).ToString(_ => GetPollutionNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetPollutionNotificationPrefabName() {
            List<string> result = new();
            PollutionParameterData singleton = pollutionNotificationParameterQuery.GetSingleton<Game.Prefabs.PollutionParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AirPollutionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoisePollutionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_GroundPollutionNotification).name);
            return result;
        }

        private string LogPollutionNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogPollutionNotificationPrefabName")).ToString(_ => GetPollutionNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetPoliceNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            PoliceConfigurationData singleton = policeNotificationParameterQuery.GetSingleton<PoliceConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrafficAccidentNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CrimeSceneNotificationPrefab));
            return result;
        }

        private List<string> GetPoliceNotificationSvg() => GetPoliceNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogPoliceNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogPoliceNotificationSvgSources")).ToString(_ => GetPoliceNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetPoliceNotificationPrefabName() {
            List<string> result = new();
            PoliceConfigurationData singleton = policeNotificationParameterQuery.GetSingleton<Game.Prefabs.PoliceConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrafficAccidentNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CrimeSceneNotificationPrefab).name);
            return result;
        }

        private string LogPoliceNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogPoliceNotificationPrefabName")).ToString(_ => GetPoliceNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetHealthcareNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            HealthcareParameterData singleton = healthcareNotificationParameterQuery.GetSingleton<HealthcareParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AmbulanceNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HearseNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FacilityFullNotificationPrefab));
            return result;
        }

        private List<string> GetHealthcareNotificationSvg() => GetHealthcareNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogHealthcareNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogHealthcareNotificationSvgSources")).ToString(_ => GetHealthcareNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetHealthcareNotificationPrefabName() {
            List<string> result = new();
            HealthcareParameterData singleton = healthcareNotificationParameterQuery.GetSingleton<Game.Prefabs.HealthcareParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AmbulanceNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HearseNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FacilityFullNotificationPrefab).name);
            return result;
        }

        private string LogHealthcareNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogHealthcareNotificationPrefabName")).ToString(_ => GetHealthcareNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetGarbageNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            GarbageParameterData singleton = garbageNotificationParameterQuery.GetSingleton<GarbageParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_GarbageNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FacilityFullNotificationPrefab));
            return result;
        }

        private List<string> GetGarbageNotificationSvg() => GetGarbageNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogGarbageNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogGarbageNotificationSvgSources")).ToString(_ => GetGarbageNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetGarbageNotificationPrefabName() {
            List<string> result = new();
            GarbageParameterData singleton = garbageNotificationParameterQuery.GetSingleton<Game.Prefabs.GarbageParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_GarbageNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FacilityFullNotificationPrefab).name);
            return result;
        }

        private string LogGarbageNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogGarbageNotificationPrefabName")).ToString(_ => GetGarbageNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<NotificationIconPrefab> GetFireNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            FireConfigurationData singleton = fireNotificationParameterQuery.GetSingleton<FireConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FireNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BurnedDownNotificationPrefab));
            return result;
        }

        private List<string> GetFireNotificationSvg() => GetFireNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogFireNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogFireNotificationSvgSources")).ToString(_ => GetFireNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetFireNotificationPrefabName() {
            List<string> result = new();
            FireConfigurationData singleton = fireNotificationParameterQuery.GetSingleton<Game.Prefabs.FireConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_FireNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BurnedDownNotificationPrefab).name);
            return result;
        }

        private string LogFireNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogFireNotificationPrefabName")).ToString(_ => GetFireNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);


        private List<NotificationIconPrefab> GetDisasterNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            DisasterConfigurationData singleton = disasterNotificationParameterQuery.GetSingleton<DisasterConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WeatherDamageNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WeatherDestroyedNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterDamageNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterDestroyedNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DestroyedNotificationPrefab));
            return result;
        }

        private List<string> GetDisasterNotificationSvg() => GetDisasterNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private string LogDisasterNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogDisasterNotificationSvgSources")).ToString(_ => GetDisasterNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetDisasterNotificationPrefabName() {
            List<string> result = new();
            DisasterConfigurationData singleton = disasterNotificationParameterQuery.GetSingleton<Game.Prefabs.DisasterConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WeatherDamageNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WeatherDestroyedNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterDamageNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterDestroyedNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DestroyedNotificationPrefab).name);
            return result;
        }

        private string LogDisasterNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogDisasterNotificationPrefabName")).ToString(_ => GetDisasterNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private string LogWorkProviderNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogWorkProviderNotificationPrefabName")).ToString(_ => GetWorkProviderNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetWorkProviderNotificationPrefabName() {
            List<string> result = new();
            WorkProviderParameterData singleton = workProviderNotificationParameterQuery.GetSingleton<Game.Prefabs.WorkProviderParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_UneducatedNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_EducatedNotificationPrefab).name);
            return result;
        }

        private string LogWorkProviderNotificationSvgSources() => logBuilder.ClearAndAppendLine(LogFlag("LogWorkProviderNotificationSvgSources")).ToString(_ => GetWorkProviderNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);

        private List<string> GetWorkProviderNotificationSvg() => GetWorkProviderNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetWorkProviderNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            WorkProviderParameterData singleton = workProviderNotificationParameterQuery.GetSingleton<WorkProviderParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_UneducatedNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_EducatedNotificationPrefab));
            return result;
        }

        private string LogCompanyNotificationPrefabName() => logBuilder.ClearAndAppendLine(LogFlag("LogCompanyNotificationPrefabName")).ToString(_ => GetCompanyNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);


        private List<string> GetCompanyNotificationPrefabName() {
            List<string> result = new();
            CompanyNotificationParameterData singleton = companyNotificationParameterQuery.GetSingleton<CompanyNotificationParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoInputsNotificationPrefab).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoCustomersNotificationPrefab).name);
            return result;
        }

        private string LogCompanyNotificationSvgSources() {
            logBuilder.ClearAndAppendLine(LogFlag("LogCompanyNotificationSvgSources"));
            return logBuilder.ToString(_ => GetCompanyNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);
        }

        private List<string> GetCompanyNotificationSvg() => GetCompanyNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetCompanyNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            CompanyNotificationParameterData singleton = companyNotificationParameterQuery.GetSingleton<CompanyNotificationParameterData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoInputsNotificationPrefab));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NoCustomersNotificationPrefab));
            return result;
        }

        private string LogTrafficNotificationPrefabName() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogTrafficNotificationPrefabName"));
            logBuilder.ToString(_ => GetTrafficNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetTrafficNotificationPrefabName() {
            List<string> result = new();
            TrafficConfigurationData singleton = trafficConfigurationDataQuery.GetSingleton<TrafficConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BottleneckNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DeadEndNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_RoadConnectionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrackConnectionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CarConnectionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_ShipConnectionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrainConnectionNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_PedestrianConnectionNotification).name);
            return result;
        }

        private string LogTrafficNotificationSvgSources() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogTrafficNotificationSvgSources"));
            logBuilder.ToString(_ => GetTrafficNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetTrafficNotificationSvg() => GetTrafficNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetTrafficNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            TrafficConfigurationData singleton = trafficConfigurationDataQuery.GetSingleton<TrafficConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BottleneckNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DeadEndNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_RoadConnectionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrackConnectionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CarConnectionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_ShipConnectionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TrainConnectionNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_PedestrianConnectionNotification));
            return result;
        }

        private string LogBuildingNotificationPrefabName() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogBuildingNotificationPrefabName"));
            logBuilder.ToString(_ => GetBuildingNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetBuildingNotificationPrefabName() {
            List<string> result = new();
            BuildingConfigurationData singleton = buildingConfigurationDataQuery.GetSingleton<BuildingConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AbandonedCollapsedNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AbandonedNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CondemnedNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_LevelUpNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TurnedOffNotification).name);
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HighRentNotification).name);
            return result;
        }

        private string LogBuildingNotificationSvgSources() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogBuildingNotificationSvgSources"));
            logBuilder.ToString(_ => GetBuildingNotificationSvg().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetBuildingNotificationSvg() => GetBuildingNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetBuildingNotificationPrefab() {
            List<NotificationIconPrefab> result = new();
            BuildingConfigurationData singleton = buildingConfigurationDataQuery.GetSingleton<BuildingConfigurationData>();
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AbandonedCollapsedNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_AbandonedNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_CondemnedNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_LevelUpNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TurnedOffNotification));
            result.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HighRentNotification));
            return result;
        }

        private string LogWaterPipeNotificationPrefabName() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogWaterPipeNotificationPrefabName"));
            logBuilder.ToString(_ => GetWaterPipeNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetWaterPipeNotificationPrefabName() {
            List<string> name = new();
            WaterPipeParameterData singleton = waterPipeParameterQuery.GetSingleton<WaterPipeParameterData>();
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DirtyWaterNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_SewageNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterPipeNotConnectedNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_SewagePipeNotConnectedNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughWaterCapacityNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughSewageCapacityNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughGroundwaterNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughSurfaceWaterNotification).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DirtyWaterPumpNotification).name);
            return name;
        }

        private string LogWaterPipeNotificationSvgSources() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogWaterPipeNotificationSvgSources"));
            logBuilder.ToString(_ => GetWaterPipeNotificationSvgSources().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetWaterPipeNotificationSvgSources() => GetWaterPipeNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetWaterPipeNotificationPrefab() {
            List<NotificationIconPrefab> notificationIconPrefabs = new();
            WaterPipeParameterData singleton = waterPipeParameterQuery.GetSingleton<WaterPipeParameterData>();
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DirtyWaterNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_SewageNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_WaterPipeNotConnectedNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_SewagePipeNotConnectedNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughWaterCapacityNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughSewageCapacityNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughGroundwaterNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughSurfaceWaterNotification));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_DirtyWaterPumpNotification));
            return notificationIconPrefabs;
        }

        private string LogElectricityNotificationPrefabName() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogElectricityNotificationPrefabName"));
            logBuilder.ToString(_ => GetElectricityNotificationPrefabName().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetElectricityNotificationPrefabName() {
            List<string> name = new();
            ElectricityParameterData singleton = electricityParameterQuery.GetSingleton<ElectricityParameterData>();
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_ElectricityNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BottleneckNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BuildingBottleneckNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughProductionNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TransformerNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughConnectedNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BatteryEmptyNotificationPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_LowVoltageNotConnectedPrefab).name);
            name.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HighVoltageNotConnectedPrefab).name);
            return name;
        }

        private string LogElectricityNotificationSvgSources() {
            logBuilder.Clear();
            logBuilder.AppendLine(LogFlag("LogElectricityNotificationSvgSources"));
            logBuilder.ToString(_ => GetElectricityNotificationSvgSources().ForEach(v => _.AppendLine($"\"{v}\",")), false);
            return logBuilder.ToString();
        }

        private List<string> GetElectricityNotificationSvgSources() => GetElectricityNotificationPrefab().Select(_ => ImageSystem.GetIcon(_)).ToList();

        private List<NotificationIconPrefab> GetElectricityNotificationPrefab() {
            List<NotificationIconPrefab> notificationIconPrefabs = new();
            ElectricityParameterData singleton = electricityParameterQuery.GetSingleton<ElectricityParameterData>();
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_ElectricityNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BottleneckNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BuildingBottleneckNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughProductionNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_TransformerNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_NotEnoughConnectedNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_BatteryEmptyNotificationPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_LowVoltageNotConnectedPrefab));
            notificationIconPrefabs.Add(prefabSystem.GetPrefab<NotificationIconPrefab>(singleton.m_HighVoltageNotConnectedPrefab));
            return notificationIconPrefabs;
        }

        private string LogFlag(string name) => $"--- {name} ---";

    #endif
    }
}
