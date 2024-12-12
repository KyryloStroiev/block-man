using Code.Gameplay.Features.Block.Systems;
using Code.Infrastructure.Systems;

public sealed class BlockFeature : Feature
{
    public BlockFeature(ISystemFactory systems)
    {
        Add(systems.Create<InitializeSpawnTimer>());
        
        Add(systems.Create<AddToListCubeSystem>());
        Add(systems.Create<UpdateSpawnPointPositionSystem>());
        Add(systems.Create<UpdateSpawnTimerSystem>());
        Add(systems.Create<AccelerationSpeedBlockSystem>());
        Add(systems.Create<CheckGroundBlockSystem>());
        Add(systems.Create<CheckAnotherBlockSystem>());
        Add(systems.Create<SpawnBlockSystem>());
        Add(systems.Create<ChangeWorldPositionBlockSystem>());
        
        Add(systems.Create<DestructAllCube>());
        Add(systems.Create<ReleaseBlockSystem>());
        
    }
}