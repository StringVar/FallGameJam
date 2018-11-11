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

    // Use this for initialization
    void Start () {
        powerUpSlotsBG1 = new GameObject[powerUpSlotsContainerBG1.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG1.transform.childCount; i++) {
            powerUpSlotsBG1[i] = powerUpSlotsContainerBG1.transform.GetChild(i).gameObject;
        }

        powerUpSlotsBG2 = new GameObject[powerUpSlotsContainerBG2.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG2.transform.childCount; i++) {
            powerUpSlotsBG2[i] = powerUpSlotsContainerBG2.transform.GetChild(i).gameObject;
        }

        powerUpSlotsBG3 = new GameObject[powerUpSlotsContainerBG3.transform.childCount];
        for (int i = 0; i < powerUpSlotsContainerBG3.transform.childCount; i++) {
            powerUpSlotsBG3[i] = powerUpSlotsContainerBG3.transform.GetChild(i).gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (totalActivePowerUps < 2) {
            int slotChoiceBG1 = Random.Range(0, powerUpSlotsBG1.Length);
            int slotChoiceBG2 = Random.Range(0, powerUpSlotsBG2.Length);
            int slotChoiceBG3 = Random.Range(0, powerUpSlotsBG3.Length);

            powerUpSlotsBG1[slotChoiceBG1].GetComponent<PowerUpSlot>().PlacePowerUp();
            powerUpSlotsBG2[slotChoiceBG2].GetComponent<PowerUpSlot>().PlacePowerUp();
            powerUpSlotsBG3[slotChoiceBG3].GetComponent<PowerUpSlot>().PlacePowerUp();

            totalActivePowerUps += 3;
        }
    }
    /*
    private IEnumerator PowerUpSpawnTimer() {
        int spawnTimer = Random.Range(10, 20);
        yield return new WaitForSeconds(spawnTimer);
        slotScript.PlacePowerUp();
    }
    */
}
