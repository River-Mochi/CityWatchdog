// File: src/Systems/MilestoneSystem.cs
// Purpose: Applies the custom milestone setting to new or loaded cities.

namespace CityWatchdog.Systems
{

    using Colossal.Serialization.Entities;
    using Game.City;
    using Game.Common;
    using Game.Prefabs;
    using Game.Simulation;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    public partial class MilestoneSystem : GameSystemBaseExtension
    {
        private EntityArchetype unlockEventArchetype;
        private EntityQuery milestoneLevelGroup;
        private EntityQuery milestoneGroup;
        private CitySystem citySystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            citySystem = World.GetOrCreateSystemManaged<CitySystem>();

            // Use vanilla Unlock events so milestone rewards and side effects stay game-native.
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
                ApplyConfiguredMilestone();
            }
        }

        private void ApplyConfiguredMilestone()
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
                if (!TryGetTargetMilestone(milestoneEntities, milestoneLevel, out int targetMilestone))
                {
                    return;
                }

                PlayerMoney playerMoney = EntityManager.GetComponentData<PlayerMoney>(citySystem.City);
                Creditworthiness creditworthiness = EntityManager.GetComponentData<Creditworthiness>(citySystem.City);
                DevTreePoints devTreePoints = EntityManager.GetComponentData<DevTreePoints>(citySystem.City);
                XP xp = EntityManager.GetComponentData<XP>(citySystem.City);

                // Apply every skipped milestone so jumping several levels keeps rewards consistent.
                for (int i = milestoneLevel.m_AchievedMilestone; i < targetMilestone; i++)
                {
                    QueueMilestoneUnlock(milestoneEntities[i]);
                    milestoneLevel.m_AchievedMilestone = math.max(milestoneLevel.m_AchievedMilestone, milestoneData[i].m_Index);
                    ApplyMilestoneRewards(milestoneData[i], ref playerMoney, ref creditworthiness, ref devTreePoints, ref xp);
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

        private static bool TryGetTargetMilestone(
            NativeArray<Entity> milestoneEntities,
            MilestoneLevel currentMilestone,
            out int targetMilestone)
        {
            targetMilestone = math.min(Setting.Instance.MilestoneLevel + 1, milestoneEntities.Length);
            return currentMilestone.m_AchievedMilestone < targetMilestone;
        }

        private void QueueMilestoneUnlock(Entity milestoneEntity)
        {
            Entity entity = EntityManager.CreateEntity(unlockEventArchetype);
            EntityManager.SetComponentData(entity, new Unlock(milestoneEntity));
        }

        private static void ApplyMilestoneRewards(
            MilestoneData milestoneData,
            ref PlayerMoney playerMoney,
            ref Creditworthiness creditworthiness,
            ref DevTreePoints devTreePoints,
            ref XP xp)
        {
            playerMoney.Add(milestoneData.m_Reward);
            creditworthiness.m_Amount += milestoneData.m_LoanLimit;
            devTreePoints.m_Points += milestoneData.m_DevTreePoints;
            xp.m_XP = milestoneData.m_XpRequried;
        }
    }
}
