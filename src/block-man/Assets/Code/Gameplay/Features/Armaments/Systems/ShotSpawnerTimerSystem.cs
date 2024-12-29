using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class ShotSpawnerTimerSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _timer;

        public ShotSpawnerTimerSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _timer = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnShotTimer,
                    GameMatcher.SpawnShotTimerInterval));
        }

        public void Execute()
        {
            foreach (GameEntity timer in _timer)
            {
                timer.ReplaceSpawnShotTimer(timer.SpawnShotTimer - _time.DeltaTime);

                if (timer.SpawnShotTimer <= 0)
                {
                    timer.ReplaceSpawnShotTimer(timer.SpawnShotTimerInterval);
                    timer.isShotReady = true;       
                }
            }
        }
    }
}