using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class ChangeWorldPositionBlockSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _blocks;

        public ChangeWorldPositionBlockSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.VerticalDirection,
                    GameMatcher.Block,
                    GameMatcher.Moving, 
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity block in _blocks)
            { 
                block.ReplaceWorldPosition((Vector2)block.WorldPosition +
                                           new Vector2(0, block.VerticalDirection * block.Speed * _time.DeltaTime));
                block.Rigidbody.linearVelocityY = block.VerticalDirection * block.Speed;
            }
        }
    }
}