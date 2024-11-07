using UnityEngine;

namespace Code.Common.Extensions
{
    public static class TransformExtensions
    {
        public static void SetScaleX(this Transform t, float scale) =>
            t.localScale = new Vector3(scale, t.localScale.y, t.localScale.z);
    }
}