using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Damage_System
{
    public class PlayerManager : MonoBehaviour
    {
        public List<GameObject> players;
        private List<PlayerController> playerControllers;
        public int maxhealth;
        public GameObject lastAlive;
        void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player").ToList();
            foreach (GameObject player in players)
            {
                Damageable health = player.GetComponent<Damageable>();
                health.maxHealth = maxhealth;
                playerControllers.Add(player.GetComponent<PlayerController>());
                
            }
            

        }

        void Update()
        {
            int enabledPlayers = 0;// when the player runs out of health it will disable itself after dying
            foreach (GameObject player in players)
            {
                if (player.activeSelf)
                {
                    lastAlive = player;
                    enabledPlayers++;
                }
                    
            }

            if (enabledPlayers==1 && lastAlive)
            {
                Debug.Log(lastAlive.name+ ""+ "wins !!");
            }
            
            
        }
    }
}