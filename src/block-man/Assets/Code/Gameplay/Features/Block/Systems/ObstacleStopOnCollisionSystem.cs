using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class ObstacleStopOnCollisionSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _blocks;

        public ObstacleStopOnCollisionSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Block,
                    GameMatcher.TargetLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity block in _blocks)
            {
                if (HasOverlap(block, block.TargetLayerMask))
                {
                    float currentX = block.WorldPosition.x;

                    if (!block.hasClampedPosition)
                     block.AddClampedPosition(currentX);
                    

                    Vector3 clampedPosition = block.WorldPosition;

                    if (currentX > 0) 
                    {
                        clampedPosition.x = Mathf.Min(block.clampedPosition.Value, currentX);
                    }
                    else if (currentX < 0) 
                    {
                        clampedPosition.x = Mathf.Max(block.clampedPosition.Value, currentX);
                    }

                    block.ReplaceWorldPosition(clampedPosition);
                }
                else
                {
                    if (block.hasClampedPosition)
                     block.RemoveClampedPosition();
                    
                }
            }
        }
        
        private bool HasOverlap(GameEntity block, LayerMask layerMask)
        {
            foreach (GameObject cube in block.Cube)
            {
                if (OverlapBox(cube.transform, layerMask) > 0)
                    return true;
            }
            return false;
        }
        
        
        private int OverlapBox(Transform childBlock, LayerMask layerMask) => 
            _physicsService.BoxCastParents(childBlock, layerMask);
    }
}