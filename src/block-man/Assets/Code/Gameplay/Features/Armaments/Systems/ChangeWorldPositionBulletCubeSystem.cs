using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class ChangeWorldPositionBulletCubeSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _blocks;

        public ChangeWorldPositionBulletCubeSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.HorizontalDirection,
                    GameMatcher.BulletCube,
                    GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (GameEntity block in _blocks)
            {
                block.ReplaceWorldPosition((Vector2)block.WorldPosition +
                                           new Vector2(block.HorizontalDirection * block.Speed * _time.DeltaTime, 0));
            }
        }
    }
}