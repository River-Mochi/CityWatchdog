// File: src/Systems/SignatureBuildingControllerSystem.cs
// Purpose: Clears the unique-placement flag from signature building placeable data after load.

namespace CityWatchdog.Systems
{
    using Colossal.Serialization.Entities;
    using Game.Objects;
    using Game.Prefabs;
    using Unity.Collections;
    using Unity.Entities;

    public partial class SignatureBuildingControllerSystem : GameSystemBaseExtension
    {
        private EntityQuery signatureBuildingGroup;

        protected override void OnCreate()
        {
            base.OnCreate();

            signatureBuildingGroup = GetEntityQuery(new ComponentType[]
            {
                ComponentType.ReadOnly<SignatureBuildingData>(),
                ComponentType.ReadWrite<PlaceableObjectData>()
            });

            RequireForUpdate(signatureBuildingGroup);
        }

        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            NativeArray<Entity> signatureBuildings = signatureBuildingGroup.ToEntityArray(Allocator.TempJob);
            try
            {
                for (int i = 0; i < signatureBuildings.Length; i++)
                {
                    PlaceableObjectData placeableObjectData = EntityManager.GetComponentData<PlaceableObjectData>(signatureBuildings[i]);
                    placeableObjectData.m_Flags ^= PlacementFlags.Unique;
                    EntityManager.SetComponentData(signatureBuildings[i], placeableObjectData);
                    LogUtils.Info(() => placeableObjectData.m_Flags.ToString());
                }
            }
            finally
            {
                if (signatureBuildings.IsCreated)
                {
                    signatureBuildings.Dispose();
                }
            }
        }
    }
}
