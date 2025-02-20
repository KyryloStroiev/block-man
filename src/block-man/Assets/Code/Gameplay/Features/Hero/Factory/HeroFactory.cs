using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        
        private readonly IIdentifierService _identifier;
        private readonly IStaticDataService _staticDataService;

        public HeroFactory(IIdentifierService identifier, IStaticDataService staticDataService)
        {
            _identifier = identifier;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            HeroConfig baseData = _staticDataService.GetHeroConfig(); 
            
           return CreateEntity.Empty()
                .AddId(_identifier.NextId())
                .AddWorldPosition(at)
                .AddMaxHeightHero(at.y)
                .AddSpeed(baseData.Speed)
                .AddHorizontalDirection(0)
                .AddLastDirection(1)
                .AddVerticalDirection(0)
                .AddDestructCubes(0)
                .AddRadiusGroundCheck(baseData.CircleGroundRadius)
                .AddCircleOffsetY(baseData.CircleOffsetYGround)
                .AddJumpHeight(baseData.JumpHeight)
                .AddGravity(GameplayConst.Gravity)
                .AddTargets(1)
                .AddRadiusCastTargets(baseData.CircleTargetsRadius)
                .AddCircleOffsetX(baseData.CircleOffsetXTarget)
                .AddCameraOffsetY(baseData.CameraOffsetY)
                .AddViewPrefab(baseData.HeroPrefab)
                .With(x=>x.isTurnedAlongDirection = true)
                .With(x=>x.isHero = true)
                .With(x => x.isMoving = true);
        }
        public GameEntity CreateCrosshair(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifier.NextId())
                .AddViewPrefab(_staticDataService.GetHeroConfig().CrosshairPrefab)
                .AddWorldPosition(at)
                .AddSmoothFactor(_staticDataService.GetHeroConfig().SmoothFactor)
                .AddTargetsBuffer( new List<int>(1))
                .AddMaxDistanceShoot(_staticDataService.GetHeroConfig().MaxDistanceShoot)
                .With(x=>x.isCrosshair = true)
                .With(x=>x.isMoving = true);
        }
        
    }
}