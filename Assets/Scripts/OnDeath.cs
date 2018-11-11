using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Damage_System
{
    public class OnDeath : MonoBehaviour
    {
        public bool destroy;//destroys the gameobject
        public bool Disable;//disables on death
        
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
            if (Disable)
            {
                gameObject.SetActive(false);
            }

            if(destroy){Destroy(gameObject);}
            
        }
    }
}