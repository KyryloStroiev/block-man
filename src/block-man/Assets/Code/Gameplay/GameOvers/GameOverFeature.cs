using Code.Gameplay.GameOvers.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.GameOvers
{
    public sealed class GameOverFeature : Feature
    {
        public GameOverFeature(ISystemFactory systems)
        {
            Add(systems.Create<HeroFallCheckSystem>());
            Add(systems.Create<FlagTargetSystem>());
            
            Add(systems.Create<GameOverFinalSystem>());
            Add(systems.Create<GameOverSystem>());
        }
    }
}