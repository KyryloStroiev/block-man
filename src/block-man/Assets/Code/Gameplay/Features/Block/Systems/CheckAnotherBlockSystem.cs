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
        private readonly IGroup<GameEntity> _crosshairs;

        public CheckAnotherBlockSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.RadiusGroundCheck,
                    GameMatcher.Block, 
                    GameMatcher.TargetLayerMask));
            _crosshairs = game.GetGroup(GameMatcher.Shoot);
        }

        public void Execute()
        {
            
            bool isShooting = IsShooting();
            
            foreach (GameEntity entity in _blocks.GetEntities(_buffer))
            {
                ProcessEntity(entity, isShooting);
            }
        }

        private void ProcessEntity(GameEntity entity, bool isShooting)
        {
            if (isShooting && HasOverlap(entity))
                entity.ReplaceVerticalDirection(0);
            else
                entity.ReplaceVerticalDirection(-1);
        }
        private bool HasOverlap(GameEntity block)
        {
            foreach (GameObject cube in block.Cube)
            {
                
                if (OverlapCircle(block, cube.transform) > 0)
                    return true;
            }
            return false;
        }
        private bool IsShooting()
        {
            foreach (GameEntity crosshair in _crosshairs)
            {
                if (crosshair.isShoot)
                    return true;
            }
            return false;
        }

        private int OverlapCircle(GameEntity entity, Transform childBlock)
        {
            return _physicsService.BoxCastParents(childBlock, entity.TargetLayerMask);
        }
    }
    
    
}