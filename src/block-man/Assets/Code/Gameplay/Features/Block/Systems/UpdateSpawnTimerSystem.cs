using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Block.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Block.Systems
{
    public class UpdateSpawnTimerSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _timers;

        public UpdateSpawnTimerSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _timers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnTimer,
                    GameMatcher.SpawnTimerInterval));
        }

        public void Execute()
        {
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _time.DeltaTime);

                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(timer.SpawnTimerInterval);
                    timer.isSpawnReady = true;       
                }
            }
        }
    }
}