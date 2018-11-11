using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerController : MonoBehaviour
{
	private Rigidbody2D _rb;

	public Vector2 MaxVelocity;
	public Vector2 ModVelocity;
	public Vector2 MinVelocity;
	
	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody2D>();
	}
	
	// move (-1,1)
	public void Move(Vector2 move)
	{
		_rb.velocity = clamp(move * ModVelocity,MinVelocity,MaxVelocity);
	}

	public Vector2 clamp(Vector2 value, Vector2 min, Vector2 max)
	{
		//TODO add min
		if (max.x < value.x )
		{
			value.x = max.x;
		}
		if (max.y < value.y)
		{
			value.y = max.y;
		}
		return value;
	}

}
