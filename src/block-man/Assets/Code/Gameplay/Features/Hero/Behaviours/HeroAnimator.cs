using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HeroAnimator: MonoBehaviour
    {
        public Animator Animator;
        public SpriteRenderer SpriteRenderer;
        
        private readonly int _isMovingHash = Animator.StringToHash("isMoving");
        private readonly int _isAttackHammer = Animator.StringToHash("Hammer");

        public void PlayMove() => Animator.SetBool(_isMovingHash, true);

        public void PlayIdle() => Animator.SetBool(_isMovingHash, false);

        public void PlayAttackHammer() => Animator.SetTrigger(_isAttackHammer);
    }
}