using Code.Infrastructure.States.StateMachine;
using IState = Code.Infrastructure.States.StateInfrastructure.IState;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        
        public BattleEnterState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Exit()
        {
            
        }

    }
}