using System.Linq;
using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;

        public CastForTargetsSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair,
                    GameMatcher.WorldPosition, GameMatcher.TargetLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity ready in _ready)
            {
                ready.ReplaceTargets(TargetInRadius(ready));
            }
        }
        
        private int TargetInRadius(GameEntity crosshair) => 
            _physicsService
                .CircleCast(crosshair.WorldPosition, 0, 1, 1f, crosshair.TargetLayerMask)
                .Select(x=>x.Id)
                .FirstOrDefault();
    }
}