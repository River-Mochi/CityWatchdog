// File: src/UI/src/mods/InfoPanel/InfoPanel.tsx
// Purpose: Reusable collapsible section wrapper for the City Watchdog notification panel.

import { CSSProperties, KeyboardEvent, ReactNode, useState } from "react";
import styles from "../InfoPanel/InfoPanel.module.scss";

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
    renderChildren,
}: InfoPanelProps) => {
    const [internalExpanded, setInternalExpanded] = useState(defaultExpanded);
    const isExpanded = expanded ?? internalExpanded;
    const showBody = !collapsible || isExpanded;

    const setExpanded = (value: boolean) => {
        if (expanded === undefined) {
            setInternalExpanded(value);
        }

        onExpandedChange?.(value);
    };

    const toggleExpanded = () => {
        setExpanded(!isExpanded);
    };

    const onHeaderKeyDown = (event: KeyboardEvent<HTMLDivElement>) => {
        if (event.key !== "Enter" && event.key !== " ") {
            return;
        }

        event.preventDefault();
        toggleExpanded();
    };

    return (
        <div className={`${styles.infoPanel} ${className}`} style={style}>
            {title && collapsible && (
                <div
                    className={styles.infoPanelHeader}
                    role="button"
                    tabIndex={0}
                    aria-expanded={isExpanded}
                    onClick={toggleExpanded}
                    onKeyDown={onHeaderKeyDown}
                >
                    <span className={styles.infoPanelTitle}>{title}</span>
                    <span className={styles.infoPanelSummary}>{summary}</span>
                    <span className={styles.infoPanelToggle}>{isExpanded ? "-" : "+"}</span>
                </div>
            )}
            {title && !collapsible && <div className={styles.infoPanelTitle}>{title}</div>}
            {showBody && (renderChildren ? renderChildren() : children)}
        </div>
    );
};
