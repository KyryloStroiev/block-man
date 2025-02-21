using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class BootstrapState: IState
    {
        private const string BattleScene = "Main";
       
        private readonly IGameStateMachine _stateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly ILevelDataProvider _levelDataProvider;

        public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService, ILevelDataProvider levelDataProvider)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
            _levelDataProvider = levelDataProvider;
        }
        public void Enter()
        {
            _staticDataService.LoadAll();
            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        public void Exit()
        {
            
        }
    }
}