using UnityEngine;

namespace Damage_System
{
    public class DamagableParticleCollision : DamageGiver
    {
        public int DamageToTake;

        void OnParticleCollision(GameObject other)
        {
            DamageObject(other.gameObject);
        }
    }
}