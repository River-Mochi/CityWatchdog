// File: src/UI/src/mods/MoneyView/MoneyView.tsx
// Purpose: Hooks vanilla toolbar/tooltip exports to inject City Watchdog Money View UI.

import type { ModuleRegistryExtend } from "cs2/modding";
import { cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { MoneyViewTooltipContent, isMoneyTooltip } from "./MoneyViewTooltip";
import { PopulationViewTooltipContent, isPopulationTooltip } from "./PopulationViewTooltip";
import { ToolbarMoneyDelta, ToolbarPopulationDelta } from "./ToolbarTrendAmount";
import { MONEY_ICON, POPULATION_ICON } from "./moneyViewShared";

export const StatFieldMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        const result = Component(props);
        const moneyViewText = getMoneyViewText(props);

        if (!moneyViewText || !isValidElement(result)) {
            return result;
        }

        return appendMoneyViewText(result, moneyViewText);
    };
};

// MoneyField is already captured by the vanilla toolbar before this mod can reliably wrap it.
// Hook the shared DescriptionTooltip instead, then filter to the money toolbar child only.
export const DescriptionTooltipMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (isMoneyTooltip(props)) {
            return Component({
                ...props,
                title: null,
                description: null,
                content: <MoneyViewTooltipContent baseContent={props.content} />,
            });
        }

        if (isPopulationTooltip(props)) {
            return Component({
                ...props,
                title: null,
                description: null,
                content: <PopulationViewTooltipContent baseContent={props.content} />,
            });
        }

        return Component(props);
    };
};

const getMoneyViewText = (props: any): ReactNode | null => {
    if (props?.unlimited === true) {
        return null;
    }

    if (props?.icon === MONEY_ICON) {
        return <ToolbarMoneyDelta />;
    }

    if (props?.icon === POPULATION_ICON) {
        return <ToolbarPopulationDelta />;
    }

    return null;
};

const appendMoneyViewText = (element: ReactElement<any>, moneyViewText: ReactNode): ReactElement<any> => {
    return cloneElement(
        element,
        undefined,
        <>
            {element.props.children}
            {moneyViewText}
        </>
    );
};
