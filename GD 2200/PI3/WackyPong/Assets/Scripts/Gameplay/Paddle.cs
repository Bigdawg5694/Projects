using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
	//our serialize field for which side the paddle is on
	[SerializeField]
	ScreenSide screenSide;

	//this sets our rigidbody, boxcollider, halfcollider, and Vector2 variables
	Rigidbody2D rb2d;
	BoxCollider2D bCol;
	float halfPaddleHeight;
	Vector2 newPosition;

	//this is the contact fields for our paddles
	ContactPoint2D contactPoint;
	int contact;

	//Declare field to store our input value
	float moveInput;

	//adding our bounceanglehalfrange variable
	const float BounceAngleHalfRange = -60f * Mathf.Deg2Rad;

	HUD hud;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		//get the rigidbody2d and boxcollider2d from the object
		rb2d = GetComponent<Rigidbody2D>();
		bCol = GetComponent<BoxCollider2D>();
		GameObject hudGameObject = GameObject.FindGameObjectWithTag("HUD");
		hud = hudGameObject.GetComponent<HUD>();

		//set our new position to whatever the objects position is
		newPosition = rb2d.position;

		//set our half collider variable to half the box collider
		halfPaddleHeight = bCol.size.y / 2;
	}

	/// <summary>
	/// This fixedUpdate method will be used 
	/// to move the paddle with our rb2d component
	/// </summary>
	private void FixedUpdate()
	{
		//this is for determining which side the paddle is on,
		//and which input axis to use
		switch (screenSide)
		{
			case ScreenSide.Left:
				moveInput = Input.GetAxis("LeftPaddle");
				break;
			case ScreenSide.Right:
				moveInput = Input.GetAxis("RightPaddle");
				break;
		}

		//this calculates our new position for the paddle
		newPosition.y += moveInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * 
			Time.fixedDeltaTime;

		//this sets our newPosition.y into a clamp, to ensure it dosent go off the screen
		float yPos = Mathf.Clamp(newPosition.y, ScreenUtils.ScreenBottom + halfPaddleHeight,
			ScreenUtils.ScreenTop - halfPaddleHeight);

		//this is used to ensure the value of our newpositoin will stay within the clamp
		if (newPosition.y > yPos || newPosition.y < yPos)
		{
			newPosition.y = yPos;
		}

		//this moves our paddle to that position
		rb2d.MovePosition(new Vector2(newPosition.x, yPos));
	}
	/// <summary>
	/// Detects collision with a ball to aim the ball
	/// </summary>
	/// <param name="coll">collision info</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Ball") && PaddleFront(coll) == true)
		{
			// calculate new ball direction
			float ballOffsetFromPaddleCenter =
				coll.transform.position.y - transform.position.y;
			float normalizedBallOffset = ballOffsetFromPaddleCenter /
				halfPaddleHeight;
			float angleOffset = normalizedBallOffset * BounceAngleHalfRange;

			// angle modification is based on screen side
			float angle;
			if (screenSide == ScreenSide.Left)
			{
				angle = angleOffset;
			}
			else
			{
				angle = (float)(Mathf.PI - angleOffset);
			}
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

			// tell ball to set direction to new direction
			Ball ballScript = coll.gameObject.GetComponent<Ball>();
			ballScript.SetDirection(direction);

			hud.AddHit(screenSide, ballScript.Hits);
		}
	}

	/// <summary>
	/// This method is a check for the system to find out if
	/// the collision on the paddle is on the front of the paddle
	/// </summary>
	/// <param name="col"></param>
	/// <returns></returns>
	public bool PaddleFront(Collision2D col)
	{
		//this gets our contact point from the paddle
		contactPoint = col.GetContact(contact);

		//this checks if our point of contact is not zero, to ensure
		//we can get a true statement if that is the case, and false if not
		if (contactPoint.point.x != 0)
		{
			//this checks what side our paddle is on, and if the x coordinate for
			//the contact is on the "front" of the paddle for that side
			if (screenSide == ScreenSide.Left && 
				contactPoint.point.x >= 0.05f + transform.position.x)
			{
				return true;
			}
			else if (screenSide == ScreenSide.Right &&
				contactPoint.point.x <= 0.05f + transform.position.x)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}
}
