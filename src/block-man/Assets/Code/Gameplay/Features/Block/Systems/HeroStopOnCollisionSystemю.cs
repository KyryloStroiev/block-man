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
                    GameMatcher.Block,
                    GameMatcher.ObstacleLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity block in _blocks.GetEntities(_buffer))
            { 
                if(HasOverlap(block, block.ObstacleLayerMask))
                    block.ReplaceVerticalDirection(0);
                else
                    block.ReplaceVerticalDirection(-1);
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
            _physicsService.BoxCast(childBlock, layerMask);
    }
    
    
}