using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class ShootGunInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public ShootGunInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
               input.isShootInput = _inputService.GetButtonShoot();
               
            }
        }
    }
}