using Entitas;

namespace Code.Gameplay.Features.Block.Systems
{
    public class CheckCubeList : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _block;
      

        public CheckCubeList(GameContext game)
        {
            _block = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Block,
                    GameMatcher.Cube));
        }
        
        public void Execute()
        {
            foreach (GameEntity block in _block)
            {
                block.Cube.RemoveAll(obj => obj == null);
            }
            
            
        }
    }
}