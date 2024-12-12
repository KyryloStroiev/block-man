using Code.Gameplay.UI.Behaviours;
using Code.Infrastructure.View.Registrar;

namespace Code.Gameplay.UI.Registrar
{
    public class PointsCounterRegistrar: EntityComponentRegistrar
    {
        public PointsCounter PointsCounter;
        public override void RegisterComponents()
        {
            Entity
                .AddPointsCounter(PointsCounter);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasPointsCounter)
                Entity.RemovePointsCounter();
        }
    }
}