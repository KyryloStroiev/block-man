using Code.Gameplay.Cameras.Provider;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class UpdateCrosshairPositionSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _crosshairs;
        private readonly IGroup<GameEntity> _heroes;

        public UpdateCrosshairPositionSystem(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair,
                    GameMatcher.WorldPosition));
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity crosshair in _crosshairs)
            {
                crosshair.ReplaceWorldPosition(PositionMouse(hero, crosshair.MaxDistanceShoot));
            }
        }

        private Vector3 PositionMouse(GameEntity entity, float maxShootDistance)
        {
            
            Vector3 cameraPosition = _cameraProvider.MainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            cameraPosition.z = 0;
            
            float distance = Vector3.Distance(entity.WorldPosition, cameraPosition);
            if (distance > maxShootDistance)
            {
                Vector3 direction = (cameraPosition - entity.WorldPosition).normalized;
                return entity.WorldPosition + direction * maxShootDistance;
            }
            else
            {
                return cameraPosition;
            }
        }
    }
}