using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection
{
    [Game] public class TargetsBuffer: IComponent {public List<int> Value; }
    [Game] public class Targets: IComponent {public int Value; }
    [Game] public class Ground: IComponent { }                                          
    [Game] public class ReadyToCollectTargets: IComponent { }                                          
    [Game] public class RadiusGroundCheck: IComponent {public float Value; }
    [Game] public class RadiusCastTargets: IComponent {public float Value; }
    [Game] public class CircleOffsetY : IComponent {public float Value; }
    [Game] public class CircleOffsetX: IComponent {public float Value; }
    [Game] public class GroundLayerMask: IComponent {public int Value; }
    [Game] public class TargetLayerMask: IComponent {public int Value; }
    [Game] public class ObstacleLayerMask: IComponent {public int Value; }
   
    

}