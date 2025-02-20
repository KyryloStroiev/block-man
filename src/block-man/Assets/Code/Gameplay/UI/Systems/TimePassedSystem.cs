using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.UI.Systems
{
    public class TimePassedSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _points;
        private readonly IGroup<GameEntity> _gameTimers;

        public TimePassedSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _gameTimers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GameTimer));
            _points = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.PointsCounter));
        }

        public void Execute()
        {
            foreach (GameEntity point in _points)
            foreach (GameEntity gameTimer in _gameTimers)
            {
                gameTimer.ReplaceTimePassed(gameTimer.TimePassed + _timeService.DeltaTime);
                point.PointsCounter.SetTime(gameTimer.TimePassed);
            }
        }
    }
}