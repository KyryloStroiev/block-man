using System.Collections.Generic;
using Code.Infrastructure.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Features.Block
{
    [CreateAssetMenu(fileName = "blockConfig", menuName = "Configs/blockConfig")]
    public class BlockConfig : SerializedScriptableObject
    {
      
        public float Speed = 1;
        public float AccelerationSpeed = 3;
        public float SpawnTimerInterval = 30;
        public float CircleGroundRadius = 0.53f;
        public float RotationSpeed = 100;
        
        public EntityBehaviour SpawnPointPrefab;

        public Dictionary<BlockTypeId, EntityBehaviour> BlockPrefab;
        
    }
}