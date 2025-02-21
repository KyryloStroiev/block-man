using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Hud
{
    public class HomeHUD : MonoBehaviour
    {
        public Button NewGameButton;
        private const string BattleScene = "Main";
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            NewGameButton.onClick.AddListener(StartNewGame);
        }

        private void StartNewGame()
        {
            _gameStateMachine.Enter<LoadingBattleState, string>(BattleScene);
        }
    }
}