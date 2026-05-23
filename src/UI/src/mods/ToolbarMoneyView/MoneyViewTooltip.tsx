import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import { Unit, useLocalization, type Localization } from "cs2/l10n";
import { Children, isValidElement, type CSSProperties, type ReactNode } from "react";
import { moneyTooltipFontScale$, moneyTooltipMode$, moneyView$ } from "../Bindings/Bindings";
import styles from "./ToolbarMoneyView.module.scss";
import {
    formatTooltipMoneyValue,
    formatTooltipMoneyViewValue,
    getDisplayWholeValue,
    getNumericValue,
    getSignedAmountTone,
    HOURS_PER_GAME_MONTH,
    MONEY_ICON,
    MONEY_TOOLTIP_MODE_COMPACT,
    MONEY_TOOLTIP_MODE_DEFAULT,
    MONEY_TOOLTIP_MODE_MINI,
} from "./moneyViewShared";

export const MoneyViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const localization = useLocalization();
    // Text uses translate(); numbers below reuse this object with LocalizedNumber so both match the game locale.
    const { translate } = localization;
    const localize = (key: string, fallback: string) => translate(`CityWatchdog.UI[${key}]`) ?? fallback;
    const moneyViewEnabled = useValue(moneyView$);
    const moneyTooltipMode = useValue(moneyTooltipMode$);
    const moneyTooltipFontScale = useValue(moneyTooltipFontScale$);
    const hourlyNet = getNumericValue(useValue(toolbarBottom.moneyDelta$));
    const monthlyIncome = getNumericValue(useValue(economyBudget.totalIncome$));
    // Normalize Budget expenses before net monthly income is calculated.
    const monthlyExpenses = -Math.abs(getNumericValue(useValue(economyBudget.totalExpenses$)));
    const monthlyBalance = monthlyIncome + monthlyExpenses;
    const hourlyIncome = monthlyIncome / HOURS_PER_GAME_MONTH;
    const hourlyExpenses = monthlyExpenses / HOURS_PER_GAME_MONTH;

    // Current total city money same as vanilla bottom toolbar.
    const totalMoney = getNumericValue(useValue(toolbarBottom.money$));

    if (!moneyViewEnabled) {
        return <>{baseContent}</>;
    }

    const compact = moneyTooltipMode !== MONEY_TOOLTIP_MODE_DEFAULT;
    const mini = moneyTooltipMode === MONEY_TOOLTIP_MODE_MINI;
    const tooltipClassName = getTooltipRowsClassName(moneyTooltipMode);
    const tooltipValueSize = getTooltipValueSize(moneyTooltipFontScale);
    const tooltipStyle = {
        "--moneyTooltipValueSizeFull": tooltipValueSize,
        "--moneyTooltipValueSizeCompact": tooltipValueSize,
        "--moneyTooltipValueSizeMini": tooltipValueSize,
    } as CSSProperties;

    return (
        <div className={tooltipClassName} style={tooltipStyle}>
            <div className={styles.tooltipTitle}>WATCHDOG</div>
            {!mini && <MoneyViewTooltipGroup localization={localization} label={localize("MoneyViewTooltipIncome", "Income:")} hourlyValue={hourlyIncome} monthlyValue={monthlyIncome} compact={compact} mode={moneyTooltipMode} />}
            {!mini && <MoneyViewTooltipGroup localization={localization} label={localize("MoneyViewTooltipExpenses", "Expenses:")} hourlyValue={hourlyExpenses} monthlyValue={monthlyExpenses} compact={compact} mode={moneyTooltipMode} />}
            <MoneyViewTooltipGroup localization={localization} label={localize("MoneyViewTooltipNet", "Net:")} hourlyValue={hourlyNet} monthlyValue={monthlyBalance} compact={compact} mode={moneyTooltipMode} />
            {moneyTooltipMode === MONEY_TOOLTIP_MODE_DEFAULT && <MoneyViewTooltipSingleValue localization={localization} label={localize("MoneyViewTooltipTotal", "Total:")} value={totalMoney} mode={moneyTooltipMode} />}
        </div>
    );
};

const getTooltipValueSize = (value: number): string => {
    const percent = Math.min(130, Math.max(90, Number(value) || 100));
    return `${percent / 100}em`;
};

const getTooltipRowsClassName = (mode: number): string => {
    const classes = [styles.tooltipRows];

    if (mode === MONEY_TOOLTIP_MODE_MINI) {
        classes.push(styles.tooltipRowsMini);
    } else if (mode === MONEY_TOOLTIP_MODE_COMPACT) {
        classes.push(styles.tooltipRowsCompact);
    } else {
        classes.push(styles.tooltipRowsFull);
    }

    return classes.join(" ");
};

export const isMoneyTooltip = (props: any): boolean => {
    return Boolean(props?.content) && containsIcon(props?.children, MONEY_ICON);
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

const MoneyViewTooltipGroup = ({ localization, label, hourlyValue, monthlyValue, compact, mode }: { readonly localization: Localization; readonly label: string; readonly hourlyValue: number; readonly monthlyValue: number; readonly compact: boolean; readonly mode: number }) => {
    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <MoneyViewTooltipValue localization={localization} value={hourlyValue} unit={Unit.IntegerPerHour} compact={compact} mode={mode} />
                <MoneyViewTooltipValue localization={localization} value={monthlyValue} unit={Unit.IntegerPerMonth} compact={compact} mode={mode} />
            </div>
        </div>
    );
};

const MoneyViewTooltipSingleValue = ({ localization, label, value, mode }: { readonly localization: Localization; readonly label: string; readonly value: number; readonly mode: number }) => {
    const displayValue = getDisplayWholeValue(value);
    const tone = getSignedAmountTone(displayValue);
    const text = formatTooltipMoneyValue(localization, displayValue);

    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <div className={`${styles.tooltipValueLine} ${getTooltipValueClassName(mode)} ${styles[tone]}`}>{text}</div>
            </div>
        </div>
    );
};

const MoneyViewTooltipValue = ({ localization, value, unit, compact, mode }: { readonly localization: Localization; readonly value: number; readonly unit: Unit; readonly compact: boolean; readonly mode: number }) => {
    const displayValue = getDisplayWholeValue(value);
    const tone = getSignedAmountTone(displayValue);
    const text = formatTooltipMoneyViewValue(localization, displayValue, compact, unit);

    return <div className={`${styles.tooltipValueLine} ${getTooltipValueClassName(mode)} ${styles[tone]}`}>{text}</div>;
};

const getTooltipValueClassName = (mode: number): string => {
    if (mode === MONEY_TOOLTIP_MODE_MINI) {
        return styles.tooltipValueLineMini;
    }

    if (mode === MONEY_TOOLTIP_MODE_COMPACT) {
        return styles.tooltipValueLineCompact;
    }

    return styles.tooltipValueLineFull;
};
