using Code.Gameplay.Features.Block.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class InitializeSpawnBlockComponentSystem: IInitializeSystem
    {
        private readonly IBlockFactory _blockFactory;

        public InitializeSpawnBlockComponentSystem(IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
        }
        
        public void Initialize()
        {
            _blockFactory.CreateSpawnPoint(new Vector3(0,10,0));
            _blockFactory.CreateListCube();
        }
    }
}