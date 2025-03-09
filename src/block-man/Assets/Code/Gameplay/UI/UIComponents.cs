
using Code.Gameplay.GameOvers.Behaviours;
using Code.Gameplay.UI.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.UI
{
    
    [Game] public class PointsCounterComponent: IComponent {public PointsCounter Value; }
    [Game] public class PointsGameOverComponent: IComponent {public PointsGameOver Value; }
    [Game] public class TimePassed: IComponent {public float Value; }
    [Game] public class RectTransformComponent: IComponent {public RectTransform Value; }
    [Game] public class FlagAnimatorComponent: IComponent {public FlagAnimator Value; }
    [Game] public class GameTimer: IComponent { }
    [Game] public class GameOver: IComponent { }
    [Game] public class FlagGameOver: IComponent { }
    [Game] public class DeathCollider: IComponent { }
    [Game] public class Final: IComponent { }
    
  
}