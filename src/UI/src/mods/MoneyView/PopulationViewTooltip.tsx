// File: src/UI/src/mods/MoneyView/PopulationViewTooltip.tsx
// Purpose: Adds CWD population flow rows to the vanilla population tooltip.

import { bindValue, useValue } from "cs2/api";
import { infoview, toolbarBottom } from "cs2/bindings";
import { LocalizedNumber, Unit, useLocalization, type Localization } from "cs2/l10n";
import { Children, isValidElement, type CSSProperties, type ReactNode } from "react";
import { moneyView$, populationTooltipFontScale$ } from "../Bindings/Bindings";
import styles from "./MoneyView.module.scss";
import { getDisplayWholeValue, getNumericValue, getSignedAmountTone, POPULATION_ICON } from "./moneyViewShared";

// Vanilla exposes this binding, but the generated cs2/bindings type does not currently list it.
const homeless$ = bindValue<number>("populationInfo", "homeless", 0);

export const PopulationViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const localization = useLocalization();
    const { translate } = localization;
    const localize = (key: string, fallback: string) => translate(`CityWatchdog.UI[${key}]`) ?? fallback;
    const moneyViewEnabled = useValue(moneyView$);
    const populationTooltipFontScale = useValue(populationTooltipFontScale$);
    const currentTrend = getNumericValue(useValue(toolbarBottom.populationDelta$));

    // These come from vanilla PopulationInfoviewUISystem, so CWD does not need its own sim queries.
    const births = getNumericValue(useValue(infoview.birthRate$));
    const deaths = getNumericValue(useValue(infoview.deathRate$));
    const homeless = getNumericValue(useValue(homeless$));
    const movedIn = getNumericValue(useValue(infoview.movedIn$));
    const movedAway = getNumericValue(useValue(infoview.movedAway$));

    if (!moneyViewEnabled) {
        return baseContent ? <>{baseContent}</> : null;
    }

    const tooltipStyle = {
        "--populationTooltipValueSize": getTooltipValueSize(populationTooltipFontScale),
    } as CSSProperties;

    return (
        <div className={styles.populationTooltipWrapper} style={tooltipStyle}>
            <div className={styles.tooltipTitle}>WATCHDOG</div>
            <PopulationTooltipCurrentTrend
                localization={localization}
                label={localize("PopulationTooltipCurrentTrend", "Current trend:")}
                value={currentTrend}
            />
            <div className={styles.populationTooltipExtra}>
                <PopulationTooltipFlow
                    localization={localization}
                    label={localize("PopulationTooltipBirths", "Births:")}
                    value={births}
                    direction={1}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={localize("PopulationTooltipDeaths", "Deaths:")}
                    value={deaths}
                    direction={-1}
                />
                <PopulationTooltipCount
                    localization={localization}
                    label={localize("PopulationTooltipHomeless", "Homeless:")}
                    value={homeless}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={localize("PopulationTooltipMovedIn", "Moved in:")}
                    value={movedIn}
                    direction={1}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={localize("PopulationTooltipMovedOut", "Moved out:")}
                    value={movedAway}
                    direction={-1}
                />
            </div>
        </div>
    );
};

export const isPopulationTooltip = (props: any): boolean => {
    return containsIcon(props?.children, POPULATION_ICON);
};

// Walk the vanilla tooltip tree instead of querying generated CSS class names.
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

const PopulationTooltipFlow = ({
    localization,
    label,
    value,
    direction,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
    readonly direction: 1 | -1;
}) => {
    const displayValue = getDisplayWholeValue(value);

    // Births/moved-in add population; deaths/moved-out subtract population.
    const signedValue = displayValue === 0 ? 0 : displayValue * direction;

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={signedValue}
            unit={Unit.IntegerPerMonth}
        />
    );
};

const PopulationTooltipCount = ({
    localization,
    label,
    value,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
}) => {
    const displayValue = getDisplayWholeValue(value);

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={displayValue}
            unit={Unit.Integer}
            toneOverride="neutral"
            showSign={false}
        />
    );
};

const PopulationTooltipCurrentTrend = ({
    localization,
    label,
    value,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
}) => {
    const displayValue = getDisplayWholeValue(value);

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={displayValue}
            unit={Unit.IntegerPerHour}
            topRow={true}
        />
    );
};

const PopulationTooltipRate = ({
    localization,
    label,
    value,
    unit,
    topRow = false,
    toneOverride,
    showSign = true,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
    readonly unit: Unit;
    readonly topRow?: boolean;
    readonly toneOverride?: "positive" | "negative" | "neutral";
    readonly showSign?: boolean;
}) => {
    const tone = toneOverride ?? getSignedAmountTone(value);
    const text = showSign
        ? formatPopulationRateValue(localization, value, unit)
        : formatLocalizedIntegerValue(localization, value, unit);

    return (
        <div className={`${styles.populationTooltipGroup} ${topRow ? styles.populationTooltipTopTrend : ""}`}>
            <div className={styles.tooltipLabel}>{trimLabelPunctuation(label)}</div>
            <div className={`${styles.populationTooltipValueLine} ${styles[tone]}`}>{text}</div>
        </div>
    );
};

const formatPopulationRateValue = (localization: Localization, value: number, unit: Unit): string => {
    const magnitude = formatLocalizedIntegerValue(localization, Math.abs(value), unit);
    const spacer = "\u200A";

    if (value > 0) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

const formatLocalizedIntegerValue = (localization: Localization, value: number, unit: Unit): string => {
    try {
        // Vanilla formatter keeps separators and /h or /mo aligned with the selected game language.
        return LocalizedNumber.renderString(localization, {
            value,
            unit,
            signed: false,
        });
    } catch {
        const suffix =
            unit === Unit.IntegerPerMonth
                ? " /mo"
                : unit === Unit.IntegerPerHour
                    ? " /h"
                    : "";

        return `${Math.round(Math.abs(value)).toString()}${suffix}`;
    }
};

const getTooltipValueSize = (value: number): string => {
    const percent = Math.min(130, Math.max(90, Number(value) || 100));
    return `${percent / 100}em`;
};

const trimLabelPunctuation = (label: string): string => {
    return label.replace(/[\s:：]+$/u, "");
};
