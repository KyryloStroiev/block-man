using System.Collections.Generic;
using Code.Gameplay.Common.CollisionRegistry;
using UnityEngine;
using UnityEngine.UIElements;

namespace Code.Gameplay.Common.PhysicsService
{
    public class PhysicsService : IPhysicsService
    {
        private static readonly RaycastHit2D[] Hits = new RaycastHit2D[128];
        private static readonly Collider2D[] OverlapHits = new Collider2D[128];
    
        private readonly ICollisionRegistry _collisionRegistry;

        public PhysicsService(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }
        public int CircleCastGround(Vector3 position, float circleOffsetY, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0.0f, circleOffsetY);
            
            return Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask).Length;
            
            
        }

        public Collider2D[] CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(circleOffsetX, 0);

            return Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask);
        }

        public IEnumerable<GameEntity> CircleCast(Vector3 worldPosition, float circleOffsetX, float scaleHeroX, float radius, int layerMask)
        {
            Vector2 positionCircle = (Vector2)worldPosition + new Vector2(circleOffsetX * scaleHeroX, 0.0f);
            
            int hitCount = OverlapCircle(positionCircle, radius, OverlapHits, layerMask);

            DrawDebug(positionCircle, radius, 1f, Color.red);
      
            for (int i = 0; i < hitCount; i++)
            {
                GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
                if (entity == null)
                    continue;

                yield return entity;
            }
        }


        public int OverlapCircle(Vector3 worldPos, float radius, Collider2D[] hits, int layerMask) =>
            Physics2D.OverlapCircleNonAlloc(worldPos, radius, hits, layerMask);

        
        private static void DrawDebug(Vector2 worldPos, float radius, float seconds, Color color)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
        }
    }
    
}