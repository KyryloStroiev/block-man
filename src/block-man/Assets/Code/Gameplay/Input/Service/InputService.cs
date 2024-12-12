using Unity.VisualScripting;

namespace Code.Gameplay.Input.Service
{
    public class InputService : IInputService
    {
        private HeroControler _input;

        private bool _isJumpPressed;
        private bool _isHammerPressed;
        private bool _isShootPressed;
        private bool _isAccelerationPressed;

        public InputService()
        {
            _input = new HeroControler();
            _input?.Enable();

            _input.Hero.Jump.performed +=_=> _isJumpPressed = true;
            _input.Hero.Jump.canceled +=_=> _isJumpPressed = false;
            
            _input.Hero.Hammer.performed +=_=> _isHammerPressed = true;
            _input.Hero.Hammer.canceled +=_=> _isHammerPressed = false;
            
            _input.Hero.Shoot.performed +=_=> _isShootPressed = true;
            _input.Hero.Shoot.canceled +=_=> _isShootPressed = false;
            
            _input.Hero.Acceleration.performed +=_=> _isAccelerationPressed = true;
            _input.Hero.Acceleration.canceled +=_=> _isAccelerationPressed = false;
        }
        

        public bool HasAxisInput() => GetHorizontalAxis() != 0;

        public float GetHorizontalAxis() => 
            _input.Hero.HorizontalMove.ReadValue<float>();

        public bool GetButtonJump() => _isJumpPressed;
        public bool GetButtonShoot() => _isShootPressed;
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