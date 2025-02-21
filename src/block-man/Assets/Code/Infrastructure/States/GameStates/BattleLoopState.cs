using Code.Gameplay;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState: IState, IUpdateable
    {
        private readonly ISystemFactory _systems;
        private readonly IInputService _inputService;
        private readonly GameContext _gameContext;
        private readonly ILevelDataProvider _levelDataProvider;
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, IInputService inputService, GameContext gameContext,
            ILevelDataProvider levelDataProvider)
        {
            _systems = systems;
            _inputService = inputService;
            _gameContext = gameContext;
            _levelDataProvider = levelDataProvider;
        }
        public void Enter()
        {
            
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
            
        }


        public void Exit()
        {
            
            _inputService.Cleanup();
        
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();
            _battleFeature.TearDown();

            DestructEntities();

            _battleFeature.Cleanup();

            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
            {
                entity.isDestructed = true;
            }
        }
    }
}