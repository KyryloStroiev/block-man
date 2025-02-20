using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Factory;
using Code.Gameplay.Windows.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.UI.GameOvers.Systems
{
    public class GameOverSystem : IExecuteSystem
    {
        private readonly IWindowService _windowService;
        private readonly IWindowFactory _windowFactory;
        private readonly IGroup<GameEntity> _flags;
        private readonly IGroup<GameEntity> _points;
        private readonly IGroup<GameEntity> _timers;

        public GameOverSystem(GameContext game, IWindowService windowService)
        {
            _windowService = windowService;

            _flags = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GameOver));
            _timers = game.GetGroup(GameMatcher.TimePassed);
            _points = game.GetGroup(GameMatcher.PointsGameOver);
            
        }

        public void Execute()
        {
            foreach (GameEntity flag in _flags)
            {
                _windowService.Open(WindowsId.GameOverWindow);
                flag.isDestructed = true;
            }

            foreach (GameEntity point in _points)
            foreach (GameEntity time in _timers)
            {
                
                point.PointsGameOver.CounterGameOverPoints(time.TimePassed);
            }
        }
    }
}