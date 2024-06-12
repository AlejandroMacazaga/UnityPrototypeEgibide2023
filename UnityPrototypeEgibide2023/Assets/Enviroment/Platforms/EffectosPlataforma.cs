using Entities;
using UnityEngine;

namespace Enviroment.Platforms
{
    public class EffectosPlataforma : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particulas;
    

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent<EntityControler>(out var _)) return;
            particulas.Play();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent<EntityControler>(out var _)) return;
            if (!other.gameObject.TryGetComponent<Rigidbody2D>(out var rb)) return;
            if (rb.velocity.y < 0)
            {
                particulas.Play();
            }
        }
        
    }
}
