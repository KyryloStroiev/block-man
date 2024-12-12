using Entitas;

namespace Code.Gameplay.UI.Systems
{
   public class PointDestructCubeCountingSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _points;
      private readonly IGroup<GameEntity> _heroes;

      public PointDestructCubeCountingSystem(GameContext game)
      {
         _points = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.PointsCounter));
         _heroes = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.DestructCubes));
      }

      public void Execute()
      {
         foreach (GameEntity point in _points)
         foreach (GameEntity hero in _heroes)
         {
            point.PointsCounter.SetPointsDestructCube(hero.DestructCubes);
         }
      }
   }
}