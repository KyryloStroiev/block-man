using Code.Common.Entity;
using Code.Gameplay.Features.Armaments.Configs;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class InitializeArmamentsSystem: IInitializeSystem
    {
        
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentsFactory _iArmamentsFactory;

        public InitializeArmamentsSystem(IStaticDataService staticDataService, IArmamentsFactory iArmamentsFactory)
        {
            _staticDataService = staticDataService;
            _iArmamentsFactory = iArmamentsFactory;
        }

        public void Initialize()
        {
            CreateEntity.Empty()
                .AddSpawnShotTimer(1)
                .AddSpawnShotTimerInterval(_staticDataService.GetArmamentsConfig().SpawnTimerInterval);
            
            foreach (ArmamentsSpawnerData spawner in _staticDataService.GetArmamentsConfig().GunSpawners)
            {
                _iArmamentsFactory.CreateArmaments(spawner.TypeId, spawner.Position, spawner.IsLookRight);
               
            }
        }
    }
}