using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Hero;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {

        private Dictionary<BlockTypeId, BlockConfigPrefab> _blockPrefab;
        private HeroConfig _hero;
        private BlockConfig _blockConfig;
        
        
        public void LoadAll()
        {
            LoadHero();
            LoadBlockConfig();
            LoadBlockPrefab();
        }

        public HeroConfig GetHeroConfig() => _hero;
        public BlockConfig GetBlockConfig() => _blockConfig;

        public BlockConfigPrefab GetBlockPrefab(BlockTypeId blockId)
        {
            if (_blockPrefab.TryGetValue(blockId, out BlockConfigPrefab config))
                return config;
            
            throw new Exception($"Block config for {blockId} was not found");
        }
        private void LoadBlockPrefab() =>
            _blockPrefab = Resources
                .LoadAll<BlockConfigPrefab>("Config/Block/Prefab")
                .ToDictionary(x => x.TypeId, x => x);

        private void LoadHero() =>
            _hero = Resources
                .Load<HeroConfig>("Config/Hero/heroConfig");

        private void LoadBlockConfig() =>
            _blockConfig = Resources
                .Load<BlockConfig>("Config/Block/blockConfig");
    }
}