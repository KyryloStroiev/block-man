using Code.Gameplay.Common.PhysicsService;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class AttackHammerHeroSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _damageDealer;
        private readonly IGroup<GameEntity> _inputs;

        public AttackHammerHeroSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _damageDealer = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
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
                
                    foreach (Collider2D collider in BlockIsTarget(damageDealer))
                    {
                        GameObject obj = collider.gameObject;
                        Object.Destroy(obj);
                    }
                    damageDealer.HeroAnimator.PlayAttackHammer();
                    
            }
        }

        private Collider2D[] BlockIsTarget(GameEntity damageDealer)
        {
            Collider2D[] colliders = _physicsService.CircleCastCollider(damageDealer.WorldPosition,
                damageDealer.CircleOffsetX * damageDealer.SpriteRenderer.transform.localScale.x, damageDealer.RadiusCastTargets,
                damageDealer.TargetLayerMask);
            return colliders;
        }
    }
}