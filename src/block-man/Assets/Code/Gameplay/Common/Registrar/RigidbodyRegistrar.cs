using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Common.Registrar
{
    public class RigidbodyRegistrar: EntityComponentRegistrar
    {
        public Rigidbody2D Rigidbody;
        
        public override void RegisterComponents()
        {
            Entity
                .AddRigidbody(Rigidbody);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasRigidbody)
                Entity.RemoveRigidbody();
        }
    }
}