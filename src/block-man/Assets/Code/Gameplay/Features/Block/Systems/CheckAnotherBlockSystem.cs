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
        private readonly IGroup<GameEntity> _crosshair;

        public CheckAnotherBlockSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.RadiusGroundCheck,
                    GameMatcher.Block, 
                    GameMatcher.TargetLayerMask));
            _crosshair = game.GetGroup(GameMatcher.Shoot);
        }

        public void Execute()
        {
            bool isShooting = false;
            
            foreach (GameEntity crosshair in _crosshair)
            {
                if (crosshair.isShoot)
                {
                    isShooting = true;
                    break;
                }
            }
            
            if (isShooting)
            {
                foreach (GameEntity entity in _blocks.GetEntities(_buffer))
                {
                    List<GameObject> cubes = entity.Cube;

                    bool hasCollision = false;

                    for (int i = 0; i < cubes.Count; i++)
                    {
                        if (OverlapCircle(entity, cubes[i].transform) > 0)
                        {
                            hasCollision = true;
                            break;
                        }
                    }

                    if (hasCollision)
                    {
                        entity.ReplaceVerticalDirection(0); 
                    }
                    else
                    {
                        entity.ReplaceVerticalDirection(-1);
                    }
                }
            }
            else
            {
                foreach (GameEntity entity in _blocks.GetEntities(_buffer))
                {
                    entity.ReplaceVerticalDirection(-1); 
                }
            }
        } 

        private int OverlapCircle(GameEntity entity, Transform childBlock)
        {
            return _physicsService.CircleCastCube(childBlock.position, entity.CircleOffsetY, entity.RadiusGroundCheck,
                entity.TargetLayerMask, entity.Transform.gameObject);
        }
    }
}