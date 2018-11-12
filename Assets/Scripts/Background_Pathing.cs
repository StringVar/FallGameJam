using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Pathing : MonoBehaviour {
    public float backgroundSpeed = 200f;
    public Transform[] PathPts;

    private int endT;
    private float t, dT;
    private Transform target, start, firstPos;
    private bool firstRun = true;

	// Use this for initialization
	void Start () {
        endT = 1;
        target = PathPts[1];
        start = PathPts[0];
        firstPos = PathPts[2];
        dT = backgroundSpeed / Vector2.Distance(firstPos.position, target.position);
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime * dT;

        if (t >= endT) {
            transform.position = start.position;
            endT = (int)Mathf.Floor(t) + 1;
            dT = backgroundSpeed / Vector2.Distance(start.position, target.position);
            firstRun = false;
        }

        if (firstRun) {
            float left = t - endT + 1;
            transform.position = Vector2.Lerp(firstPos.position, target.position, left);
        }
        else {
            float left = t - endT + 1;
            transform.position = Vector2.Lerp(start.position, target.position, left);
        }
    }
}
