using System.Numerics;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class ChangeWorldPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public ChangeWorldPositionSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.VerticalDirection,
                    GameMatcher.HorizontalDirection,
                    GameMatcher.Speed,
                    GameMatcher.Gravity));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.ReplaceWorldPosition((Vector2)mover.WorldPosition + Direction(mover)*_time.DeltaTime);
            }
        }

        private Vector2 Direction(GameEntity entity)
        {
            if (!entity.isMoving)
                return new Vector2(0, entity.VerticalDirection);
            else
                return new Vector2(entity.HorizontalDirection * entity.Speed , entity.VerticalDirection );
        }
           
    }
}