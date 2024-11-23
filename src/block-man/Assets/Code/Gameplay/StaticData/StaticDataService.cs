using System.Collections.Generic;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Hero;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private HeroConfig _hero;
        private BlockConfig _blockConfig;
        
        
        public void LoadAll()
        {
            LoadHero();
            LoadBlockConfig();
        }

        public HeroConfig GetHeroConfig() => _hero;
        public BlockConfig GetBlockConfig() => _blockConfig;
        

        private void LoadHero() =>
            _hero = Resources
                .Load<HeroConfig>("Config/Hero/heroConfig");

        private void LoadBlockConfig() =>
            _blockConfig = Resources
                .Load<BlockConfig>("Config/Block/blockConfig");
    }
}