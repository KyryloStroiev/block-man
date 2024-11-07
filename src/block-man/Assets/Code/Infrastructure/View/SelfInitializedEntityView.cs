using System;
using Code.Common.Entity;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class SelfInitializedEntityView: MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        private IIdentifierService _identifier;

        [Inject]
        private void Consrtruct(IIdentifierService identifier)
        {
            _identifier = identifier;
        }

        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifier.NextId());
            
            EntityBehaviour.SetEntity(entity);
        }
    }
}