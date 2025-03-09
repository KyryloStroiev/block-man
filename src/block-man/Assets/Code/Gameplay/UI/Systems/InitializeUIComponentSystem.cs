using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.UI.Config;
using Code.Gameplay.UI.Factory;
using Code.Gameplay.Windows.Factory;
using Entitas;

namespace Code.Gameplay.UI.Systems
{
    public class InitializeUIComponentSystem: IInitializeSystem
    {
        private readonly IWindowFactory _windowFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IStaticDataService _staticDataService;

        public InitializeUIComponentSystem(IWindowFactory windowFactory, IUIFactory uiFactory, ILevelDataProvider levelDataProvider, IStaticDataService staticDataService)
        {
            _windowFactory = windowFactory;
            _uiFactory = uiFactory;
            _levelDataProvider = levelDataProvider;
            _staticDataService = staticDataService;
        }
        
        public void Initialize()
        {
            _windowFactory.CreatePointsCounter();
            _uiFactory.CreateFlagGameOver(_levelDataProvider.FlagPoint);
            _uiFactory.CreateGameTimer();
            
            foreach (DeathColliderSpawnerData deathCollider in _staticDataService.GetUIElementsConfig().DeathColliderSpawners)
            {
                _uiFactory.CreateDeathCollider(deathCollider.Position);
               
            }
        }
    }
}