using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Gameplay.UI.Factory;
using Code.Gameplay.Windows.Factory;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using IState = Code.Infrastructure.States.StateInfrastructure.IState;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IUIFactory _uiFactory;
        private readonly IWindowFactory _windowFactory;

        public BattleEnterState(IGameStateMachine gameStateMachine,
            IHeroFactory heroFactory, 
            ILevelDataProvider levelDataProvider,
            IUIFactory uiFactory, IWindowFactory windowFactory)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _uiFactory = uiFactory;
            _windowFactory = windowFactory;
        }

        public void Enter()
        {
            CreateStartEntity();
            
            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Exit()
        {
            
           
        }

        private void CreateStartEntity()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _heroFactory.CreateCrosshair(_levelDataProvider.StartPoint);
            _windowFactory.CreatePointsCounter();
            _uiFactory.CreateFlagGameOver(_levelDataProvider.FlagPoint);
            _uiFactory.CreateGameTimer();
        }
    }
}