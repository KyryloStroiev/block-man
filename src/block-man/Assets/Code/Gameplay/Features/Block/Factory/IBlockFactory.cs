using UnityEngine;

namespace Code.Gameplay.Features.Block.Factory
{
    public interface IBlockFactory
    {
        GameEntity CreateBlock(BlockTypeId typeId, Vector3 at);
        GameEntity CreateSpawnPoint(Vector3 at);
        
    }
}