using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Factory;
using Code.Gameplay.Windows.Service;
using Entitas;

namespace Code.Gameplay.GameOvers.Systems
{
    public class GameOverFinalSystem : IExecuteSystem
    {
        private readonly IWindowService _windowService;
        private readonly ITimeService _timeService;
        private readonly IWindowFactory _windowFactory;
        private readonly IGroup<GameEntity> _flags;
        private readonly IGroup<GameEntity> _points;
        private readonly IGroup<GameEntity> _timers;
        
        private List<GameEntity> _buffer = new(2);
        private float _timeToOpenWindows = 1.5f;
        private float _timePassed;

        public GameOverFinalSystem(GameContext game, IWindowService windowService, ITimeService timeService)
        {
            _windowService = windowService;
            _timeService = timeService;

            _flags = game.GetGroup(GameMatcher
                .AllOf( GameMatcher.Final));
            _timers = game.GetGroup(GameMatcher.TimePassed);
            _points = game.GetGroup(GameMatcher.PointsGameOver);
            
        }

        public void Execute()
        {
            foreach (GameEntity flag in _flags.GetEntities(_buffer))
            {
                _timePassed += _timeService.DeltaTime;
                if (_timePassed >= _timeToOpenWindows)
                {
                    _windowService.Open(WindowsId.FinalGameOverWindow);
                    flag.isFinal = false;
                }
                
            }

            foreach (GameEntity point in _points)
            foreach (GameEntity time in _timers)
            {
                point.PointsGameOver.CounterGameOverPoints(time.TimePassed);
            }
        }
    }
}