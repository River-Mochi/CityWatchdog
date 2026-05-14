// File: src/Systems/MoneyControllerSystem.cs
// Purpose: Handles City Watchdog money actions, initial money, and automatic money support.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game;
    using Game.City;
    using Game.Input;
    using Game.SceneFlow;
    using Game.Simulation;
    using System.Reflection;
    using System.Text;
    using Unity.Entities;

    public partial class MoneyControllerSystem : GameSystemBaseExtension
    {
        private CitySystem citySystem = null!;
        private CityConfigurationSystem cityConfigurationSystem = null!;
        private ProxyAction? addMoneyAction;
        private ProxyAction? subtractMoneyAction;

        public enum ModifyMoneyType
        {
            AutoAdd,
            ManualAdd,
            AutoSubtract,
            ManualSubtract,
            None
        }

        public void ExportCurrentCityConfigurationInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("---Current City Configuration Information---");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.cityName)}: {cityConfigurationSystem.cityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideCityName)}: {cityConfigurationSystem.overrideCityName}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.leftHandTraffic)}: {cityConfigurationSystem.leftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLeftHandTraffic)}: {cityConfigurationSystem.overrideLeftHandTraffic}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.naturalDisasters)}: {cityConfigurationSystem.naturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideNaturalDisasters)}: {cityConfigurationSystem.overrideNaturalDisasters}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockAll)}: {cityConfigurationSystem.unlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockAll)}: {cityConfigurationSystem.overrideUnlockAll}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlimitedMoney)}: {cityConfigurationSystem.unlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlimitedMoney)}: {cityConfigurationSystem.overrideUnlimitedMoney}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.unlockMapTiles)}: {cityConfigurationSystem.unlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideUnlockMapTiles)}: {cityConfigurationSystem.overrideUnlockMapTiles}");
            stringBuilder.AppendLine($"{nameof(cityConfigurationSystem.overrideLoadedOptions)}: {cityConfigurationSystem.overrideLoadedOptions}");
            stringBuilder.AppendLine(string.Join(", ", cityConfigurationSystem.usedMods));
            stringBuilder.AppendLine("---End Current City Configuration Information---");

            LogUtils.Info(() => stringBuilder.ToString());
        }

        public void SetUnlimitedMoneyToLimitedMoney()
        {
            if (!CanConvertUnlimitedMoneySave())
            {
                return;
            }

            PlayerMoney beforeMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            LogUtils.Info(() => $"Starting set unlimited money to limited money, PlayerMoney.m_Unlimited: {beforeMoney.m_Unlimited}, PlayerMoney.money: {beforeMoney.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");

            cityConfigurationSystem.unlimitedMoney = false;
            cityConfigurationSystem.overrideUnlimitedMoney = false;

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            playerMoney.m_Unlimited = false;
            EntityManager.SetComponentData(citySystem.City, playerMoney);

            FieldInfo? loadedUnlimitedMoneyField = typeof(CityConfigurationSystem).GetField("m_LoadedUnlimitedMoney", BindingFlags.NonPublic | BindingFlags.Instance);
            if (loadedUnlimitedMoneyField == null)
            {
                LogUtils.Info(() => "m_LoadedUnlimitedMoney is null");
            }
            else
            {
                loadedUnlimitedMoneyField.SetValue(cityConfigurationSystem, false);
            }

            LogUtils.Info(() => $"Set unlimited money to limited money completed, PlayerMoney.m_Unlimited: {playerMoney.m_Unlimited}, PlayerMoney.money: {playerMoney.money}, CityConfigurationSystem.unlimitedMoney: {cityConfigurationSystem.unlimitedMoney}, CityConfigurationSystem.overrideUnlimitedMoney: {cityConfigurationSystem.overrideUnlimitedMoney}");
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

            Entity city = citySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return false;
            }

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(city);
            return playerMoney.m_Unlimited ||
                   cityConfigurationSystem.unlimitedMoney ||
                   cityConfigurationSystem.overrideUnlimitedMoney;
        }

        public void OnSubtractMoney()
        {
            ModifyMoney(ModifyMoneyType.ManualSubtract, Setting.Instance.ManualMoneyAmount);
        }

        public void OnAddMoney()
        {
            ModifyMoney(ModifyMoneyType.ManualAdd, Setting.Instance.ManualMoneyAmount);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            citySystem = World.GetOrCreateSystemManaged<CitySystem>();
            cityConfigurationSystem = World.GetOrCreateSystemManaged<CityConfigurationSystem>();

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

            if ((serializationContext.purpose == Purpose.NewGame || serializationContext.purpose == Purpose.LoadGame) &&
                Setting.Instance.InitialMoney != 0)
            {
                PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                if (!playerMoney.m_Unlimited)
                {
                    int rawMoney = playerMoney.money;
                    LogUtils.Info(() => $"Setting initial money, default money: {rawMoney}");

                    ModifyMoney(ModifyMoneyType.AutoSubtract, rawMoney);
                    ModifyMoney(ModifyMoneyType.AutoAdd, Setting.Instance.InitialMoney);
                    Setting.Instance.ResetInitialMoney();

                    PlayerMoney updatedMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                    LogUtils.Info(() => $"Set initial money completed, money: {updatedMoney.money}");
                }
            }
        }

        protected override void OnUpdate()
        {
            if (Setting.Instance.AutomaticAddMoney && InGame)
            {
                PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                if (playerMoney.money < Setting.Instance.AutomaticAddMoneyThreshold)
                {
                    LogUtils.Info(() => $"{playerMoney.money} < {Setting.Instance.AutomaticAddMoneyThreshold}, automatically add money");
                    ModifyMoney(ModifyMoneyType.AutoAdd, Setting.Instance.AutomaticAddMoneyAmount);
                }
            }

            if (InGame && addMoneyAction != null && addMoneyAction.WasPerformedThisFrame())
            {
                OnAddMoney();
            }

            if (InGame && subtractMoneyAction != null && subtractMoneyAction.WasPerformedThisFrame())
            {
                OnSubtractMoney();
            }
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

        private void ModifyMoney(ModifyMoneyType modifyMoneyType, int money)
        {
            if (GameManager.instance.gameMode != GameMode.Game ||
                citySystem == null ||
                modifyMoneyType == ModifyMoneyType.None)
            {
                return;
            }

            PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
            if (modifyMoneyType == ModifyMoneyType.AutoAdd || modifyMoneyType == ModifyMoneyType.ManualAdd)
            {
                playerMoney.Add(money);
            }
            else if (modifyMoneyType == ModifyMoneyType.AutoSubtract || modifyMoneyType == ModifyMoneyType.ManualSubtract)
            {
                playerMoney.Subtract(money);
            }

            LogUtils.Info(() => $"{modifyMoneyType} money {money} to {playerMoney.money} ");
            EntityManager.SetComponentData(citySystem.City, playerMoney);
        }
    }
}
