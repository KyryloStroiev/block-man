using Code.Gameplay.Common;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
   public class ScaleGravitySystem : IExecuteSystem
   {
      private readonly ITimeService _time;
      private readonly IGroup<GameEntity> _movers;

      public ScaleGravitySystem(GameContext game, ITimeService time)
      {
         _time = time;
         _movers = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.VerticalDirection,
               GameMatcher.Gravity,
               GameMatcher.Rigidbody));
      }

      public void Execute()
      {
         foreach (GameEntity mover in _movers)
         {
            if (!mover.isJump)
            {
               mover.ReplaceVerticalDirection(VerticalDirection(mover));
            }
         }
      }

      private float VerticalDirection(GameEntity mover)
      {
         if (mover.isGround) 
            return 0f;

         return Mathf.Max(mover.VerticalDirection + mover.Gravity * _time.DeltaTime, GameplayConst.Gravity * 2);
      }
   }
}