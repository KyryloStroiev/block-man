using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cubes;

        public RotationSystem(GameContext game)
        {
            _cubes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.RotationSpeed, GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity cube in _cubes)
            { 
                cube.Rigidbody.angularVelocity = cube.RotationSpeed;
            }
        }
    }
}