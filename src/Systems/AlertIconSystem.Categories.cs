// File: src/Systems/AlertIconSystem.Categories.cs
// Purpose: Contains per-category notification alert mapping for City Watchdog.

namespace CityWatchdog.Systems
{
    using CityWatchdog.Data;
    using Game.Notifications;
    using Game.Prefabs;
    using System.Collections.Generic;
    using Unity.Collections;
    using Unity.Entities;

    public partial class AlertIconSystem
    {
        public void EnableTransportLineNotification(TransportLineNotificationIcon transportLineNotificationIcon, bool value, bool refresh = false) {
            TransportLineData singleton = transportLineNotificationParameterQuery.GetSingleton<TransportLineData>();
            if (transportLineNotificationIcon == TransportLineNotificationIcon.VehicleNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_VehicleNotification, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetTransportLineNotifications(bool refresh = true) {
            EnableTransportLineNotification(TransportLineNotificationIcon.VehicleNotification, Setting.Instance.Notification.TransportLineVehicleNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableRouteNotification(RouteNotificationIcon routeNotificationIcon, bool value, bool refresh = false) {
            RouteConfigurationData singleton = routeNotificationParameterQuery.GetSingleton<RouteConfigurationData>();
            if (routeNotificationIcon == RouteNotificationIcon.PathfindNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_PathfindNotification, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetRouteNotifications(bool refresh = true) {
            EnableRouteNotification(RouteNotificationIcon.PathfindNotification, Setting.Instance.Notification.RoutePathfindNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableResourceConsumerNotification(ResourceConsumerNotificationIcon resourceConsumerNotificationIcon, bool value, bool refresh = false) {
            if (resourceConsumerNotificationIcon == ResourceConsumerNotificationIcon.NoResourceNotification) {
                SetAllResourceConsumerNoResourceNotifications(value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetResourceConsumerNotifications(bool refresh = true) {
            EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoResourceNotification, Setting.Instance.Notification.ResourceConsumerNoResourceNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableResourceConnectionNotification(ResourceConnectionNotificationIcon resourceConnectionNotificationIcon, bool value, bool refresh = false) {
            if (resourceConnectionNotificationIcon == ResourceConnectionNotificationIcon.ConnectionWarningNotification) {
                SetAllResourceConnectionWarningNotifications(value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetResourceConnectionNotifications(bool refresh = true) {
            EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.ConnectionWarningNotification, Setting.Instance.Notification.ResourceConnectionWarningNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnablePollutionNotification(PollutionNotificationIcon pollutionNotificationIcon, bool value, bool refresh = false) {
            PollutionParameterData singleton = pollutionNotificationParameterQuery.GetSingleton<PollutionParameterData>();
            if (pollutionNotificationIcon == PollutionNotificationIcon.AirPollutionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_AirPollutionNotification, value);
            }
            else if (pollutionNotificationIcon == PollutionNotificationIcon.NoisePollutionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NoisePollutionNotification, value);
            }
            else if (pollutionNotificationIcon == PollutionNotificationIcon.GroundPollutionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_GroundPollutionNotification, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetPollutionNotifications(bool refresh = true) {
            EnablePollutionNotification(PollutionNotificationIcon.AirPollutionNotification, Setting.Instance.Notification.PollutionAirPollutionNotification);
            EnablePollutionNotification(PollutionNotificationIcon.NoisePollutionNotification, Setting.Instance.Notification.PollutionNoisePollutionNotification);
            EnablePollutionNotification(PollutionNotificationIcon.GroundPollutionNotification, Setting.Instance.Notification.PollutionGroundPollutionNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnablePoliceNotification(PoliceNotificationIcon policeNotificationIcon, bool value, bool refresh = false) {
            PoliceConfigurationData singleton = policeNotificationParameterQuery.GetSingleton<PoliceConfigurationData>();
            if (policeNotificationIcon == PoliceNotificationIcon.TrafficAccidentNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_TrafficAccidentNotificationPrefab, value);
            }
            else if (policeNotificationIcon == PoliceNotificationIcon.CrimeSceneNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_CrimeSceneNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetPoliceNotifications(bool refresh = true) {
            EnablePoliceNotification(PoliceNotificationIcon.TrafficAccidentNotification, Setting.Instance.Notification.PoliceTrafficAccidentNotification);
            EnablePoliceNotification(PoliceNotificationIcon.CrimeSceneNotification, Setting.Instance.Notification.PoliceCrimeSceneNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableHealthcareNotification(HealthcareNotificationIcon healthcareNotificationIcon, bool value, bool refresh = false) {
            HealthcareParameterData singleton = healthcareNotificationParameterQuery.GetSingleton<HealthcareParameterData>();
            if (healthcareNotificationIcon == HealthcareNotificationIcon.AmbulanceNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_AmbulanceNotificationPrefab, value);
            }
            else if (healthcareNotificationIcon == HealthcareNotificationIcon.HearseNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_HearseNotificationPrefab, value);
            }
            else if (healthcareNotificationIcon == HealthcareNotificationIcon.FacilityFullNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_FacilityFullNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetHealthcareNotifications(bool refresh = true) {
            EnableHealthcareNotification(HealthcareNotificationIcon.AmbulanceNotification, Setting.Instance.Notification.HealthcareAmbulanceNotification);
            EnableHealthcareNotification(HealthcareNotificationIcon.HearseNotification, Setting.Instance.Notification.HealthcareHearseNotification);
            EnableHealthcareNotification(HealthcareNotificationIcon.FacilityFullNotification, Setting.Instance.Notification.HealthcareFacilityFullNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableGarbageNotification(GarbageNotificationIcon garbageNotificationIcon, bool value, bool refresh = false) {
            GarbageParameterData singleton = garbageNotificationParameterQuery.GetSingleton<GarbageParameterData>();
            if (garbageNotificationIcon == GarbageNotificationIcon.GarbageNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_GarbageNotificationPrefab, value);
            }
            else if (garbageNotificationIcon == GarbageNotificationIcon.FacilityFullNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_FacilityFullNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetGarbageNotifications(bool refresh = true) {
            EnableGarbageNotification(GarbageNotificationIcon.GarbageNotification, Setting.Instance.Notification.GarbageGarbageNotification);
            EnableGarbageNotification(GarbageNotificationIcon.FacilityFullNotification, Setting.Instance.Notification.GarbageFacilityFullNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableFireNotification(FireNotificationIcon fireNotificationIcon, bool value, bool refresh = false) {
            FireConfigurationData singleton = fireNotificationParameterQuery.GetSingleton<FireConfigurationData>();
            if (fireNotificationIcon == FireNotificationIcon.FireNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_FireNotificationPrefab, value);
            }
            else if (fireNotificationIcon == FireNotificationIcon.BurnedDownNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BurnedDownNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetFireNotifications(bool refresh = true) {
            EnableFireNotification(FireNotificationIcon.FireNotification, Setting.Instance.Notification.FireFireNotification);
            EnableFireNotification(FireNotificationIcon.BurnedDownNotification, Setting.Instance.Notification.FireBurnedDownNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableDisasterNotification(DisasterNotificationIcon disasterNotificationIcon, bool value, bool refresh = false) {
            DisasterConfigurationData singleton = disasterNotificationParameterQuery.GetSingleton<DisasterConfigurationData>();
            if (disasterNotificationIcon == DisasterNotificationIcon.WeatherDamageNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WeatherDamageNotificationPrefab, value);
            }
            else if (disasterNotificationIcon == DisasterNotificationIcon.WeatherDestroyedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WeatherDestroyedNotificationPrefab, value);
            }
            else if (disasterNotificationIcon == DisasterNotificationIcon.WaterDamageNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WaterDamageNotificationPrefab, value);
            }
            else if (disasterNotificationIcon == DisasterNotificationIcon.WaterDestroyedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WaterDestroyedNotificationPrefab, value);
            }
            else if (disasterNotificationIcon == DisasterNotificationIcon.DestroyedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_DestroyedNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetDisasterNotifications(bool refresh = true) {
            EnableDisasterNotification(DisasterNotificationIcon.WeatherDamageNotification, Setting.Instance.Notification.DisasterWeatherDamageNotification);
            EnableDisasterNotification(DisasterNotificationIcon.WeatherDestroyedNotification, Setting.Instance.Notification.DisasterWeatherDestroyedNotification);
            EnableDisasterNotification(DisasterNotificationIcon.WaterDamageNotification, Setting.Instance.Notification.DisasterWaterDamageNotification);
            EnableDisasterNotification(DisasterNotificationIcon.WaterDestroyedNotification, Setting.Instance.Notification.DisasterWaterDestroyedNotification);
            EnableDisasterNotification(DisasterNotificationIcon.DestroyedNotification, Setting.Instance.Notification.DisasterDestroyedNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableWorkProviderNotification(WorkProviderNotificationIcon workProviderNotificationIcon, bool value, bool refresh = false) {
            WorkProviderParameterData singleton = workProviderNotificationParameterQuery.GetSingleton<WorkProviderParameterData>();
            if (workProviderNotificationIcon == WorkProviderNotificationIcon.UneducatedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_UneducatedNotificationPrefab, value);
            }
            else if (workProviderNotificationIcon == WorkProviderNotificationIcon.EducatedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_EducatedNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetWorkProviderNotifications(bool refresh = true) {
            EnableWorkProviderNotification(WorkProviderNotificationIcon.UneducatedNotification, Setting.Instance.Notification.WorkProviderUneducatedNotification);
            EnableWorkProviderNotification(WorkProviderNotificationIcon.EducatedNotification, Setting.Instance.Notification.WorkProviderEducatedNotification);
            if (refresh)
                RefreshIcon();
        }

        public void SetCompanyNotifications(bool refresh = true) {
            EnableCompanyNotification(CompanyNotificationIcon.NoInputsNotification, Setting.Instance.Notification.CompanyNoInputsNotification);
            EnableCompanyNotification(CompanyNotificationIcon.NoCustomersNotification, Setting.Instance.Notification.CompanyNoCustomersNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableCompanyNotification(CompanyNotificationIcon companyNotificationIcon, bool value, bool refresh = false) {
            CompanyNotificationParameterData singleton = companyNotificationParameterQuery.GetSingleton<CompanyNotificationParameterData>();
            if (companyNotificationIcon == CompanyNotificationIcon.NoInputsNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NoInputsNotificationPrefab, value);
            }
            else if (companyNotificationIcon == CompanyNotificationIcon.NoCustomersNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NoCustomersNotificationPrefab, value);
            }
            if (refresh) {
                RefreshIcon();
            }
        }

        public void SetTrafficNotifications(bool refresh = true) {
            EnableTrafficNotification(TrafficNotificationIcon.BottleneckNotification, Setting.Instance.Notification.TrafficBottleneckNotification);
            EnableTrafficNotification(TrafficNotificationIcon.DeadEndNotification, Setting.Instance.Notification.TrafficDeadEndNotification);
            EnableTrafficNotification(TrafficNotificationIcon.RoadConnectionNotification, Setting.Instance.Notification.TrafficRoadConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.TrackConnectionNotification, Setting.Instance.Notification.TrafficTrackConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.CarConnectionNotification, Setting.Instance.Notification.TrafficCarConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.ShipConnectionNotification, Setting.Instance.Notification.TrafficShipConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.TrainConnectionNotification, Setting.Instance.Notification.TrafficTrainConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.PedestrianConnectionNotification, Setting.Instance.Notification.TrafficPedestrianConnectionNotification);
            EnableTrafficNotification(TrafficNotificationIcon.BicycleConnectionNotification, Setting.Instance.Notification.TrafficBicycleConnectionNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableTrafficNotification(TrafficNotificationIcon trafficNotificationIcon, bool value, bool refresh = false) {
            TrafficConfigurationData singleton = trafficConfigurationDataQuery.GetSingleton<TrafficConfigurationData>();
            if (trafficNotificationIcon == TrafficNotificationIcon.BottleneckNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BottleneckNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.DeadEndNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_DeadEndNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.RoadConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_RoadConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.TrackConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_TrackConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.CarConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_CarConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.ShipConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_ShipConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.TrainConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_TrainConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.PedestrianConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_PedestrianConnectionNotification, value);
            }
            else if (trafficNotificationIcon == TrafficNotificationIcon.BicycleConnectionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BicycleConnectionNotification, value);
            }

            if (refresh) {
                RefreshIcon();
            }
        }

        private void SetAllResourceConsumerNoResourceNotifications(bool value) {
            NativeArray<ResourceConsumerData> consumers = resourceConsumerNotificationParameterQuery.ToComponentDataArray<ResourceConsumerData>(Allocator.Temp);
            try {
                HashSet<Entity> seen = new();
                for (int i = 0; i < consumers.Length; i++) {
                    Entity notificationPrefab = consumers[i].m_NoResourceNotificationPrefab;
                    if (seen.Add(notificationPrefab)) {
                        SetNotificationIconDisplayEnabled(notificationPrefab, value);
                    }
                }
            }
            finally {
                consumers.Dispose();
            }
        }

        private void SetAllResourceConnectionWarningNotifications(bool value) {
            NativeArray<ResourceConnectionData> connections = resourceConnectionNotificationParameterQuery.ToComponentDataArray<ResourceConnectionData>(Allocator.Temp);
            try {
                HashSet<Entity> seen = new();
                for (int i = 0; i < connections.Length; i++) {
                    Entity notificationPrefab = connections[i].m_ConnectionWarningNotification;
                    if (seen.Add(notificationPrefab)) {
                        SetNotificationIconDisplayEnabled(notificationPrefab, value);
                    }
                }
            }
            finally {
                connections.Dispose();
            }
        }

        private void SetNotificationIconDisplayEnabled(Entity notificationPrefab, bool value) {
            if (notificationPrefab == Entity.Null || !EntityManager.HasComponent<NotificationIconDisplayData>(notificationPrefab)) {
                return;
            }

            EntityManager.SetComponentEnabled<NotificationIconDisplayData>(notificationPrefab, value);
        }

        public void SetBuildingNotifications(bool refresh = true) {
            EnableBuildingNotification(BuildingNotificationIcon.AbandonedCollapsedNotification, Setting.Instance.Notification.BuildingAbandonedCollapsedNotification);
            EnableBuildingNotification(BuildingNotificationIcon.AbandonedNotification, Setting.Instance.Notification.BuildingAbandonedNotification);
            EnableBuildingNotification(BuildingNotificationIcon.CondemnedNotification, Setting.Instance.Notification.BuildingCondemnedNotification);
            EnableBuildingNotification(BuildingNotificationIcon.TurnedOffNotification, Setting.Instance.Notification.BuildingTurnedOffNotification);
            EnableBuildingNotification(BuildingNotificationIcon.HighRentNotification, Setting.Instance.Notification.BuildingHighRentNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableBuildingNotification(BuildingNotificationIcon buildingNotificationIcon, bool value, bool refresh = false) {
            BuildingConfigurationData singleton = buildingConfigurationDataQuery.GetSingleton<BuildingConfigurationData>();
            if (buildingNotificationIcon == BuildingNotificationIcon.AbandonedCollapsedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_AbandonedCollapsedNotification, value);
            }
            else if (buildingNotificationIcon == BuildingNotificationIcon.AbandonedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_AbandonedNotification, value);
            }
            else if (buildingNotificationIcon == BuildingNotificationIcon.CondemnedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_CondemnedNotification, value);
            }
            else if (buildingNotificationIcon == BuildingNotificationIcon.TurnedOffNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_TurnedOffNotification, value);
            }
            else if (buildingNotificationIcon == BuildingNotificationIcon.HighRentNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_HighRentNotification, value);
            }

            if (refresh)
                RefreshIcon();
        }

        public void SetWaterPipeNotifications(bool refresh = true) {
            EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterNotification, Setting.Instance.Notification.WaterPipeWaterNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterNotification, Setting.Instance.Notification.WaterPipeDirtyWaterNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.SewageNotification, Setting.Instance.Notification.WaterPipeSewageNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterPipeNotConnectedNotification, Setting.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.SewagePipeNotConnectedNotification, Setting.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughWaterCapacityNotification, Setting.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSewageCapacityNotification, Setting.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughGroundwaterNotification, Setting.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSurfaceWaterNotification, Setting.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification);
            EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterPumpNotification, Setting.Instance.Notification.WaterPipeDirtyWaterPumpNotification);
            if (refresh)
                RefreshIcon();
        }

        public void EnableWaterPipeNotification(WaterPipeNotificationIcon waterPipeNotificationIcon, bool value, bool refresh = false) {
            WaterPipeParameterData singleton = waterPipeParameterQuery.GetSingleton<WaterPipeParameterData>();
            if (waterPipeNotificationIcon == WaterPipeNotificationIcon.WaterNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WaterNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.DirtyWaterNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_DirtyWaterNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.SewageNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_SewageNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.WaterPipeNotConnectedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_WaterPipeNotConnectedNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.SewagePipeNotConnectedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_SewagePipeNotConnectedNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.NotEnoughWaterCapacityNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughWaterCapacityNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.NotEnoughSewageCapacityNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughSewageCapacityNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.NotEnoughGroundwaterNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughGroundwaterNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.NotEnoughSurfaceWaterNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughSurfaceWaterNotification, value);
            }
            else if (waterPipeNotificationIcon == WaterPipeNotificationIcon.DirtyWaterPumpNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_DirtyWaterPumpNotification, value);
            }

            if (refresh) {
                RefreshIcon();
            }
        }

        public void SetElectricityNotifications(bool refresh = true) {
            EnableElectricityNotification(ElectricityNotificationIcon.ElectricityNotification, Setting.Instance.Notification.ElectricityElectricityNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.BottleneckNotification, Setting.Instance.Notification.ElectricityBottleneckNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.BuildingBottleneckNotification, Setting.Instance.Notification.ElectricityBuildingBottleneckNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughProductionNotification, Setting.Instance.Notification.ElectricityNotEnoughProductionNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.TransformerNotification, Setting.Instance.Notification.ElectricityTransformerNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughConnectedNotification, Setting.Instance.Notification.ElectricityNotEnoughConnectedNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.BatteryEmptyNotification, Setting.Instance.Notification.ElectricityBatteryEmptyNotification);
            EnableElectricityNotification(ElectricityNotificationIcon.LowVoltageNotConnected, Setting.Instance.Notification.ElectricityLowVoltageNotConnected);
            EnableElectricityNotification(ElectricityNotificationIcon.HighVoltageNotConnected, Setting.Instance.Notification.ElectricityHighVoltageNotConnected);
            if (refresh)
                RefreshIcon();
        }

        public void EnableElectricityNotification(ElectricityNotificationIcon electricityNotificationIcon, bool value, bool refresh = false) {
            ElectricityParameterData singleton = electricityParameterQuery.GetSingleton<ElectricityParameterData>();
            if (electricityNotificationIcon == ElectricityNotificationIcon.ElectricityNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_ElectricityNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.BottleneckNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BottleneckNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.BuildingBottleneckNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BuildingBottleneckNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.NotEnoughProductionNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughProductionNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.TransformerNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_TransformerNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.NotEnoughConnectedNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NotEnoughConnectedNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.BatteryEmptyNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_BatteryEmptyNotificationPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.LowVoltageNotConnected) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_LowVoltageNotConnectedPrefab, value);
            }
            else if (electricityNotificationIcon == ElectricityNotificationIcon.HighVoltageNotConnected) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_HighVoltageNotConnectedPrefab,
                    value);
            }

            if (refresh) {
                RefreshIcon();
            }
        }
    }
}
