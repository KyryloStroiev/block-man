using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class SetHeroDirectionBuInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroDirectionBuInputSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                    hero.ReplaceHorizontalDirection(input.AxisInput);
                
            }
        }
        
    }
}