using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Factory
{
    public class BlockFactory : IBlockFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;

        public BlockFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateBlock(BlockTypeId typeId, Vector3 at)
        {
            BlockConfig baseConfig = _staticDataService.GetBlockConfig();
            
           return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddBlockTypeId(typeId)
                .AddWorldPosition(at)
                .AddSpeed(baseConfig.Speed)
                .AddViewPrefab(_staticDataService.GetBlockPrefab(typeId).BlockPrefab)
                .AddVerticalDirection(-1)
                .AddHorizontalDirection(0)
                .AddCircleOffsetY(0)
                .AddTargetLayerMask(CollisionLayer.Block.AsMask())
                .AddRadiusGroundCheck(baseConfig.CircleGroundRadius)
                .With(x=>x.isBlock = true)
                .With(x=>x.isMoving = true);
           
        }
        
        public GameEntity CreateSpawnPoint(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddWorldPosition(at)
                .AddViewPrefab(_staticDataService.GetBlockConfig().SpawnPointPrefab)
                .With(x => x.isSpawnPoint = true);
        }
        
    }
}