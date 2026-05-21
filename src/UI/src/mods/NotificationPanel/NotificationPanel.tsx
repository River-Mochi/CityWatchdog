// File: src/UI/src/mods/NotificationPanel/NotificationPanel.tsx
// Purpose: In-game City Watchdog notification icon control panel.

import { useValue, type ValueBinding } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { Button, Panel, Tooltip } from "cs2/ui";
import { useEffect, useState } from "react";
import {
    BuildingAbandonedCollapsedNotificationBinding$, BuildingAbandonedNotificationBinding$, BuildingCondemnedNotificationBinding$,
    BuildingHighRentNotificationBinding$,
    BuildingTurnedOffNotificationBinding$,
    CompanyNoCustomersNotificationBinding$, CompanyNoInputsNotificationBinding$,
    controlPanelEnabled$,
    DisasterDestroyedNotificationBinding$, DisasterWaterDamageNotificationBinding$, DisasterWaterDestroyedNotificationBinding$, DisasterWeatherDamageNotificationBinding$, DisasterWeatherDestroyedNotificationBinding$,
    ElectricityBatteryEmptyNotificationBinding$,
    ElectricityBottleneckNotificationBinding$, ElectricityBuildingBottleneckNotificationBinding$,
    ElectricityElectricityNotificationBinding$,
    ElectricityHighVoltageNotConnectedBinding$, ElectricityLowVoltageNotConnectedBinding$,
    ElectricityNotEnoughConnectedNotificationBinding$,
    ElectricityNotEnoughProductionNotificationBinding$, ElectricityTransformerNotificationBinding$,
    FireBurnedDownNotificationBinding$, FireFireNotificationBinding$,
    GarbageFacilityFullNotificationBinding$, GarbageGarbageNotificationBinding$,
    HealthcareAmbulanceNotificationBinding$, HealthcareFacilityFullNotificationBinding$, HealthcareHearseNotificationBinding$,
    OnBuildingAbandonedCollapsedNotificationBindingToggle, OnBuildingAbandonedNotificationBindingToggle, OnBuildingCondemnedNotificationBindingToggle,
    OnBuildingHighRentNotificationBindingToggle,
    OnBuildingTurnedOffNotificationBindingToggle,
    OnCompanyNoCustomersNotificationBindingToggle, OnCompanyNoInputsNotificationBindingToggle,
    OnControlPanelBindingToggle,
    OnDisasterDestroyedNotificationBindingToggle, OnDisasterWaterDamageNotificationBindingToggle, OnDisasterWaterDestroyedNotificationBindingToggle, OnDisasterWeatherDamageNotificationBindingToggle, OnDisasterWeatherDestroyedNotificationBindingToggle,
    OnElectricityBatteryEmptyNotificationBindingToggle,
    OnElectricityBottleneckNotificationBindingToggle, OnElectricityBuildingBottleneckNotificationBindingToggle,
    OnElectricityElectricityNotificationBindingToggle,
    OnElectricityHighVoltageNotConnectedBindingToggle, OnElectricityLowVoltageNotConnectedBindingToggle,
    OnElectricityNotEnoughConnectedNotificationBindingToggle,
    OnElectricityNotEnoughProductionNotificationBindingToggle, OnElectricityTransformerNotificationBindingToggle,
    OnFireBurnedDownNotificationBindingToggle, OnFireFireNotificationBindingToggle,
    OnGarbageFacilityFullNotificationBindingToggle, OnGarbageGarbageNotificationBindingToggle,
    OnHealthcareAmbulanceNotificationBindingToggle, OnHealthcareFacilityFullNotificationBindingToggle, OnHealthcareHearseNotificationBindingToggle,
    OnPoliceCrimeSceneNotificationBindingToggle, OnPoliceTrafficAccidentNotificationBindingToggle,
    OnPollutionAirPollutionNotificationBindingToggle, OnPollutionGroundPollutionNotificationBindingToggle, OnPollutionNoisePollutionNotificationBindingToggle,
    OnResourceConsumerNoResourceNotificationBindingToggle,
    OnRoutePathfindNotificationBindingToggle,
    OnTrafficBottleneckNotificationBindingToggle,
    OnTrafficCarConnectionNotificationBindingToggle,
    OnTrafficDeadEndNotificationBindingToggle,
    OnTrafficPedestrianConnectionNotificationBindingToggle,
    OnTrafficRoadConnectionNotificationBindingToggle,
    OnTrafficShipConnectionNotificationBindingToggle,
    OnTrafficTrackConnectionNotificationBindingToggle,
    OnTrafficTrainConnectionNotificationBindingToggle,
    OnTransportLineVehicleNotificationBindingToggle,
    OnToggleAllNotifications,
    OnWaterPipeDirtyWaterNotificationBindingToggle,
    OnWaterPipeDirtyWaterPumpNotificationBindingToggle,
    OnWaterPipeNotEnoughGroundwaterNotificationBindingToggle,
    OnWaterPipeNotEnoughSewageCapacityNotificationBindingToggle,
    OnWaterPipeNotEnoughSurfaceWaterNotificationBindingToggle,
    OnWaterPipeNotEnoughWaterCapacityNotificationBindingToggle,
    OnWaterPipeSewageNotificationBindingToggle,
    OnWaterPipeSewagePipeNotConnectedNotificationBindingToggle,
    OnWaterPipeWaterNotificationBindingToggle,
    OnWaterPipeWaterPipeNotConnectedNotificationBindingToggle,
    PoliceCrimeSceneNotificationBinding$, PoliceTrafficAccidentNotificationBinding$,
    PollutionAirPollutionNotificationBinding$, PollutionGroundPollutionNotificationBinding$, PollutionNoisePollutionNotificationBinding$,
    ResourceConsumerNoResourceNotificationBinding$,
    RoutePathfindNotificationBinding$,
    TrafficBottleneckNotificationBinding$,
    TrafficCarConnectionNotificationBinding$,
    TrafficDeadEndNotificationBinding$,
    TrafficPedestrianConnectionNotificationBinding$,
    TrafficRoadConnectionNotificationBinding$,
    TrafficShipConnectionNotificationBinding$,
    TrafficTrackConnectionNotificationBinding$,
    TrafficTrainConnectionNotificationBinding$,
    TransportLineVehicleNotificationBinding$,
    WaterPipeDirtyWaterNotificationBinding$,
    WaterPipeDirtyWaterPumpNotificationBinding$,
    WaterPipeNotEnoughGroundwaterNotificationBinding$,
    WaterPipeNotEnoughSewageCapacityNotificationBinding$,
    WaterPipeNotEnoughSurfaceWaterNotificationBinding$,
    WaterPipeNotEnoughWaterCapacityNotificationBinding$,
    WaterPipeSewageNotificationBinding$,
    WaterPipeSewagePipeNotConnectedNotificationBinding$,
    WaterPipeWaterNotificationBinding$,
    WaterPipeWaterPipeNotConnectedNotificationBinding$,
    WorkProviderEducatedNotificationBinding$, WorkProviderUneducatedNotificationBinding$,
    OnWorkProviderEducatedNotificationBindingToggle, OnWorkProviderUneducatedNotificationBindingToggle,
} from "../Bindings/Bindings";
import { Divider } from "../Divider/Divider";
import { InfoCheckbox } from "../InfoCheckbox/InfoCheckbox";
import { InfoPanel } from "../InfoPanel/InfoPanel";
import styles from "../NotificationPanel/NotificationPanel.module.scss";
import { VanillaComponentResolver } from "../VanillaComponentResolver/VanillaComponentResolver";


// Title icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import TitleBarIconPath from "../../../images/NotificationIcon_TitleBar.svg";

const modIconSrc = TitleBarIconPath;

// Info icon uses the built-in game media path, notification icon path below.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

// Toolbar icons use built-in game media paths.
// All.svg is vanilla snap-options "all" icon.
const toggleAllIconSrc = "Media/Tools/Snap Options/All.svg";

// ParallelPlus / ParallelMinus used as compact expand/collapse icons.
const expandAllIconSrc = "Media/Tools/Net Tool/ParallelPlus.svg";
const collapseAllIconSrc = "Media/Tools/Net Tool/ParallelMinus.svg";

const roundButtonHighlightStyle = getModule("game-ui/common/input/button/themes/round-highlight-button.module.scss", "classes");
const icon = (name: string) => `Media/Game/Notifications/${name}.svg`;

const gameTitleKeys: Record<string, string> = {
    ElectricityElectricityNotification: "Notifications.TITLE[Electricity Notification]",
    ElectricityBottleneckNotification: "Notifications.TITLE[Electricity Bottleneck Notification]",
    ElectricityBuildingBottleneckNotification: "Notifications.TITLE[Electricity Building Bottleneck Notification]",
    ElectricityNotEnoughProductionNotification: "Notifications.TITLE[Electricity Not Enough Production Notification]",
    ElectricityTransformerNotification: "Notifications.TITLE[Electricity Transformer Out of Capacity]",
    ElectricityNotEnoughConnectedNotification: "Notifications.TITLE[Electricity Not Enough Connected Notification]",
    ElectricityBatteryEmptyNotification: "Notifications.TITLE[Battery Empty]",
    ElectricityLowVoltageNotConnected: "Notifications.TITLE[Powerline Not Connected - Low]",
    ElectricityHighVoltageNotConnected: "Notifications.TITLE[Powerline Not Connected]",

    WaterPipeWaterNotification: "Notifications.TITLE[Water Notification]",
    WaterPipeDirtyWaterNotification: "Notifications.TITLE[Dirty Water]",
    WaterPipeSewageNotification: "Notifications.TITLE[Sewage Notification]",
    WaterPipeWaterPipeNotConnectedNotification: "Notifications.TITLE[Pipeline Not Connected]",
    WaterPipeSewagePipeNotConnectedNotification: "Notifications.TITLE[Pipeline Not Connected - Sewage]",
    WaterPipeNotEnoughWaterCapacityNotification: "Notifications.TITLE[Water Not Enough Production Notification]",
    WaterPipeNotEnoughSewageCapacityNotification: "Notifications.TITLE[Sewage Not Enough Production Notification]",
    WaterPipeNotEnoughGroundwaterNotification: "Notifications.TITLE[Not Enough Groundwater Notification]",
    WaterPipeNotEnoughSurfaceWaterNotification: "Notifications.TITLE[Not Enough Surface Water Notification]",
    WaterPipeDirtyWaterPumpNotification: "Notifications.TITLE[Dirty Water Pump Notification]",

    BuildingAbandonedCollapsedNotification: "Notifications.TITLE[Abandoned Collapsed]",
    BuildingAbandonedNotification: "Notifications.TITLE[Abandoned]",
    BuildingCondemnedNotification: "Notifications.TITLE[Condemned]",
    BuildingTurnedOffNotification: "Notifications.TITLE[Turned Off]",
    BuildingHighRentNotification: "Notifications.TITLE[Rent Too High]",

    TrafficBottleneckNotification: "Notifications.TITLE[Traffic Bottleneck Notification]",
    TrafficDeadEndNotification: "Notifications.TITLE[Dead End]",
    TrafficRoadConnectionNotification: "Notifications.TITLE[No Road Access]",
    TrafficTrackConnectionNotification: "Notifications.TITLE[Track Not Connected]",
    TrafficCarConnectionNotification: "Notifications.TITLE[No Car Access]",
    TrafficShipConnectionNotification: "Notifications.TITLE[No Watercraft Access]",
    TrafficTrainConnectionNotification: "Notifications.TITLE[No Train Access]",
    TrafficPedestrianConnectionNotification: "Notifications.TITLE[No Pedestrian Access]",

    CompanyNoInputsNotification: "Notifications.TITLE[No Inputs]",
    CompanyNoCustomersNotification: "Notifications.TITLE[No Customers]",

    WorkProviderUneducatedNotification: "Notifications.TITLE[MissingUneducatedWorkers]",
    WorkProviderEducatedNotification: "Notifications.TITLE[MissingEducatedWorkers]",

    DisasterWeatherDamageNotification: "Notifications.TITLE[Weather Damage]",
    DisasterWeatherDestroyedNotification: "Notifications.TITLE[Weather Destroyed]",
    DisasterWaterDamageNotification: "Notifications.TITLE[Water Damage]",
    DisasterWaterDestroyedNotification: "Notifications.TITLE[Water Destroyed]",
    DisasterDestroyedNotification: "Notifications.TITLE[Destroyed]",

    FireFireNotification: "Notifications.TITLE[Fire Notification]",
    FireBurnedDownNotification: "Notifications.TITLE[Burned Down]",

    GarbageGarbageNotification: "Notifications.TITLE[Garbage Notification]",
    GarbageFacilityFullNotification: "Notifications.TITLE[Facility Full]",

    HealthcareAmbulanceNotification: "Notifications.TITLE[Ambulance Notification]",
    HealthcareHearseNotification: "Notifications.TITLE[Hearse Notification]",
    HealthcareFacilityFullNotification: "Notifications.TITLE[Facility Full]",

    PoliceTrafficAccidentNotification: "Notifications.TITLE[Traffic Accident]",
    PoliceCrimeSceneNotification: "Notifications.TITLE[Crime Scene]",

    PollutionAirPollutionNotification: "Notifications.TITLE[Air Pollution]",
    PollutionNoisePollutionNotification: "Notifications.TITLE[Noise Pollution]",
    PollutionGroundPollutionNotification: "Notifications.TITLE[Ground Pollution]",

    ResourceConsumerNoResourceNotification: "Notifications.TITLE[No Emergency Shelter Supplies]",
    RoutePathfindNotification: "Notifications.TITLE[Pathfind Failed]",
    TransportLineVehicleNotification: "Notifications.TITLE[No Vehicles]",
};


type Localize = (localeId: string, fallback?: string, raw?: boolean) => string;

interface NotificationItem {
    readonly localeId: string;

    // Built-in game localization key for the notification title.
    // Example: Notifications.TITLE[No Inputs] or NOTIFICATIONS.TITLE[GATE BYPASS]
    // If the game key is missing, CWD falls back to localeId.
    readonly gameTitleKey?: string;

    readonly icon: string;
    readonly binding: ValueBinding<boolean>;
    readonly onToggle: (enabled: boolean) => void;
}


interface NotificationSection {
    readonly localeId: string;
    readonly defaultExpanded?: boolean;
    readonly items: NotificationItem[];
}

const sections: NotificationSection[] = [
    {
        localeId: "Electricity",
        defaultExpanded: true,
        items: [
            { icon: icon("NotEnoughElectricity"), localeId: "ElectricityElectricityNotification", binding: ElectricityElectricityNotificationBinding$, onToggle: OnElectricityElectricityNotificationBindingToggle },
            { icon: icon("ElectricityBottleneck"), localeId: "ElectricityBottleneckNotification", binding: ElectricityBottleneckNotificationBinding$, onToggle: OnElectricityBottleneckNotificationBindingToggle },
            { icon: icon("BadServiceElectricity"), localeId: "ElectricityBuildingBottleneckNotification", binding: ElectricityBuildingBottleneckNotificationBinding$, onToggle: OnElectricityBuildingBottleneckNotificationBindingToggle },
            { icon: icon("LowProductionElectricity"), localeId: "ElectricityNotEnoughProductionNotification", binding: ElectricityNotEnoughProductionNotificationBinding$, onToggle: OnElectricityNotEnoughProductionNotificationBindingToggle },
            { icon: icon("OutOfCapacityElectricity"), localeId: "ElectricityTransformerNotification", binding: ElectricityTransformerNotificationBinding$, onToggle: OnElectricityTransformerNotificationBindingToggle },
            { icon: icon("NotEnoughOutputLinesConnected"), localeId: "ElectricityNotEnoughConnectedNotification", binding: ElectricityNotEnoughConnectedNotificationBinding$, onToggle: OnElectricityNotEnoughConnectedNotificationBindingToggle },
            { icon: icon("BatteryEmpty"), localeId: "ElectricityBatteryEmptyNotification", binding: ElectricityBatteryEmptyNotificationBinding$, onToggle: OnElectricityBatteryEmptyNotificationBindingToggle },
            { icon: icon("PowerlineDisconnectedLow"), localeId: "ElectricityLowVoltageNotConnected", binding: ElectricityLowVoltageNotConnectedBinding$, onToggle: OnElectricityLowVoltageNotConnectedBindingToggle },
            { icon: icon("PowerlineDisconnected"), localeId: "ElectricityHighVoltageNotConnected", binding: ElectricityHighVoltageNotConnectedBinding$, onToggle: OnElectricityHighVoltageNotConnectedBindingToggle },
        ],
    },
    {
        localeId: "WaterPipe",
        items: [
            { icon: icon("NoRunningWater"), localeId: "WaterPipeWaterNotification", binding: WaterPipeWaterNotificationBinding$, onToggle: OnWaterPipeWaterNotificationBindingToggle },
            { icon: icon("ContaminatedWaterPumped"), localeId: "WaterPipeDirtyWaterNotification", binding: WaterPipeDirtyWaterNotificationBinding$, onToggle: OnWaterPipeDirtyWaterNotificationBindingToggle },
            { icon: icon("Sewage"), localeId: "WaterPipeSewageNotification", binding: WaterPipeSewageNotificationBinding$, onToggle: OnWaterPipeSewageNotificationBindingToggle },
            { icon: icon("WaterPipeDisconnected"), localeId: "WaterPipeWaterPipeNotConnectedNotification", binding: WaterPipeWaterPipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeWaterPipeNotConnectedNotificationBindingToggle },
            { icon: icon("SewagePipeDisconnected"), localeId: "WaterPipeSewagePipeNotConnectedNotification", binding: WaterPipeSewagePipeNotConnectedNotificationBinding$, onToggle: OnWaterPipeSewagePipeNotConnectedNotificationBindingToggle },
            { icon: icon("WaterFacilityOverload"), localeId: "WaterPipeNotEnoughWaterCapacityNotification", binding: WaterPipeNotEnoughWaterCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughWaterCapacityNotificationBindingToggle },
            { icon: icon("SewageFacilityOverload"), localeId: "WaterPipeNotEnoughSewageCapacityNotification", binding: WaterPipeNotEnoughSewageCapacityNotificationBinding$, onToggle: OnWaterPipeNotEnoughSewageCapacityNotificationBindingToggle },
            { icon: icon("GroundwaterLevelLow"), localeId: "WaterPipeNotEnoughGroundwaterNotification", binding: WaterPipeNotEnoughGroundwaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughGroundwaterNotificationBindingToggle },
            { icon: icon("SurfaceWaterLevelLow"), localeId: "WaterPipeNotEnoughSurfaceWaterNotification", binding: WaterPipeNotEnoughSurfaceWaterNotificationBinding$, onToggle: OnWaterPipeNotEnoughSurfaceWaterNotificationBindingToggle },
            { icon: icon("DirtyWaterPump"), localeId: "WaterPipeDirtyWaterPumpNotification", binding: WaterPipeDirtyWaterPumpNotificationBinding$, onToggle: OnWaterPipeDirtyWaterPumpNotificationBindingToggle },
        ],
    },
    {
        localeId: "Building",
        items: [
            { icon: icon("BuildingCollapsed"), localeId: "BuildingAbandonedCollapsedNotification", binding: BuildingAbandonedCollapsedNotificationBinding$, onToggle: OnBuildingAbandonedCollapsedNotificationBindingToggle },
            { icon: icon("BuildingAbandoned"), localeId: "BuildingAbandonedNotification", binding: BuildingAbandonedNotificationBinding$, onToggle: OnBuildingAbandonedNotificationBindingToggle },
            { icon: icon("BuildingCondemned"), localeId: "BuildingCondemnedNotification", binding: BuildingCondemnedNotificationBinding$, onToggle: OnBuildingCondemnedNotificationBindingToggle },
            { icon: icon("TurnedOff"), localeId: "BuildingTurnedOffNotification", binding: BuildingTurnedOffNotificationBinding$, onToggle: OnBuildingTurnedOffNotificationBindingToggle },
            { icon: icon("RentTooHigh"), localeId: "BuildingHighRentNotification", binding: BuildingHighRentNotificationBinding$, onToggle: OnBuildingHighRentNotificationBindingToggle },
        ],
    },
    {
        localeId: "Traffic",
        items: [
            { icon: icon("TrafficBottleneck"), localeId: "TrafficBottleneckNotification", binding: TrafficBottleneckNotificationBinding$, onToggle: OnTrafficBottleneckNotificationBindingToggle },
            { icon: icon("DeadEnd"), localeId: "TrafficDeadEndNotification", binding: TrafficDeadEndNotificationBinding$, onToggle: OnTrafficDeadEndNotificationBindingToggle },
            { icon: icon("RoadNotConnected"), localeId: "TrafficRoadConnectionNotification", binding: TrafficRoadConnectionNotificationBinding$, onToggle: OnTrafficRoadConnectionNotificationBindingToggle },
            { icon: icon("TrackNotConnected"), localeId: "TrafficTrackConnectionNotification", binding: TrafficTrackConnectionNotificationBinding$, onToggle: OnTrafficTrackConnectionNotificationBindingToggle },
            { icon: icon("NoCarAccess"), localeId: "TrafficCarConnectionNotification", binding: TrafficCarConnectionNotificationBinding$, onToggle: OnTrafficCarConnectionNotificationBindingToggle },
            { icon: icon("NoBoatAccess"), localeId: "TrafficShipConnectionNotification", binding: TrafficShipConnectionNotificationBinding$, onToggle: OnTrafficShipConnectionNotificationBindingToggle },
            { icon: icon("NoTrainAccess"), localeId: "TrafficTrainConnectionNotification", binding: TrafficTrainConnectionNotificationBinding$, onToggle: OnTrafficTrainConnectionNotificationBindingToggle },
            { icon: icon("NoPedestrianAccess"), localeId: "TrafficPedestrianConnectionNotification", binding: TrafficPedestrianConnectionNotificationBinding$, onToggle: OnTrafficPedestrianConnectionNotificationBindingToggle },
        ],
    },
    {
        localeId: "Company",
        items: [
            {
                icon: icon("NoInputs"),
                localeId: "CompanyNoInputsNotification",
                gameTitleKey: "Notifications.TITLE[No Inputs]",
                binding: CompanyNoInputsNotificationBinding$,
                onToggle: OnCompanyNoInputsNotificationBindingToggle,
            },

            { icon: icon("NoCustomers"), localeId: "CompanyNoCustomersNotification", binding: CompanyNoCustomersNotificationBinding$, onToggle: OnCompanyNoCustomersNotificationBindingToggle },
        ],
    },
    {
        localeId: "WorkProvider",
        items: [
            { icon: icon("NoWorkers"), localeId: "WorkProviderUneducatedNotification", binding: WorkProviderUneducatedNotificationBinding$, onToggle: OnWorkProviderUneducatedNotificationBindingToggle },
            { icon: icon("NoEducatedWorkers"), localeId: "WorkProviderEducatedNotification", binding: WorkProviderEducatedNotificationBinding$, onToggle: OnWorkProviderEducatedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Disaster",
        items: [
            { icon: icon("WeatherDamage"), localeId: "DisasterWeatherDamageNotification", binding: DisasterWeatherDamageNotificationBinding$, onToggle: OnDisasterWeatherDamageNotificationBindingToggle },
            { icon: icon("WeatherDestroyed"), localeId: "DisasterWeatherDestroyedNotification", binding: DisasterWeatherDestroyedNotificationBinding$, onToggle: OnDisasterWeatherDestroyedNotificationBindingToggle },
            { icon: icon("WaterDamage"), localeId: "DisasterWaterDamageNotification", binding: DisasterWaterDamageNotificationBinding$, onToggle: OnDisasterWaterDamageNotificationBindingToggle },
            { icon: icon("WaterDestroyed"), localeId: "DisasterWaterDestroyedNotification", binding: DisasterWaterDestroyedNotificationBinding$, onToggle: OnDisasterWaterDestroyedNotificationBindingToggle },
            { icon: icon("Destroyed"), localeId: "DisasterDestroyedNotification", binding: DisasterDestroyedNotificationBinding$, onToggle: OnDisasterDestroyedNotificationBindingToggle },
        ],
    },
    {
        localeId: "Fire",
        items: [
            { icon: icon("BuildingOnFire"), localeId: "FireFireNotification", binding: FireFireNotificationBinding$, onToggle: OnFireFireNotificationBindingToggle },
            { icon: icon("BurnedDown"), localeId: "FireBurnedDownNotification", binding: FireBurnedDownNotificationBinding$, onToggle: OnFireBurnedDownNotificationBindingToggle },
        ],
    },
    {
        localeId: "Garbage",
        items: [
            { icon: icon("TooMuchGarbage"), localeId: "GarbageGarbageNotification", binding: GarbageGarbageNotificationBinding$, onToggle: OnGarbageGarbageNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "GarbageFacilityFullNotification", binding: GarbageFacilityFullNotificationBinding$, onToggle: OnGarbageFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Healthcare",
        items: [
            { icon: icon("MedicalEmergency"), localeId: "HealthcareAmbulanceNotification", binding: HealthcareAmbulanceNotificationBinding$, onToggle: OnHealthcareAmbulanceNotificationBindingToggle },
            { icon: icon("HearseServiceNeeded"), localeId: "HealthcareHearseNotification", binding: HealthcareHearseNotificationBinding$, onToggle: OnHealthcareHearseNotificationBindingToggle },
            { icon: icon("FacilityFull"), localeId: "HealthcareFacilityFullNotification", binding: HealthcareFacilityFullNotificationBinding$, onToggle: OnHealthcareFacilityFullNotificationBindingToggle },
        ],
    },
    {
        localeId: "Police",
        items: [
            { icon: icon("TrafficAccident"), localeId: "PoliceTrafficAccidentNotification", binding: PoliceTrafficAccidentNotificationBinding$, onToggle: OnPoliceTrafficAccidentNotificationBindingToggle },
            { icon: icon("CrimeScene"), localeId: "PoliceCrimeSceneNotification", binding: PoliceCrimeSceneNotificationBinding$, onToggle: OnPoliceCrimeSceneNotificationBindingToggle },
        ],
    },
    {
        localeId: "Pollution",
        items: [
            { icon: icon("AirPollution"), localeId: "PollutionAirPollutionNotification", binding: PollutionAirPollutionNotificationBinding$, onToggle: OnPollutionAirPollutionNotificationBindingToggle },
            { icon: icon("NoisePollution"), localeId: "PollutionNoisePollutionNotification", binding: PollutionNoisePollutionNotificationBinding$, onToggle: OnPollutionNoisePollutionNotificationBindingToggle },
            { icon: icon("PollutedSoil"), localeId: "PollutionGroundPollutionNotification", binding: PollutionGroundPollutionNotificationBinding$, onToggle: OnPollutionGroundPollutionNotificationBindingToggle },
        ],
    },
    {
        localeId: "ResourceConsumer",
        items: [
            { icon: icon("NotEnoughIndustrialGoods"), localeId: "ResourceConsumerNoResourceNotification", binding: ResourceConsumerNoResourceNotificationBinding$, onToggle: OnResourceConsumerNoResourceNotificationBindingToggle },
        ],
    },
    {
        localeId: "Route",
        items: [
            { icon: icon("PathfindFailed"), localeId: "RoutePathfindNotification", binding: RoutePathfindNotificationBinding$, onToggle: OnRoutePathfindNotificationBindingToggle },
        ],
    },
    {
        localeId: "TransportLine",
        items: [
            { icon: icon("NoVehicles"), localeId: "TransportLineVehicleNotification", binding: TransportLineVehicleNotificationBinding$, onToggle: OnTransportLineVehicleNotificationBindingToggle },
        ],
    },
];

const allItems = sections.flatMap((section) => section.items);

const setAllNotifications = (enabled: boolean) => {
    OnToggleAllNotifications(enabled);
};

const createExpandedSections = (expanded: boolean | null = null) => {
    const result: Record<string, boolean> = {};

    sections.forEach((section) => {
        // Fresh UI sessions start collapsed.
        // In the same city/session, manual expand/collapse state is still remembered by React state.
        result[section.localeId] = expanded ?? false;

    });

    return result;
};

export const NotificationPanel = () => {
    const showPanel = useValue(controlPanelEnabled$);
    const isPhotoMode = useValue(game.activeGamePanel$)?.__Type == game.GamePanelType.PhotoMode;

    if (isPhotoMode || !showPanel) {
        return null;
    }

    return <NotificationPanelContent />;
};

const NotificationPanelContent = () => {
    const { translate } = useLocalization();
    const [sortAscending, setSortAscending] = useState(true);
    const [expandedSections, setExpandedSections] = useState(createExpandedSections);
    const allValues = useAllNotificationValues();

    const allSelected = allValues.every(Boolean);
    const anySelected = allValues.some(Boolean);
    const toggleAllStateClass = allSelected
        ? styles.toggleAllOn
        : anySelected
            ? styles.toggleAllPartial
            : styles.toggleAllOff;

    const allSectionsExpanded = sections.every((section) => expandedSections[section.localeId] === true);

    const localize: Localize = (localeId, fallback, raw = false) => {
        if (raw) {
            return translate(localeId) ?? fallback ?? localeId;
        }

        return translate(`CityWatchdog.UI[${localeId}]`) ?? fallback ?? localeId;
    };

    const tooltipContent = (localeId: string, fallback: string) => {
        const tooltip = localize(localeId, fallback);
        const lines = tooltip.split("\n");

        if (lines.length <= 1) {
            return tooltip;
        }

        return (
            <div className={styles.tooltipText}>
                {lines.map((line, index) => (
                    <div key={`${localeId}-${index}`}>{line}</div>
                ))}
            </div>
        );
    };

    const orderedSections = [...sections].sort((a, b) => {
        const result = localize(a.localeId).localeCompare(localize(b.localeId));
        return sortAscending ? result : -result;
    });

    const onToggleAll = () => {
        setAllNotifications(!allSelected);
    };

    const onToggleAllSections = () => {
        setExpandedSections(createExpandedSections(!allSectionsExpanded));
    };

    const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
        setExpandedSections((current) => ({
            ...current,
            [section.localeId]: expanded,
        }));
    };

    return (
        <Panel
            className={styles.panel}


            header={
                <div className={styles.header}>
                    <div className={styles.headerTitleArea}>
                        <img src={modIconSrc} className={styles.headerModIcon} />
                        <div className={styles.headerModName}>CITY WATCHDOG</div>
                    </div>
                    <Button
                        className={roundButtonHighlightStyle.button + " " + styles.headerCloseButton}
                        variant="icon"
                        onClick={() => { OnControlPanelBindingToggle(false); }}
                        focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                    >
                        <img src="coui://uil/Standard/XClose.svg"></img>
                    </Button>
                </div>
            }

        >

            {/* Keeps the help icon pinned left and the three action buttons grouped right. */}
            <div className={styles.toolbar}>
                <Tooltip tooltip={tooltipContent("NotificationIconShowOrHide", "Expand any row; [✓] check to show, uncheck to hide alerts.\nThis does not fix city problems, it hides icon clutter.")}>
                    <div className={styles.infoButton}>
                        <img src={infoIconSrc} className={styles.infoIcon} />
                    </div>
                </Tooltip>

                <div className={styles.toolbarButtons}>

                    <Tooltip tooltip={allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows")}>
                        <Button
                            className={styles.toolbarButton + " " + styles.expandButton}
                            onClick={onToggleAllSections}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={allSectionsExpanded ? collapseAllIconSrc : expandAllIconSrc}              
                                className={`${styles.toolbarIcon} ${styles.expandCollapseIcon}`}
                                alt=""
                            />

                        </Button>
                    </Tooltip>

                    <Tooltip tooltip={localize("SortOrderTooltip", "Sort order")}>
                        <Button
                            className={styles.toolbarButton + " " + styles.sortButton}
                            onClick={() => { setSortAscending(!sortAscending); }}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            {sortAscending ? localize("SortAscending", "ASC ↑") : localize("SortDescending", "DESC ↓")}
                        </Button>
                    </Tooltip>

                    <Tooltip tooltip={tooltipContent("ToggleAllTooltip", "Show/hide all icons.\nColor: green = all on; blue = mixed; red = all off.")}>
                        <Button
                            className={`${styles.toolbarButton} ${styles.toggleButton} ${toggleAllStateClass}`}

                            onClick={onToggleAll}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={toggleAllIconSrc}
                                className={`${styles.toolbarIcon} ${styles.toggleAllIcon}`}
                                alt=""
                            />
                        </Button>
                    </Tooltip>

                </div>
            </div>

            {orderedSections.map((section, index) => (
                <NotificationSectionView
                    key={section.localeId}
                    section={section}
                    expanded={expandedSections[section.localeId] === true}
                    localize={localize}
                    showDivider={index > 0}
                    onExpandedChange={(expanded) => onSectionExpandedChange(section, expanded)}
                />
            ))}
        </Panel>
    );
};

const NotificationSectionView = ({
    section,
    expanded,
    localize,
    showDivider,
    onExpandedChange,
}: {
    section: NotificationSection;
    expanded: boolean;
    localize: Localize;
    showDivider: boolean;
    onExpandedChange: (expanded: boolean) => void;
}) => {
    const values = useSectionValues(section);
    const selectedCount = values.filter(Boolean).length;

    return (
        <>
            {showDivider && <Divider></Divider>}
            <InfoPanel
                title={localize(section.localeId)}
                collapsible={true}
                expanded={expanded}
                onExpandedChange={onExpandedChange}
                summary={`${selectedCount}/${section.items.length}`}
                renderChildren={() => section.items.map((item, itemIndex) => (
                    <NotificationRow
                        key={item.localeId}
                        item={item}
                        isChecked={values[itemIndex] ?? false}
                        localize={localize}
                    />
                ))}
            />
        </>
    );
};

const useAllNotificationValues = () => {
    const [values, setValues] = useState(() => allItems.map((item) => item.binding.value));

    useEffect(() => {
        setValues(allItems.map((item) => item.binding.value));

        const subscriptions = allItems.map((item, itemIndex) => item.binding.subscribe((value) => {
            setValues((currentValues) => {
                if (currentValues[itemIndex] === value) {
                    return currentValues;
                }

                const nextValues = currentValues.slice();
                nextValues[itemIndex] = value;
                return nextValues;
            });
        }));

        return () => {
            subscriptions.forEach((subscription) => subscription.dispose());
        };
    }, []);

    return values;
};

const useSectionValues = (section: NotificationSection) => {
    const [values, setValues] = useState(() => section.items.map((item) => item.binding.value));

    useEffect(() => {
        setValues(section.items.map((item) => item.binding.value));

        const subscriptions = section.items.map((item, itemIndex) => item.binding.subscribe((value) => {
            setValues((currentValues) => {
                if (currentValues[itemIndex] === value) {
                    return currentValues;
                }

                const nextValues = currentValues.slice();
                nextValues[itemIndex] = value;
                return nextValues;
            });
        }));

        return () => {
            subscriptions.forEach((subscription) => subscription.dispose());
        };
    }, [section]);

    return values;
};


const NotificationRow = ({
    item,
    isChecked,
    localize,
}: {
    item: NotificationItem;
    isChecked: boolean;
    localize: Localize;
}) => {
    const gameTitleKey = item.gameTitleKey ?? gameTitleKeys[item.localeId];
    const gameLabel = gameTitleKey
        ? localize(gameTitleKey, undefined, true)
        : undefined;

    const label =
        gameLabel &&
            gameLabel !== gameTitleKey &&
            !gameLabel.includes("NOTIFICATIONS.TITLE") &&
            !gameLabel.includes("Notifications.TITLE")
            ? gameLabel
            : localize(item.localeId);

    return (
        <InfoCheckbox
            image={item.icon}
            label={label}
            isChecked={isChecked}
            onToggle={item.onToggle}
            style={{ marginBottom: "5rem" }}
        ></InfoCheckbox>
    );
};
