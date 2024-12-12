using System.Collections.Generic;
using Code.Infrastructure.View;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block
{
    [Game] public class Block: IComponent { }
    [Game] public class SpawnPoint: IComponent { }
    [Game] public class AddCube: IComponent { }
    [Game] public class EnemyBlock: IComponent { }
    
    [Game] public class Cube: IComponent {public List<GameObject> Value; }
    [Game] public class AllCube: IComponent {public List<GameObject> Value; }

    [Game] public class BlockTypeIdComponent: IComponent {public BlockTypeId Value; }

    [Game] public class ChangingLayer: IComponent {public LayerMask Value; }

    [Game] public class BlockColliding: IComponent { }
    [Game] public class SpawnReady: IComponent { }

    [Game] public class SpawnTimer: IComponent {public float Value; }
    
    [Game] public class SpawnTimerInterval: IComponent {public float Value; }
}