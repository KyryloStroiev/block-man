using Code.Gameplay.Features.Armaments.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments
{
    public sealed class ArmamentsFeature : Feature
    {
        public ArmamentsFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeArmamentsSystem>());
            
            Add(systems.Create<ShotSpawnerTimerSystem>());
            Add(systems.Create<SpawnBulletSystem>());
            Add(systems.Create<ChangeWorldPositionBulletCubeSystem>());
            Add(systems.Create<CollidingBulletSystem>());
            Add(systems.Create<CollidingRotationCubeSystem>());
            Add(systems.Create<CheckObjectSystem>());
        }
    }
}