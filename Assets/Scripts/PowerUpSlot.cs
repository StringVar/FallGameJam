using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlot : MonoBehaviour {
    public GameObject powerUpTypeContainers;
    private GameObject[] powerUps;
    private int powerUpChoice;

    private void Start() {
        powerUps = new GameObject[powerUpTypeContainers.transform.childCount];
        for (int i = 0; i < powerUpTypeContainers.transform.childCount; i++) {
            powerUps[i] = powerUpTypeContainers.transform.GetChild(i).gameObject;
        }
    }

    public void PlacePowerUp() {
        Debug.Log("Placing a Power Up in slot");
        powerUpChoice = Random.Range(0, powerUps.Length);
        GameObject powerup = Instantiate(powerUps[powerUpChoice], this.transform, false) as GameObject;


    }
}
