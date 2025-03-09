using Code.Gameplay.Sound.Configs;
using UnityEngine;

namespace Code.Gameplay.Sound.Service
{
    public class PlaySoundsService : IPlaySoundsService
    {
        public void PlayOne(AudioClip audioClip, GameEntity entity)
        {
            if (audioClip != null)
            {
              entity.AudioSource.PlayOneShot(audioClip);
            }
        }
    }
}