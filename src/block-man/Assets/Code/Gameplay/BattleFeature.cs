using Code.Common.Destruct;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay

{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<BlockFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}