// File: src/UI/src/index.tsx
// Purpose: Registers City Watchdog UI modules and vanilla UI extensions.

import { ModRegistrar, type ModuleRegistry, type ModuleRegistryExtend } from "cs2/modding";
import mod from "../mod.json";
import { NotificationPanel } from "./mods/NotificationPanel/NotificationPanel";
import { EntryButton } from "./mods/EntryButton/EntryButton";
import { DescriptionTooltipMoneyViewExtension, StatFieldMoneyViewExtension } from "./mods/MoneyView/MoneyView";
import { VanillaComponentResolver } from "./mods/VanillaComponentResolver/VanillaComponentResolver";
import "../images/NotificationIcon_TitleBar.svg";
import "../images/CWDNotificationIcon_white02.svg";

const STAT_FIELD_MODULE = "game-ui/game/components/toolbar/components/stat-field/stat-field.tsx";
// Vanilla export name. Keep this value aligned with the game module export.
const STAT_FIELD_VANILLA_TREND_EXPORT = "StatFieldTrend";
const DESCRIPTION_TOOLTIP_MODULE = "game-ui/common/tooltip/description-tooltip/description-tooltip.tsx";
const DESCRIPTION_TOOLTIP_EXPORT = "DescriptionTooltip";

const extendSafe = (
    registry: ModuleRegistry,
    modulePath: string,
    exportId: string,
    extension: ModuleRegistryExtend
) => {
    try {
        registry.extend(modulePath, exportId, extension);
    } catch (error) {
        console.error(`${mod.id} - UI extension failed for ${modulePath}#${exportId}`, error);
    }
};

const register: ModRegistrar = (moduleRegistry) => {
    VanillaComponentResolver.setRegistry(moduleRegistry);
    extendSafe(moduleRegistry, STAT_FIELD_MODULE, STAT_FIELD_VANILLA_TREND_EXPORT, StatFieldMoneyViewExtension);
    extendSafe(moduleRegistry, DESCRIPTION_TOOLTIP_MODULE, DESCRIPTION_TOOLTIP_EXPORT, DescriptionTooltipMoneyViewExtension);
    moduleRegistry.append("GameTopLeft", EntryButton);
    moduleRegistry.append("Game", NotificationPanel);
};

export default register;
