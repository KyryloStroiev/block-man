using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Service;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Gameplay.Input.Service
{
    public class InputService : IInputService
    {
        private readonly IWindowService _windowService;
        private HeroControler _input;

        private bool _isJumpPressed;
        private bool _isHammerPressed;
        private bool _isShootPressed;
        private bool _isAccelerationPressed;
        
        private Vector2 _joystickAxis;

        public InputService()
        {
            _input = new HeroControler();
            _input?.Enable();

            _input.Hero.Jump.performed +=_=> _isJumpPressed = true;
            _input.Hero.Jump.canceled +=_=> _isJumpPressed = false;
            
            _input.Hero.Hammer.performed +=_=> _isHammerPressed = true;
            _input.Hero.Hammer.canceled +=_=> _isHammerPressed = false;
            
            _input.Hero.Acceleration.performed +=_=> _isAccelerationPressed = true;
            _input.Hero.Acceleration.canceled +=_=> _isAccelerationPressed = false;
            
            
            
            /*_input.Hero.Shoot.performed +=_=> _isShootPressed = true;
            _input.Hero.Shoot.canceled +=_=> _isShootPressed = false;*/
        }
        

        public bool HasAxisInput() => GetHorizontalAxis() != 0;

        public Vector2 JoystickAxis() => 
            _input.Hero.Aim.ReadValue<Vector2>();

        public void Test()
        {
        
        }
        public float GetHorizontalAxis() => 
            _input.Hero.HorizontalMove.ReadValue<float>();

        public bool GetButtonJump() => _isJumpPressed;
        public bool GetButtonShoot() => _input.Hero.Aim.IsPressed();
        public bool GetButtonAcceleration() => _isAccelerationPressed;

        public bool GetButtonHammerAttack() => 
            PressOnceButton();

        private bool PressOnceButton()
        {
           
            if (_isHammerPressed)
            {
                _isHammerPressed = false;
                return true;
            }

            return false;
        }

        public void Cleanup()
        {   
        }
    }
}