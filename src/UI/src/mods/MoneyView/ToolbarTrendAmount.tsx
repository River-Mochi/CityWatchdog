// File: src/UI/src/mods/MoneyView/ToolbarTrendAmount.tsx
// Purpose: Renders Money View trend amounts beside vanilla money and population fields.

import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import { Unit, useLocalization, type Localization } from "cs2/l10n";
import { moneyViewMode$, moneyView$ } from "../Bindings/Bindings";
import styles from "./MoneyView.module.scss";
import {
    formatMoneyViewValue,
    getDisplayWholeValue,
    getNumericValue,
    getSignedAmountTone,
    HOURS_PER_GAME_MONTH,
    MONEY_VIEW_MODE_MONTHLY,
} from "./moneyViewShared";

export const ToolbarMoneyDelta = () => {
    const localization = useLocalization();
    const moneyViewEnabled = useValue(moneyView$);
    const moneyViewMode = useValue(moneyViewMode$);
    const unlimitedMoney = useValue(toolbarBottom.unlimitedMoney$);
    const moneyDelta = useValue(toolbarBottom.moneyDelta$);
    const totalIncome = useValue(economyBudget.totalIncome$);
    const totalExpenses = useValue(economyBudget.totalExpenses$);

    if (!moneyViewEnabled || unlimitedMoney) {
        return null;
    }

    // Normalize Budget expenses before net monthly income is calculated.
    const normalizedMonthlyExpenses = -Math.abs(getNumericValue(totalExpenses));
    const monthlyMoney = getNumericValue(totalIncome) + normalizedMonthlyExpenses;
    const displayedValue = moneyViewMode === MONEY_VIEW_MODE_MONTHLY
        ? monthlyMoney
        : getNumericValue(moneyDelta);
    // Use vanilla integer units so Money View gets localized /h or /mo labels without repeating the money symbol.
    const unit = moneyViewMode === MONEY_VIEW_MODE_MONTHLY
        ? Unit.IntegerPerMonth
        : Unit.IntegerPerHour;

    return <ToolbarTrendAmount localization={localization} value={displayedValue} unit={unit} />;
};

export const ToolbarPopulationDelta = () => {
    const localization = useLocalization();
    const moneyViewEnabled = useValue(moneyView$);
    const moneyViewMode = useValue(moneyViewMode$);
    const populationDelta = useValue(toolbarBottom.populationDelta$);

    if (!moneyViewEnabled) {
        return null;
    }

    const displayedValue = moneyViewMode === MONEY_VIEW_MODE_MONTHLY
        ? getNumericValue(populationDelta) * HOURS_PER_GAME_MONTH
        : getNumericValue(populationDelta);
    // Population uses the same localized unit path as money, just without the money symbol.
    const unit = moneyViewMode === MONEY_VIEW_MODE_MONTHLY
        ? Unit.IntegerPerMonth
        : Unit.IntegerPerHour;

    return <ToolbarTrendAmount localization={localization} value={displayedValue} unit={unit} />;
};

const ToolbarTrendAmount = ({ localization, value, unit }: { readonly localization: Localization; readonly value: number; readonly unit: Unit }) => {
    const displayValue = getDisplayWholeValue(value);
    const tone = getSignedAmountTone(displayValue);
    const text = formatMoneyViewValue(localization, displayValue, unit);

    return (
        <div className={`${styles.moneyViewText} ${styles[tone]}`}>
            {text}
        </div>
    );
};
