using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
  
        [Game] public class Hero: IComponent { }
        [Game] public class Jump: IComponent { }
        [Game] public class HeroAnimatorComponent: IComponent {public HeroAnimator Value; }
        [Game] public class JumpHeight: IComponent {public float Value; }
        [Game] public class MaxHeightHero: IComponent {public float Value; }
        [Game] public class DestructCubes: IComponent {public int Value; }
        [Game] public class CameraOffsetY: IComponent {public float Value; }
        
        
}