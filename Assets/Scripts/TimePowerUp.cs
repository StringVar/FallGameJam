using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class TimePowerUp : MonoBehaviour, IPowerup {
    public void Effect() {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Effect();

        }
    }
}
