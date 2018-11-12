using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class TimePowerUp : MonoBehaviour, IPowerup {
    [SerializeField] private float activeTime;

    private Background_Pathing pathing;
    private float defaultSpeed = 200f;

    private void Start() {
        pathing = GetComponent<Background_Pathing>();
    }

    public void Effect() {
        int speed = Random.Range(1, 2);
        if (speed == 1) {
            pathing.backgroundSpeed /= 2;
        }
        if (speed == 2) {
            pathing.backgroundSpeed *= 2;
        }
        StartCoroutine(PowerUpLength(activeTime));
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Effect();
        }
    }

    private IEnumerator PowerUpLength(float powerUpTime) {
        yield return new WaitForSeconds(powerUpTime);
        pathing.backgroundSpeed = defaultSpeed;
    }
}
