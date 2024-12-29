using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.PhysicsService
{
    public interface IPhysicsService
    {
        int CircleCastEntity(Vector3 position, float circleOffsetY, float circleRadius, int layerMask);

        IEnumerable<GameEntity> CircleCastEntity(Vector3 worldPosition, float circleOffsetX, float scaleHeroX, float radius,
            int layerMask);

        Collider2D CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask);

        Collider2D[] CircleCastAllCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask);
        int CircleCastCube(Vector3 position, float circleOffsetY, float circleRadius, int layerMask, GameObject parent);
        bool RaycastCast(Vector2 position, Vector2 raycastDirection, float raycastDistance, int layerMask);

        int CircleCastEntity(Vector3 position, float circleOffsetY, float circleRadius);
        Collider2D BoxCastCollider(Transform transform, int layerMask);
    }
}