import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { Children, isValidElement, type ReactNode } from "react";
import { moneyTooltipMode$, moneyView$ } from "../Bindings/Bindings";
import styles from "./ToolbarMoneyView.module.scss";
import {
    formatTooltipMoneyValue,
    formatTooltipMoneyViewValue,
    getNumericValue,
    getSignedAmountTone,
    HOURS_PER_GAME_MONTH,
    MONEY_ICON,
    MONEY_TOOLTIP_MODE_COMPACT,
    MONEY_TOOLTIP_MODE_DEFAULT,
    MONEY_TOOLTIP_MODE_MINI,
} from "./moneyViewShared";

export const MoneyViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const { translate } = useLocalization();
    const localize = (key: string, fallback: string) => translate(`CityWatchdog.UI[${key}]`) ?? fallback;
    const moneyViewEnabled = useValue(moneyView$);
    const moneyTooltipMode = useValue(moneyTooltipMode$);
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

    return (
        <div className={tooltipClassName}>
            <div className={styles.tooltipTitle}>WATCHDOG</div>
            {!mini && <MoneyViewTooltipGroup label={localize("MoneyViewTooltipIncome", "Income:")} hourlyValue={hourlyIncome} monthlyValue={monthlyIncome} compact={compact} mode={moneyTooltipMode} />}
            {!mini && <MoneyViewTooltipGroup label={localize("MoneyViewTooltipExpenses", "Expenses:")} hourlyValue={hourlyExpenses} monthlyValue={monthlyExpenses} compact={compact} mode={moneyTooltipMode} />}
            <MoneyViewTooltipGroup label={localize("MoneyViewTooltipNet", "Net:")} hourlyValue={hourlyNet} monthlyValue={monthlyBalance} compact={compact} mode={moneyTooltipMode} />
            {moneyTooltipMode === MONEY_TOOLTIP_MODE_DEFAULT && <MoneyViewTooltipSingleValue label={localize("MoneyViewTooltipTotal", "Total:")} value={totalMoney} mode={moneyTooltipMode} />}
        </div>
    );
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

const MoneyViewTooltipGroup = ({ label, hourlyValue, monthlyValue, compact, mode }: { readonly label: string; readonly hourlyValue: number; readonly monthlyValue: number; readonly compact: boolean; readonly mode: number }) => {
    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <MoneyViewTooltipValue value={hourlyValue} suffix="/h" compact={compact} mode={mode} />
                <MoneyViewTooltipValue value={monthlyValue} suffix="/mo" compact={compact} mode={mode} />
            </div>
        </div>
    );
};

const MoneyViewTooltipSingleValue = ({ label, value, mode }: { readonly label: string; readonly value: number; readonly mode: number }) => {
    const tone = getSignedAmountTone(value);
    const text = formatTooltipMoneyValue(value);

    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <div className={`${styles.tooltipValueLine} ${getTooltipValueClassName(mode)} ${styles[tone]}`}>{text}</div>
            </div>
        </div>
    );
};

const MoneyViewTooltipValue = ({ value, suffix, compact, mode }: { readonly value: number; readonly suffix: string; readonly compact: boolean; readonly mode: number }) => {
    const tone = getSignedAmountTone(value);
    const text = `${formatTooltipMoneyViewValue(value, compact)}\u00A0${suffix}`;

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
