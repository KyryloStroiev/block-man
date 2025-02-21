using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HeroAnimator: MonoBehaviour
    {
        public Animator Animator;
        public SpriteRenderer SpriteRenderer;
        
        private readonly int _isMovingHash = Animator.StringToHash("isMoving");
        private readonly int _isAttackHammer = Animator.StringToHash("Hammer");
        private readonly int _isJumpHash = Animator.StringToHash("Jump");
        private readonly int _isTouchDown = Animator.StringToHash("isGround");
        private readonly int _isShootingHash = Animator.StringToHash("isShooting");
        private readonly int _shotAngle = Animator.StringToHash("Shot");

        public void PlayMove() => Animator.SetBool(_isMovingHash, true);

        public void PlayIdle() => Animator.SetBool(_isMovingHash, false);
        
        public void PlayTouchDown(bool isGround) => Animator.SetBool(_isTouchDown, isGround);
        public void PlayShooting(bool isShot) => Animator.SetBool(_isShootingHash, isShot);
        public void PlayShot(float angle) => Animator.SetFloat(_shotAngle, angle);

        public void PlayAttackHammer() => Animator.SetTrigger(_isAttackHammer);
        public void PlayJump() => Animator.SetTrigger(_isJumpHash);
    }
}