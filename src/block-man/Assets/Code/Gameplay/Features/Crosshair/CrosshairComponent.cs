using Entitas;

namespace Code.Gameplay.Features.Crosshair
{
    [Game] public class Crosshair: IComponent { }
    [Game] public class Shoot: IComponent { }
    [Game] public class MaxDistanceShoot: IComponent { public float Value; }
}