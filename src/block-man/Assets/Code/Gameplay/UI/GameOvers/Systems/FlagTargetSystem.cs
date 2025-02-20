using System.Collections.Generic;
using Code.Gameplay.Common.PhysicsService;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.UI.GameOvers.Systems
{
    public class FlagTargetSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IWindowFactory _windowFactory;
        private readonly IGroup<GameEntity> _flags;
        private List<GameEntity> _buffer = new(1);

        public FlagTargetSystem(GameContext game, IPhysicsService physicsService, IWindowFactory windowFactory)
        {
            _physicsService = physicsService;
            _windowFactory = windowFactory;
            _flags = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.FlagGameOver, 
                    GameMatcher.Transform,
                    GameMatcher.TargetLayerMask)
                .NoneOf(GameMatcher.GameOver));
        }

        public void Execute()
        {
            foreach (GameEntity flag in _flags.GetEntities(_buffer))
            {
                if (_physicsService.BoxCast(flag.Transform, flag.TargetLayerMask) >0)
                {
                   flag.isFinal = true;
                    flag.isGameOver = true;
                }
            }
        }
    }
}