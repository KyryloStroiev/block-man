using Code.Gameplay.Features.Block.Systems;
using Code.Infrastructure.Systems;

public sealed class BlockFeature : Feature
{
    public BlockFeature(ISystemFactory systems)
    {
        Add(systems.Create<InitializeSpawnTimer>());
        Add(systems.Create<InitializeSpawnBlockComponentSystem>());

        Add(systems.Create<CheckCubeList>());
        Add(systems.Create<UpdateSpawnPointPositionSystem>());
        Add(systems.Create<UpdateSpawnTimerSystem>());
        Add(systems.Create<AccelerationSpeedBlockSystem>());
        Add(systems.Create<CheckGroundBlockSystem>());
        Add(systems.Create<HeroStopOnCollisionSystem>());
        Add(systems.Create<CheckAnotherBlockSystem>());
        Add(systems.Create<SpawnBlockSystem>());
        Add(systems.Create<ChangeWorldPositionBlockSystem>());
        //Add(systems.Create<ObstacleStopOnCollisionSystem>());

        Add(systems.Create<ReleaseBlockSystem>());
        Add(systems.Create<DestructAllCube>());

    }
}