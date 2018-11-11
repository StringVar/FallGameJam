using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlatformerController))]
public class PlayerController : MonoBehaviour
{
    private Gamepad gamepad;
    public int controllerNumber;

    public PlatformerController Controller;
    public GameObject Gun;
    public CirclePositioner gunPositioner;
    public ParticleSystem gun;


    private bool _isShooting;

    public bool isShooting
    {
        set
        {
            if (!_isShooting && value)
            {
                gun.Play();
            }

            if (!value)
            {
                gun.Stop(false,
                    ParticleSystemStopBehavior.StopEmitting);
            }

            _isShooting = value;
        }
        get { return _isShooting; }
    }

    void Start()
    {
        Controller = GetComponent<PlatformerController>();
        gun.Stop();

        if (Gamepad.all.Count < controllerNumber)
        {
        }
    }

    void Update()
    {
        Debug.Log(Gamepad.all.Count);
        try
        {
            gamepad = Gamepad.all[controllerNumber];

            Controller.Move(gamepad.leftStick.ReadValue());
            Vector2 RightAxis = gamepad.rightStick.ReadValue();
            gunPositioner.SetRotation(RightAxis);
            if (!Vector2isZero(RightAxis))
            {
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
        }
        catch (Exception e)
        {
            gameObject.SetActive(false);
            Debug.Log("playercontroller: " + gameObject.name + " disabled due to device not pluged in" +
                      Gamepad.all.Count);
            return;
        }
    }

    bool Vector2isZero(Vector2 value)
    {
        const float threshold = 0.2f;
        if (Math.Abs(value.x) > threshold)
        {
            return false;
        }

        if (Math.Abs(value.y) > threshold)
        {
            return false;
        }

        return true;
    }
}