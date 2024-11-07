
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Block
{
    [CreateAssetMenu(fileName = "blockConfig", menuName = "Configs/blockConfig")]
    public class BlockConfig : ScriptableObject
    {
        public float Speed = 1;
        public float SpawnTimerInterval = 30;
        public float CircleGroundRadius = 0.53f;
        
        public EntityBehaviour SpawnPointPrefab;
    }
}