using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Block.Configs;
using Code.Gameplay.Features.Hero;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        HeroConfig GetHeroConfig();
        BlockConfig GetBlockConfig();
        ArmamentsConfig GetArmamentsConfig();
    }

}