export const MONEY_ICON = "Media/Game/Icons/Money.svg";
export const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
export const MONEY_VIEW_MODE_MONTHLY = 1;
export const MONEY_TOOLTIP_MODE_DEFAULT = 0;
export const MONEY_TOOLTIP_MODE_COMPACT = 1;
export const MONEY_TOOLTIP_MODE_MINI = 2;

// CS2 budget totals are monthly, while the vanilla toolbar trend is hourly.
export const HOURS_PER_GAME_MONTH = 24;

export type SignedAmountTone = "positive" | "negative" | "neutral";

type NumberFormatter = {
    format(value: number): string;
};

const numberFormatterCache = new Map<string, NumberFormatter | null>();

const normalizeLocale = (locale?: string | null): string | undefined => {
    const trimmedLocale = locale?.trim();
    if (!trimmedLocale || trimmedLocale.toLowerCase() === "os") {
        return undefined;
    }

    return trimmedLocale.replace(/_/g, "-");
};

const getNumberFormatter = (
    locale: string | null | undefined,
    cacheName: string,
    options: Intl.NumberFormatOptions
): NumberFormatter | null => {
    const normalizedLocale = normalizeLocale(locale);
    const cacheKey = `${normalizedLocale ?? "runtime"}:${cacheName}`;

    if (numberFormatterCache.has(cacheKey)) {
        return numberFormatterCache.get(cacheKey) ?? null;
    }

    const formatter = createNumberFormatter(normalizedLocale, options);
    numberFormatterCache.set(cacheKey, formatter);
    return formatter;
};

const createNumberFormatter = (locale: string | undefined, options: Intl.NumberFormatOptions): NumberFormatter | null => {
    try {
        // Coherent may run without Intl support; only use it when the game runtime exposes it safely.
        if (typeof Intl === "undefined" || typeof Intl.NumberFormat !== "function") {
            return null;
        }

        return new Intl.NumberFormat(locale, options);
    } catch {
        return null;
    }
};

export const isMoneyViewLocaleProbeEnabled = (): boolean => {
    try {
        // Temp locale probe. Enable in Coherent console:
        // localStorage.setItem("CWDMoneyViewLocaleProbe", "1"); location.reload();
        // Disable:
        // localStorage.removeItem("CWDMoneyViewLocaleProbe"); location.reload();
        return typeof localStorage !== "undefined" && localStorage.getItem("CWDMoneyViewLocaleProbe") === "1";
    } catch {
        return false;
    }
};

export const getMoneyViewLocaleProbeLines = (activeLocale?: string | null): string[] => {
    try {
        const hasIntl = typeof Intl !== "undefined" && typeof Intl.NumberFormat === "function";
        const normalizedLocale = normalizeLocale(activeLocale) ?? "(runtime)";

        if (!hasIntl) {
            return [
                `activeLocale: ${activeLocale ?? "(empty)"}`,
                "hasIntl: false",
            ];
        }

        return [
            `activeLocale: ${activeLocale ?? "(empty)"}`,
            `normalizedLocale: ${normalizedLocale}`,
            `runtimeLocale: ${new Intl.NumberFormat(undefined).resolvedOptions().locale}`,
            `activeExample: ${new Intl.NumberFormat(normalizeLocale(activeLocale)).format(1234567.89)}`,
            `de-DE example: ${new Intl.NumberFormat("de-DE").format(1234567.89)}`,
            `fr-FR example: ${new Intl.NumberFormat("fr-FR").format(1234567.89)}`,
        ];
    } catch (error) {
        return [
            `activeLocale: ${activeLocale ?? "(empty)"}`,
            `probeError: ${String(error)}`,
        ];
    }
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

const formatSignedWholeNumber = (
    value: number,
    includePositiveSign: boolean,
    useThinSpace: boolean,
    locale?: string | null
): string => {
    const magnitude = formatWholeNumberMagnitude(value, locale);
    const spacer = useThinSpace ? "\u200A" : "";

    if (value > 0 && includePositiveSign) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

const formatWholeNumberMagnitude = (value: number, locale?: string | null): string => {
    const roundedValue = Math.round(Math.abs(value));
    const wholeNumberFormatter = getNumberFormatter(locale, "whole", {
        maximumFractionDigits: 0,
    });

    if (wholeNumberFormatter) {
        return wholeNumberFormatter.format(roundedValue);
    }

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

export const formatTooltipMoneyViewValue = (value: number, compact: boolean, locale?: string | null): string => {
    return compact ? formatCompactTooltipValue(value, locale) : formatSignedWholeNumber(value, true, true, locale);
};

// Total city money is a balance, so do not add a plus sign for positive values.
export const formatTooltipMoneyValue = (value: number, locale?: string | null): string => {
    return formatSignedWholeNumber(value, false, true, locale);
};

export const formatToolbarMoneyViewValue = (value: number, locale?: string | null): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+" : value < 0 ? "-" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000_000, locale)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000, locale)}M`;
    }

    return formatSignedWholeNumber(value, true, false, locale);
};

const formatCompactTooltipValue = (value: number, locale?: string | null): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000_000, locale)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000, locale)}M`;
    }

    return formatSignedWholeNumber(value, true, true, locale);
};

const formatCompactNumber = (value: number, locale?: string | null): string => {
    if (value >= 100) {
        return formatWholeNumberMagnitude(value, locale);
    }

    return getNumberFormatter(locale, "compact-decimal", {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
    })?.format(value) ?? value.toFixed(2);
};

const formatFixedCompactNumber = (value: number, locale?: string | null): string => {
    if (value >= 100) {
        return formatWholeNumberMagnitude(value, locale);
    }

    return getNumberFormatter(locale, "compact-decimal", {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
    })?.format(value) ?? value.toFixed(2);
};
