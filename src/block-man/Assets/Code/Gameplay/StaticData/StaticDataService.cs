using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Block.Configs;
using Code.Gameplay.Features.Hero;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private HeroConfig _hero;
        private BlockConfig _blockConfig;
        private ArmamentsConfig _armamentsConfig;
        
        
        public void LoadAll()
        {
            LoadHero();
            LoadBlockConfig();
            LoadArmamentsConfig();
        }

        public HeroConfig GetHeroConfig() => _hero;
        public BlockConfig GetBlockConfig() => _blockConfig;
        public ArmamentsConfig GetArmamentsConfig() => _armamentsConfig;


        private void LoadHero() =>
            _hero = Resources
                .Load<HeroConfig>("Config/Hero/heroConfig");

        private void LoadBlockConfig() =>
            _blockConfig = Resources
                .Load<BlockConfig>("Config/Block/blockConfig");
        private void LoadArmamentsConfig() =>
            _armamentsConfig = Resources
                .Load<ArmamentsConfig>("Config/Armaments/armamentsConfig");
    }
}