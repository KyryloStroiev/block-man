using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
    public class HeroComponents
    {
        [Game] public class Hero: IComponent { }
        [Game] public class Jump: IComponent { }
        [Game] public class HeroAnimatorComponent: IComponent {public HeroAnimator Value; }
        [Game] public class JumpHeight: IComponent {public float Value; }
        [Game] public class MaxHeightHero: IComponent {public float Value; }


    }
}