using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class DestructAllCube : ITearDownSystem
    {
        private readonly IGroup<GameEntity> _allCubes;
        private readonly IGroup<GameEntity> _inputs;

        public DestructAllCube(GameContext game)
        {
            _allCubes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AllCube));
            
        }

        
        public void Initialize()
        {
            
        }

        public void TearDown()
        {
            foreach (GameEntity allCube in _allCubes)
            {
                foreach (GameObject cube in allCube.AllCube)
                {
                    Object.Destroy(cube);
                }
            }
        }
            
    }
}