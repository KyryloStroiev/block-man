using Entitas;

namespace Code.Gameplay.Features.Armaments
{
   
    [Game] public class BulletCube: IComponent { }
    [Game] public class RotationCube: IComponent { }
    [Game] public class GunCube: IComponent { }
  
    [Game] public class DirectionShot: IComponent { public int Value; }
    
    [Game] public class ShotReady: IComponent { }

    [Game] public class SpawnShotTimer: IComponent {public float Value; }
    
    [Game] public class SpawnShotTimerInterval: IComponent {public float Value; }
}