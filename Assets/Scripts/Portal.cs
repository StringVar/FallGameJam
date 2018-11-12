using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] private float teleportTime = 0.1f;
    [SerializeField] private AudioClip teleportEntry;

    public GameObject entryPortal;
    public GameObject exitPortal;
    public Bullet bulletScript;

    private Transform objToTeleport;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Teleport() {
        if (objToTeleport.gameObject.name == "Bullet") {
            bulletScript.canTeleport = false;
        }
        audioSource.clip = teleportEntry;
        audioSource.Play();
        objToTeleport.position = exitPortal.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        objToTeleport = collision.transform;
        if (objToTeleport.gameObject.name == "Bullet") {
            if (bulletScript.canTeleport == true) {
                Teleport();
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (objToTeleport.gameObject.name == "Bullet") {
            StartCoroutine(WaitToTeleport(teleportTime));
        }
    }

    private IEnumerator WaitToTeleport(float teleportDelay) {
        yield return new WaitForSeconds(teleportDelay);
        bulletScript.canTeleport = true;
    } 

}

