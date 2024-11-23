using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.PhysicsService
{
    public interface IPhysicsService
    {
        int CircleCastGround(Vector3 position, float circleOffsetY, float circleRadius, int layerMask);

        IEnumerable<GameEntity> CircleCast(Vector3 worldPosition, float circleOffsetX, float scaleHeroX, float radius,
            int layerMask);

        Collider2D[] CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask);
        int CircleCastCube(Vector3 position, float circleOffsetY, float circleRadius, int layerMask, GameObject parent);
    }
}