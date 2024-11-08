using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    [SerializeField]
    ScreenSide side;

    // saved for efficiency
    Rigidbody2D rb2d;
    Vector2 newPosition = Vector2.zero;
    float halfPaddleHeight;
    float halfPaddleWidth;

    // HUD support
    HUD hud;

    // aiming support
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // saved for efficiency
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        halfPaddleHeight = bc2d.size.y / 2;
        halfPaddleWidth = bc2d.size.x / 2;

        // saved for efficiency
        GameObject hudGameObject = GameObject.Find("HUD");
        hud = hudGameObject.GetComponent<HUD>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// FixedUpdate is called 50 times a second
    /// </summary>
    void FixedUpdate()
    {
        // get side-specific input
        float input;
        if (side == ScreenSide.Left)
        {
            input = Input.GetAxis("LeftPaddle");
        }
        else
        {
            input = Input.GetAxis("RightPaddle");
        }

        // move paddle as appropriate
        if (input != 0)
        {
            newPosition = rb2d.position;
            newPosition.y += input *
                ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y,
                ScreenUtils.ScreenBottom + halfPaddleHeight,
                ScreenUtils.ScreenTop - halfPaddleHeight);
            rb2d.MovePosition(newPosition);
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") &&
            FrontCollision(coll))
        {
            // add hits to HUD
            hud.AddHits(side, coll.gameObject.GetComponent<Ball>().Hits);

            // calculate new ball direction
            float ballOffsetFromPaddleCenter =
                coll.transform.position.y - transform.position.y;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfPaddleHeight;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;

            // angle modification is based on screen side
            float angle;
            if (side == ScreenSide.Left)
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
        }
    }

    /// <summary>
    /// Checks for a collision at the front of the paddle
    /// </summary>
    /// <returns><c>true</c>, if collision was at the front of the paddle, <c>false</c> otherwise.</returns>
    /// <param name="coll">collision info</param>
    bool FrontCollision(Collision2D coll)
    {
        const float Tolerance = 0.05f;

        // on front collisions, both contact points are at the same x location
        return Mathf.Abs(coll.GetContact(0).point.x - 
            coll.GetContact(1).point.x) < Tolerance;
    }
    void Freeze(Timer duration)
    {

    }
}
