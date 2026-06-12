// File: src/Systems/CityWatchdogUISystem.cs
// Purpose: Contains a City Watchdog gameplay or UI system.

namespace CityWatchdog.Systems
{
    using CityWatchdog.Data;
    using CS2Shared.RiverMochi;
    using Colossal.UI.Binding;
    using Game;
    using Game.Input;
    using Game.SceneFlow;
    using System;

    public partial class CityWatchdogUISystem : UISystemBaseExtension {

        private AlertIconSystem alertIconSystem = null!;
        private ProxyAction? toggleNotificationsAction;
        private ProxyAction? toggleNotificationPanelAction;
        private BoolBinding panelVisibleBinding = null!;
        private ValueBinding<bool>? moneyViewBinding;
        private ValueBinding<int>? moneyViewModeBinding;
        private ValueBinding<int>? moneyTooltipModeBinding;
        private ValueBinding<int>? moneyTooltipFontScaleBinding;
        private ValueBinding<int>? populationTooltipFontScaleBinding;

        private BoolBinding electricityElectricityNotificationBinding = null!;
        private BoolBinding electricityBottleneckNotificationBinding = null!;
        private BoolBinding electricityBuildingBottleneckNotificationBinding = null!;
        private BoolBinding electricityNotEnoughProductionNotificationBinding = null!;
        private BoolBinding electricityTransformerNotificationBinding = null!;
        private BoolBinding electricityNotEnoughConnectedNotificationBinding = null!;
        private BoolBinding electricityBatteryEmptyNotificationBinding = null!;
        private BoolBinding electricityLowVoltageNotConnectedBinding = null!;
        private BoolBinding electricityHighVoltageNotConnectedBinding = null!;

        private BoolBinding waterPipeWaterNotificationBinding = null!;
        private BoolBinding waterPipeDirtyWaterNotificationBinding = null!;
        private BoolBinding waterPipeSewageNotificationBinding = null!;
        private BoolBinding waterPipeWaterPipeNotConnectedNotificationBinding = null!;
        private BoolBinding waterPipeSewagePipeNotConnectedNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughWaterCapacityNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughSewageCapacityNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughGroundwaterNotificationBinding = null!;
        private BoolBinding waterPipeNotEnoughSurfaceWaterNotificationBinding = null!;
        private BoolBinding waterPipeDirtyWaterPumpNotificationBinding = null!;

        private BoolBinding buildingAbandonedCollapsedNotificationBinding = null!;
        private BoolBinding buildingAbandonedNotificationBinding = null!;
        private BoolBinding buildingCondemnedNotificationBinding = null!;
        private BoolBinding buildingTurnedOffNotificationBinding = null!;
        private BoolBinding buildingHighRentNotificationBinding = null!;

        private BoolBinding trafficBottleneckNotificationBinding = null!;
        private BoolBinding trafficDeadEndNotificationBinding = null!;
        private BoolBinding trafficRoadConnectionNotificationBinding = null!;
        private BoolBinding trafficTrackConnectionNotificationBinding = null!;
        private BoolBinding trafficCarConnectionNotificationBinding = null!;
        private BoolBinding trafficShipConnectionNotificationBinding = null!;
        private BoolBinding trafficTrainConnectionNotificationBinding = null!;
        private BoolBinding trafficPedestrianConnectionNotificationBinding = null!;
        private BoolBinding trafficBicycleConnectionNotificationBinding = null!;

        private BoolBinding companyNoInputsNotificationBinding = null!;
        private BoolBinding companyNoCustomersNotificationBinding = null!;

        private BoolBinding workProviderUneducatedNotificationBinding = null!;
        private BoolBinding workProviderEducatedNotificationBinding = null!;

        private BoolBinding disasterWeatherDamageNotificationBinding = null!;
        private BoolBinding disasterWeatherDestroyedNotificationBinding = null!;
        private BoolBinding disasterWaterDamageNotificationBinding = null!;
        private BoolBinding disasterWaterDestroyedNotificationBinding = null!;
        private BoolBinding disasterDestroyedNotificationBinding = null!;

        private BoolBinding fireFireNotificationBinding = null!;
        private BoolBinding fireBurnedDownNotificationBinding = null!;

        private BoolBinding garbageGarbageNotificationBinding = null!;
        private BoolBinding garbageFacilityFullNotificationBinding = null!;

        private BoolBinding healthcareAmbulanceNotificationBinding = null!;
        private BoolBinding healthcareHearseNotificationBinding = null!;
        private BoolBinding healthcareFacilityFullNotificationBinding = null!;

        private BoolBinding policeTrafficAccidentNotificationBinding = null!;
        private BoolBinding policeCrimeSceneNotificationBinding = null!;

        private BoolBinding pollutionAirPollutionNotificationBinding = null!;
        private BoolBinding pollutionNoisePollutionNotificationBinding = null!;
        private BoolBinding pollutionGroundPollutionNotificationBinding = null!;

        private BoolBinding resourceConsumerNoResourceNotificationBinding = null!;
        private BoolBinding resourceConsumerNoFuelNotificationBinding = null!;
        private BoolBinding resourceConnectionWarningNotificationBinding = null!;
        private BoolBinding resourceConnectionOilPipeNotConnectedNotificationBinding = null!;
        private BoolBinding resourceConnectionFishingPierNotConnectedNotificationBinding = null!;

        private BoolBinding routePathfindNotificationBinding = null!;
        private BoolBinding routeGateBypassNotificationBinding = null!;

        private BoolBinding transportLineVehicleNotificationBinding = null!;

        protected override void OnCreate() {
            base.OnCreate();

            alertIconSystem = World.GetOrCreateSystemManaged<AlertIconSystem>();
            InitializeKeybindActions();

            panelVisibleBinding = AddBoolBindingAndTriggerBinding("ControlPanelEnabled", false, OnControlPanelBindingToggle);
            AddBoolTriggerBinding("ToggleAllNotifications", ApplyAllNotificationToggles);
            moneyViewBinding = AddValueBinding(nameof(Setting.MoneyView), Setting.Instance.MoneyView);
            moneyViewModeBinding = AddValueBinding(nameof(Setting.MoneyViewMode), Setting.Instance.MoneyViewMode);
            moneyTooltipModeBinding = AddValueBinding(nameof(Setting.MoneyTooltipMode), Setting.Instance.MoneyTooltipMode);
            moneyTooltipFontScaleBinding = AddValueBinding(nameof(Setting.MoneyTooltipFontScale), Setting.Instance.MoneyTooltipFontScale);
            populationTooltipFontScaleBinding = AddValueBinding(nameof(Setting.PopulationTooltipFontScale), Setting.Instance.PopulationTooltipFontScale);

            electricityElectricityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityElectricityNotification), Setting.Instance.Notification.ElectricityElectricityNotification, OnElectricityElectricityNotificationToggle);
            electricityBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityBottleneckNotification), Setting.Instance.Notification.ElectricityBottleneckNotification, OnElectricityBottleneckNotificationToggle);
            electricityBuildingBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityBuildingBottleneckNotification), Setting.Instance.Notification.ElectricityBuildingBottleneckNotification, OnElectricityBuildingBottleneckNotificationToggle);
            electricityNotEnoughProductionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityNotEnoughProductionNotification), Setting.Instance.Notification.ElectricityNotEnoughProductionNotification, OnElectricityNotEnoughProductionNotificationToggle);
            electricityTransformerNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityTransformerNotification), Setting.Instance.Notification.ElectricityTransformerNotification, OnElectricityTransformerNotificationToggle);
            electricityNotEnoughConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityNotEnoughConnectedNotification), Setting.Instance.Notification.ElectricityNotEnoughConnectedNotification, OnElectricityNotEnoughConnectedNotificationToggle);
            electricityBatteryEmptyNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityBatteryEmptyNotification), Setting.Instance.Notification.ElectricityBatteryEmptyNotification, OnElectricityBatteryEmptyNotificationToggle);
            electricityLowVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityLowVoltageNotConnected), Setting.Instance.Notification.ElectricityLowVoltageNotConnected, OnElectricityLowVoltageNotConnectedToggle);
            electricityHighVoltageNotConnectedBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ElectricityHighVoltageNotConnected), Setting.Instance.Notification.ElectricityHighVoltageNotConnected, OnElectricityHighVoltageNotConnectedToggle);

            waterPipeWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeWaterNotification), Setting.Instance.Notification.WaterPipeWaterNotification, OnWaterPipeWaterNotificationToggle);
            waterPipeDirtyWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeDirtyWaterNotification), Setting.Instance.Notification.WaterPipeDirtyWaterNotification, OnWaterPipeDirtyWaterNotificationToggle);
            waterPipeSewageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeSewageNotification), Setting.Instance.Notification.WaterPipeSewageNotification, OnWaterPipeSewageNotificationToggle);
            waterPipeWaterPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification), Setting.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification, OnWaterPipeWaterPipeNotConnectedNotificationToggle);
            waterPipeSewagePipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification), Setting.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification, OnWaterPipeSewagePipeNotConnectedNotificationToggle);
            waterPipeNotEnoughWaterCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification), Setting.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification, OnWaterPipeNotEnoughWaterCapacityNotificationToggle);
            waterPipeNotEnoughSewageCapacityNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification), Setting.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification, OnWaterPipeNotEnoughSewageCapacityNotificationToggle);
            waterPipeNotEnoughGroundwaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification), Setting.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification, OnWaterPipeNotEnoughGroundwaterNotificationToggle);
            waterPipeNotEnoughSurfaceWaterNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification), Setting.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification, OnWaterPipeNotEnoughSurfaceWaterNotificationToggle);
            waterPipeDirtyWaterPumpNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WaterPipeDirtyWaterPumpNotification), Setting.Instance.Notification.WaterPipeDirtyWaterPumpNotification, OnWaterPipeDirtyWaterPumpNotificationToggle);

            buildingAbandonedCollapsedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.BuildingAbandonedCollapsedNotification), Setting.Instance.Notification.BuildingAbandonedCollapsedNotification, OnBuildingAbandonedCollapsedNotificationToggle);
            buildingAbandonedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.BuildingAbandonedNotification), Setting.Instance.Notification.BuildingAbandonedNotification, OnBuildingAbandonedNotificationToggle);
            buildingCondemnedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.BuildingCondemnedNotification), Setting.Instance.Notification.BuildingCondemnedNotification, OnBuildingCondemnedNotificationToggle);
            buildingTurnedOffNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.BuildingTurnedOffNotification), Setting.Instance.Notification.BuildingTurnedOffNotification, OnBuildingTurnedOffNotificationToggle);
            buildingHighRentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.BuildingHighRentNotification), Setting.Instance.Notification.BuildingHighRentNotification, OnBuildingHighRentNotificationToggle);

            trafficBottleneckNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficBottleneckNotification), Setting.Instance.Notification.TrafficBottleneckNotification, OnTrafficBottleneckNotificationToggle);
            trafficDeadEndNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficDeadEndNotification), Setting.Instance.Notification.TrafficDeadEndNotification, OnTrafficDeadEndNotificationToggle);
            trafficRoadConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficRoadConnectionNotification), Setting.Instance.Notification.TrafficRoadConnectionNotification, OnTrafficRoadConnectionNotificationToggle);
            trafficTrackConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficTrackConnectionNotification), Setting.Instance.Notification.TrafficTrackConnectionNotification, OnTrafficTrackConnectionNotificationToggle);
            trafficCarConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficCarConnectionNotification), Setting.Instance.Notification.TrafficCarConnectionNotification, OnTrafficCarConnectionNotificationToggle);
            trafficShipConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficShipConnectionNotification), Setting.Instance.Notification.TrafficShipConnectionNotification, OnTrafficShipConnectionNotificationToggle);
            trafficTrainConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficTrainConnectionNotification), Setting.Instance.Notification.TrafficTrainConnectionNotification, OnTrafficTrainConnectionNotificationToggle);
            trafficPedestrianConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficPedestrianConnectionNotification), Setting.Instance.Notification.TrafficPedestrianConnectionNotification, OnTrafficPedestrianConnectionNotificationToggle);
            trafficBicycleConnectionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TrafficBicycleConnectionNotification), Setting.Instance.Notification.TrafficBicycleConnectionNotification, OnTrafficBicycleConnectionNotificationToggle);

            companyNoInputsNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.CompanyNoInputsNotification), Setting.Instance.Notification.CompanyNoInputsNotification, OnCompanyNoInputsNotificationToggle);
            companyNoCustomersNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.CompanyNoCustomersNotification), Setting.Instance.Notification.CompanyNoCustomersNotification, OnCompanyNoCustomersNotificationToggle);

            workProviderUneducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WorkProviderUneducatedNotification), Setting.Instance.Notification.WorkProviderUneducatedNotification, OnWorkProviderUneducatedNotificationToggle);
            workProviderEducatedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.WorkProviderEducatedNotification), Setting.Instance.Notification.WorkProviderEducatedNotification, OnWorkProviderEducatedNotificationToggle);

            disasterWeatherDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.DisasterWeatherDamageNotification), Setting.Instance.Notification.DisasterWeatherDamageNotification, OnDisasterWeatherDamageNotificationToggle);
            disasterWeatherDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.DisasterWeatherDestroyedNotification), Setting.Instance.Notification.DisasterWeatherDestroyedNotification, OnDisasterWeatherDestroyedNotificationToggle);
            disasterWaterDamageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.DisasterWaterDamageNotification), Setting.Instance.Notification.DisasterWaterDamageNotification, OnDisasterWaterDamageNotificationToggle);
            disasterWaterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.DisasterWaterDestroyedNotification), Setting.Instance.Notification.DisasterWaterDestroyedNotification, OnDisasterWaterDestroyedNotificationToggle);
            disasterDestroyedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.DisasterDestroyedNotification), Setting.Instance.Notification.DisasterDestroyedNotification, OnDisasterDestroyedNotificationToggle);

            fireFireNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.FireFireNotification), Setting.Instance.Notification.FireFireNotification, OnFireFireNotificationToggle);
            fireBurnedDownNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.FireBurnedDownNotification), Setting.Instance.Notification.FireBurnedDownNotification, OnFireBurnedDownNotificationToggle);

            garbageGarbageNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.GarbageGarbageNotification), Setting.Instance.Notification.GarbageGarbageNotification, OnGarbageGarbageNotificationToggle);
            garbageFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.GarbageFacilityFullNotification), Setting.Instance.Notification.GarbageFacilityFullNotification, OnGarbageFacilityFullNotificationToggle);

            healthcareAmbulanceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.HealthcareAmbulanceNotification), Setting.Instance.Notification.HealthcareAmbulanceNotification, OnHealthcareAmbulanceNotificationToggle);
            healthcareHearseNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.HealthcareHearseNotification), Setting.Instance.Notification.HealthcareHearseNotification, OnHealthcareHearseNotificationToggle);
            healthcareFacilityFullNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.HealthcareFacilityFullNotification), Setting.Instance.Notification.HealthcareFacilityFullNotification, OnHealthcareFacilityFullNotificationToggle);

            policeTrafficAccidentNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.PoliceTrafficAccidentNotification), Setting.Instance.Notification.PoliceTrafficAccidentNotification, OnPoliceTrafficAccidentNotificationToggle);
            policeCrimeSceneNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.PoliceCrimeSceneNotification), Setting.Instance.Notification.PoliceCrimeSceneNotification, OnPoliceCrimeSceneNotificationToggle);

            pollutionAirPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.PollutionAirPollutionNotification), Setting.Instance.Notification.PollutionAirPollutionNotification, OnPollutionAirPollutionNotificationToggle);
            pollutionNoisePollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.PollutionNoisePollutionNotification), Setting.Instance.Notification.PollutionNoisePollutionNotification, OnPollutionNoisePollutionNotificationToggle);
            pollutionGroundPollutionNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.PollutionGroundPollutionNotification), Setting.Instance.Notification.PollutionGroundPollutionNotification, OnPollutionGroundPollutionNotificationToggle);

            resourceConsumerNoResourceNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ResourceConsumerNoResourceNotification), Setting.Instance.Notification.ResourceConsumerNoResourceNotification, OnResourceConsumerNoResourceNotificationToggle);
            resourceConsumerNoFuelNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ResourceConsumerNoFuelNotification), Setting.Instance.Notification.ResourceConsumerNoFuelNotification, OnResourceConsumerNoFuelNotificationToggle);
            resourceConnectionWarningNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ResourceConnectionWarningNotification), Setting.Instance.Notification.ResourceConnectionWarningNotification, OnResourceConnectionWarningNotificationToggle);
            resourceConnectionOilPipeNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification), Setting.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification, OnResourceConnectionOilPipeNotConnectedNotificationToggle);
            resourceConnectionFishingPierNotConnectedNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification), Setting.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification, OnResourceConnectionFishingPierNotConnectedNotificationToggle);

            routePathfindNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.RoutePathfindNotification), Setting.Instance.Notification.RoutePathfindNotification, OnRoutePathfindNotificationToggle);
            routeGateBypassNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.RouteGateBypassNotification), Setting.Instance.Notification.RouteGateBypassNotification, OnRouteGateBypassNotificationToggle);

            transportLineVehicleNotificationBinding = AddBoolBindingAndTriggerBinding(nameof(Setting.Instance.Notification.TransportLineVehicleNotification), Setting.Instance.Notification.TransportLineVehicleNotification, OnTransportLineVehicleNotificationToggle);
        }



        #region OnElectricityNotificationToggle
        private void OnElectricityElectricityNotificationToggle(bool value) {
            electricityElectricityNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityElectricityNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.ElectricityNotification, value, true);
        }
        private void OnElectricityBottleneckNotificationToggle(bool value) {
            electricityBottleneckNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityBottleneckNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnElectricityBuildingBottleneckNotificationToggle(bool value) {
            electricityBuildingBottleneckNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityBuildingBottleneckNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BuildingBottleneckNotification, value, true);
        }
        private void OnElectricityNotEnoughProductionNotificationToggle(bool value) {
            electricityNotEnoughProductionNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityNotEnoughProductionNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughProductionNotification, value, true);
        }
        private void OnElectricityTransformerNotificationToggle(bool value) {
            electricityTransformerNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityTransformerNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.TransformerNotification, value, true);
        }
        private void OnElectricityNotEnoughConnectedNotificationToggle(bool value) {
            electricityNotEnoughConnectedNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityNotEnoughConnectedNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.NotEnoughConnectedNotification, value, true);
        }
        private void OnElectricityBatteryEmptyNotificationToggle(bool value) {
            electricityBatteryEmptyNotificationBinding.Update(value);
            Setting.Instance.Notification.ElectricityBatteryEmptyNotification = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.BatteryEmptyNotification, value, true);
        }
        private void OnElectricityLowVoltageNotConnectedToggle(bool value) {
            electricityLowVoltageNotConnectedBinding.Update(value);
            Setting.Instance.Notification.ElectricityLowVoltageNotConnected = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.LowVoltageNotConnected, value, true);
        }
        private void OnElectricityHighVoltageNotConnectedToggle(bool value) {
            electricityHighVoltageNotConnectedBinding.Update(value);
            Setting.Instance.Notification.ElectricityHighVoltageNotConnected = value;
            alertIconSystem.EnableElectricityNotification(ElectricityNotificationIcon.HighVoltageNotConnected, value, true);
        }

        #endregion

        #region OnWaterPipeNotificationToggle
        private void OnWaterPipeWaterNotificationToggle(bool value) {
            waterPipeWaterNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterNotificationToggle(bool value) {
            waterPipeDirtyWaterNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeDirtyWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterNotification, value, true);
        }
        private void OnWaterPipeSewageNotificationToggle(bool value) {
            waterPipeSewageNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeSewageNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewageNotification, value, true);
        }
        private void OnWaterPipeWaterPipeNotConnectedNotificationToggle(bool value) {
            waterPipeWaterPipeNotConnectedNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeWaterPipeNotConnectedNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.WaterPipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeSewagePipeNotConnectedNotificationToggle(bool value) {
            waterPipeSewagePipeNotConnectedNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeSewagePipeNotConnectedNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.SewagePipeNotConnectedNotification, value, true);
        }
        private void OnWaterPipeNotEnoughWaterCapacityNotificationToggle(bool value) {
            waterPipeNotEnoughWaterCapacityNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeNotEnoughWaterCapacityNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughWaterCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSewageCapacityNotificationToggle(bool value) {
            waterPipeNotEnoughSewageCapacityNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeNotEnoughSewageCapacityNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSewageCapacityNotification, value, true);
        }
        private void OnWaterPipeNotEnoughGroundwaterNotificationToggle(bool value) {
            waterPipeNotEnoughGroundwaterNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeNotEnoughGroundwaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughGroundwaterNotification, value, true);
        }
        private void OnWaterPipeNotEnoughSurfaceWaterNotificationToggle(bool value) {
            waterPipeNotEnoughSurfaceWaterNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeNotEnoughSurfaceWaterNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.NotEnoughSurfaceWaterNotification, value, true);
        }
        private void OnWaterPipeDirtyWaterPumpNotificationToggle(bool value) {
            waterPipeDirtyWaterPumpNotificationBinding.Update(value);
            Setting.Instance.Notification.WaterPipeDirtyWaterPumpNotification = value;
            alertIconSystem.EnableWaterPipeNotification(WaterPipeNotificationIcon.DirtyWaterPumpNotification, value, true);
        }
        #endregion

        #region OnBuildingNotificationToggle
        private void OnBuildingAbandonedCollapsedNotificationToggle(bool value) {
            buildingAbandonedCollapsedNotificationBinding.Update(value);
            Setting.Instance.Notification.BuildingAbandonedCollapsedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedCollapsedNotification, value, true);
        }
        private void OnBuildingAbandonedNotificationToggle(bool value) {
            buildingAbandonedNotificationBinding.Update(value);
            Setting.Instance.Notification.BuildingAbandonedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.AbandonedNotification, value, true);
        }
        private void OnBuildingCondemnedNotificationToggle(bool value) {
            buildingCondemnedNotificationBinding.Update(value);
            Setting.Instance.Notification.BuildingCondemnedNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.CondemnedNotification, value, true);
        }
        private void OnBuildingTurnedOffNotificationToggle(bool value) {
            buildingTurnedOffNotificationBinding.Update(value);
            Setting.Instance.Notification.BuildingTurnedOffNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.TurnedOffNotification, value, true);
        }
        private void OnBuildingHighRentNotificationToggle(bool value) {
            buildingHighRentNotificationBinding.Update(value);
            Setting.Instance.Notification.BuildingHighRentNotification = value;
            alertIconSystem.EnableBuildingNotification(BuildingNotificationIcon.HighRentNotification, value, true);
        }
        #endregion

        #region OnTrafficNotificationToggle
        private void OnTrafficBottleneckNotificationToggle(bool value) {
            trafficBottleneckNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficBottleneckNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BottleneckNotification, value, true);
        }
        private void OnTrafficDeadEndNotificationToggle(bool value) {
            trafficDeadEndNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficDeadEndNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.DeadEndNotification, value, true);
        }
        private void OnTrafficRoadConnectionNotificationToggle(bool value) {
            trafficRoadConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficRoadConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.RoadConnectionNotification, value, true);
        }
        private void OnTrafficTrackConnectionNotificationToggle(bool value) {
            trafficTrackConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficTrackConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrackConnectionNotification, value, true);
        }
        private void OnTrafficCarConnectionNotificationToggle(bool value) {
            trafficCarConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficCarConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.CarConnectionNotification, value, true);
        }
        private void OnTrafficShipConnectionNotificationToggle(bool value) {
            trafficShipConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficShipConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.ShipConnectionNotification, value, true);
        }
        private void OnTrafficTrainConnectionNotificationToggle(bool value) {
            trafficTrainConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficTrainConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.TrainConnectionNotification, value, true);
        }
        private void OnTrafficPedestrianConnectionNotificationToggle(bool value) {
            trafficPedestrianConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficPedestrianConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.PedestrianConnectionNotification, value, true);
        }
        private void OnTrafficBicycleConnectionNotificationToggle(bool value) {
            trafficBicycleConnectionNotificationBinding.Update(value);
            Setting.Instance.Notification.TrafficBicycleConnectionNotification = value;
            alertIconSystem.EnableTrafficNotification(TrafficNotificationIcon.BicycleConnectionNotification, value, true);
        }
        #endregion

        #region OnCompanyNotificationToggle
        private void OnCompanyNoInputsNotificationToggle(bool value) {
            companyNoInputsNotificationBinding.Update(value);
            Setting.Instance.Notification.CompanyNoInputsNotification = value;
            alertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoInputsNotification, value, true);
        }
        private void OnCompanyNoCustomersNotificationToggle(bool value) {
            companyNoCustomersNotificationBinding.Update(value);
            Setting.Instance.Notification.CompanyNoCustomersNotification = value;
            alertIconSystem.EnableCompanyNotification(CompanyNotificationIcon.NoCustomersNotification, value, true);
        }
        #endregion

        #region OnWorkProviderNotificationToggle
        private void OnWorkProviderUneducatedNotificationToggle(bool value) {
            workProviderUneducatedNotificationBinding.Update(value);
            Setting.Instance.Notification.WorkProviderUneducatedNotification = value;
            alertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.UneducatedNotification, value, true);
        }
        private void OnWorkProviderEducatedNotificationToggle(bool value) {
            workProviderEducatedNotificationBinding.Update(value);
            Setting.Instance.Notification.WorkProviderEducatedNotification = value;
            alertIconSystem.EnableWorkProviderNotification(WorkProviderNotificationIcon.EducatedNotification, value, true);
        }
        #endregion

        #region OnDisasterNotificationToggle
        private void OnDisasterWeatherDamageNotificationToggle(bool value) {
            disasterWeatherDamageNotificationBinding.Update(value);
            Setting.Instance.Notification.DisasterWeatherDamageNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDamageNotification, value, true);
        }
        private void OnDisasterWeatherDestroyedNotificationToggle(bool value) {
            disasterWeatherDestroyedNotificationBinding.Update(value);
            Setting.Instance.Notification.DisasterWeatherDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WeatherDestroyedNotification, value, true);
        }
        private void OnDisasterWaterDamageNotificationToggle(bool value) {
            disasterWaterDamageNotificationBinding.Update(value);
            Setting.Instance.Notification.DisasterWaterDamageNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDamageNotification, value, true);
        }
        private void OnDisasterWaterDestroyedNotificationToggle(bool value) {
            disasterWaterDestroyedNotificationBinding.Update(value);
            Setting.Instance.Notification.DisasterWaterDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.WaterDestroyedNotification, value, true);
        }
        private void OnDisasterDestroyedNotificationToggle(bool value) {
            disasterDestroyedNotificationBinding.Update(value);
            Setting.Instance.Notification.DisasterDestroyedNotification = value;
            alertIconSystem.EnableDisasterNotification(DisasterNotificationIcon.DestroyedNotification, value, true);
        }
        #endregion

        #region OnFireNotificationToggle
        private void OnFireFireNotificationToggle(bool value) {
            fireFireNotificationBinding.Update(value);
            Setting.Instance.Notification.FireFireNotification = value;
            alertIconSystem.EnableFireNotification(FireNotificationIcon.FireNotification, value, true);
        }
        private void OnFireBurnedDownNotificationToggle(bool value) {
            fireBurnedDownNotificationBinding.Update(value);
            Setting.Instance.Notification.FireBurnedDownNotification = value;
            alertIconSystem.EnableFireNotification(FireNotificationIcon.BurnedDownNotification, value, true);
        }
        #endregion

        #region OnGarbageNotificationToggle
        private void OnGarbageGarbageNotificationToggle(bool value) {
            garbageGarbageNotificationBinding.Update(value);
            Setting.Instance.Notification.GarbageGarbageNotification = value;
            alertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.GarbageNotification, value, true);
        }
        private void OnGarbageFacilityFullNotificationToggle(bool value) {
            garbageFacilityFullNotificationBinding.Update(value);
            Setting.Instance.Notification.GarbageFacilityFullNotification = value;
            alertIconSystem.EnableGarbageNotification(GarbageNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnHealthcareNotificationToggle
        private void OnHealthcareAmbulanceNotificationToggle(bool value) {
            healthcareAmbulanceNotificationBinding.Update(value);
            Setting.Instance.Notification.HealthcareAmbulanceNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.AmbulanceNotification, value, true);
        }
        private void OnHealthcareHearseNotificationToggle(bool value) {
            healthcareHearseNotificationBinding.Update(value);
            Setting.Instance.Notification.HealthcareHearseNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.HearseNotification, value, true);
        }
        private void OnHealthcareFacilityFullNotificationToggle(bool value) {
            healthcareFacilityFullNotificationBinding.Update(value);
            Setting.Instance.Notification.HealthcareFacilityFullNotification = value;
            alertIconSystem.EnableHealthcareNotification(HealthcareNotificationIcon.FacilityFullNotification, value, true);
        }
        #endregion

        #region OnPoliceNotificationToggle
        private void OnPoliceTrafficAccidentNotificationToggle(bool value) {
            policeTrafficAccidentNotificationBinding.Update(value);
            Setting.Instance.Notification.PoliceTrafficAccidentNotification = value;
            alertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.TrafficAccidentNotification, value, true);
        }
        private void OnPoliceCrimeSceneNotificationToggle(bool value) {
            policeCrimeSceneNotificationBinding.Update(value);
            Setting.Instance.Notification.PoliceCrimeSceneNotification = value;
            alertIconSystem.EnablePoliceNotification(PoliceNotificationIcon.CrimeSceneNotification, value, true);
        }
        #endregion

        #region OnPollutionNotificationToggle
        private void OnPollutionAirPollutionNotificationToggle(bool value) {
            pollutionAirPollutionNotificationBinding.Update(value);
            Setting.Instance.Notification.PollutionAirPollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.AirPollutionNotification, value, true);
        }
        private void OnPollutionNoisePollutionNotificationToggle(bool value) {
            pollutionNoisePollutionNotificationBinding.Update(value);
            Setting.Instance.Notification.PollutionNoisePollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.NoisePollutionNotification, value, true);
        }
        private void OnPollutionGroundPollutionNotificationToggle(bool value) {
            pollutionGroundPollutionNotificationBinding.Update(value);
            Setting.Instance.Notification.PollutionGroundPollutionNotification = value;
            alertIconSystem.EnablePollutionNotification(PollutionNotificationIcon.GroundPollutionNotification, value, true);
        }
        #endregion

        #region OnResourceConsumerNotificationToggle
        private void OnResourceConsumerNoResourceNotificationToggle(bool value) {
            resourceConsumerNoResourceNotificationBinding.Update(value);
            Setting.Instance.Notification.ResourceConsumerNoResourceNotification = value;
            alertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoResourceNotification, value, true);
        }

        private void OnResourceConsumerNoFuelNotificationToggle(bool value) {
            resourceConsumerNoFuelNotificationBinding.Update(value);
            Setting.Instance.Notification.ResourceConsumerNoFuelNotification = value;
            alertIconSystem.EnableResourceConsumerNotification(ResourceConsumerNotificationIcon.NoFuelNotification, value, true);
        }
        #endregion

        #region OnResourceConnectionNotificationToggle
        private void OnResourceConnectionWarningNotificationToggle(bool value) {
            resourceConnectionWarningNotificationBinding.Update(value);
            Setting.Instance.Notification.ResourceConnectionWarningNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.ConnectionWarningNotification, value, true);
        }

        private void OnResourceConnectionOilPipeNotConnectedNotificationToggle(bool value) {
            resourceConnectionOilPipeNotConnectedNotificationBinding.Update(value);
            Setting.Instance.Notification.ResourceConnectionOilPipeNotConnectedNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.OilPipeNotConnectedNotification, value, true);
        }

        private void OnResourceConnectionFishingPierNotConnectedNotificationToggle(bool value) {
            resourceConnectionFishingPierNotConnectedNotificationBinding.Update(value);
            Setting.Instance.Notification.ResourceConnectionFishingPierNotConnectedNotification = value;
            alertIconSystem.EnableResourceConnectionNotification(ResourceConnectionNotificationIcon.FishingPierNotConnectedNotification, value, true);
        }
        #endregion

        #region OnRouteNotificationToggle
        private void OnRoutePathfindNotificationToggle(bool value) {
            routePathfindNotificationBinding.Update(value);
            Setting.Instance.Notification.RoutePathfindNotification = value;
            alertIconSystem.EnableRouteNotification(RouteNotificationIcon.PathfindNotification, value, true);
        }

        private void OnRouteGateBypassNotificationToggle(bool value) {
            routeGateBypassNotificationBinding.Update(value);
            Setting.Instance.Notification.RouteGateBypassNotification = value;
            alertIconSystem.EnableRouteNotification(RouteNotificationIcon.GateBypassNotification, value, true);
        }
        #endregion

        #region OnTransportLineNotificationToggle
        private void OnTransportLineVehicleNotificationToggle(bool value) {
            transportLineVehicleNotificationBinding.Update(value);
            Setting.Instance.Notification.TransportLineVehicleNotification = value;
            alertIconSystem.EnableTransportLineNotification(TransportLineNotificationIcon.VehicleNotification, value, true);
        }
        #endregion

        protected override void OnUpdate()
        {
            RefreshKeybindActions();

            if (!IsInGame())
            {
                return;
            }

            if (toggleNotificationPanelAction?.WasReleasedThisFrame() == true)
            {
                ToggleControlPanelFromHotkey();
                return;
            }

            if (toggleNotificationsAction?.WasReleasedThisFrame() == true)
            {
                ToggleAllNotificationsFromHotkey();
            }
        }

        private void InitializeKeybindActions()
        {
            toggleNotificationsAction = EnableAction(Setting.ToggleNotificationsAction);
            toggleNotificationPanelAction = EnableAction(Setting.ToggleNotificationPanelAction);
        }

        private void RefreshKeybindActions()
        {
            if (toggleNotificationsAction == null)
            {
                toggleNotificationsAction = EnableAction(Setting.ToggleNotificationsAction);
            }

            if (toggleNotificationPanelAction == null)
            {
                toggleNotificationPanelAction = EnableAction(Setting.ToggleNotificationPanelAction);
            }
        }

        private void ToggleAllNotificationsFromHotkey()
        {
            bool enabled = !AreAllNotificationSettingsEnabled();

            ApplyAllNotificationToggles(enabled);
        }

        private void ApplyAllNotificationToggles(bool enabled)
        {
            // Shared path for the hotkey and panel Toggle All button.
            // The controller applies icon state in bulk, then bindings update panel state.
            alertIconSystem.SetAllNotifications(enabled);
            UpdateAllNotificationBindings(enabled);
        }

        private void UpdateAllNotificationBindings(bool enabled)
        {
            // Keep this list aligned with Setting.NotificationSetting and the BoolBinding fields above.
            electricityElectricityNotificationBinding.Update(enabled);
            electricityBottleneckNotificationBinding.Update(enabled);
            electricityBuildingBottleneckNotificationBinding.Update(enabled);
            electricityNotEnoughProductionNotificationBinding.Update(enabled);
            electricityTransformerNotificationBinding.Update(enabled);
            electricityNotEnoughConnectedNotificationBinding.Update(enabled);
            electricityBatteryEmptyNotificationBinding.Update(enabled);
            electricityLowVoltageNotConnectedBinding.Update(enabled);
            electricityHighVoltageNotConnectedBinding.Update(enabled);

            waterPipeWaterNotificationBinding.Update(enabled);
            waterPipeDirtyWaterNotificationBinding.Update(enabled);
            waterPipeSewageNotificationBinding.Update(enabled);
            waterPipeWaterPipeNotConnectedNotificationBinding.Update(enabled);
            waterPipeSewagePipeNotConnectedNotificationBinding.Update(enabled);
            waterPipeNotEnoughWaterCapacityNotificationBinding.Update(enabled);
            waterPipeNotEnoughSewageCapacityNotificationBinding.Update(enabled);
            waterPipeNotEnoughGroundwaterNotificationBinding.Update(enabled);
            waterPipeNotEnoughSurfaceWaterNotificationBinding.Update(enabled);
            waterPipeDirtyWaterPumpNotificationBinding.Update(enabled);

            buildingAbandonedCollapsedNotificationBinding.Update(enabled);
            buildingAbandonedNotificationBinding.Update(enabled);
            buildingCondemnedNotificationBinding.Update(enabled);
            buildingTurnedOffNotificationBinding.Update(enabled);
            buildingHighRentNotificationBinding.Update(enabled);

            trafficBottleneckNotificationBinding.Update(enabled);
            trafficDeadEndNotificationBinding.Update(enabled);
            trafficRoadConnectionNotificationBinding.Update(enabled);
            trafficTrackConnectionNotificationBinding.Update(enabled);
            trafficCarConnectionNotificationBinding.Update(enabled);
            trafficShipConnectionNotificationBinding.Update(enabled);
            trafficTrainConnectionNotificationBinding.Update(enabled);
            trafficPedestrianConnectionNotificationBinding.Update(enabled);
            trafficBicycleConnectionNotificationBinding.Update(enabled);

            companyNoInputsNotificationBinding.Update(enabled);
            companyNoCustomersNotificationBinding.Update(enabled);

            workProviderUneducatedNotificationBinding.Update(enabled);
            workProviderEducatedNotificationBinding.Update(enabled);

            disasterWeatherDamageNotificationBinding.Update(enabled);
            disasterWeatherDestroyedNotificationBinding.Update(enabled);
            disasterWaterDamageNotificationBinding.Update(enabled);
            disasterWaterDestroyedNotificationBinding.Update(enabled);
            disasterDestroyedNotificationBinding.Update(enabled);

            fireFireNotificationBinding.Update(enabled);
            fireBurnedDownNotificationBinding.Update(enabled);

            garbageGarbageNotificationBinding.Update(enabled);
            garbageFacilityFullNotificationBinding.Update(enabled);

            healthcareAmbulanceNotificationBinding.Update(enabled);
            healthcareHearseNotificationBinding.Update(enabled);
            healthcareFacilityFullNotificationBinding.Update(enabled);

            policeTrafficAccidentNotificationBinding.Update(enabled);
            policeCrimeSceneNotificationBinding.Update(enabled);

            pollutionAirPollutionNotificationBinding.Update(enabled);
            pollutionNoisePollutionNotificationBinding.Update(enabled);
            pollutionGroundPollutionNotificationBinding.Update(enabled);

            resourceConsumerNoResourceNotificationBinding.Update(enabled);
            resourceConsumerNoFuelNotificationBinding.Update(enabled);
            resourceConnectionWarningNotificationBinding.Update(enabled);
            resourceConnectionOilPipeNotConnectedNotificationBinding.Update(enabled);
            resourceConnectionFishingPierNotConnectedNotificationBinding.Update(enabled);
            routePathfindNotificationBinding.Update(enabled);
            routeGateBypassNotificationBinding.Update(enabled);
            transportLineVehicleNotificationBinding.Update(enabled);
        }

        private static bool AreAllNotificationSettingsEnabled()
        {
            // Keep this list aligned with Setting.NotificationSetting.
            Setting.NotificationSetting notification = Setting.Instance.Notification;

            return notification.ElectricityElectricityNotification &&
                   notification.ElectricityBottleneckNotification &&
                   notification.ElectricityBuildingBottleneckNotification &&
                   notification.ElectricityNotEnoughProductionNotification &&
                   notification.ElectricityTransformerNotification &&
                   notification.ElectricityNotEnoughConnectedNotification &&
                   notification.ElectricityBatteryEmptyNotification &&
                   notification.ElectricityLowVoltageNotConnected &&
                   notification.ElectricityHighVoltageNotConnected &&
                   notification.WaterPipeWaterNotification &&
                   notification.WaterPipeDirtyWaterNotification &&
                   notification.WaterPipeSewageNotification &&
                   notification.WaterPipeWaterPipeNotConnectedNotification &&
                   notification.WaterPipeSewagePipeNotConnectedNotification &&
                   notification.WaterPipeNotEnoughWaterCapacityNotification &&
                   notification.WaterPipeNotEnoughSewageCapacityNotification &&
                   notification.WaterPipeNotEnoughGroundwaterNotification &&
                   notification.WaterPipeNotEnoughSurfaceWaterNotification &&
                   notification.WaterPipeDirtyWaterPumpNotification &&
                   notification.BuildingAbandonedCollapsedNotification &&
                   notification.BuildingAbandonedNotification &&
                   notification.BuildingCondemnedNotification &&
                   notification.BuildingTurnedOffNotification &&
                   notification.BuildingHighRentNotification &&
                   notification.TrafficBottleneckNotification &&
                   notification.TrafficDeadEndNotification &&
                   notification.TrafficRoadConnectionNotification &&
                   notification.TrafficTrackConnectionNotification &&
                   notification.TrafficCarConnectionNotification &&
                   notification.TrafficShipConnectionNotification &&
                   notification.TrafficTrainConnectionNotification &&
                   notification.TrafficPedestrianConnectionNotification &&
                   notification.TrafficBicycleConnectionNotification &&
                   notification.CompanyNoInputsNotification &&
                   notification.CompanyNoCustomersNotification &&
                   notification.WorkProviderUneducatedNotification &&
                   notification.WorkProviderEducatedNotification &&
                   notification.DisasterWeatherDamageNotification &&
                   notification.DisasterWeatherDestroyedNotification &&
                   notification.DisasterWaterDamageNotification &&
                   notification.DisasterWaterDestroyedNotification &&
                   notification.DisasterDestroyedNotification &&
                   notification.FireFireNotification &&
                   notification.FireBurnedDownNotification &&
                   notification.GarbageGarbageNotification &&
                   notification.GarbageFacilityFullNotification &&
                   notification.HealthcareAmbulanceNotification &&
                   notification.HealthcareHearseNotification &&
                   notification.HealthcareFacilityFullNotification &&
                   notification.PoliceTrafficAccidentNotification &&
                   notification.PoliceCrimeSceneNotification &&
                   notification.PollutionAirPollutionNotification &&
                   notification.PollutionNoisePollutionNotification &&
                   notification.PollutionGroundPollutionNotification &&
                   notification.ResourceConsumerNoResourceNotification &&
                   notification.ResourceConsumerNoFuelNotification &&
                   notification.ResourceConnectionWarningNotification &&
                   notification.ResourceConnectionOilPipeNotConnectedNotification &&
                   notification.ResourceConnectionFishingPierNotConnectedNotification &&
                   notification.RoutePathfindNotification &&
                   notification.RouteGateBypassNotification &&
                   notification.TransportLineVehicleNotification;
        }

        private static bool IsInGame()
        {
            return GameManager.instance != null &&
                   GameManager.instance.gameMode == GameMode.Game;
        }

        private ProxyAction? EnableAction(string actionName)
        {
            try
            {
                ProxyAction? action = Setting.Instance.GetAction(actionName);
                if (action != null)
                {
                    action.shouldBeEnabled = true;
                }

                return action;
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "missing-keybind-" + actionName,
                    () => $"Keybinding action '{actionName}' is unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private void OnControlPanelBindingToggle(bool value) => panelVisibleBinding.Update(value);

        private void ToggleControlPanelFromHotkey() => panelVisibleBinding.Update(!panelVisibleBinding.Value);

        public void UpdateMoneyViewBinding(bool value) => moneyViewBinding?.Update(value);

        public void UpdateMoneyViewModeBinding(int value) => moneyViewModeBinding?.Update(value);

        public void UpdateMoneyTooltipModeBinding(int value) => moneyTooltipModeBinding?.Update(value);

        public void UpdateMoneyTooltipFontScaleBinding(int value) => moneyTooltipFontScaleBinding?.Update(value);

        public void UpdatePopulationTooltipFontScaleBinding(int value) => populationTooltipFontScaleBinding?.Update(value);

    }

}
