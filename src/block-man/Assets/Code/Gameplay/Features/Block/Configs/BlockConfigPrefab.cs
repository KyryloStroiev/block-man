using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Block
{
    [CreateAssetMenu(fileName = "blockConfigPrefab", menuName = "Configs/blockPrefab")]
    public class BlockConfigPrefab : ScriptableObject
    {
        public BlockTypeId TypeId;
        
        public EntityBehaviour BlockPrefab;
    }
}