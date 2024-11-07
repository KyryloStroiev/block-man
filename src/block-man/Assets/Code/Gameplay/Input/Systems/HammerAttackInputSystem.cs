using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class HammerAttackInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _heroes;

        public HammerAttackInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.isHammerAttackInput = _inputService.GetButtonHammerAttack();
            }
        }
    }
}