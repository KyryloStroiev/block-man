using Code.Gameplay.Common.PhysicsService;
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
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input).NoneOf(GameMatcher.ShootInput));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {

                if (input.hasAxisInput)
                {
                    hero.ReplaceHorizontalDirection(input.AxisInput);
                    
                    if (Mathf.Abs(input.AxisInput) > 0.01f)
                    {
                        hero.ReplaceLastDirection(input.AxisInput);
                    }
                }
                else if (input.isShootInput)
                {
                    hero.ReplaceHorizontalDirection(0);
                }
                else
                {
                    hero.ReplaceHorizontalDirection(0);
                }
                
            }
        }
        
    }
}