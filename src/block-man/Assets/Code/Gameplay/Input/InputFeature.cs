using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            
            Add(systems.Create<EmitAxisInputSystem>());
            Add(systems.Create<JumpInputSystem>());
            Add(systems.Create<HammerAttackInputSystem>());
            Add(systems.Create<ShootGunInputSystem>());
        }
    }
}