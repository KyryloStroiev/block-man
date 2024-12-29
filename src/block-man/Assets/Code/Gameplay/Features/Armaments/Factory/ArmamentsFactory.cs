using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentsFactory : IArmamentsFactory
    {
        private const float TimeOfLife = 20;
        
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;
        private ArmamentsConfig _armamentsConfig;

        public ArmamentsFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
            
        }


        public GameEntity CreateArmaments(ArmamentsTypeId typeId, Vector3 at, bool isLookRight )
        {
            switch (typeId)
            {
                case ArmamentsTypeId.GunCube:
                  return  CreateGunCube(at, isLookRight);

                case ArmamentsTypeId.RotationCube:
                    return CreateRotationCube(at);
                
                default:
                    throw new ArgumentException($"EnemyTypeId {typeId} is not supported.");
            }
           
        }
        
        private GameEntity CreateGunCube(Vector3 at, bool isLookRight)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddWorldPosition(at)
                .AddDirectionShot(isLookRight ? 1 : -1)
                .With(x=>x.isGunCube = true);
        }

        private GameEntity CreateRotationCube( Vector3 at)
        {
            _armamentsConfig = _staticDataService.GetArmamentsConfig();
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddWorldPosition(at)
                .AddViewPrefab(_armamentsConfig.cubePrefab)
                .AddRotationSpeed(_armamentsConfig.RotationSpeed)
                .AddTargetLayerMask(CollisionLayer.Cube.AsMask())
                .With(x=>x.isRotationCube = true)
                .With(x=>x.isMoving = true);
           
        }

        public GameEntity CreateBulletCube( Vector3 at, float horizontalDirection)
        {
            _armamentsConfig = _staticDataService.GetArmamentsConfig();
            return CreateEntity.Empty()
                .AddId(_identifiers.NextId())
                .AddWorldPosition(at)
                .AddSpeed(_armamentsConfig.Speed)
                .AddViewPrefab(_armamentsConfig.cubePrefab)
                .AddHorizontalDirection(horizontalDirection)
                .AddRotationSpeed(_armamentsConfig.RotationSpeed)
                .AddTargetLayerMask(CollisionLayer.Cube.AsMask())
                .AddSelfDestructTimer(TimeOfLife)
                .With(x=>x.isBulletCube = true)
                .With(x=>x.isMoving = true);
           
        }
    }
}