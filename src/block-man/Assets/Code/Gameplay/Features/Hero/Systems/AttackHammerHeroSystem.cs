using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Sound.Configs;
using Code.Gameplay.Sound.Service;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class AttackHammerHeroSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IStaticDataService _staticData;
        private readonly IPlaySoundsService _playSounds;
        private readonly IGroup<GameEntity> _damageDealer;
        private readonly IGroup<GameEntity> _inputs;
        
        public AttackHammerHeroSystem(GameContext game, IPhysicsService physicsService, IStaticDataService staticData, IPlaySoundsService playSounds)
        {
            _physicsService = physicsService;
            _staticData = staticData;
            _playSounds = playSounds;
            _damageDealer = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.DestructCubes,
                    GameMatcher.HeroAnimator));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input,
                    GameMatcher.HammerAttackInput)
                .NoneOf(GameMatcher.ShootInput));
        }

        public void Execute()
        {
            foreach (GameEntity damageDealer in _damageDealer)
            foreach (GameEntity input in _inputs)
            {
                
                if (BlockIsTarget(damageDealer) != null)
                {
                    GameObject obj = BlockIsTarget(damageDealer).gameObject;
                    Object.Destroy(obj, 0.3f);
                   
                }
                _playSounds.PlayOne(_staticData.GetSounds().HummerSound, damageDealer);
                damageDealer.HeroAnimator.PlayAttackHammer();
            }
        }

        private Collider2D BlockIsTarget(GameEntity damageDealer) =>
            _physicsService.CircleCastCollider(damageDealer.WorldPosition,
                damageDealer.CircleOffsetX * damageDealer.SpriteRenderer.transform.localScale.x, damageDealer.RadiusCastTargets,
                damageDealer.TargetLayerMask);
    }
}