using System;
using Code.Common.Entity;
using Code.Gameplay.Common.PhysicsService;
using UnityEngine;
using Zenject;

namespace Code.Test
{
    public class TestCreateEntity : MonoBehaviour
    {
        public float circleOffsetY;
        public float circleRadius;
        private IPhysicsService _physicsService;
        public LayerMask layerMask;

        [Inject]
        private void Construct(IPhysicsService physicsService)
        {
            _physicsService = physicsService;
        }
        
    }
}