using UnityEngine;

namespace Damage_System
{
    public class DamageCollider : DamageGiver
    {
        private void OnCollisionEnter(Collision other)
        {
            DamageObject(other.gameObject);
        }
    }
}