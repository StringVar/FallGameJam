using UnityEngine;

namespace Damage_System
{
    public class GiveDamageOnCollision2D : DamageGiver
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            DamageObject(col.gameObject);
        }
    }
}