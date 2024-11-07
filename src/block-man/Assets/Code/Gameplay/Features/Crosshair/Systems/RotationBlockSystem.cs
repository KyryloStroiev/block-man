using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class RotationBlockSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _crosshair;
        private readonly IGroup<GameEntity> _inputs;

        public RotationBlockSystem(GameContext game)
        {
            _game = game;
            
            _crosshair = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetsBuffer, 
                    GameMatcher.Crosshair,
                    GameMatcher.Shoot));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input,
                    GameMatcher.HammerAttackInput));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity crosshair in _crosshair)
            {
                if (crosshair.Targets != 0)
                {
                    GameEntity target = _game.GetEntityWithId(crosshair.Targets);
                    target.Transform.Rotate(0f, 0f, 90f);
                }
            }
        }
    }
}