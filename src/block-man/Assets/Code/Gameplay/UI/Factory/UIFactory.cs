using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public UIFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateGameTimer()
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.NextId())
                .AddTimePassed(0)
                .With(x => x.isGameTimer = true);
        }

        public GameEntity CreateFlagGameOver(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.NextId())
                .AddWorldPosition(at)
                .AddViewPrefab(_staticDataService.GetUIElementsConfig().FlagPrefab)
                ;
        }

        public GameEntity CreateDeathCollider(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.NextId())
                .AddWorldPosition(at)
                .AddViewPrefab(_staticDataService.GetUIElementsConfig().DeathCollider);
        }
        
      
    }
}