using System;
using Code.Gameplay.Common;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class JumpHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public JumpHeroSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.VerticalDirection,
                    GameMatcher.JumpHeight));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input,
                    GameMatcher.JumpInput));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity input in _inputs)
            {
                if (hero.isGround)
                {
                    hero.ReplaceVerticalDirection(JumpHeight(hero));
                    hero.isJump = true;
                }
                else
                {
                    hero.isJump = false;
                }
                
            }
        }

        private float JumpHeight(GameEntity entity) => 
            (float)Math.Sqrt(entity.JumpHeight * -1f * GameplayConst.Gravity);
    }
}