using Code.Gameplay.Common;
using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
   public class ScaleGravitySystem : IExecuteSystem
   {
      private readonly ITimeService _time;
      private readonly IPhysicsService _physicsService;
      private readonly IGroup<GameEntity> _movers;

      public ScaleGravitySystem(GameContext game, ITimeService time, IPhysicsService physicsService)
      {
         _time = time;
         _physicsService = physicsService;
         _movers = game.GetGroup(GameMatcher
            .AllOf(GameMatcher.VerticalDirection,
               GameMatcher.Gravity,
               GameMatcher.Rigidbody));
      }

      public void Execute()
      {
         foreach (GameEntity mover in _movers)
         {
            if (!mover.isJump || !mover.isGround && mover.VerticalDirection > 0)
            {
               mover.ReplaceVerticalDirection(VerticalDirection(mover));
              
            }

            if (IsTouchingCeiling(mover) && !mover.isGround )
            {
               mover.ReplaceVerticalDirection(-2);
            }
         }
      }

      private float VerticalDirection(GameEntity mover)
      {
         if (mover.isGround) 
            return 0f;

         return Mathf.Max(mover.VerticalDirection + mover.Gravity * _time.DeltaTime, GameplayConst.Gravity * 2);
      }

      private bool IsTouchingCeiling(GameEntity mover) => 
         _physicsService.RaycastCast(mover.WorldPosition, Vector2.up, 0.5f, mover.GroundLayerMask);
   }
}