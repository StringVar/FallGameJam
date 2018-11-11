using System;
using UnityEngine;
using UnityEngine.Events;

namespace Damage_System
{
    
    //gives damage
    public class DamageGiver : MonoBehaviour
    {
        [Serializable]
        public class DamagableEvent : UnityEvent<DamageGiver, Damageable>
        {
        }

        [Serializable]
        public class NonDamagableEvent : UnityEvent<DamageGiver>
        {
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

        public int damage = 1;
        public bool canDamage = true;
        public bool disableAfterHit = false;
        [Tooltip("After a succesfull hit this object is destroyed")]
        public bool destoyAfterHit;
        public DamagableEvent OnDamageableHit;
        public NonDamagableEvent OnNonDamageableHit;


        public virtual void EnableDamage()
        {
            canDamage = true;
        }

        public virtual void DisableDamage()
        {
            canDamage = false;
        }

        public virtual void DamageObject(GameObject obj)
        {
            if (!canDamage)
                return;

            Damageable damageable = obj.GetComponent<Damageable>();
            if (damageable)
            {
                OnDamageableHit.Invoke(this, damageable);
                damageable.TakeDamage(this);
                if (disableAfterHit)
                    DisableDamage();
                if (destoyAfterHit)
                    Destroy(this);
            }
            else
            {
                OnNonDamageableHit.Invoke(this);
            }
        }
    }
}