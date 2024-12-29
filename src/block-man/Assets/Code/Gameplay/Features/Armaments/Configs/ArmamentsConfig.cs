using System.Collections.Generic;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Configs
{
    [CreateAssetMenu(fileName = "armamentsConfig", menuName = "Config/Armaments/armamentsConfig")]
    public class ArmamentsConfig : ScriptableObject
    {
        public float Speed = 1;
        public float RotationSpeed = 100;
        public float SpawnTimerInterval = 30;

         public List<ArmamentsSpawnerData> GunSpawners;

        public EntityBehaviour cubePrefab;

        
    }
}