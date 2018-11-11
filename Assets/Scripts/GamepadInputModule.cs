using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "1 Gamepad Map", menuName = "Input Map/Gamepad Map")]
public class GamepadInputModule : ScriptableObject
{
    public KeyCode AButton;

    public bool A
    {
        get { return Input.GetKey(AButton); }
    }
    
    public KeyCode BButton;

    public bool B
    {
        get { return Input.GetKey(BButton); }
    }
    
    public KeyCode XButton;

    public bool X
    {
        get { return Input.GetKey(XButton); }
    }
    public KeyCode YButton;

    public bool Y
    {
        get { return Input.GetKey(YButton); }
    }
   
    // RightBumper = 4,
    // LeftBumper = 5,
    // Back = 6,
    // Start = 7,
    // RightStick = 8,
    // LeftStick = 9,

    public string LeftStickVerticalAxis;
    public string LeftStickHorizontalAxis;

    public Vector2 LeftAxis {get{return new Vector2(Input.GetAxis(LeftStickHorizontalAxis),-Input.GetAxis(LeftStickVerticalAxis));}}

    public string RightStickVerticalAxis;
    public string RightStickHorizontalAxis;

    public Vector2 RightAxis
    {
        get
        {
            return new Vector2(Input.GetAxis(RightStickHorizontalAxis),-Input.GetAxis(RightStickVerticalAxis));
        }
    }
    //Axis
    //Right Stick X Axis ,Right Stick Y Axis 
    //Left Trigger,Right Trigger

    #region Triggers

    public string LeftTriggerAxis;
    public float LeftTrigger
    {
        get { return Input.GetAxis(LeftTriggerAxis); }
    }

    public string RightTriggerAxis;
    public float RightTrigger
    {
        get { return Input.GetAxis(RightTriggerAxis); }
    }
    
    #endregion
  
}