using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows
{
    public class MenuWindows : BaseWindow
    {
        private const string BattleScene = "Main";
        public Button NewGameButton;
        public Button CloseButton;
        private IWindowService _windowService;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IWindowService windowService, IGameStateMachine gameStateMachine)
        {
            Id = WindowsId.PauseWindow;
            _gameStateMachine = gameStateMachine;
            _windowService = windowService;
        }

        protected override void OnAwake() => 
            Time.timeScale = 0f;

        protected override void Initialize()
        {
            CloseButton.onClick.AddListener(Close);
            NewGameButton.onClick.AddListener(StartNewGame);
        }

        private void StartNewGame()
        {
            Close();
            _gameStateMachine.Enter<LoadingBattleState, string>(BattleScene);
        }
            

        private void Close()
        {
            Time.timeScale = 1f;
            _windowService.OpenMenu = false;
            _windowService.Close(Id);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            CloseButton.onClick.RemoveListener(Close);
            NewGameButton.onClick.RemoveListener(StartNewGame);
        }
    }
}