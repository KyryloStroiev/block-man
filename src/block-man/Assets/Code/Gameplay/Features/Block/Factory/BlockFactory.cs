using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Block.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Factory
{
    public class BlockFactory : IBlockFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;
        private BlockConfig _blockConfig;

        public BlockFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
            _blockConfig = _staticDataService.GetBlockConfig();
        }

        public GameEntity CreateBlock(BlockTypeId typeId, Vector3 at)
        {
           return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddBlockTypeId(typeId)
                .AddWorldPosition(at)
                .AddSpeed(_blockConfig.Speed)
                .AddViewPrefab(PrefabBlockId(typeId))
                .AddVerticalDirection(-1)
                .AddCircleOffsetY(0)
                .AddTargetLayerMask(CollisionLayer.Cube.AsMask()) 
                .AddRadiusGroundCheck(_blockConfig.CircleGroundRadius)
                .With(x=>x.isBlock = true)
                .With(x=>x.isMoving = true);
           
        }
        
       
        

        public GameEntity CreateListCube()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddAllCube(new List<GameObject>(512));
        }
        
        public GameEntity CreateSpawnPoint(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddWorldPosition(at)
                .AddViewPrefab(_blockConfig.SpawnPointPrefab)
                .With(x => x.isSpawnPoint = true);
        }

        private EntityBehaviour PrefabBlockId(BlockTypeId typeId)
        {
            if (!_blockConfig.BlockPrefab.TryGetValue(typeId, out var prefab))
            {
                throw new Exception($"No prefab found for BlockId: {typeId}");
                
            }
            return prefab;
        }
        
    }
}