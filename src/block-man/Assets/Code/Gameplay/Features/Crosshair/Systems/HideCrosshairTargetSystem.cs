using Entitas;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class HideCrosshairTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _crosshairs;
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _heroes;

        public HideCrosshairTargetSystem(GameContext game)
        {
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair,
                    GameMatcher.CrosshairTarget,
                    GameMatcher.WorldPosition));
            _inputs = game.GetGroup(GameMatcher.Input);
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, 
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity crosshair in _crosshairs)
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                if (!input.isShootInput)
                {
                    crosshair.ReplaceWorldPosition(hero.WorldPosition);
                    crosshair.CrosshairTarget.gameObject.SetActive(false);
                    
                }
                else
                {
                    crosshair.CrosshairTarget.gameObject.SetActive(true);
                }
                
            }
        }
    }
}