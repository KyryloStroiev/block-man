using Code.Common.Destruct.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.Destruct
{
    public sealed class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systems)
        {
            Add(systems.Create<SelfDestructTimerSystem>());
            
            Add(systems.Create<CleanupGameDestructViewSystem>());
            Add(systems.Create<CleanupGameDestructSystem>());
            
        }
    }
}