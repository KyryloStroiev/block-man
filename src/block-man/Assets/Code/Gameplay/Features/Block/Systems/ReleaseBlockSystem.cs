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

        public ReleaseBlockSystem(GameContext game, ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Block,
                    GameMatcher.Ground));
        }
        
        public void Cleanup()
        {
            foreach (GameEntity block in _blocks)
            {
                _collisionRegistry.ChangeLayerOnAll((int)Mathf.Log(CollisionLayer.CubeOnGround.AsMask(), 2), block);
                block.Rigidbody.bodyType = RigidbodyType2D.Static;
                block.RemoveCube();
                block.isDestructed = true;
            }
        }
    }
}