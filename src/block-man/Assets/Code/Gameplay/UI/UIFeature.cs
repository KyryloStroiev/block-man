using Code.Gameplay.GameOvers.Systems;
using Code.Gameplay.UI.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.UI
{
    public sealed class UIFeature : Feature
    {
        public UIFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeUIComponentSystem>());
            
            Add(systems.Create<PointHeightCountingSystem>());
            Add(systems.Create<TimePassedSystem>());
            
            
        }
    }
}