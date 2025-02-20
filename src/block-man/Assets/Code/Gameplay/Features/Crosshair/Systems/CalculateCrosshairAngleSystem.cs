using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class CalculateCrosshairAngleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _crosshairs;
        private readonly IGroup<GameEntity> _heroes;

        public CalculateCrosshairAngleSystem(GameContext game)
        {
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair));
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.HeroAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity crosshair in _crosshairs)
            foreach (GameEntity hero in _heroes)
            {
                Vector2 direction = crosshair.WorldPosition - hero.WorldPosition;
                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                crosshair.ReplaceCrosshairAngle(angle);
                
                
            }
        }
    }
}