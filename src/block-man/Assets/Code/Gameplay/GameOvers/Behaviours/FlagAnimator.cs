using UnityEngine;

namespace Code.Gameplay.GameOvers.Behaviours
{
    public class FlagAnimator : MonoBehaviour
    {
        public Animator Animator;
        
        private readonly int _gameOverAnimationHash = Animator.StringToHash("GameOver");
        
        public void PlayGameOverAnimation() => Animator.SetTrigger(_gameOverAnimationHash);
    }
}