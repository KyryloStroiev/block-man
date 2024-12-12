using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class AddToListCubeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _block;
        private readonly IGroup<GameEntity> _allCubes;
        private List<GameEntity> _buffer = new(64);

        public AddToListCubeSystem(GameContext game)
        {
            _block = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Block).NoneOf(GameMatcher.AddCube));
            _allCubes = game.GetGroup(GameMatcher.AllCube);
        }
        
        public void Execute()
        {
            foreach (GameEntity block in _block.GetEntities(_buffer))
            foreach (GameObject cube in block.Cube)
            foreach (GameEntity allCube  in _allCubes )
            {
                allCube.AllCube.Add(cube);
                block.isAddCube = true;
            }
            
            
        }
    }
}