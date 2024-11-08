using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
	#region Fields

	// points and hits the ball is worth
	int points;
    int hits;

    // move delay timer
    Timer moveTimer;

    // ball death support
    Timer deathTimer;

    // save for efficiency
    Rigidbody2D rb2d;

    //add BallLostEvent invoker field
    BallLostEvent ballLostEvent;

    //adds balltype field
    [SerializeField]
    BallType type;

	#endregion

	#region Properties

	/// <summary>
	/// Gets the number of hits the ball is worth
	/// </summary>
	public int Hits
    {
        get { return hits; }
    }

	#endregion

	#region Unity methods

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // fins out if the ball type is a normal ball
        // or a bonus ball
        if (type == BallType.Normal)
        {
            // set number of points and hits the ball is worth
            points = ConfigurationUtils.StandardPoints;
            hits = ConfigurationUtils.StandardHits;
        }
        if (type == BallType.Bonus)
        {
            //set number of points to bonusball
            points = ConfigurationUtils.BonusPoints;
            hits = ConfigurationUtils.BonusHits;
        }

        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.AddTimerFinishedEventListener(HandleMoveTimerFinishedEvent);
        moveTimer.Duration = 1;
        moveTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.AddTimerFinishedEventListener(HandleDeathTimerFinishedEvent);
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();

        // save for efficiency
        rb2d = GetComponent<Rigidbody2D>();

        // make the ball the invoker
        ballLostEvent = new BallLostEvent();
        EventManager.AddBallLostEventInvoker(this);
    }

    /// <summary>
    /// Destroys ball when it becomes invisible
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only lost ball if outside screen
            if (OutsideScreen())
            {
                // adjust score in HUD and spawn new ball
                // through invoking BallLostEvent
                if (transform.position.x > 0)
                {
                    ballLostEvent.Invoke(points, ScreenSide.Left);
                }
                else
                {
                    ballLostEvent.Invoke(points, ScreenSide.Right);
                }

                // destroy self                
                Destroy(gameObject);
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // set min and max angles going to the right
        float minAngle = -45 * Mathf.Deg2Rad;
        float maxAngle = 45 * Mathf.Deg2Rad;

        // switch to going to the left half the time
        if (Random.value < 0.5)
        {
            minAngle += Mathf.PI;
            maxAngle += Mathf.PI;
        }

        // build and apply force vector
        float angle = Random.Range(minAngle, maxAngle);
        Vector2 force = new Vector2(
            (float)Mathf.Cos(angle) * ConfigurationUtils.BallImpulseForce,
            (float)Mathf.Sin(angle) * ConfigurationUtils.BallImpulseForce);
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Tells whether or not the ball it outside the screen horizontally
    /// </summary>
    /// <returns>true if ball outside screen horizontally, false otherwise</returns>
    bool OutsideScreen()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        float halfBallWidth = collider.size.x / 2;
        return (transform.position.x + halfBallWidth < ScreenUtils.ScreenLeft) ||
            (transform.position.x - halfBallWidth > ScreenUtils.ScreenRight);
    }
    void SpeedUp(float speedUpFactor, Timer duration)
    {

    }
    /// <summary>
    /// adds a listener to BallLostEvent
    /// </summary>
    /// <param name="handler"></param>
    public void AddBallLostEventListener(UnityAction <int, ScreenSide> handler)
    {
        ballLostEvent.AddListener(handler);
    }

    /// <summary>
    /// Handles when the moveTimer is finished
    /// </summary>
    void HandleMoveTimerFinishedEvent()
    {
        // stop timer and start ball movement
        moveTimer.Stop();
        StartMoving();
    }

    /// <summary>
    /// Handles when the deathTimer is finished
    /// </summary>
    void HandleDeathTimerFinishedEvent()
    {
        // spawn a new ball and destroy self
        ballLostEvent.Invoke(0, ScreenSide.Left);
        Destroy(gameObject);
    }

    #endregion
}
