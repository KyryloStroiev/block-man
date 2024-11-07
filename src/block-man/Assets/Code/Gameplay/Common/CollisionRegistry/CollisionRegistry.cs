using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Common.CollisionRegistry
{
    public class CollisionRegistry : ICollisionRegistry
    {
        private readonly Dictionary<int, IEntity> _entityByInstanceId = new();

        public void Register(int instanceId, IEntity entity)
        {
            _entityByInstanceId[instanceId] = entity;
        }

        public void Unregister(int instanceId)
        {
            if (_entityByInstanceId.ContainsKey(instanceId))
                _entityByInstanceId.Remove(instanceId);
        }

        public TEntity Get<TEntity>(int instanceId) where TEntity : class
        {
            return _entityByInstanceId.TryGetValue(instanceId, out IEntity entity) 
                ? entity as TEntity
                : null;
        }
        
        public void ChangeLayerOnAll(int newLayer, GameEntity entity)
        {
            if(!_entityByInstanceId.ContainsValue(entity))
                return;
            
            if (entity.hasTransform)
            {
                var gameObject = entity.Transform.gameObject;
                SetLayerRecursively(gameObject, newLayer);
            }
            
        }

        private void SetLayerRecursively(GameObject obj, int newLayer)
        {
            obj.layer = newLayer;
            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}