// File: src/UI/src/mods/NotificationPanel/NotificationRow.tsx
// Purpose: Renders one notification icon row and prefers vanilla game title text when available.

import { InfoCheckbox } from "../InfoCheckbox/InfoCheckbox";
import { gameTitleKeys, type Localize, type NotificationItem } from "./notificationData";

export const NotificationRow = ({
    item,
    isChecked,
    localize,
}: {
    item: NotificationItem;
    isChecked: boolean;
    localize: Localize;
}) => {
    const gameTitleKey = item.gameTitleKey ?? gameTitleKeys[item.localeId];
    const gameLabel = gameTitleKey
        ? localize(gameTitleKey, undefined, true)
        : undefined;

    const label =
        gameLabel &&
            gameLabel !== gameTitleKey &&
            !gameLabel.includes("NOTIFICATIONS.TITLE") &&
            !gameLabel.includes("Notifications.TITLE")
            ? gameLabel
            : localize(item.localeId);

    return (
        <InfoCheckbox
            image={item.icon}
            label={label}
            isChecked={isChecked}
            onToggle={item.onToggle}
            style={{ marginBottom: "5rem" }}
        ></InfoCheckbox>
    );
};
