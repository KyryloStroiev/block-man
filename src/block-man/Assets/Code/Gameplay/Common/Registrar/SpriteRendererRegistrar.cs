using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Common.Registrar
{
    public class SpriteRendererRegistrar: EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;
        public override void RegisterComponents()
        {
            Entity
                .AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnregisterComponents()
        {
                if (Entity.hasSpriteRenderer)
                    Entity.RemoveSpriteRenderer();
        }
    }
}