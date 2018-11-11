using System;
using UnityEngine;
using UnityEngine.Events;

/* Health component 
 * Usage: place on any components that can take damage required 
 */
namespace Damage_System
{
    public class Damageable : MonoBehaviour
    {
        [Serializable]
        public class HealthEvent : UnityEvent<Damageable>
        {
        }

        [Serializable]
        public class GivenDamageEvent : UnityEvent<DamageGiver, Damageable>
        {
        }
        public class TakeDamageEvent : UnityEvent<DamageTaker, Damageable>
        {
        }
        public class DamageEvent : UnityEvent<Damageable>
        {
        }
        public void DestroySelfOnHit(DamageGiver damage, Damageable health)
        {
            Destroy(health.gameObject);
        }

        public static void LogDamageEvent(DamageGiver damage, Damageable health)
        {
            Debug.Log("Damage Given:" + health.gameObject.name +
                      " takes " + damage.damage +
                      " from " + damage.gameObject);
        }
        public static void LogDamageEvent(DamageTaker damage, Damageable health)
        {
            Debug.Log("Damage Taken:" + health.gameObject.name +
                      " takes " + damage.damage +
                      " from " + damage.gameObject);
        }

        [Serializable]
        public class HealEvent : UnityEvent<int, Damageable>
        {
        }

        public int maxHealth = 5;
        int currentHealth = 5;
        public bool invulnrable = false;
        public bool debugLog;

        [Header("Events")] public HealthEvent onHealthSet;
        public HealEvent onGainHealth;
        public GivenDamageEvent onGivenDamage;
        public TakeDamageEvent onTakeDamage;
        public DamageEvent onDie;

        public int CurrentHealth()
        {
            return currentHealth;
        }

        public void Start()
        {
            if (debugLog)
            {
                onTakeDamage.AddListener(LogDamageEvent);
            }
        }

        void OnEnable()
        {
            resetHealth();
            onHealthSet.Invoke(this);
            DisableInvulnerability();
        }

        public void EnableInvulnerability()
        {
            invulnrable = true;
        }

        public void DisableInvulnerability()
        {
            invulnrable = false;
        }

        public void TakeDamage(DamageGiver damageGiver)
        {
            if ((invulnrable) || currentHealth <= 0)
                return;

            if (!invulnrable)
            {
                currentHealth -= damageGiver.damage;
                onHealthSet.Invoke(this);
            }

            onGivenDamage.Invoke(damageGiver, this);

            if (currentHealth <= 0)
            {
                onDie.Invoke(this);
            }
        }
        public void TakeDamage(DamageTaker damagerTaker)
        {
            if ((invulnrable) || currentHealth <= 0)
                return;

            if (!invulnrable)
            {
                currentHealth -= damagerTaker.damage;
                onHealthSet.Invoke(this);
            }

            onTakeDamage.Invoke(damagerTaker, this);

            if (currentHealth <= 0)
            {
                onDie.Invoke(this);
            }
        }

        public void GainHealth(int amount)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }


            onHealthSet.Invoke(this);
            onGainHealth.Invoke(amount, this);
        }

        public void SetHealth(int amount)
        {
            currentHealth = amount; //NOTE setHealth can go over max

            onHealthSet.Invoke(this);
        }

        public void resetHealth()
        {
            currentHealth = maxHealth;
        }
    }
}