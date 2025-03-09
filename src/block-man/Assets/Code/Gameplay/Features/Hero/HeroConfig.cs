using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    [CreateAssetMenu(fileName = "heroConfig", menuName = "Configs/hero")]
    public class HeroConfig : ScriptableObject
    {
        public float Speed = 4;
        public float JumpHeight = 3;
        
        public float MaxDistanceShoot = 10;
        
        public float CircleTargetsRadius = 0.2f;
        public float CircleOffsetXTarget= 0.6f;

        public float CircleGroundRadius = 0.2f;
        public float CircleOffsetYGround = -0.29f;

        public float CameraOffsetY = 5f;

        public EntityBehaviour HeroPrefab;
        public EntityBehaviour CrosshairPrefab;
    }
}