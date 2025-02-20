using System.Numerics;
using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class ChangeWorldPositionSystem : IExecuteSystem
    {
        private const float RaycastDistance = 0.3f;
        private readonly ITimeService _time;
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _movers;

        public ChangeWorldPositionSystem(GameContext game, ITimeService time, IPhysicsService physicsService)
        {
            _time = time;
            _physicsService = physicsService;
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
            /*if (!entity.isMoving || RaycastCast(entity) )
                return new Vector2(0, entity.VerticalDirection);
            else*/
                return new Vector2(entity.HorizontalDirection * entity.Speed , entity.VerticalDirection );
        }
        
        private bool RaycastCast(GameEntity hero) => 
            _physicsService.RaycastCast(hero.WorldPosition, new Vector2(hero.HorizontalDirection, 0f), RaycastDistance, hero.GroundLayerMask);
           
    }
    
    }