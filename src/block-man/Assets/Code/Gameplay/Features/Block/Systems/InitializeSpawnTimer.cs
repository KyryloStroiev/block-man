using Code.Common.Entity;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Block.Systems
{
    public class InitializeSpawnTimer: IInitializeSystem
    {
        private readonly IStaticDataService _staticDataService;

        public InitializeSpawnTimer(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddSpawnTimer(1)
                .AddSpawnTimerInterval(_staticDataService.GetBlockConfig().SpawnTimerInterval);
        }
    }
}