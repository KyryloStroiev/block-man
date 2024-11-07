using Code.Gameplay.Input.Service;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
    public class EmitAxisInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitAxisInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                if (_inputService.HasAxisInput())
                    input.ReplaceAxisInput(_inputService.GetHorizontalAxis());
                else if(input.hasAxisInput) 
                    input.RemoveAxisInput();
                
            }
        }
    }
}