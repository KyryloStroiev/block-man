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
        public float CircleOffsetYGround = -0.29f;
        
        private void OnDrawGizmos()
        {
            Vector3 playerCenter = transform.position + new Vector3(0.0f, CircleOffsetYGround, 0.0f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(playerCenter, CircleGroundRadius);
        }
        
    }
}