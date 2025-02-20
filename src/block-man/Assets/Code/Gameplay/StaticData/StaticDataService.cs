using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Block.Configs;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.UI.GameOvers.Config;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowsId, GameObject> _windowsPrefabsById;
        private HeroConfig _hero;
        private UIElementsConfig _uiElements;
        private BlockConfig _blockConfig;
        private ArmamentsConfig _armamentsConfig;
        
        
        public void LoadAll()
        {
            LoadHero();
            LoadBlockConfig();
            LoadArmamentsConfig();
            LoadWindows();
            LoadUIElement();
        }

        public HeroConfig GetHeroConfig() => _hero;
        public UIElementsConfig GetUIElementsConfig() => _uiElements;
        public BlockConfig GetBlockConfig() => _blockConfig;
        public ArmamentsConfig GetArmamentsConfig() => _armamentsConfig;
        public GameObject GetWindowPrefab(WindowsId windowsId) =>
            _windowsPrefabsById.TryGetValue(windowsId, out GameObject windowPrefab)
                ? windowPrefab
                : throw new Exception($"Prefab config for window {windowsId} was not found");


        private void LoadHero() =>
            _hero = Resources
                .Load<HeroConfig>("Config/Hero/heroConfig");
        private void LoadUIElement() =>
            _uiElements = Resources
                .Load<UIElementsConfig>("Config/UI/UIElements");

        private void LoadBlockConfig() =>
            _blockConfig = Resources
                .Load<BlockConfig>("Config/Block/blockConfig");
        private void LoadArmamentsConfig() =>
            _armamentsConfig = Resources
                .Load<ArmamentsConfig>("Config/Armaments/armamentsConfig");

        private void LoadWindows()
        {
            _windowsPrefabsById = Resources
                .Load<WindowsConfig>("Config/UI/Windows/windowConfig")
                .WindowConfigs
                .ToDictionary(x=>x.Id, x=>x.Prefab);
        }
    }
}