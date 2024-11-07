using Code.Gameplay.Features.Crosshair.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Crosshair
{
    public sealed class CrosshairFeature : Feature
    {
        public CrosshairFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateCrosshairPositionSystem>());
            Add(systems.Create<BlockFollowsCrosshairSystem>());
            Add(systems.Create<RotationBlockSystem>());
        }
    }
}