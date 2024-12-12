using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class UpdateMaxHeightHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public UpdateMaxHeightHeroSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition,
                    GameMatcher.MaxHeightHero));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (hero.WorldPosition.y > hero.MaxHeightHero)
                {
                    hero.ReplaceMaxHeightHero(hero.WorldPosition.y);
                   
                }
                
            }
            
        }
    }
}