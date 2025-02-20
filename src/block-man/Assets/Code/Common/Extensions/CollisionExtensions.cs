using UnityEngine;

namespace Code.Common.Extensions
{
    public static class CollisionExtensions
    {
        public static bool Matches(this Collider2D collider, LayerMask layerMask) =>
            ((1 << collider.gameObject.layer) & layerMask) != 0;
        
        public static int AsMask(this CollisionLayer layer) =>
            1 << (int)layer;
    }

    public enum CollisionLayer
    {
        Ground = 6,
        CubeOnGround = 7,
        Cube = 8,
        Block = 9,
        Hero = 12,
    }
}