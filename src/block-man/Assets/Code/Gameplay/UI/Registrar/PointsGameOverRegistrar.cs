using Code.Gameplay.UI.Behaviours;
using Code.Infrastructure.View.Registrar;

namespace Code.Gameplay.UI.Registrar
{
    public class PointsGameOverRegistrar: EntityComponentRegistrar
    {
        public PointsGameOver PointsGameOver;
        public override void RegisterComponents()
        {
            Entity
                .AddPointsGameOver(PointsGameOver);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasPointsGameOver)
                Entity.RemovePointsGameOver();
        }
    }
}