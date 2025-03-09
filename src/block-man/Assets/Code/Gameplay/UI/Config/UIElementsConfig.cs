using System.Collections.Generic;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.UI.Config
{
    [CreateAssetMenu(fileName = "flagGameOver", menuName = "Configs/flag")]
    public class UIElementsConfig : ScriptableObject
    {
        public EntityBehaviour FlagPrefab;
        public EntityBehaviour GameplayHUD;
        public EntityBehaviour HomeHUD;

        public EntityBehaviour DeathCollider;
        public List<DeathColliderSpawnerData> DeathColliderSpawners;
    }
}