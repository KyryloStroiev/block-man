using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Registrar
{
    public class CrosshairTargetRegistrar: EntityComponentRegistrar
    {
        public GameObject Target;
        
        public override void RegisterComponents()
        {
            Entity
                .AddCrosshairTarget(Target);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasCrosshairTarget)
            {
                Entity.RemoveCrosshairTarget();
            }
                
        }
    }
}