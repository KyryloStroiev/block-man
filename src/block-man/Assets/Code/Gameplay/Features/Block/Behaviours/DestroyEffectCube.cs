using UnityEngine;

namespace Code.Gameplay.Features.Block.Behaviours
{
    public class DestroyEffectCube : MonoBehaviour
    {
        public ParticleSystem particlePrefab;
        private void OnDestroy()
        {
            if (!gameObject.scene.isLoaded) return;
            
            ParticleSystem effect = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 2); 
        }
    }
}