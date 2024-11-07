using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrar;

namespace Code.Gameplay.Features.Hero.Registrar
{
    public class HeroAnimatorRegistrar: EntityComponentRegistrar
    {
        public HeroAnimator HeroAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddHeroAnimator(HeroAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHeroAnimator)
                Entity.RemoveHeroAnimator();
        }
    }
}