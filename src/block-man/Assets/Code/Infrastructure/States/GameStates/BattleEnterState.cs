using Code.Gameplay.Features.Block.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateMachine;
using Unity.VisualScripting;
using UnityEngine;
using IState = Code.Infrastructure.States.StateInfrastructure.IState;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        public BattleEnterState(IGameStateMachine gameStateMachine,
            IHeroFactory heroFactory, 
            ILevelDataProvider levelDataProvider)
        {
            _gameStateMachine = gameStateMachine;
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
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
        }
    }
}