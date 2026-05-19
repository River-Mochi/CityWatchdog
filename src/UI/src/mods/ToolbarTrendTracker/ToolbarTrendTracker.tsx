import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import type { ModuleRegistryExtend } from "cs2/modding";
import { Children, cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { trendDisplayMode$, trendTracker$ } from "../Bindings/Bindings";
import styles from "./ToolbarTrendTracker.module.scss";

const MONEY_ICON = "Media/Game/Icons/Money.svg";
const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
const TREND_DISPLAY_MODE_MONTHLY = 1;
const HOURS_PER_GAME_MONTH = 24;

type TrendTone = "positive" | "negative" | "neutral";

export const StatFieldTrendTrackerExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        const result = Component(props);
        const trendText = getTrendText(props);

        if (!trendText || !isValidElement(result)) {
            return result;
        }

        return appendTrendText(result, trendText);
    };
};

// MoneyField is already captured by the vanilla toolbar before this mod can reliably wrap it.
// Hook the shared DescriptionTooltip instead, then filter to the money toolbar child only.
export const DescriptionTooltipTrendTrackerExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (!isMoneyTooltip(props)) {
            return Component(props);
        }

        return Component({
            ...props,
            content: <MoneyTrendTooltipContent baseContent={props.content} />,
        });
    };
};

const getTrendText = (props: any): ReactNode | null => {
    if (props?.unlimited === true) {
        return null;
    }

    if (props?.icon === MONEY_ICON) {
        return <MoneyTrendText />;
    }

    if (props?.icon === POPULATION_ICON) {
        return <PopulationTrendText />;
    }

    return null;
};

const appendTrendText = (element: ReactElement<any>, trendText: ReactNode): ReactElement<any> => {
    return cloneElement(
        element,
        undefined,
        <>
            {element.props.children}
            {trendText}
        </>
    );
};

const MoneyTrendText = () => {
    const trendTracker = useValue(trendTracker$);
    const trendDisplayMode = useValue(trendDisplayMode$);
    const unlimitedMoney = useValue(toolbarBottom.unlimitedMoney$);
    const moneyDelta = useValue(toolbarBottom.moneyDelta$);
    const totalIncome = useValue(economyBudget.totalIncome$);
    const totalExpenses = useValue(economyBudget.totalExpenses$);

    if (!trendTracker || unlimitedMoney) {
        return null;
    }

    const monthlyMoney = getNumericValue(totalIncome) - Math.abs(getNumericValue(totalExpenses));
    const displayedValue = trendDisplayMode === TREND_DISPLAY_MODE_MONTHLY
        ? monthlyMoney
        : getNumericValue(moneyDelta);

    return <TrendText value={displayedValue} displayMode={trendDisplayMode} />;
};

const PopulationTrendText = () => {
    const trendTracker = useValue(trendTracker$);
    const trendDisplayMode = useValue(trendDisplayMode$);
    const populationDelta = useValue(toolbarBottom.populationDelta$);

    if (!trendTracker) {
        return null;
    }

    const displayedValue = trendDisplayMode === TREND_DISPLAY_MODE_MONTHLY
        ? getNumericValue(populationDelta) * HOURS_PER_GAME_MONTH
        : getNumericValue(populationDelta);

    return <TrendText value={displayedValue} displayMode={trendDisplayMode} />;
};

const TrendText = ({ value, displayMode }: { readonly value: number; readonly displayMode: number }) => {
    const tone = getTrendTone(value);
    const suffix = displayMode === TREND_DISPLAY_MODE_MONTHLY ? "/mo" : "/h";
    const text = `${formatTrendValue(value)}\u00A0${suffix}`;

    return (
        <div className={`${styles.trendText} ${styles[tone]}`}>
            {text}
        </div>
    );
};

const MoneyTrendTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const trendTracker = useValue(trendTracker$);
    const trendDisplayMode = useValue(trendDisplayMode$);
    const monthlyIncome = getNumericValue(useValue(economyBudget.totalIncome$));
    const monthlyExpenses = -Math.abs(getNumericValue(useValue(economyBudget.totalExpenses$)));
    const monthlyBalance = monthlyIncome + monthlyExpenses;
    const hourlyIncome = monthlyIncome / HOURS_PER_GAME_MONTH;
    const hourlyExpenses = monthlyExpenses / HOURS_PER_GAME_MONTH;

    if (!trendTracker) {
        return <>{baseContent}</>;
    }

    return (
        <>
            {baseContent}
            <div className={styles.tooltipRows}>
                <TrendTooltipRow label="Monthly balance:" value={monthlyBalance} suffix="/mo" />
                <TrendTooltipRow label="Monthly income:" value={monthlyIncome} suffix="/mo" />
                <TrendTooltipRow label="Monthly expenses:" value={monthlyExpenses} suffix="/mo" />
                {trendDisplayMode === TREND_DISPLAY_MODE_MONTHLY && (
                    <>
                        <TrendTooltipRow label="Hourly income:" value={hourlyIncome} suffix="/h" />
                        <TrendTooltipRow label="Hourly expenses:" value={hourlyExpenses} suffix="/h" />
                    </>
                )}
            </div>
        </>
    );
};

const isMoneyTooltip = (props: any): boolean => {
    return Boolean(props?.content) && containsIcon(props?.children, MONEY_ICON);
};

const containsIcon = (node: ReactNode, icon: string): boolean => {
    if (!isValidElement(node)) {
        return false;
    }

    const props = node.props as any;
    if (props?.icon === icon) {
        return true;
    }

    return Children.toArray(props?.children).some((child) => containsIcon(child, icon));
};

const TrendTooltipRow = ({ label, value, suffix }: { readonly label: string; readonly value: number; readonly suffix: string }) => {
    const tone = getTrendTone(value);
    const text = `${formatTrendValue(value)}\u00A0${suffix}`;

    return (
        <div className={styles.tooltipRow}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={`${styles.tooltipValue} ${styles[tone]}`}>
                {text}
            </div>
        </div>
    );
};

const getTrendTone = (value: number): TrendTone => {
    if (value > 0) {
        return "positive";
    }

    if (value < 0) {
        return "negative";
    }

    return "neutral";
};

const getNumericValue = (value: number): number => {
    return Number.isFinite(value) ? value : 0;
};

const formatTrendValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+" : value < 0 ? "-" : "";
    return `${sign}${roundedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;
};
