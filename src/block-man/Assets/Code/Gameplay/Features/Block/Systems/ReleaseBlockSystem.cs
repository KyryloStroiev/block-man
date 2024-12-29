using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Common.CollisionRegistry;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class ReleaseBlockSystem : ICleanupSystem
    {
        private readonly ICollisionRegistry _collisionRegistry;
        private readonly IGroup<GameEntity> _blocks;
        private List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _allCubes;

        public ReleaseBlockSystem(GameContext game, ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Block,
                    GameMatcher.Ground).NoneOf(GameMatcher.Release));
            _allCubes = game.GetGroup(GameMatcher.AllCube);
        }
        
        public void Cleanup()
        {
            foreach (GameEntity block in _blocks.GetEntities(_buffer))
            foreach (GameEntity allCube in _allCubes)
            {
                _collisionRegistry.ChangeLayerOnAll((int)Mathf.Log(CollisionLayer.CubeOnGround.AsMask(), 2), block);
                block.Rigidbody.bodyType = RigidbodyType2D.Static;
                block.isMoving = false;

                foreach (GameObject cube in block.Cube)
                {
                    allCube.AllCube.Add(cube);
                    cube.transform.parent = null;
                }
                block.isDestructed = true;
               
                
              
            }
        }
    }
}