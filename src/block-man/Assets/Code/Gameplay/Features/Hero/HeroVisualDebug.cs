using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrar;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Hero.Registrar
{
    public class HeroVisualDebug : MonoBehaviour
    {
        public float CircleGroundRadius = 0.2f;
        public float CircleTargetsRadius = 0.2f;
        public float CircleOffsetYGround = -0.29f;
        public float Speed = 4;
        public float JumpHeight = 4;
        
     
        
        private void OnDrawGizmos()
        {
            Vector3 playerCenter = transform.position + new Vector3(0.0f, -0.29f, 0.0f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(playerCenter, CircleGroundRadius);
        }
        
    }
}