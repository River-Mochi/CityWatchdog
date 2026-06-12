// File: src/Systems/AlertIconSystem.cs
// Purpose: Applies City Watchdog notification icon settings to vanilla alert prefabs.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game.Common;
    using Game.Notifications;
    using Game.Prefabs;
    using Game.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Unity.Collections;
    using Unity.Entities;

    public partial class AlertIconSystem : GameSystemBaseExtension {
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
        private EntityQuery resourceConnectionNotificationParameterQuery;
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
            SetResourceConnectionNotifications();
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
            resourceConnectionNotificationParameterQuery = GetEntityQuery(ComponentType.ReadOnly<ResourceConnectionData>());
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
            SetResourceConnectionNotifications(false);
            SetRouteNotifications(false);
            SetTransportLineNotifications(false);

            RefreshIcon();
        }

        private static void SetAllNotificationSettings(bool enabled)
        {
            Setting.NotificationSetting notification = Setting.Instance.Notification;

            notification.ElectricityElectricityNotification = enabled;
            notification.ElectricityBottleneckNotification = enabled;
            notification.ElectricityBuildingBottleneckNotification = enabled;
            notification.ElectricityNotEnoughProductionNotification = enabled;
            notification.ElectricityTransformerNotification = enabled;
            notification.ElectricityNotEnoughConnectedNotification = enabled;
            notification.ElectricityBatteryEmptyNotification = enabled;
            notification.ElectricityLowVoltageNotConnected = enabled;
            notification.ElectricityHighVoltageNotConnected = enabled;

            notification.WaterPipeWaterNotification = enabled;
            notification.WaterPipeDirtyWaterNotification = enabled;
            notification.WaterPipeSewageNotification = enabled;
            notification.WaterPipeWaterPipeNotConnectedNotification = enabled;
            notification.WaterPipeSewagePipeNotConnectedNotification = enabled;
            notification.WaterPipeNotEnoughWaterCapacityNotification = enabled;
            notification.WaterPipeNotEnoughSewageCapacityNotification = enabled;
            notification.WaterPipeNotEnoughGroundwaterNotification = enabled;
            notification.WaterPipeNotEnoughSurfaceWaterNotification = enabled;
            notification.WaterPipeDirtyWaterPumpNotification = enabled;

            notification.BuildingAbandonedCollapsedNotification = enabled;
            notification.BuildingAbandonedNotification = enabled;
            notification.BuildingCondemnedNotification = enabled;
            notification.BuildingTurnedOffNotification = enabled;
            notification.BuildingHighRentNotification = enabled;

            notification.TrafficBottleneckNotification = enabled;
            notification.TrafficDeadEndNotification = enabled;
            notification.TrafficRoadConnectionNotification = enabled;
            notification.TrafficTrackConnectionNotification = enabled;
            notification.TrafficCarConnectionNotification = enabled;
            notification.TrafficShipConnectionNotification = enabled;
            notification.TrafficTrainConnectionNotification = enabled;
            notification.TrafficPedestrianConnectionNotification = enabled;
            notification.TrafficBicycleConnectionNotification = enabled;

            notification.CompanyNoInputsNotification = enabled;
            notification.CompanyNoCustomersNotification = enabled;

            notification.WorkProviderUneducatedNotification = enabled;
            notification.WorkProviderEducatedNotification = enabled;

            notification.DisasterWeatherDamageNotification = enabled;
            notification.DisasterWeatherDestroyedNotification = enabled;
            notification.DisasterWaterDamageNotification = enabled;
            notification.DisasterWaterDestroyedNotification = enabled;
            notification.DisasterDestroyedNotification = enabled;

            notification.FireFireNotification = enabled;
            notification.FireBurnedDownNotification = enabled;

            notification.GarbageGarbageNotification = enabled;
            notification.GarbageFacilityFullNotification = enabled;

            notification.HealthcareAmbulanceNotification = enabled;
            notification.HealthcareHearseNotification = enabled;
            notification.HealthcareFacilityFullNotification = enabled;

            notification.PoliceTrafficAccidentNotification = enabled;
            notification.PoliceCrimeSceneNotification = enabled;

            notification.PollutionAirPollutionNotification = enabled;
            notification.PollutionNoisePollutionNotification = enabled;
            notification.PollutionGroundPollutionNotification = enabled;

            notification.ResourceConsumerNoResourceNotification = enabled;
            notification.ResourceConnectionWarningNotification = enabled;
            notification.RoutePathfindNotification = enabled;
            notification.TransportLineVehicleNotification = enabled;
        }


        public void RefreshIcon() => World.GetOrCreateSystemManaged<IconClusterSystem>().RecalculateClusters();

    }
}
