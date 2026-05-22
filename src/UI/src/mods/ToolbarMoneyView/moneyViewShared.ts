export const MONEY_ICON = "Media/Game/Icons/Money.svg";
export const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
export const MONEY_VIEW_DISPLAY_MODE_MONTHLY = 1;
export const MONEY_TOOLTIP_MODE_DEFAULT = 0;
export const MONEY_TOOLTIP_MODE_COMPACT = 1;
export const MONEY_TOOLTIP_MODE_MINI = 2;

// CS2 budget totals are monthly, while the vanilla toolbar trend is hourly.
export const HOURS_PER_GAME_MONTH = 24;

export type SignedAmountTone = "positive" | "negative" | "neutral";

const wholeNumberFormatter = new Intl.NumberFormat("en-US", {
    maximumFractionDigits: 0,
});

export const getSignedAmountTone = (value: number): SignedAmountTone => {
    if (value > 0) {
        return "positive";
    }

    if (value < 0) {
        return "negative";
    }

    return "neutral";
};

export const getNumericValue = (value: number): number => {
    return Number.isFinite(value) ? value : 0;
};

const formatSignedWholeNumber = (
    value: number,
    includePositiveSign: boolean,
    useThinSpace: boolean
): string => {
    const magnitude = wholeNumberFormatter.format(Math.round(Math.abs(value)));
    const spacer = useThinSpace ? "\u200A" : "";

    if (value > 0 && includePositiveSign) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

export const formatTooltipMoneyViewValue = (value: number, compact: boolean): string => {
    return compact ? formatCompactTooltipValue(value) : formatSignedWholeNumber(value, true, true);
};

// Total city money is a balance, so do not add a plus sign for positive values.
export const formatTooltipMoneyValue = (value: number): string => {
    return formatSignedWholeNumber(value, false, true);
};

export const formatToolbarMoneyViewValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+" : value < 0 ? "-" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000_000)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000)}M`;
    }

    return formatSignedWholeNumber(value, true, false);
};

const formatCompactTooltipValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000_000)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000)}M`;
    }

    return formatSignedWholeNumber(value, true, true);
};

const formatCompactNumber = (value: number): string => {
    if (value >= 100) {
        return Math.round(value).toString();
    }

    return value.toFixed(2);
};

const formatFixedCompactNumber = (value: number): string => {
    if (value >= 100) {
        return Math.round(value).toString();
    }

    return value.toFixed(2);
};
