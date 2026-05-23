import { LocalizedNumber, Unit, type Localization } from "cs2/l10n";

export const MONEY_ICON = "Media/Game/Icons/Money.svg";
export const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
export const MONEY_VIEW_MODE_MONTHLY = 1;
export const MONEY_TOOLTIP_MODE_DEFAULT = 0;
export const MONEY_TOOLTIP_MODE_COMPACT = 1;
export const MONEY_TOOLTIP_MODE_MINI = 2;

// CS2 budget totals are monthly, while the vanilla toolbar trend is hourly.
export const HOURS_PER_GAME_MONTH = 24;

export type SignedAmountTone = "positive" | "negative" | "neutral";

// Match color/tone to the rounded number the player actually sees.
export const getDisplayWholeValue = (value: number): number => {
    return Math.round(getNumericValue(value));
};

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

const formatLocalizedValue = (
    localization: Localization,
    value: number,
    unit: Unit
): string => {
    try {
        // Prefer the CS2 localization API for game numbers; browser-style number formatting does not reliably follow the selected game language.
        return LocalizedNumber.renderString(localization, { value, unit, signed: false });
    } catch {
        return formatWholeNumberMagnitude(value);
    }
};

const formatSignedLocalizedValue = (
    localization: Localization,
    value: number,
    unit: Unit,
    includePositiveSign: boolean,
    useThinSpace: boolean
): string => {
    const magnitude = formatLocalizedValue(localization, Math.abs(value), unit);
    const spacer = useThinSpace ? "\u200A" : "";

    if (value > 0 && includePositiveSign) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

const formatWholeNumberMagnitude = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    return formatFallbackGroupedWholeNumber(roundedValue);
};

const formatFallbackGroupedWholeNumber = (value: number): string => {
    const digits = value.toString();
    let formatted = "";
    let digitCount = 0;

    for (let i = digits.length - 1; i >= 0; i--) {
        if (digitCount > 0 && digitCount % 3 === 0) {
            formatted = "," + formatted;
        }

        formatted = digits[i] + formatted;
        digitCount++;
    }

    return formatted;
};

export const formatTooltipMoneyViewValue = (
    localization: Localization,
    value: number,
    compact: boolean,
    unit: Unit
): string => {
    return compact
        ? formatCompactTooltipValue(localization, value, unit)
        : formatSignedLocalizedValue(localization, value, unit, true, true);
};

// Total city money is a balance, so do not add a plus sign for positive values.
export const formatTooltipMoneyValue = (localization: Localization, value: number): string => {
    return formatSignedLocalizedValue(localization, value, Unit.Integer, false, true);
};

export const formatToolbarMoneyViewValue = (
    localization: Localization,
    value: number,
    unit: Unit
): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatLocalizedCompactMagnitude(localization, roundedValue / 1_000_000_000)}B${extractLocalizedRateSuffix(localization, unit)}`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatLocalizedCompactMagnitude(localization, roundedValue / 1_000_000)}M${extractLocalizedRateSuffix(localization, unit)}`;
    }

    return formatSignedLocalizedValue(localization, value, unit, true, true);
};

const formatCompactTooltipValue = (
    localization: Localization,
    value: number,
    unit: Unit
): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatLocalizedCompactMagnitude(localization, roundedValue / 1_000_000_000)}B${extractLocalizedRateSuffix(localization, unit)}`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatLocalizedCompactMagnitude(localization, roundedValue / 1_000_000)}M${extractLocalizedRateSuffix(localization, unit)}`;
    }

    return formatSignedLocalizedValue(localization, value, unit, true, true);
};

const formatLocalizedCompactMagnitude = (localization: Localization, value: number): string => {
    const unit = value >= 100 ? Unit.Integer : Unit.FloatTwoFractions;
    return formatLocalizedValue(localization, value, unit);
};

const extractLocalizedRateSuffix = (localization: Localization, unit: Unit): string => {
    if (unit === Unit.Integer || unit === Unit.FloatTwoFractions) {
        return "";
    }

    try {
        // Compact M/B values still need vanilla's localized rate suffix.
        // Format "0 /h" or "0 /mo", then remove the plain "0" and keep the suffix.
        const zeroWithUnit = LocalizedNumber.renderString(localization, { value: 0, unit, signed: false });
        const zeroPlain = LocalizedNumber.renderString(localization, { value: 0, unit: Unit.Integer, signed: false });

        return zeroWithUnit.startsWith(zeroPlain)
            ? zeroWithUnit.slice(zeroPlain.length)
            : "";
    } catch {
        return unit === Unit.IntegerPerMonth ? " /mo" : unit === Unit.IntegerPerHour ? " /h" : "";
    }
};
