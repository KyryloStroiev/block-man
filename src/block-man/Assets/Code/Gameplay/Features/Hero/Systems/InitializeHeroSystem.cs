using Code.Gameplay.Features.Block.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class InitializeHeroSystem: IInitializeSystem
    {
        private readonly IBlockFactory _blockFactory;
        private readonly IHeroFactory _heroFactory;

        public InitializeHeroSystem(GameContext game, IBlockFactory blockFactory, IHeroFactory heroFactory)
        {
            _blockFactory = blockFactory;
            _heroFactory = heroFactory;
        }
        
        public void Initialize()
        {
            _blockFactory.CreateSpawnPoint(new Vector3(0,10,0));
            _blockFactory.CreateListCube();
        }
    }
}