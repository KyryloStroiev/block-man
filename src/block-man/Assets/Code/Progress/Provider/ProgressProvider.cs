using Code.Progress.Data;

namespace Code.Progress.Provider
{
    public class ProgressProvider : IProgressProvider
    {
        public ProgressData ProgressData { get; set; }
        public EntityData EntityData => ProgressData.EntityData;

        public void SetProgressData(ProgressData progressData)
        {
            ProgressData = progressData;
        }
    }
}