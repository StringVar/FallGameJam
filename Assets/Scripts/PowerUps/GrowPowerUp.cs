using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPowerUp : MonoBehaviour {
    [SerializeField] private float activeTime;

    public void Effect() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Effect();
        }
    }

    private IEnumerator PowerUpLength(float powerUpTime) {
        yield return new WaitForSeconds(powerUpTime);
    }
}
