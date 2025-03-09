using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
    public class LoadProgressState :IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressProvider _progressProvider;

        public LoadProgressState(
            IGameStateMachine stateMachine,
            ISaveLoadService saveLoadService,
            IStaticDataService staticDataService, 
            IProgressProvider progressProvider)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
            _progressProvider = progressProvider;
        }
        
        public void Enter()
        {
            InitializeProgress();
            
            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        public void Exit()
        {
            
        }

        private void InitializeProgress()
        {
            if(_saveLoadService.HasSavedProgress)
                _saveLoadService.LoadProgress();
            CreateNewProgress();
        }

        private void CreateNewProgress()
        {
            _saveLoadService.CreateProgress();
        }
    }
}