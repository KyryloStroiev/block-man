using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    public class MovementComponents
    {
        
        [Game] public class Moving: IComponent {  }
        [Game] public class TurnedAlongDirection: IComponent {  }
        [Game] public class RotationSpeed: IComponent { public float Value; }
        [Game] public class HorizontalDirection: IComponent { public float Value; }
        [Game] public class LastDirection: IComponent { public float Value; }

        [Game] public class VerticalDirection: IComponent { public float Value; }

        [Game] public class Gravity: IComponent { public float Value; }

        [Game] public class Speed: IComponent { public float Value; }
        [Game] public class RigidbodyComponent: IComponent { public Rigidbody2D Value; }
    }
}