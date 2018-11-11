using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int totalActivePowerUps;
    public GameObject powerUpSlotsContainerBG1;
    public GameObject powerUpSlotsContainerBG2;
    public GameObject powerUpSlotsContainerBG3;
    private GameObject[] powerUpSlotsBG1;
    private GameObject[] powerUpSlotsBG2;
    private GameObject[] powerUpSlotsBG3;
    private PowerUpSlot slotScript;

    // Use this for initialization
    void Start () {
        powerUpSlotsBG1 = new GameObject[powerUpSlotsContainerBG1.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG1.transform.childCount; i++) {
            powerUpSlotsBG1[i] = powerUpSlotsContainerBG1.transform.GetChild(i).gameObject;
        }

        powerUpSlotsBG2 = new GameObject[powerUpSlotsContainerBG1.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG1.transform.childCount; i++) {
            powerUpSlotsBG2[i] = powerUpSlotsContainerBG1.transform.GetChild(i).gameObject;
        }

        powerUpSlotsBG3 = new GameObject[powerUpSlotsContainerBG1.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG1.transform.childCount; i++) {
            powerUpSlotsBG3[i] = powerUpSlotsContainerBG1.transform.GetChild(i).gameObject;
        }

        slotScript = GetComponent<PowerUpSlot>();
    }
	
	// Update is called once per frame
	void Update () {
        if (totalActivePowerUps < 2) {
            slotScript.PlacePowerUp();
        }
    }

    private IEnumerator PowerUpSpawnTimer() {
        int spawnTimer = Random.Range(10, 20);
        yield return new WaitForSeconds(spawnTimer);
        slotScript.PlacePowerUp();
    }
}
