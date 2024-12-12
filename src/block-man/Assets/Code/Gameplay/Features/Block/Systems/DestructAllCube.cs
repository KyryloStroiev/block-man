using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class DestructAllCube : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _allCubes;
        private readonly IGroup<GameEntity> _inputs;

        public DestructAllCube(GameContext game)
        {
            _allCubes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AllCube));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Cleanup()
        {
            foreach (GameEntity allCube in _allCubes)
            foreach (GameEntity input in _inputs)
            {
                if (input.isAccelerationInput)
                {
                    
                    foreach (GameObject cube in allCube.AllCube)
                    {
                        Object.Destroy(cube);
                    }
                }
            }
        }
        
    }
}