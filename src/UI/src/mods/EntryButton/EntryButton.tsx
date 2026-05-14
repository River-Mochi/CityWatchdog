import { useValue } from "cs2/api";
import { Button, Icon, Tooltip } from "cs2/ui";
import { OnControlPanelBindingToggle, controlPanelEnabled$ } from "../Bindings/Bindings";

export const EntryButton = () => {
    const showPanel = useValue(controlPanelEnabled$);
    const modIcon = "coui://ui-mods/images/CWDNotificationIcon_Blk_Wht_Lg.svg";

    return (
        <Tooltip tooltip="CITY WATCHDOG">
            <Button
                variant="floating"
                selected={showPanel}
                onSelect={() => { OnControlPanelBindingToggle(!showPanel); }}>
                <Icon tinted={true} src={modIcon} />
            </Button>
        </Tooltip>
    );
};
