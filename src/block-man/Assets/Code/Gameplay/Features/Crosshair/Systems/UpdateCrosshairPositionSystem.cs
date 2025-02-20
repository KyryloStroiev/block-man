using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Crosshair.Systems
{
    public class UpdateCrosshairPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _crosshairs;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public UpdateCrosshairPositionSystem(GameContext game, ITimeService timeService, ICameraProvider cameraProvider)
        {
            _timeService = timeService;
            _cameraProvider = cameraProvider;
            _crosshairs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Crosshair,
                    GameMatcher.WorldPosition));
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            _inputs = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AimPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity crosshair in _crosshairs)
            //foreach (GameEntity input in _inputs)
            {
                //crosshair.ReplaceWorldPosition(PositionJoystick(crosshair, hero, input));
                crosshair.ReplaceWorldPosition(PositionTouch(hero, crosshair));
            }
        }

        /*private Vector3 PositionJoystick(GameEntity crosshair, GameEntity hero, GameEntity input)
        {
            if (input.AimPosition.magnitude < 0.01f)  
            {
                return crosshair.WorldPosition;
            }
            
            Vector2 direction = input.AimPosition.normalized;
            float distance = Mathf.Min(input.AimPosition.magnitude, crosshair.MaxDistanceShoot);
            
            Vector2 targetPosition = hero.WorldPosition + (Vector3)(direction * distance);
            float smoothFactor = crosshair.SmoothFactor * _timeService.DeltaTime;
            Debug.Log(crosshair.SmoothFactor);
            return Vector2.Lerp(crosshair.WorldPosition, targetPosition, smoothFactor);
        }*/
        
        
        private Vector3 PositionMouse(GameEntity hero, GameEntity crosshair)
        {
            
            Vector3 cameraPosition = _cameraProvider.MainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
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
        
        private Vector3 PositionTouch(GameEntity hero, GameEntity crosshair)
        {
            
            if (UnityEngine.Input.touchCount == 0)  
            {
                return crosshair.WorldPosition; // Якщо дотиків немає, не змінюємо позицію
            }

            Touch touch = UnityEngine.Input.GetTouch(0);
            Vector3 touchPosition = _cameraProvider.MainCamera.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0; 
            
            
            float distance = Vector3.Distance(hero.WorldPosition, touchPosition);
            if (distance > crosshair.MaxDistanceShoot)
            {
                Vector3 direction = (touchPosition - hero.WorldPosition).normalized;
                return hero.WorldPosition + direction * crosshair.MaxDistanceShoot;
            }
            else
            {
                return touchPosition;
            }
        }
        
    }
}