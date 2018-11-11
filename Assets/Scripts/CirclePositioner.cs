using UnityEngine;
using UnityEngine.Serialization;


public class CirclePositioner : MonoBehaviour
{
    public GameObject Center;
    public float angle;
    
    public void SetRotation(Vector2 position)
    {
        float new_angle = 90 + Mathf.Atan2(-position.y, position.x)*Mathf.Rad2Deg;
        transform.RotateAround(Center.transform.position, Vector3.forward, angle - new_angle);
        angle = new_angle;

    }
    
    private float _angle;
}