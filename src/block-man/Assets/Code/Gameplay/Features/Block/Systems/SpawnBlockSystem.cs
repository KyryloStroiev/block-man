using System.Collections.Generic;
using Code.Gameplay.Features.Block.Factory;
using Entitas;

namespace Code.Gameplay.Features.Block.Systems
{
    public class SpawnBlockSystem : IExecuteSystem
    {
        private readonly IBlockFactory _blockFactory;
        private readonly IGroup<GameEntity> _spawnPoints;
        private readonly IGroup<GameEntity> _timers;
        private List<GameEntity> _buffer = new(2);

        public SpawnBlockSystem(GameContext game, IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
            _spawnPoints = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnPoint));
            _timers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnTimer));
        }

        public void Execute()
        {
            foreach (GameEntity spawnPoint in _spawnPoints)
            foreach (GameEntity timer in _timers.GetEntities(_buffer))
            {
                if (timer.isSpawnReady)
                {
                    timer.isSpawnReady = false;
                    _blockFactory.CreateBlock(BlockTypeId.BlockI, spawnPoint.WorldPosition);
                }
            }
        }
    }
}