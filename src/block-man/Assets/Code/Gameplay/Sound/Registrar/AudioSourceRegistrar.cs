using Code.Infrastructure.View.Registrar;
using UnityEngine;

namespace Code.Gameplay.Sound.Registrar
{
    public class AudioSourceRegistrar: EntityComponentRegistrar
    {
        public AudioSource AudioSource;
        public override void RegisterComponents()
        {
            Entity.AddAudioSource(AudioSource);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasAudioSource)
                Entity.RemoveAudioSource();
        }
    }
}