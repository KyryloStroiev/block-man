using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.UI.HUD
{
    public class GameplayHUD : MonoBehaviour
    {
        public Button MenuButton;
        
        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IWindowService windowService)
        {
            _windowService = windowService;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            MenuButton.onClick.AddListener(OpenMenu);
        }

        private void OpenMenu()
        {
            if (!_windowService.OpenMenu)
            {
                _windowService.OpenMenu = true;
                _windowService.Open(WindowsId.PauseWindow);
            }
            
        }
    }
}