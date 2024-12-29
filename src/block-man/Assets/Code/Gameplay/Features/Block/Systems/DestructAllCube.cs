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
            
        }

        public void Cleanup()
        {
            foreach (GameEntity allCube in _allCubes)
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.E))
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