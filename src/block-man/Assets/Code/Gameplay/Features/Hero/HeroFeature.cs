using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Crosshair;
using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
    public sealed class HeroFeature : Feature
    {       
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeHeroSystem>());
            Add(systems.Create<SetHeroDirectionBuInputSystem>());
            Add(systems.Create<JumpHeroSystem>());
            Add(systems.Create<AttackHammerHeroSystem>());
            Add(systems.Create<AnimateHeroSystem>());
            Add(systems.Create<AnimateShootHeroSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<ShootHeroSystem>());
            Add(systems.Create<CameraFollowHeroSystem>());
            Add(systems.Create<UpdateMaxHeightHeroSystem>());
            Add(systems.Create<ObstacleCheckerSystem>());
            
        }
    }
}
