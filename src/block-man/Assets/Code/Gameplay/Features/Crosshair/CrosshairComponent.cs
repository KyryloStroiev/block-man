using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair
{
    [Game] public class Crosshair: IComponent { }
    [Game] public class Shoot: IComponent { }
    [Game] public class MaxDistanceShoot: IComponent { public float Value; }
    [Game] public class ClampedPosition: IComponent { public float Value; }
    [Game] public class CrosshairAngle: IComponent { public float Value; }
    [Game] public class SmoothFactor: IComponent { public int Value; }
    [Game] public class CrosshairTarget: IComponent { public GameObject Value; }
    
}