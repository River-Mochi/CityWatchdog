// File: src/Systems/UnlockMilestonesSystem.cs
// Purpose: Applies the custom milestone setting to new or loaded cities.

namespace CityWatchdog.Systems
{
    using CityWatchdog.Settings;
    using Colossal.Serialization.Entities;
    using Game.City;
    using Game.Common;
    using Game.Prefabs;
    using Game.Simulation;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    public partial class UnlockMilestonesSystem : GameSystemBaseExtension
    {
        private EntityArchetype unlockEventArchetype;
        private EntityQuery milestoneLevelGroup;
        private EntityQuery milestoneGroup;
        private CitySystem citySystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            citySystem = World.GetOrCreateSystemManaged<CitySystem>();

            unlockEventArchetype = EntityManager.CreateArchetype(new ComponentType[]
            {
                ComponentType.ReadWrite<Event>(),
                ComponentType.ReadWrite<Unlock>()
            });

            milestoneLevelGroup = GetEntityQuery(new ComponentType[]
            {
                ComponentType.ReadWrite<MilestoneLevel>()
            });

            milestoneGroup = GetEntityQuery(new ComponentType[]
            {
                ComponentType.ReadOnly<MilestoneData>()
            });

            RequireForUpdate(milestoneLevelGroup);
            RequireForUpdate(milestoneGroup);
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            if (InGame)
            {
                UnlockMilestone();
            }
        }

        private void UnlockMilestone()
        {
            if (!Setting.Instance.CustomMilestone)
            {
                return;
            }

            NativeArray<Entity> milestoneEntities = milestoneGroup.ToEntityArray(Allocator.TempJob);
            NativeArray<MilestoneData> milestoneData = milestoneGroup.ToComponentDataArray<MilestoneData>(Allocator.TempJob);

            try
            {
                MilestoneLevel milestoneLevel = milestoneLevelGroup.GetSingleton<MilestoneLevel>();
                int targetMilestone = math.min(Setting.Instance.MilestoneLevel + 1, milestoneEntities.Length);

                if (milestoneLevel.m_AchievedMilestone >= targetMilestone)
                {
                    return;
                }

                PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                Creditworthiness creditworthiness = EntityManager.GetComponentData<Creditworthiness>(citySystem.City);
                DevTreePoints devTreePoints = EntityManager.GetComponentData<DevTreePoints>(citySystem.City);
                XP xp = EntityManager.GetComponentData<XP>(citySystem.City);

                for (int i = milestoneLevel.m_AchievedMilestone; i < targetMilestone; i++)
                {
                    Entity entity = EntityManager.CreateEntity(unlockEventArchetype);
                    EntityManager.SetComponentData(entity, new Unlock(milestoneEntities[i]));

                    milestoneLevel.m_AchievedMilestone = math.max(milestoneLevel.m_AchievedMilestone, milestoneData[i].m_Index);
                    playerMoney.Add(milestoneData[i].m_Reward);
                    creditworthiness.m_Amount += milestoneData[i].m_LoanLimit;
                    devTreePoints.m_Points += milestoneData[i].m_DevTreePoints;
                    xp.m_XP = milestoneData[i].m_XpRequried;
                }

                milestoneLevelGroup.SetSingleton(milestoneLevel);
                EntityManager.SetComponentData(citySystem.City, playerMoney);
                EntityManager.SetComponentData(citySystem.City, creditworthiness);
                EntityManager.SetComponentData(citySystem.City, devTreePoints);
                EntityManager.SetComponentData(citySystem.City, xp);

                LogUtils.Info(() => $"Unlock level {Setting.Instance.MilestoneLevel + 1} Milestone");
            }
            finally
            {
                if (milestoneEntities.IsCreated)
                {
                    milestoneEntities.Dispose();
                }

                if (milestoneData.IsCreated)
                {
                    milestoneData.Dispose();
                }
            }
        }
    }
}
