using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Service;
using Entitas;

namespace Code.Gameplay.GameOvers.Systems
{
    public class GameOverSystem : IExecuteSystem
    {
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _hero;

        public GameOverSystem(GameContext game, IWindowService windowService)
        {
            _windowService = windowService;
            _hero = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.GameOver));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _hero)
            {
                hero.isDestructed = true;
                _windowService.Open(WindowsId.GameOverWindow);
            }
        }
    }
}