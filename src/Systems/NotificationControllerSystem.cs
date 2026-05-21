// File: src/Systems/NotificationControllerSystem.cs
// Purpose: Contains a City Watchdog gameplay or UI system.

namespace CityWatchdog.Systems
{
    using CityWatchdog.Data;
    using Colossal.Serialization.Entities;
    using Game.Common;
    using Game.Notifications;
    using Game.Prefabs;
    using Game.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Unity.Collections;
    using Unity.Entities;

    public partial class NotificationControllerSystem : GameSystemBaseExtension {
        private StringBuilder logBuilder = null!;
        private EntityQuery iconQuery;
        private EntityQuery waterPipeParameterQuery;
        private PrefabSystem prefabSystem = null!;
        private EntityQuery notificationIconDisplayDataQuery;
        private EntityQuery electricityParameterQuery;
        private EntityQuery buildingConfigurationDataQuery;
        private EntityQuery trafficConfigurationDataQuery;
        private EntityQuery companyNotificationParameterQuery;
        private EntityQuery workProviderNotificationParameterQuery;
        private EntityQuery disasterNotificationParameterQuery;
        private EntityQuery fireNotificationParameterQuery;
        private EntityQuery garbageNotificationParameterQuery;
        private EntityQuery healthcareNotificationParameterQuery;
        private EntityQuery policeNotificationParameterQuery;
        private EntityQuery pollutionNotificationParameterQuery;
        private EntityQuery resourceConsumerNotificationParameterQuery;
        private EntityQuery routeNotificationParameterQuery;
        private EntityQuery transportLineNotificationParameterQuery;

        protected override void OnGameLoaded(Context serializationContext) {
            base.OnGameLoaded(serializationContext);
            SetElectricityNotifications();
            SetWaterPipeNotifications();
            SetBuildingNotifications();
            SetTrafficNotifications();
            SetCompanyNotifications();
            SetWorkProviderNotifications();
            SetDisasterNotifications();
            SetFireNotifications();
            SetGarbageNotifications();
            SetHealthcareNotifications();
            SetPoliceNotifications();
            SetPollutionNotifications();
            SetResourceConsumerNotifications();
            SetRouteNotifications();
            SetTransportLineNotifications();
    #if DEBUG
            Debug();
    #endif
        }

        protected override void OnCreate() {
            base.OnCreate();
            logBuilder = new();
            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            iconQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<Icon>(),
                ComponentType.Exclude<Deleted>()
            });

            notificationIconDisplayDataQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<NotificationIconDisplayData>(),
            });

            electricityParameterQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<ElectricityParameterData>()
            });
            waterPipeParameterQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<WaterPipeParameterData>()
            });
            buildingConfigurationDataQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<BuildingConfigurationData>()
            });
            trafficConfigurationDataQuery = GetEntityQuery(new ComponentType[] {
                ComponentType.ReadOnly<TrafficConfigurationData>()
            });
            companyNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<CompanyNotificationParameterData>());
            workProviderNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<WorkProviderParameterData>());
            disasterNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<DisasterConfigurationData>());
            fireNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<FireConfigurationData>());
            garbageNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<GarbageParameterData>());
            healthcareNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<HealthcareParameterData>());
            policeNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<PoliceConfigurationData>());
            pollutionNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<PollutionParameterData>());
            resourceConsumerNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<ResourceConsumerData>());
            routeNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<RouteConfigurationData>());
            transportLineNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<TransportLineData>());
            RequireForUpdate(electricityParameterQuery);
            RequireForUpdate(waterPipeParameterQuery);
            RequireForUpdate(buildingConfigurationDataQuery);
            RequireForUpdate(trafficConfigurationDataQuery);
            RequireForUpdate(companyNotificationParameterQuery);
            RequireForUpdate(workProviderNotificationParameterQuery);
            RequireForUpdate(disasterNotificationParameterQuery);
            RequireForUpdate(fireNotificationParameterQuery);
            RequireForUpdate(garbageNotificationParameterQuery);
            RequireForUpdate(healthcareNotificationParameterQuery);
            RequireForUpdate(policeNotificationParameterQuery);
            RequireForUpdate(pollutionNotificationParameterQuery);
            RequireForUpdate(resourceConsumerNotificationParameterQuery);
            RequireForUpdate(routeNotificationParameterQuery);
            RequireForUpdate(transportLineNotificationParameterQuery);
        }

        private readonly Dictionary<Entity, int> EntityDictionary = new();

        public void Refresh() {
            EntityDictionary.Clear();
            NativeArray<ArchetypeChunk> nativeArray = iconQuery.ToArchetypeChunkArray(Allocator.TempJob);
            ComponentTypeHandle<PrefabRef> prefabRefTypeHandle = GetComponentTypeHandle<PrefabRef>();
            for (int i = 0; i < nativeArray.Length; i++) {
                NativeArray<PrefabRef> nativeArray2 = nativeArray[i].GetNativeArray(ref prefabRefTypeHandle);
                for (int j = 0; j < nativeArray2.Length; j++) {
                    Entity prefab = nativeArray2[j].m_Prefab;
                    if (EntityDictionary.TryGetValue(prefab, out int num)) {
                        EntityDictionary[prefab] = num + 1;
                    }
                    else {
                        EntityDictionary.Add(prefab, 1);
                    }
                }
            }

            nativeArray.Dispose();
            if (EntityDictionary.Any()) {
                foreach (KeyValuePair<Entity, int> item in EntityDictionary) {
                    CityWatchdog.Mod.DebugLog(() => $"{prefabSystem.GetPrefab<NotificationIconPrefab>(item.Key).name} | {item.Value}");
                    //EnableNotification(item.Key, Act);
                }
            }
        }

        public void DebugNotificationIconPrefab() {
            CityWatchdog.Mod.DebugLog(() => "Debug NotificationIconPrefab");
            NativeArray<Entity> entityArray = notificationIconDisplayDataQuery.ToEntityArray(Allocator.TempJob);
            foreach (Entity item in entityArray) {
                CityWatchdog.Mod.DebugLog(() => $"{prefabSystem.GetPrefab<NotificationIconPrefab>(item).name}");
            }

            entityArray.Dispose();
            CityWatchdog.Mod.DebugLog(() => "Debug NotificationIconPrefab completed");
        }

        public void EnableNotification(Entity entity, bool enabled) {
            EntityManager.SetComponentEnabled<NotificationIconDisplayData>(entity, enabled);
            RefreshIcon();
        }


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
            ResourceConsumerData singleton = resourceConsumerNotificationParameterQuery.GetSingleton<ResourceConsumerData>();
            if (resourceConsumerNotificationIcon == ResourceConsumerNotificationIcon.NoResourceNotification) {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(singleton.m_NoResourceNotificationPrefab, value);
            }
            if (refresh)
                RefreshIcon();
        }

        public void SetResourceConsumerNotifications(bool refresh = true) {
            EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoResourceNotification, Setting.Instance.Notification.ResourceConsumerNoResourceNotification);
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

            if (refresh) {
                RefreshIcon();
            }
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



        public void SetAllNotifications(bool enabled)
        {
            SetAllNotificationSettings(enabled);

            SetElectricityNotifications(false);
            SetWaterPipeNotifications(false);
            SetBuildingNotifications(false);
            SetTrafficNotifications(false);
            SetCompanyNotifications(false);
            SetWorkProviderNotifications(false);
            SetDisasterNotifications(false);
            SetFireNotifications(false);
            SetGarbageNotifications(false);
            SetHealthcareNotifications(false);
            SetPoliceNotifications(false);
            SetPollutionNotifications(false);
            SetResourceConsumerNotifications(false);
            SetRouteNotifications(false);
            SetTransportLineNotifications(false);

            RefreshIcon();
        }

        private static void SetAllNotificationSettings(bool enabled)
        {
            Setting.NotificationSetting notification = Setting.Instance.Notification;
            PropertyInfo[] properties = typeof(Setting.NotificationSetting).GetProperties(
                BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(bool) && property.CanWrite)
                {
                    property.SetValue(notification, enabled);
                }
            }
        }


        public void RefreshIcon() => World.GetOrCreateSystemManaged<IconClusterSystem>().RecalculateClusters();

    }
}
