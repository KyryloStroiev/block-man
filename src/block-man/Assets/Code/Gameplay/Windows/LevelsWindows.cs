using System.Collections.Generic;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.Service
{
    public class LevelsWindows: BaseWindow
    {
  
        [ShowInInspector]
        public Dictionary<Button, LevelId> LevelsButtons = new();
        
        private IWindowService _windowService;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IWindowService windowService, IGameStateMachine gameStateMachine)
        {
            Id = WindowsId.LevelsWindows;
            _gameStateMachine = gameStateMachine;
            _windowService = windowService;
        }
        
        protected override void Initialize()
        {


            foreach (KeyValuePair<Button, LevelId> button in LevelsButtons)
            { button.Key.onClick.AddListener(
                () => StartNewLevel(button.Value.ToString()));
            }
        }

        private void StartNewLevel(string levelName)
        {
            Close();
            _gameStateMachine.Enter<LoadingBattleState, string>(levelName);
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
            
            foreach (KeyValuePair<Button,LevelId> button in LevelsButtons)
            {
                button.Key.onClick.RemoveAllListeners();
            }
        }
    }
}