using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public interface IInputService
    {
        bool HasAxisInput();
        float GetHorizontalAxis();
        bool GetButtonJump();
        void Cleanup();
        bool GetButtonHammerAttack();
        bool GetButtonShoot();
        bool GetButtonAcceleration();
        Vector2 JoystickAxis();
        void Test();
    }
}