﻿using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
   [Game] public class Input: IComponent {  }
   [Game] public class JumpInput: IComponent {  }
   [Game] public class HammerAttackInput: IComponent {  }
   [Game] public class ShootInput: IComponent {  }
   [Game] public class AxisInput: IComponent { public float Value; }
}