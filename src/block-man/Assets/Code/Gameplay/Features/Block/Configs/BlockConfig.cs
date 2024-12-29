using System.Collections.Generic;
using Code.Infrastructure.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Configs
{
    [CreateAssetMenu(fileName = "blockConfig", menuName = "Configs/blockConfig")]
    public class BlockConfig : SerializedScriptableObject
    {
      
        public float Speed = 1;
        public float AccelerationSpeed = 4f;
        public float SpawnTimerInterval = 8;
        
        public float CircleGroundRadius = 0.53f;
        
        public EntityBehaviour SpawnPointPrefab;

        public Dictionary<BlockTypeId, EntityBehaviour> BlockPrefab;
        
    }
}