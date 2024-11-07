using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _targets;

        public CleanupTargetBuffersSystem(GameContext game)
        {
            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetsBuffer));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _targets)
            {
                entity.TargetsBuffer.Clear();
            }
        }
    }
}