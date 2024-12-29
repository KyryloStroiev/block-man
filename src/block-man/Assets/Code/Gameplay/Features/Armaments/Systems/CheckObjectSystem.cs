using System.Collections.Generic;
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class CheckObjectSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _bullets;
        private List<GameEntity> _buffer = new(16);

        public CheckObjectSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _bullets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BulletCube,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity bullet in _bullets.GetEntities(_buffer))
            {
                if (BlockIsTarget(bullet) !=null)
                { 
                    bullet.isDestructed = true;
                }
            }
        }
        
        private Collider2D BlockIsTarget(GameEntity entity) => 
            _physicsService.BoxCastCollider(entity.Transform, entity.GroundLayerMask);
      
    }
}