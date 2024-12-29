using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class CollidingRotationCubeSystem: IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _cubes;

        public CollidingRotationCubeSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _cubes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.RotationCube,
                    GameMatcher.WorldPosition,
                    GameMatcher.GroundLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity cube in _cubes)
            {
                Object.Destroy(BlockIsTarget(cube)?.gameObject);
            }
        }

        private Collider2D BlockIsTarget(GameEntity entity) => 
            _physicsService.BoxCastCollider(entity.Transform, entity.GroundLayerMask);
    }
}