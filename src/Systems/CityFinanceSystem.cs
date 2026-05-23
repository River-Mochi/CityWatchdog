// File: src/Systems/CityFinanceSystem.cs
// Purpose: Handles City Watchdog money actions, initial money, and automatic money support.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.City;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Simulation;
    using System;
    using System.Reflection;
    using Unity.Entities;

    public partial class CityFinanceSystem : GameSystemBaseExtension
    {
        // Counts this system's OnUpdate passes, not seconds. Higher = automatic money checks less often.
        private const int AutomaticMoneyCheckIntervalUpdates = 128;
        // Hold-to-repeat delay for [ and ]. Higher = easier single-taps before repeat begins.
        private const int ManualMoneyRepeatInitialDelayUpdates = 20;
        // Hold-to-repeat speed for [ and ] after the delay. Lower = faster repeated money changes.
        private const int ManualMoneyRepeatIntervalUpdates = 9;

        private CitySystem citySystem = null!;
        private CityConfigurationSystem cityConfigurationSystem = null!;
        private ProxyAction? addMoneyAction;
        private ProxyAction? subtractMoneyAction;
        private int automaticMoneyCheckCooldown;
        private int addMoneyRepeatCooldown;
        private int subtractMoneyRepeatCooldown;

        public enum FinanceActionKind
        {
            AutoAdd,
            ManualAdd,
            AutoSubtract,
            ManualSubtract,
            None
        }

        public void SetUnlimitedMoneyToLimitedMoney()
        {
            if (!CanConvertUnlimitedMoneySave() ||
                !TryGetPlayerMoney(out PlayerMoney beforeMoney))
            {
                return;
            }

            LogUtils.Info(() =>
                "Starting set unlimited money to limited money.\n" +
                $"PlayerMoney.m_Unlimited: {beforeMoney.m_Unlimited}\n" +
                $"PlayerMoney.money: {beforeMoney.money}\n" +
                $"CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}\n" +
                $"CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");

            ApplyLimitedMoneyMode();
            ClearLoadedUnlimitedMoneyFlag();

            if (!TryGetPlayerMoney(out PlayerMoney afterMoney))
            {
                return;
            }

            LogUtils.Info(() =>
                "Set unlimited money to limited money completed.\n" +
                $"PlayerMoney.m_Unlimited: {afterMoney.m_Unlimited}\n" +
                $"PlayerMoney.money: {afterMoney.money}\n" +
                $"CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}\n" +
                $"CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");
        }

        private void ApplyLimitedMoneyMode()
        {
            cityConfigurationSystem.unlimitedMoney = false;
            cityConfigurationSystem.overrideUnlimitedMoney = false;

            if (TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                playerMoney.m_Unlimited = false;
                EntityManager.SetComponentData(citySystem.City, playerMoney);
            }
        }

        private void ClearLoadedUnlimitedMoneyFlag()
        {
            FieldInfo? loadedUnlimitedMoneyField = typeof(CityConfigurationSystem).GetField(
                "m_LoadedUnlimitedMoney",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (loadedUnlimitedMoneyField == null)
            {
                CityWatchdog.Mod.DebugLog(() => "m_LoadedUnlimitedMoney is null");
            }
            else
            {
                loadedUnlimitedMoneyField.SetValue(cityConfigurationSystem, false);
            }
        }

        public bool CanConvertUnlimitedMoneySave()
        {
            if (GameManager.instance == null ||
                GameManager.instance.gameMode != GameMode.Game ||
                citySystem == null ||
                cityConfigurationSystem == null)
            {
                return false;
            }

            if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return false;
            }

            return playerMoney.m_Unlimited ||
                   cityConfigurationSystem.unlimitedMoney ||
                   cityConfigurationSystem.overrideUnlimitedMoney;
        }

        public void OnSubtractMoney()
        {
            ApplyMoneyChange(FinanceActionKind.ManualSubtract, Setting.Instance.ManualMoneyAmount);
        }

        public void OnAddMoney()
        {
            ApplyMoneyChange(FinanceActionKind.ManualAdd, Setting.Instance.ManualMoneyAmount);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            citySystem = World.GetOrCreateSystemManaged<CitySystem>();
            cityConfigurationSystem = World.GetOrCreateSystemManaged<CityConfigurationSystem>();
            automaticMoneyCheckCooldown = 0;
            ResetManualMoneyRepeat();

            addMoneyAction = TryGetAction(Setting.AddMoneyAction);
            if (addMoneyAction != null)
            {
                addMoneyAction.shouldBeEnabled = true;
            }

            subtractMoneyAction = TryGetAction(Setting.SubtractMoneyAction);
            if (subtractMoneyAction != null)
            {
                subtractMoneyAction.shouldBeEnabled = true;
            }
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            automaticMoneyCheckCooldown = 0;

            if ((serializationContext.purpose == Purpose.NewGame || serializationContext.purpose == Purpose.LoadGame) &&
                Setting.Instance.InitialMoney != 0)
            {
                if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
                {
                    return;
                }

                if (!playerMoney.m_Unlimited)
                {
                    int rawMoney = playerMoney.money;
                    CityWatchdog.Mod.DebugLog(() => $"Setting initial money, default money: {rawMoney}");

                    ApplyMoneyChange(FinanceActionKind.AutoSubtract, rawMoney);
                    ApplyMoneyChange(FinanceActionKind.AutoAdd, Setting.Instance.InitialMoney);
                    Setting.Instance.ResetInitialMoney();

                    if (TryGetPlayerMoney(out PlayerMoney updatedMoney))
                    {
                        CityWatchdog.Mod.DebugLog(() => $"Set initial money completed, money: {updatedMoney.money}");
                    }
                }
            }
        }

        protected override void OnUpdate()
        {
            if (!InGame)
            {
                automaticMoneyCheckCooldown = 0;
                ResetManualMoneyRepeat();
                return;
            }

            UpdateAutomaticAddMoney();
            UpdateManualMoneyHotkeys();
        }

        private void UpdateManualMoneyHotkeys()
        {
            UpdateManualMoneyHotkey(addMoneyAction, FinanceActionKind.ManualAdd, ref addMoneyRepeatCooldown);
            UpdateManualMoneyHotkey(subtractMoneyAction, FinanceActionKind.ManualSubtract, ref subtractMoneyRepeatCooldown);
        }

        private void UpdateManualMoneyHotkey(ProxyAction? action, FinanceActionKind financeActionKind, ref int repeatCooldown)
        {
            if (action == null)
            {
                repeatCooldown = 0;
                return;
            }

            // First press always applies once; held keys repeat only after the delay above.
            if (action.WasPressedThisFrame())
            {
                ApplyMoneyChange(financeActionKind, Setting.Instance.ManualMoneyAmount);
                repeatCooldown = ManualMoneyRepeatInitialDelayUpdates;
                return;
            }

            if (!action.IsPressed())
            {
                repeatCooldown = 0;
                return;
            }

            if (repeatCooldown > 0)
            {
                repeatCooldown--;
                return;
            }

            ApplyMoneyChange(financeActionKind, Setting.Instance.ManualMoneyAmount);
            repeatCooldown = ManualMoneyRepeatIntervalUpdates;
        }

        private void ResetManualMoneyRepeat()
        {
            addMoneyRepeatCooldown = 0;
            subtractMoneyRepeatCooldown = 0;
        }

        private void UpdateAutomaticAddMoney()
        {
            if (!Setting.Instance.AutomaticAddMoney)
            {
                automaticMoneyCheckCooldown = 0;
                return;
            }

            if (automaticMoneyCheckCooldown > 0)
            {
                automaticMoneyCheckCooldown--;
                return;
            }

            automaticMoneyCheckCooldown = AutomaticMoneyCheckIntervalUpdates;
            TryAutomaticAddMoney();
        }

        private void TryAutomaticAddMoney()
        {
            if (!TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return;
            }

            if (playerMoney.m_Unlimited)
            {
                return;
            }

            int threshold = Setting.Instance.AutomaticAddMoneyThreshold;
            if (playerMoney.money >= threshold)
            {
                return;
            }

            int amount = GetAutomaticAddMoneyAmount(
                playerMoney.money,
                threshold,
                Setting.Instance.AutomaticAddMoneyAmount);

            if (amount <= 0)
            {
                return;
            }

            CityWatchdog.Mod.DebugLog(() => $"AutoAdd money: balance {playerMoney.money:N0} below threshold {threshold:N0}; adding {amount:N0}.");
            ApplyMoneyChange(FinanceActionKind.AutoAdd, amount);
        }

        private static int GetAutomaticAddMoneyAmount(int currentMoney, int threshold, int selectedAmount)
        {
            long deficit = (long)threshold - currentMoney;
            long requestedAmount = Math.Max(0, selectedAmount);
            long amount = Math.Max(deficit, requestedAmount);

            if (amount <= 0)
            {
                return 0;
            }

            if (amount > int.MaxValue)
            {
                return int.MaxValue;
            }

            return (int)amount;
        }

        private ProxyAction? TryGetAction(string actionName)
        {
            try
            {
                return Setting.Instance.GetAction(actionName);
            }
            catch (System.Exception ex)
            {
                LogUtils.WarnOnce(
                    "missing-keybind-" + actionName,
                    () => $"Keybinding action '{actionName}' is unavailable: {ex.GetType().Name}: {ex.Message}",
                    ex);
                return null;
            }
        }

        private bool TryGetPlayerMoney(out PlayerMoney playerMoney)
        {
            playerMoney = default;

            if (citySystem == null)
            {
                return false;
            }

            Entity city = citySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return false;
            }

            playerMoney = EntityManager.GetComponentData<PlayerMoney>(city);
            return true;
        }

        private void ApplyMoneyChange(FinanceActionKind financeActionKind, int money)
        {
            if (GameManager.instance.gameMode != GameMode.Game ||
                financeActionKind == FinanceActionKind.None ||
                !TryGetPlayerMoney(out PlayerMoney playerMoney))
            {
                return;
            }

            if (financeActionKind == FinanceActionKind.AutoAdd || financeActionKind == FinanceActionKind.ManualAdd)
            {
                playerMoney.Add(money);
            }
            else if (financeActionKind == FinanceActionKind.AutoSubtract || financeActionKind == FinanceActionKind.ManualSubtract)
            {
                playerMoney.Subtract(money);
            }

            CityWatchdog.Mod.DebugLog(() => $"{financeActionKind} money {money} to {playerMoney.money} ");
            EntityManager.SetComponentData(citySystem.City, playerMoney);
        }
    }
}
