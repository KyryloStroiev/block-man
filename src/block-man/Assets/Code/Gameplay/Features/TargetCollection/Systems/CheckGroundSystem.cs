using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CheckGroundSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _entites;

        public CheckGroundSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entites = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.RadiusGroundCheck,
                    GameMatcher.GroundLayerMask, 
                    GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entites)
            {
                entity.isGround = OverlapCircle(entity) > 0;
            }
        } 

        private int OverlapCircle(GameEntity entity)
        {
            return _physicsService.CircleCastEntity(entity.Transform.position, entity.CircleOffsetY, entity.RadiusGroundCheck,
                entity.GroundLayerMask);
        }
    }
}