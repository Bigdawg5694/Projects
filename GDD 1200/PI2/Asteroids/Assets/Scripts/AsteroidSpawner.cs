using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabAsteroid;

    // saved for efficiency
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

    // spawn control
    public const float SpawnSeconds = 10;
    Timer spawnTimer;
    public const int MaxAsteroidsInScene = 10;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        // create and start timer
        if (!spawnTimer.Running)
        {
            spawnTimer.Duration = SpawnSeconds;
            spawnTimer.Run();
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {

        // check for time to spawn a new asteroid
        if (spawnTimer.Finished)
        {

            // only spawn new asteroid if fewer than max asteroids in scene
            var AsteroidCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;
            if (AsteroidCount < MaxAsteroidsInScene)
            {
                SpawnAsteroid();
                // restart spawn timer
                spawnTimer.Run();
            }
            else
            {
                spawnTimer.Run();
            }
        }
    }

    /// <summary>
    /// Spawns a new asteroid at the center of the screen
    /// </summary>
    void SpawnAsteroid()
    {
        // create new asteroid at spawn location
        Vector3 location = new Vector3(Screen.width / 2, Screen.height / 2,
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject Asteroid = Instantiate(prefabAsteroid, worldLocation, Quaternion.identity);

        //set random sprite for new asteroid
        SpriteRenderer spriteRenderer = Asteroid.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
    }
}
