using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Common.Registrar
{
    public class LayerMaskRegistrar: EntityComponentRegistrar
    {
        public LayerMask GroundLayerMask;

        public override void RegisterComponents()
        {
            Entity
                .AddGroundLayerMask(GroundLayerMask);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasGroundLayerMask)
                Entity.RemoveGroundLayerMask();
            
        }
    }
}