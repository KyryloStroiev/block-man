using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Behaviours
{
    public class VisualDebuger : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z), Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, transform.localScale);
        }
    }
}