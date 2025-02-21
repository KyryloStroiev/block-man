using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero

{
   public class AnimateHeroSystem : IExecuteSystem
   {
      private readonly IGroup<GameEntity> _heroes;

      public AnimateHeroSystem(GameContext game)
      {
         _heroes = game.GetGroup(GameMatcher
            .AllOf(
               GameMatcher.Hero,
               GameMatcher.HeroAnimator));
      }

      public void Execute()
      {
         foreach (GameEntity hero in _heroes)
         {
            
            if(Mathf.Abs(hero.HorizontalDirection)> 0.01f)
               hero.HeroAnimator.PlayMove();
            else
               hero.HeroAnimator.PlayIdle();
            
            hero.HeroAnimator.PlayTouchDown(hero.isGround);
         }
      }
   }
}