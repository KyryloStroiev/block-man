using System;
using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly IGroup<GameEntity> _crosshairs;

        public TurnAlongDirectionSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TurnedAlongDirection,
                    GameMatcher.HorizontalDirection,
                    GameMatcher.SpriteRenderer));
            _crosshairs = game.GetGroup(GameMatcher.Shoot);
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                float direction = mover.HorizontalDirection;
                
                if (Mathf.Abs(direction) < 0.01f)
                {
                    direction = mover.LastDirection;
                }
                
                float scale = Mathf.Abs(mover.SpriteRenderer.transform.localScale.x);
                mover.SpriteRenderer.transform.SetScaleX(scale * FaceDirection(direction));
            }

            foreach (GameEntity crosshair in _crosshairs)
            foreach (GameEntity mover in _movers)
            {
                float scale = Mathf.Abs(mover.SpriteRenderer.transform.localScale.x);
                mover.SpriteRenderer.transform.SetScaleX(scale * FaceDirection(1));
            }
        }

        private float FaceDirection(float direction) =>
            direction < 0 ? -1 : 1;
    }
}