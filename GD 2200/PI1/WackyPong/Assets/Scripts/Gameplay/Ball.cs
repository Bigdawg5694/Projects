using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
	//sets our rigidbody2d and vector2 for our ball
	Rigidbody2D rb2d;
	Vector2 moveDirection = new Vector2 (0, 0);

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		//this gets the component from the game object
		rb2d = GetComponent<Rigidbody2D>();

		//this decides whether our ball is going left or right
		int side = Random.Range(0, 2);

		if (side == 0)
		{
			//this calculates our angle if the ball is going to the left
			float angleLeft = Random.Range(135f * Mathf.Deg2Rad, 225f * Mathf.Deg2Rad);
			moveDirection = new Vector2(Mathf.Cos(angleLeft), Mathf.Sin(angleLeft));

			//adds force to the ball in that direction
			rb2d.AddForce(moveDirection * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
		}

		if (side == 1)
		{
			//this calcs our angle if the ball is going to the right
			float angleRight = Random.Range(-45f * Mathf.Deg2Rad, 45f * Mathf.Deg2Rad);
			moveDirection = new Vector2(Mathf.Cos(angleRight), Mathf.Sin(angleRight));

			//add force to the ball in that direction
			rb2d.AddForce(moveDirection * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
		}
	}
	
	/// <summary>
	/// setdirection method for the ball
	/// </summary>
	public void SetDirection(Vector2 direction)
	{
		//this gives us the new direction the ball is moving in while keeping the velocity the same
		rb2d.AddForce(direction * rb2d.velocity.normalized, ForceMode2D.Impulse);
	}
	/// <summary>
	/// onbecomeinvisible method to destroy ball
	/// </summary>
	private void OnBecameInvisible()
	{
		//ball gets destroyed
		Destroy(gameObject);
	}
}
