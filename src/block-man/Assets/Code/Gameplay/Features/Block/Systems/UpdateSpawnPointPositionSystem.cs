using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class UpdateSpawnPointPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _points;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateSpawnPointPositionSystem(GameContext game)
        {
            _points = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnPoint,
                    GameMatcher.WorldPosition));
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity point in _points)
            foreach (GameEntity hero in _heroes)
            {
                point.ReplaceWorldPosition(PointPosition(hero));
                point.isMoving = true;
            }
        }

        private Vector3 PointPosition(GameEntity hero) => 
            new(0, hero.MaxHeightHero + 3f, 0);
    }
}