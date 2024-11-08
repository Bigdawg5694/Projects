using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
	#region Fields
	[SerializeField]
    GameObject ballPrefab;

    // Get a spawn timer component for this script
    Timer spawnTimer;

    // Get the col half width and half height components
    float ballColHalfWidth;
    float ballColHalfHeight;

    // Make a boolean for our pending spawn
    bool pendingSpawn = false;

    // Make Vector 2's for the overlap in our SpawnBall method
    UnityEngine.Vector2 min = new UnityEngine.Vector2();
    UnityEngine.Vector2 max = new UnityEngine.Vector2();
	#endregion

	#region Properties
	/// <summary>
	/// Sets the spawn timer variable between whatever the config file states
	/// </summary>

	public float SpawnDelay()
	{
		// this gets us a random float between our min and max values
		return (Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime));
	}
    #endregion

    #region Unity methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        // spawn and destroy a ball to cache collider values
        GameObject tempBall = Instantiate(ballPrefab);
        BoxCollider2D col = tempBall.GetComponent<BoxCollider2D>();
        ballColHalfWidth = col.size.x / 2;
        ballColHalfHeight = col.size.y / 2;
        Destroy(tempBall);

        // make a spawn timer
		spawnTimer = gameObject.AddComponent<Timer>();

        // add listener for timer finished event
        spawnTimer.AddTimerFinishedEventListener(HandleSpawnTimerFinishedEvent);

        // set its duration to our random interval
        spawnTimer.Duration = SpawnDelay();

        // run the timer
        spawnTimer.Run();

        // add a listener for lostBallEvent
        EventManager.AddBallLostEventListener(HandleBallLostEvent);
    }
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // Check to see if pendingSpawn is false
        if (!pendingSpawn)
        {
            SpawnBall();
        }
	}

    /// <summary>
    /// what the spawner does when spawnTimer is finished
    /// </summary>
    void HandleSpawnTimerFinishedEvent()
    {
        // spawn a new ball
        SpawnBall();

        // stop the spawn timer
        spawnTimer.Stop();

        // set a new random interval for our spawn timer
        spawnTimer.Duration = SpawnDelay();

        // run the spawn timer with new duration
        spawnTimer.Run();
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Spawns a ball in the center of the screen
    /// </summary>
    void SpawnBall()
    {
        SetMinAndMax(UnityEngine.Vector2.zero);
        if (Physics2D.OverlapArea(min, max) != null)
        {
            // set pending spawn to true
            pendingSpawn = true;
		}
		else
		{
			// spawn a new ball
			Instantiate(ballPrefab, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);

			// set pending spawn to false
			pendingSpawn = false;
		}
    }

    /// <summary>
    /// Setting the min and max Vectors
    /// </summary>
    void SetMinAndMax(UnityEngine.Vector2 location)
    {
        min.x = location.x - ballColHalfWidth;
        min.y = location.y - ballColHalfHeight;
        max.x = location.x + ballColHalfWidth;
        max.y = location.y + ballColHalfHeight;
    }

    /// <summary>
    /// spawns ball when ball lost event is invoked
    /// </summary>
    /// <param name="point"></param>
    /// <param name="side"></param>
    void HandleBallLostEvent(int point, ScreenSide side)
    {
        SpawnBall();
    }
    #endregion
}
