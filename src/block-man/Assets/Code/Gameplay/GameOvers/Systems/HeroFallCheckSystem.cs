using Code.Gameplay.Common.PhysicsService;
using Entitas;

namespace Code.Gameplay.GameOvers.Systems
{
    public class HeroFallCheckSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _hero;
        private readonly IGroup<GameEntity> _colliders;

        public HeroFallCheckSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _hero = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero));
            _colliders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.DeathCollider,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _hero)
            foreach (GameEntity collider in _colliders)
            {
                if (CheckTarget(collider))
                {
                    hero.isGameOver = true;
                }
            }
        }

        private bool CheckTarget(GameEntity collider)
        {
            return _physicsService.BoxCast(collider.Transform, collider.TargetLayerMask) >0;
        }
    }
}