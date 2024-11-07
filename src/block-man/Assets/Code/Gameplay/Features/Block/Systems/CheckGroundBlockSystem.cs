using System.Collections.Generic;
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class CheckGroundBlockSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _entites;

        public CheckGroundBlockSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entites = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.RadiusGroundCheck,
                    GameMatcher.GroundLayerMask, 
                    GameMatcher.Block, 
                    GameMatcher.Cube));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entites)
            {
                List<GameObject> cubes = entity.Cube;

                for (int i = 0; i < cubes.Count; i++)
                {
                    if (OverlapCircle(entity, cubes[i].transform) > 0)
                    {
                            entity.isGround = true;
                            break;
                    }
                }
            }
        } 

        private int OverlapCircle(GameEntity entity, Transform childBlock)
        {
            return _physicsService.CircleCastGround(childBlock.position, entity.CircleOffsetY, entity.RadiusGroundCheck,
                entity.GroundLayerMask);
        }
    }
}