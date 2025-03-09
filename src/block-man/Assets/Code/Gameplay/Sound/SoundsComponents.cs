using Entitas;
using UnityEngine;

namespace Code.Gameplay.Sound
{ 
    [Game] public class AudioSourceComponent: IComponent {public AudioSource Value; }
   
    [Game] public class SoundPlayer: IComponent { }
}