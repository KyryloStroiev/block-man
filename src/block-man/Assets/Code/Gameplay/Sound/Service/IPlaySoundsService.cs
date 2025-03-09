using UnityEngine;

namespace Code.Gameplay.Sound.Service
{
    public interface IPlaySoundsService
    {
        void PlayOne(AudioClip audioClip, GameEntity entity);
    }
}