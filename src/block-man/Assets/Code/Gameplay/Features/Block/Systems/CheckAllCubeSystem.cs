using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class CheckAllCubeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _allCubes;

        public CheckAllCubeSystem(GameContext game)
        {
            _allCubes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AllCube));
        }

        public void Execute()
        {
            foreach (GameEntity allCube in _allCubes)
            {
                Debug.Log(allCube.AllCube.Count);
                
            }
        }
    }
}