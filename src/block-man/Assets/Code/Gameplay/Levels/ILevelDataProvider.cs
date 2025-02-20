using UnityEngine;

namespace Code.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        Vector3 StartPoint { get; }
        Vector3 FlagPoint { get; set; }
        void SetStartPoint(Vector3 startPoint, Vector3 flagPoint);
    }
}