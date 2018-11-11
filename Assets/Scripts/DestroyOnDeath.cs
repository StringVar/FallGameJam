using UnityEngine;

namespace Damage_System
{
    public class DestroyOnDeath : MonoBehaviour
    {
        private void Start()
        {
            var damageable = GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.onDie.AddListener(OnDie);
            }
        }

        private void OnDie(Damageable damageable)
        {
            Destroy(gameObject);
        }
    }
}