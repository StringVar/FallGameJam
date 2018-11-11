using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlot : MonoBehaviour {
    private GameObject[] powerUps;
    private int powerUpChoice;

    private void Start() {
        powerUps = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            powerUps[i] = transform.GetChild(i).gameObject;
        }
    }

    public void PlacePowerUp() {
        powerUpChoice = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[powerUpChoice]);
    }
}
