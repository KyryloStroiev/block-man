using System;
using System.Collections.Generic;
using Entitas;
using Object = UnityEngine.Object;

namespace Code.Common.Destruct.Systems
{
    public class CleanupGameDestructViewSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
       

        public CleanupGameDestructViewSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.View,
                    GameMatcher.Destructed));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.View.ReleaseEntity();
                
                Object.Destroy(entity.View.gameObject);
            }
        }
    }
}