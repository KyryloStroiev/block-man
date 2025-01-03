﻿using Code.Gameplay;
using Code.Gameplay.Input.Service;
using Code.Infrastructure.States.Factory;
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
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, IInputService inputService, GameContext gameContext)
        {
            _systems = systems;
            _inputService = inputService;
            _gameContext = gameContext;
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
            
            DestructEntities();
            
            _battleFeature.Cleanup();
            _battleFeature.TearDown();  

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