using Entitas;

namespace Code.Gameplay.Features.Hero
{
    public class AnimateShootHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _crosshairs;

        public AnimateShootHeroSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.HeroAnimator));
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair,
                    GameMatcher.CrosshairAngle));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity crosshair in _crosshairs)
            {
                hero.HeroAnimator.PlayShooting(crosshair.isShoot);
                hero.HeroAnimator.PlayShot(crosshair.CrosshairAngle);
            }
        }
    }
}