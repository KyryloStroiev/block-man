using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.PhysicsService
{
    public interface IPhysicsService
    {
        int CircleCast(Vector3 position, float circleOffsetY, float circleRadius, int layerMask);

        IEnumerable<GameEntity> CircleCast(Vector3 worldPosition, float circleOffsetX, float scaleHeroX, float radius,
            int layerMask);

        Collider2D CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask);
        
        bool RaycastCast(Vector2 position, Vector2 raycastDirection, float raycastDistance, int layerMask);
        
        Collider2D BoxCastCollider(Transform transform, int layerMask);
        int BoxCast(Transform transform, int layerMask);
        int BoxCastParents(Transform transform, int layerMask);

        bool RaycastCast(Vector2 position, Vector2 raycastDirection, float circleOffsetY, float raycastDistance, int layerMask);
    }
}