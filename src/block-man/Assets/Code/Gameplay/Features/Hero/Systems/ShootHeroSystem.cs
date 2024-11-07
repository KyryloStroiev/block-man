using Entitas;

namespace Code.Gameplay.Features.Hero
{
    public class ShootHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _crosshairs;
        private readonly IGroup<GameEntity> _inputs;

        public ShootHeroSystem(GameContext game)
        {
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair));
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity crosshair in _crosshairs)
            {
                crosshair.isShoot = input.isShootInput;
            }
        }
    }
}