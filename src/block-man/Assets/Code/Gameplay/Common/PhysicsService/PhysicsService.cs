using System.Collections.Generic;
using Code.Gameplay.Common.CollisionRegistry;
using UnityEngine;

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
        public int CircleCast(Vector3 position, float circleOffsetY, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0.0f, circleOffsetY);
            
            return Physics2D.OverlapCircleAll(playerCenter, circleRadius, layerMask).Length;
            
        }
        
        public bool RaycastCast(Vector2 position, Vector2 raycastDirection, float raycastDistance, int layerMask)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(position, raycastDirection, raycastDistance, layerMask);
            Debug.DrawRay(position, raycastDirection * raycastDistance, Color.red);
            return hit;
        }
        
        public bool RaycastCast(Vector2 position, Vector2 raycastDirection, float circleOffsetY, float raycastDistance, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(0, circleOffsetY);
            RaycastHit2D hit = Physics2D.Raycast(playerCenter, raycastDirection, raycastDistance, layerMask);
            Debug.DrawRay(playerCenter, raycastDirection * raycastDistance, Color.red);
            return hit;
        }
        
        
        public Collider2D CircleCastCollider(Vector3 position, float circleOffsetX, float circleRadius, int layerMask)
        {
            Vector2 playerCenter = (Vector2)position + new Vector2(circleOffsetX, 0);

            return Physics2D.OverlapCircle(playerCenter, circleRadius, layerMask);
        }
        
        public Collider2D BoxCastCollider(Transform transform, int layerMask) => 
            Physics2D.OverlapBox(transform.position, transform.localScale, transform.eulerAngles.z, layerMask);
        
        public int BoxCast(Transform transform, int layerMask) => 
            Physics2D.OverlapBoxAll(transform.position, transform.localScale, transform.eulerAngles.z, layerMask).Length;

        public int BoxCastParents(Transform transform, int layerMask)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, transform.eulerAngles.z, layerMask);
            
            List<Collider2D> filteredColliders = new List<Collider2D>();

            foreach (Collider2D collider in colliders)
            {
                if (collider.transform.parent != transform.parent)
                {
                    filteredColliders.Add(collider);
                }
            }
            
            return filteredColliders.Count;
        }
            

        
        public IEnumerable<GameEntity> CircleCast(Vector3 worldPosition, float circleOffsetX, float scaleHeroX, float radius, int layerMask)
        {
            Vector2 positionCircle = (Vector2)worldPosition + new Vector2(circleOffsetX * scaleHeroX, 0.0f);
            
            int hitCount = OverlapCircle(positionCircle, radius, OverlapHits, layerMask);
            
      
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