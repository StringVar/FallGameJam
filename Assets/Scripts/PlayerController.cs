using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformerController))]
public class PlayerController : MonoBehaviour 
{	
	public GamepadInputModule gamepad;

	public PlatformerController controller;
	
	
	void Start ()
	{
		controller = GetComponent<PlatformerController>();
	}
	
	void Update () {
		controller.Move(gamepad.LeftAxis);

	}
}
