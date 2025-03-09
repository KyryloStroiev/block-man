using Code.Gameplay.GameOvers.Behaviours;
using Code.Infrastructure.View.Registrar;

namespace Code.Gameplay.GameOvers.Registrar
{
    public class FlagAnimatorRegistrar: EntityComponentRegistrar
    {
        public FlagAnimator FlagAnimator;
        
        public override void RegisterComponents()
        {
            Entity
                .AddFlagAnimator(FlagAnimator);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasFlagAnimator)
                Entity.RemoveFlagAnimator();
        }
    }
}