using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Common.Registrar
{
    public class LayerMaskRegistrar: EntityComponentRegistrar
    {
        public LayerMask GroundLayerMask;
        public LayerMask TargetLayerMask;
        public LayerMask ObstacleLayerMask;

        public override void RegisterComponents()
        {
            Entity
                .AddGroundLayerMask(GroundLayerMask)
                .AddTargetLayerMask(TargetLayerMask)
                .AddObstacleLayerMask(ObstacleLayerMask);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasGroundLayerMask)
                Entity.RemoveGroundLayerMask()
                    .RemoveTargetLayerMask();
            
        }
    }
}