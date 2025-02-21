using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class UpdateCrosshairPositionSystem : IExecuteSystem
    {
     
        private readonly IInputService _inputService;
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
                crosshair.ReplaceWorldPosition(PositionMouse(hero, crosshair));
            }
        }

        
        private Vector3 PositionMouse(GameEntity hero, GameEntity crosshair)
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            
            Vector3 cameraPosition =
                _cameraProvider.MainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0));
            cameraPosition.z = 0;
            
            float distance = Vector3.Distance(hero.WorldPosition, cameraPosition);
            if (distance > crosshair.MaxDistanceShoot)
            {
                Vector3 direction = (cameraPosition - hero.WorldPosition).normalized;
                return hero.WorldPosition + direction * crosshair.MaxDistanceShoot;
            }
            else
            {
                return cameraPosition;
            }
        }
        
        
    }
}