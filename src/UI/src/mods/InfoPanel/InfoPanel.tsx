// File: src/UI/src/mods/InfoPanel/InfoPanel.tsx
// Purpose: Collapsible section wrapper for grouped City Watchdog notification rows.

import { CSSProperties, ReactNode, useState } from "react";
import { Button } from "cs2/ui";
import styles from "../InfoPanel/InfoPanel.module.scss";

type SummaryState = "off" | "partial" | "on";

export interface InfoPanelProps {
    className?: string;
    style?: CSSProperties;
    title?: string;
    children?: ReactNode;
    collapsible?: boolean;
    defaultExpanded?: boolean;
    expanded?: boolean;
    onExpandedChange?: (expanded: boolean) => void;
    summary?: string;
    summaryState?: SummaryState;
    renderChildren?: () => ReactNode;
}

export const InfoPanel = ({
    className = "",
    style = {},
    title,
    children,
    collapsible = false,
    defaultExpanded = true,
    expanded,
    onExpandedChange,
    summary,
    summaryState = "off",
    renderChildren,
}: InfoPanelProps) => {
    const [internalExpanded, setInternalExpanded] = useState(defaultExpanded);
    const isExpanded = expanded ?? internalExpanded;
    const showBody = !collapsible || isExpanded;

    const summaryStateClass =
        summaryState === "on"
            ? styles.infoPanelSummaryOn
            : summaryState === "partial"
                ? styles.infoPanelSummaryPartial
                : styles.infoPanelSummaryOff;

    const setExpanded = (value: boolean) => {
        if (expanded === undefined) {
            setInternalExpanded(value);
        }

        onExpandedChange?.(value);
    };

    const toggleExpanded = () => {
        setExpanded(!isExpanded);
    };

    return (
        <div className={`${styles.infoPanel} ${className}`} style={style}>
            {title && collapsible && (
                <Button
                    className={styles.infoPanelHeader}
                    onClick={toggleExpanded}
                >
                    <span className={styles.infoPanelTitle}>{title}</span>
                    {summary && <span className={`${styles.infoPanelSummary} ${summaryStateClass}`}>{summary}</span>}
                    <span className={styles.infoPanelToggle}>{isExpanded ? "-" : "+"}</span>
                </Button>
            )}

            {title && !collapsible && <div className={styles.infoPanelTitle}>{title}</div>}

            {showBody && (
                <div className={styles.infoPanelBody}>
                    {renderChildren ? renderChildren() : children}
                </div>
            )}
        </div>
    );
};
