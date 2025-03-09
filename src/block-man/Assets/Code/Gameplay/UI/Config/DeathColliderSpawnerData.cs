using System;
using UnityEngine;

namespace Code.Gameplay.UI.Config
{
    [Serializable]
    public class DeathColliderSpawnerData
    {
        public readonly Vector3 Position;

        public DeathColliderSpawnerData(Vector3 position)
        {
            Position = position;
        }
    }
}