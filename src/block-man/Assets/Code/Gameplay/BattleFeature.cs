using Code.Common.Destruct;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.Crosshair;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.GameOvers;
using Code.Gameplay.Input;
using Code.Gameplay.Sound;
using Code.Gameplay.UI;
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
            Add(systems.Create<CrosshairFeature>());
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<BlockFeature>());
            Add(systems.Create<ArmamentsFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<UIFeature>());
            
            Add(systems.Create<GameOverFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}