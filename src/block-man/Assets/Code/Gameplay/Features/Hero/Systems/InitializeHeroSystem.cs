using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
    public class InitializeHeroSystem: IInitializeSystem
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHeroFactory _heroFactory;

        public InitializeHeroSystem(GameContext game, ILevelDataProvider levelDataProvider, IHeroFactory heroFactory)
        {
            _levelDataProvider = levelDataProvider;
            _heroFactory = heroFactory;
        }
        
        public void Initialize()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _heroFactory.CreateCrosshair(_levelDataProvider.StartPoint);
        }
    }
}