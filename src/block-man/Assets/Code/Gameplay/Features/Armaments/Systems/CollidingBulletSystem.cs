using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class CollidingBulletSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _bullets;

        public CollidingBulletSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _bullets = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.BulletCube,
                    GameMatcher.WorldPosition,
                    GameMatcher.TargetLayerMask,
                    GameMatcher.GroundLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity bullet in _bullets)
            {
                if (BlockIsTarget(bullet) != null)
                {
                    Object.Destroy(BlockIsTarget(bullet).gameObject);
                    bullet.isDestructed = true;
                }
               
            }
        }

        private Collider2D BlockIsTarget(GameEntity entity) => 
            _physicsService.BoxCastCollider(entity.Transform, entity.TargetLayerMask);
    }
}