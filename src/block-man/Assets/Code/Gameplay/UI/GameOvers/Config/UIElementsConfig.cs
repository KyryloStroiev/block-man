using Code.Infrastructure.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.UI.GameOvers.Config
{
    [CreateAssetMenu(fileName = "flagGameOver", menuName = "Configs/flag")]
    public class UIElementsConfig : ScriptableObject
    {
        public EntityBehaviour FlagPrefab;
        public EntityBehaviour GameplayHUD;
        public EntityBehaviour HomeHUD;
    }
}