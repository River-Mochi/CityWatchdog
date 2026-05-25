// File: src/UI/src/mods/NotificationPanel/NotificationPanel.tsx
// Purpose: In-city CWD notification icon panel and buttons.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { Button, Panel, Tooltip } from "cs2/ui";
import { useState } from "react";
import { controlPanelEnabled$, OnControlPanelBindingToggle } from "../Bindings/Bindings";
import { Divider } from "../Divider/Divider";
import { InfoPanel } from "../InfoPanel/InfoPanel";
import { VanillaComponentResolver } from "../VanillaComponentResolver/VanillaComponentResolver";
import { NotificationRow } from "./NotificationRow";
import styles from "./NotificationPanel.module.scss";
import {
    allIconSources,
    createExpandedSections,
    sections,
    setAllNotifications,
    type Localize,
    type NotificationSection,
} from "./notificationData";
import { useAllNotificationValues, useSectionValues } from "./notificationHooks";

// Title icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import TitleBarIconPath from "../../../images/NotificationIcon_TitleBar.svg";

// Sort icons are custom mod images emitted by webpack to coui://ui-mods/images/.
import SortArrowUpPath from "../../../images/sort-arrow-up.svg";
import SortArrowDownPath from "../../../images/sort-arrow-down.svg";

const modIconSrc = TitleBarIconPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;

// Info icon uses the built-in game media path.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

// Toolbar icons use built-in game media paths.
// All.svg is the vanilla snap-options "all" icon.
const toggleAllIconSrc = "Media/Tools/Snap Options/All.svg";

// ParallelPlus / ParallelMinus are used as compact expand/collapse icons.
const expandAllIconSrc = "Media/Tools/Net Tool/ParallelPlus.svg";
const collapseAllIconSrc = "Media/Tools/Net Tool/ParallelMinus.svg";

const roundButtonHighlightStyle = getModule("game-ui/common/input/button/themes/round-highlight-button.module.scss", "classes");

export const NotificationPanel = () => {
    const showPanel = useValue(controlPanelEnabled$);
    const isPhotoMode = useValue(game.activeGamePanel$)?.__Type == game.GamePanelType.PhotoMode;

    if (isPhotoMode || !showPanel) {
        return null;
    }

    return <NotificationPanelContent />;
};

const NotificationPanelContent = () => {
    const { translate } = useLocalization();
    const [sortAscending, setSortAscending] = useState(true);
    const [expandedSections, setExpandedSections] = useState(createExpandedSections);
    const allValues = useAllNotificationValues();

    const allSelected = allValues.every(Boolean);
    const anySelected = allValues.some(Boolean);
    const toggleAllStateClass = allSelected
        ? styles.toggleAllOn
        : anySelected
            ? styles.toggleAllPartial
            : styles.toggleAllOff;

    const allSectionsExpanded = sections.every((section) => expandedSections[section.localeId] === true);
    const sortIconSrc = sortAscending ? sortArrowUpSrc : sortArrowDownSrc;

    const localize: Localize = (localeId, fallback, raw = false) => {
        if (raw) {
            return translate(localeId) ?? fallback ?? localeId;
        }

        return translate(`CityWatchdog.UI[${localeId}]`) ?? fallback ?? localeId;
    };

    const tooltipContent = (localeId: string, fallback: string) => {
        const tooltip = localize(localeId, fallback);
        const lines = tooltip.split("\n");

        if (lines.length <= 1) {
            return tooltip;
        }

        return (
            <div className={styles.tooltipText}>
                {lines.map((line, index) => (
                    <div key={`${localeId}-${index}`}>{line}</div>
                ))}
            </div>
        );
    };

    const orderedSections = [...sections].sort((a, b) => {
        const result = localize(a.localeId).localeCompare(localize(b.localeId));
        return sortAscending ? result : -result;
    });

    const onToggleAll = () => {
        setAllNotifications(!allSelected);
    };

    const onToggleAllSections = () => {
        setExpandedSections(createExpandedSections(!allSectionsExpanded));
    };

    const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
        setExpandedSections((current) => ({
            ...current,
            [section.localeId]: expanded,
        }));
    };

    return (
        <Panel
            className={styles.panel}
            header={
                <div className={styles.header}>
                    <div className={styles.headerTitleArea}>
                        <img src={modIconSrc} className={styles.headerModIcon} />
                        <div className={styles.headerModName}>CITY WATCHDOG</div>
                    </div>
                    <Button
                        className={roundButtonHighlightStyle.button + " " + styles.headerCloseButton}
                        variant="icon"
                        onClick={() => { OnControlPanelBindingToggle(false); }}
                        focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                    >
                        <img src="coui://uil/Standard/XClose.svg"></img>
                    </Button>
                </div>
            }
        >
            {/* Left side: help + sort. Right side: mass actions. */}
            <div className={styles.toolbar}>
                <div className={styles.toolbarLeft}>
                    <Tooltip tooltip={tooltipContent("NotificationIconShowOrHide", "Expand rows; [✓] check to show, uncheck to hide alerts.\nDoes not fix city problems, it hides messy icons.")}>
                        <div className={styles.infoButton}>
                            <img src={infoIconSrc} className={styles.infoIcon} />
                        </div>
                    </Tooltip>

                    <Tooltip tooltip={localize("SortOrderTooltip", "Sort order")}>
                        <Button
                            className={`${styles.toolbarButton} ${styles.sortButton}`}
                            onClick={() => { setSortAscending(!sortAscending); }}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={sortIconSrc}
                                className={`${styles.toolbarIcon} ${styles.sortIcon}`}
                                alt=""
                            />
                        </Button>
                    </Tooltip>
                </div>

                <div className={styles.toolbarButtons}>
                    <Tooltip tooltip={allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows")}>
                        <Button
                            className={styles.toolbarButton + " " + styles.expandButton}
                            onClick={onToggleAllSections}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={allSectionsExpanded ? collapseAllIconSrc : expandAllIconSrc}
                                className={`${styles.toolbarIcon} ${styles.expandCollapseIcon}`}
                                alt=""
                            />
                        </Button>
                    </Tooltip>

                    <Tooltip tooltip={tooltipContent("ToggleAllTooltip", "Show/hide all icons.\nColor: green = all on; blue = mixed; red = all off.")}>
                        <Button
                            className={`${styles.toolbarButton} ${styles.toggleButton} ${toggleAllStateClass}`}
                            onClick={onToggleAll}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={toggleAllIconSrc}
                                className={`${styles.toolbarIcon} ${styles.toggleAllIcon}`}
                                alt=""
                            />
                        </Button>
                    </Tooltip>
                </div>
            </div>

            <IconPreloader />

            {orderedSections.map((section, index) => (
                <NotificationSectionView
                    key={section.localeId}
                    section={section}
                    expanded={expandedSections[section.localeId] === true}
                    localize={localize}
                    showDivider={index > 0}
                    onExpandedChange={(expanded) => onSectionExpandedChange(section, expanded)}
                />
            ))}
        </Panel>
    );
};

const IconPreloader = () => {
    return (
        <div className={styles.iconPreloader} aria-hidden="true">
            {allIconSources.map((source) => (
                <img key={source} src={source} alt="" />
            ))}
        </div>
    );
};

const NotificationSectionView = ({
    section,
    expanded,
    localize,
    showDivider,
    onExpandedChange,
}: {
    section: NotificationSection;
    expanded: boolean;
    localize: Localize;
    showDivider: boolean;
    onExpandedChange: (expanded: boolean) => void;
}) => {
    const values = useSectionValues(section);
    const selectedCount = values.filter(Boolean).length;

    const summaryState =
        selectedCount === section.items.length
            ? "on"
            : selectedCount > 0
                ? "partial"
                : "off";

    return (
        <>
            {showDivider && <Divider></Divider>}
            <InfoPanel
                title={localize(section.localeId)}
                collapsible={true}
                expanded={expanded}
                onExpandedChange={onExpandedChange}
                summary={`${selectedCount}/${section.items.length}`}
                summaryState={summaryState}
                renderChildren={() => section.items.map((item, itemIndex) => (
                    <NotificationRow
                        key={item.localeId}
                        item={item}
                        isChecked={values[itemIndex] ?? false}
                        localize={localize}
                    />
                ))}
            />
        </>
    );
};
