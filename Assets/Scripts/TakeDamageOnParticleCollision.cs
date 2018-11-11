using UnityEngine;

namespace Damage_System
{
    public class TakeDamageOnParticleCollision : DamageTaker
    {
        private void OnParticleCollision(GameObject other)
        {
            TakeDamage();
        }
    }
}