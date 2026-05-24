// File: src/UI/src/mods/NotificationPanel/notificationHooks.ts
// Purpose: React hooks that keep notification checkbox state synced with C# bindings.

import { useEffect, useState } from "react";
import { allItems, type NotificationSection } from "./notificationData";

export const useAllNotificationValues = () => {
    const [values, setValues] = useState(() => allItems.map((item) => item.binding.value));

    useEffect(() => {
        setValues(allItems.map((item) => item.binding.value));

        const subscriptions = allItems.map((item, itemIndex) => item.binding.subscribe((value) => {
            setValues((currentValues) => {
                if (currentValues[itemIndex] === value) {
                    return currentValues;
                }

                const nextValues = currentValues.slice();
                nextValues[itemIndex] = value;
                return nextValues;
            });
        }));

        return () => {
            subscriptions.forEach((subscription) => subscription.dispose());
        };
    }, []);

    return values;
};

export const useSectionValues = (section: NotificationSection) => {
    const [values, setValues] = useState(() => section.items.map((item) => item.binding.value));

    useEffect(() => {
        setValues(section.items.map((item) => item.binding.value));

        const subscriptions = section.items.map((item, itemIndex) => item.binding.subscribe((value) => {
            setValues((currentValues) => {
                if (currentValues[itemIndex] === value) {
                    return currentValues;
                }

                const nextValues = currentValues.slice();
                nextValues[itemIndex] = value;
                return nextValues;
            });
        }));

        return () => {
            subscriptions.forEach((subscription) => subscription.dispose());
        };
    }, [section]);

    return values;
};
