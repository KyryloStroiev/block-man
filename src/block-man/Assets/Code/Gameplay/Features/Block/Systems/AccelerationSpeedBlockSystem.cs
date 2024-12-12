using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Block.Systems
{
    public class AccelerationSpeedBlockSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IStaticDataService _staticData;
        private readonly IGroup<GameEntity> _blocks;
        private readonly IGroup<GameEntity> _inputs;

        public AccelerationSpeedBlockSystem(GameContext game, ITimeService time, IStaticDataService staticData)
        {
            _time = time;
            _staticData = staticData;
            _blocks = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.VerticalDirection,
                    GameMatcher.Block,
                    GameMatcher.Moving));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (GameEntity block in _blocks)
            foreach (GameEntity input in _inputs)
            {
                if (input.isAccelerationInput)
                {
                    block.ReplaceSpeed(_staticData.GetBlockConfig().AccelerationSpeed);
                }
                else
                {
                    block.ReplaceSpeed(_staticData.GetBlockConfig().Speed);
                }
             
            }
        }
    }
}