using Code.Gameplay.Features.Block;
using Code.Gameplay.Features.Hero;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        HeroConfig GetHeroConfig();
        BlockConfig GetBlockConfig();
    }
}