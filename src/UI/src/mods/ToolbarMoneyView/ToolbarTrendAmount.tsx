import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import { moneyViewMode$, moneyView$ } from "../Bindings/Bindings";
import styles from "./ToolbarMoneyView.module.scss";
import {
    formatToolbarMoneyViewValue,
    getNumericValue,
    getSignedAmountTone,
    HOURS_PER_GAME_MONTH,
    MONEY_VIEW_MODE_MONTHLY,
} from "./moneyViewShared";

export const ToolbarMoneyDelta = () => {
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

    return <ToolbarTrendAmount value={displayedValue} displayMode={moneyViewMode} />;
};

export const ToolbarPopulationDelta = () => {
    const moneyViewEnabled = useValue(moneyView$);
    const moneyViewMode = useValue(moneyViewMode$);
    const populationDelta = useValue(toolbarBottom.populationDelta$);

    if (!moneyViewEnabled) {
        return null;
    }

    const displayedValue = moneyViewMode === MONEY_VIEW_MODE_MONTHLY
        ? getNumericValue(populationDelta) * HOURS_PER_GAME_MONTH
        : getNumericValue(populationDelta);

    return <ToolbarTrendAmount value={displayedValue} displayMode={moneyViewMode} />;
};

const ToolbarTrendAmount = ({ value, displayMode }: { readonly value: number; readonly displayMode: number }) => {
    const tone = getSignedAmountTone(value);
    const suffix = displayMode === MONEY_VIEW_MODE_MONTHLY ? "/mo" : "/h";
    const text = `${formatToolbarMoneyViewValue(value)}\u00A0${suffix}`;

    return (
        <div className={`${styles.moneyViewText} ${styles[tone]}`}>
            {text}
        </div>
    );
};
