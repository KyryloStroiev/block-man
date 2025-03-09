using System;
using Code.Gameplay.Common;
using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Sound.Service;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
    public class JumpHeroSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IPlaySoundsService _playerSounds;
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public JumpHeroSystem(GameContext game, IPhysicsService physicsService, IPlaySoundsService playerSounds, IStaticDataService staticData)
        {
            _physicsService = physicsService;
            _playerSounds = playerSounds;
            _staticData = staticData;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Transform,
                    GameMatcher.VerticalDirection,
                    GameMatcher.JumpHeight,
                    GameMatcher.HeroAnimator));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input,
                    GameMatcher.JumpInput).NoneOf(GameMatcher.ShootInput));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity input in _inputs)
            {
                if (hero.isGround)
                {
                    hero.isJump = true;
                    hero.ReplaceVerticalDirection(JumpHeight(hero));
                    hero.HeroAnimator.PlayJump();
                    _playerSounds.PlayOne(_staticData.GetSounds().JumpSound, hero);
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