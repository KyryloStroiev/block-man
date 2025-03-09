using Code.Progress.Data;

namespace Code.Progress.Provider
{
    public interface IProgressProvider
    {
        ProgressData ProgressData { get; set; }
        EntityData EntityData { get; }
        void SetProgressData(ProgressData progressData);
    }
}