using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Block.Configs;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.UI.GameOvers.Config;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        HeroConfig GetHeroConfig();
        BlockConfig GetBlockConfig();
        ArmamentsConfig GetArmamentsConfig();
        GameObject GetWindowPrefab(WindowsId windowsId);
        UIElementsConfig GetUIElementsConfig();
    }

}