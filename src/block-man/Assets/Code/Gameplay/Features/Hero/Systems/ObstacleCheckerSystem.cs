
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class ObstacleCheckerSystem : IExecuteSystem
    {
        private const float RaycastDistance = 0.3f;
        private const float CircleOffsetY = -0.4f;
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _heroes;

        public ObstacleCheckerSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                
                if (CheckObstacles(hero, Vector2.left) && hero.HorizontalDirection < 0 ||
                    CheckObstacles(hero, Vector2.right) && hero.HorizontalDirection > 0)
                {
                    hero.ReplaceHorizontalDirection(0); 
                }
             
               
            }
        }

        private bool CheckObstacles(GameEntity hero, Vector2 direction) =>
            _physicsService.RaycastCast(hero.Transform.position, direction,  RaycastDistance,
                hero.ObstacleLayerMask) ||
            _physicsService.RaycastCast(hero.Transform.position, direction, CircleOffsetY, RaycastDistance, hero.ObstacleLayerMask);
    }
}