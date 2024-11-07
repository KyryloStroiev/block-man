using System.Collections.Generic;
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class CheckAnotherBlockSystem : IExecuteSystem
    {
       
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _blocks;
        private List<GameEntity> _buffer = new(8);

        public CheckAnotherBlockSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.RadiusGroundCheck,
                    GameMatcher.GroundLayerMask, 
                    GameMatcher.Block, 
                    GameMatcher.Cube,
                    GameMatcher.TargetLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _blocks.GetEntities(_buffer))
            {
                List<GameObject> cubes = entity.Cube;

                for (int i = 0; i < cubes.Count; i++)
                {
                    if (OverlapCircle(entity, cubes[i].transform) > 0)
                    {
                        Debug.Log(1);
                    }
                    else
                    {
                        Debug.Log(0);
                    }
                }
            }
        } 

        private int OverlapCircle(GameEntity entity, Transform childBlock)
        {
            return _physicsService.CircleCastGround(childBlock.position, entity.CircleOffsetY, entity.RadiusGroundCheck,
                entity.TargetLayerMask);
        }
    }
}