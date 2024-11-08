using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle
/// </summary>
public abstract class Paddle : MonoBehaviour
{
	#region Fields

    // set a serialize field for whichh side the paddle is on
	[SerializeField]
    protected ScreenSide side;

	// saved for efficiency
	protected Rigidbody2D rb2d;
    protected Vector2 newPosition = Vector2.zero;
    protected float halfPaddleHeight;
    float halfPaddleWidth;

    // aiming support
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    // add HitsAddedEvent invoker field
    HitsAddedEvent hitsAddedEvent;

    // add int for hit
    int hit;

    // fields for freeze effect
    bool frozen = false;
    Timer paddleFreeze;

    #endregion

    #region Properties

    /// <summary>
    /// sets a property in paddle to screenside.right
    /// </summary>
    public ScreenSide Side
    {
        set
        {
            side = value;
        }
    }

    #endregion

    #region Methods

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

        // makes a hitsadded event and adds it to event manager
        hitsAddedEvent = new HitsAddedEvent();
        EventManager.AddHitsAddedEventInvoker(this);

        // adds paddlefreeze as a listener to freeze effect event
        EventManager.AddFreezeEffectEventListener(PaddleFreeze);

        // make a timer component for freeze effect
        paddleFreeze = gameObject.AddComponent <Timer>();

        // adds unfreeze as a listener to paddle freeze timer
        paddleFreeze.AddTimerFinishedEventListener(Unfreeze);
    }

    /// <summary>
    /// FixedUpdate is called 50 times a second
    /// </summary>
    void FixedUpdate()
    {
        //checks if paddle isn't frozen
        if (frozen == false)
        {
            // the paddle moves based on this method
            UpdatePaddle();
        }
    }

    protected abstract void UpdatePaddle();

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        // checks if object colliding with it is a ball
        // and colliding in front
        if (coll.gameObject.CompareTag("Ball") &&
            FrontCollision(coll))
        {
            //find hit number
            hit = coll.gameObject.GetComponent<Ball>().Hits;

            // invoke hitAdded event
            hitsAddedEvent.Invoke(side, hit);

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

    /// <summary>
    /// the move moethod to move the paddle
    /// </summary>
    /// <param name="movement">input/movementAmt</param>
    protected void Move(float movement)
    {
        // gets rb2d of object
        newPosition = rb2d.position;

        // sets the speed that paddle will move at
        newPosition.y += movement * ConfigurationUtils.PaddleMoveUnitsPerSecond
            * Time.deltaTime;

        // clamps the paddle in our scene
        newPosition.y = Mathf.Clamp(newPosition.y, ScreenUtils.ScreenBottom + halfPaddleHeight,
            ScreenUtils.ScreenTop - halfPaddleHeight);

        // moves the paddle
        rb2d.MovePosition(newPosition);
    }

    /// <summary>
    /// adds the event listener to the paddle
    /// </summary>
    /// <param name="handler">listener</param>
    public void AddHitsAddedEventListener(UnityAction<ScreenSide, int> handler)
    {
        hitsAddedEvent.AddListener(handler);
    }

    /// <summary>
    /// this is the method to freeze the paddle
    /// </summary>
    /// <param name="side">the side that gets frozen</param>
    /// <param name="duration">the duration of the freeze effect</param>
    void PaddleFreeze(ScreenSide side, float duration)
    {
        // checks to see which paddle is affected
        if (side == this.side)
        {
            // checks to see if frozen is false
            if (frozen == false)
            {
                // make frozen true
                frozen = true;

                // sets timer duration
                paddleFreeze.Duration = ConfigurationUtils.FreezeDuration;

                // run freeze timer
                paddleFreeze.Run();
            }
            // checks to see if effect is true and timer is still running
            else if (frozen == true && !paddleFreeze.Finished)
            {
                // adds time to the timer, making the effect last longer
                paddleFreeze.AddTime(duration);
            }
        }
    }

    /// <summary>
    /// this is to unfreeze the paddle when the timer runs out
    /// </summary>
    void Unfreeze()
    {
        // change frozen to false
        frozen = false;

        // stop freeze timer
        paddleFreeze.Stop();
    }

	#endregion
}
