using UnityEngine;

namespace Code.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Vector3 StartPoint { get; private set; }
        public Vector3 FlagPoint { get; set; }

        public void SetStartPoint(Vector3 startPoint, Vector3 flagPoint)
        {
            StartPoint = startPoint;
            FlagPoint = flagPoint;
        }
    }
}