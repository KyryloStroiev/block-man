using Code.Gameplay.UI.Systems;
using Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.UI
{
    public sealed class UIFeature : Feature
    {
        public UIFeature(ISystemFactory systems)
        {
            Add(systems.Create<PointHeightCountingSystem>());
            Add(systems.Create<PointDestructCubeCountingSystem>());
        }
    }
}