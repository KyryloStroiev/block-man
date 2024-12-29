using System;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Configs
{
    [Serializable]
    public class ArmamentsSpawnerData
    {
        public ArmamentsTypeId TypeId;
        public Vector3 Position;
        public bool IsLookRight;

        public ArmamentsSpawnerData(ArmamentsTypeId typeId, Vector3 position, bool isLookRight)
        {
            TypeId = typeId;
            Position = position;
            IsLookRight = isLookRight;
        }
    }
}