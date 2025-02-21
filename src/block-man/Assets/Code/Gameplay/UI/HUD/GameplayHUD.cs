using System;
using Code.Gameplay.Cursors;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Service;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.UI.HUD
{
    public class GameplayHUD : MonoBehaviour
    {
        public Button MenuButton;
        
        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;
        private ICursorService _cursorService;
        private bool _wasCursorOverButton;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IWindowService windowService, ICursorService cursorService)
        {
            _cursorService = cursorService;
            _windowService = windowService;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            MenuButton.onClick.AddListener(OpenMenu);
        }

        private void Update()
        {
            bool isCursorOverButton = EventSystem.current.IsPointerOverGameObject();

            if (isCursorOverButton != _wasCursorOverButton)
            {
                _wasCursorOverButton = isCursorOverButton;
                if (isCursorOverButton)
                { 
                    _cursorService.ShowCursor();
                }
                else
                {
                    _cursorService.HideCursor();
                }
                
            }
            
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