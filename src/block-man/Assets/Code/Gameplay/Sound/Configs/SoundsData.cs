using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Sound.Configs
{
    [CreateAssetMenu(fileName = "Sounds", menuName = "Data/sound")]
    public class SoundsData : SerializedScriptableObject
    {
        public AudioClip HummerSound;
        public AudioClip ShotSound;
        public AudioClip JumpSound;
        public AudioClip LiftOfSound;
    }
}