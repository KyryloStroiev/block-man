using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class BlockFollowsCrosshairSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _crosshair;

        public BlockFollowsCrosshairSystem(GameContext game)
        {
            _game = game;
            _crosshair = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Targets, 
                    GameMatcher.Crosshair,
                    GameMatcher.Shoot));
        }

        public void Execute()
        {
            
            foreach (GameEntity crosshair in _crosshair)
            {
                    if (crosshair.Targets != 0)
                    {
                        GameEntity target = _game.GetEntityWithId(crosshair.Targets);
                        
                        target.ReplaceWorldPosition(crosshair.WorldPosition);
                        
                    }
            }
        }
    }
}