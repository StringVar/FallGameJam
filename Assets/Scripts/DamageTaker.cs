using System;
using UnityEngine;
using UnityEngine.Events;

namespace Damage_System
{
    public class DamageTaker : MonoBehaviour
    {
        public int damage;// the damage taken every time the Event takeDamage
        public Damageable obj;// the obj that will take damage on DamageTaker event
        
        public bool canDamage = true;
        public bool disableAfterHit = false;
        public DamagableEvent OnDamageableHit;
        public NonDamagableEvent OnNonDamageableHit;
        
        [Serializable]
        public class DamagableEvent : UnityEvent<DamageTaker, Damageable>
        {
            
        }
        [Serializable]
        public class NonDamagableEvent : UnityEvent<DamageTaker>
        {
            
        }
        
        
        
        public virtual void EnableDamage()
        {
            canDamage = true;
        }

        public virtual void DisableDamage()
        {
            canDamage = false;
        }

        public virtual void TakeDamage()
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

            }
            else
            {
                OnNonDamageableHit.Invoke(this);
            }
        }
        
        
        
    }
}