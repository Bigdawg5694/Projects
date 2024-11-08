using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    GameObject bonusPrefab;
    [SerializeField]
    GameObject freezePrefab;
    [SerializeField]
    GameObject speedupPrefab;

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

    // sets percentages to config files
    int StandardPercent = ConfigurationUtils.StandardPercent;
    int BonusPercent = ConfigurationUtils.BonusPercent;
    int FreezePercent = ConfigurationUtils.FreezePercent;
    int SpeedupPercent = ConfigurationUtils.SpeedupPercent;
    #endregion

    #region Properties
    /// <summary>
    /// Sets the spawn timer variable between whatever the config file states
    /// </summary>

    float SpawnDelay()
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

        // add listeners for lostBallEvent and ballDiedEvent
        EventManager.AddBallLostEventListener(HandleBallLostEvent);
        EventManager.AddBallDiedEventListener(HandleBallDiedEvent);
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
    /// What the spawner does when spawnTimer is finished
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
        // use setminandmax to zero vector where ball will spawn
        SetMinAndMax(UnityEngine.Vector2.zero);

        // checks to see if there is a ball at spawn location
        if (Physics2D.OverlapArea(min, max) == null)
        {
            // set pending spawn to false
            pendingSpawn = false;

            // pick a random value btw 1 and 100
            // and display the number in debug log
            float randomValue = Random.Range(1, 100);
            Debug.Log("Random Value is: " + randomValue);

            // checks if value is less than standard percent
            if (randomValue < StandardPercent)
            {
                // spawn a standrad ball and display which ball is
                // spawning in debug log (for all balls)
                SpawnPrefab(ballPrefab);
                Debug.Log("Spawning Standard Ball");
            }
            else if (randomValue < StandardPercent + BonusPercent)
            {
                // spawn a bonus ball
                SpawnPrefab(bonusPrefab);
                Debug.Log("Spawning Bonus Ball");
            }
            else if (randomValue < StandardPercent + BonusPercent + FreezePercent)
            {
                // spawn a freeze ball
                SpawnPrefab(freezePrefab);
                Debug.Log("Spawning Freeze Ball");
            }
            else
            {
                // spawn a speedup ball
                SpawnPrefab(speedupPrefab);
                Debug.Log("Spawning Speedup Ball");
            }
        }
        else
        {
            // set pending spawn to true
            pendingSpawn = true;
        }
    }

    /// <summary>
    /// spawns a ball prefab into the scene
    /// </summary>
    /// <param name="prefab"></param>
    void SpawnPrefab(GameObject prefab)
    {
        // spawn a new ball
        Instantiate(prefab, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);
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
    /// Spawns ball when ball lost event is invoked
    /// </summary>
    /// <param name="unusedInt">unused</param>
    /// <param name="unusedSide">unused</param>
    void HandleBallLostEvent(int unusedInt, ScreenSide unusedSide)
    {
        SpawnBall();
    }

    /// <summary>
    /// Spawns ball when ball died event is invoked
    /// </summary>
    void HandleBallDiedEvent()
    {
        SpawnBall();
    }

    #endregion
}
