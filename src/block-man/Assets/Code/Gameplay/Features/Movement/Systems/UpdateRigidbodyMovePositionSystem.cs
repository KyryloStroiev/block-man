using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateRigidbodyMovePositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateRigidbodyMovePositionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.Rigidbody.MovePosition((Vector2)mover.WorldPosition);
            }
        }
    }
}