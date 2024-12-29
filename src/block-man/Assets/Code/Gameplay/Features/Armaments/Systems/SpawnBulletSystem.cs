using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class SpawnBulletSystem : IExecuteSystem
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IGroup<GameEntity> _guns;
        private readonly IGroup<GameEntity> _timer;
        private List<GameEntity> _buffer = new(16);

        public SpawnBulletSystem(GameContext game, IArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
            _guns = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GunCube,
                    GameMatcher.WorldPosition,
                    GameMatcher.DirectionShot));
            _timer = game.GetGroup(GameMatcher.SpawnShotTimer);
        }

        public void Execute()
        {
            
            foreach (GameEntity timer in _timer.GetEntities(_buffer))
            {
                if (timer.isShotReady)
                {
                    SpawnBulletsFromAllGuns();
                    timer.isShotReady = false;
                }
            }
        }

        private void SpawnBulletsFromAllGuns()
        {
            foreach (GameEntity gun in _guns)
            {
                _armamentsFactory.CreateBulletCube(gun.WorldPosition, gun.DirectionShot);
            }
        }
    }
}