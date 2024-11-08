using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
/// <summary>
/// This class will be used to spawn asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    /// <summary>
    /// these serialize fields are to have a prefab asteroid
    /// and asteroid sprites selector in the Inspector in Unity, which
    /// is where we will attach these things, also sets variables
    /// </summary>
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

    //Set these variables outside all the methods becase they are used in all of them
    Direction dir = Direction.Up;
    Vector3 location = new Vector3(0, 0, 0);

    /// <summary>
    /// in our start, we spawn in an asteroid to get its radius.  That
    /// way we can determin an angle from the asteroid to get our thrust
    /// direction for the ones that get spawned in around the screen
    /// </summary>
    public void Start()
    {
        //spawn an asteroid in
        GameObject Asteroid = Instantiate(prefabAsteroid, location, Quaternion.identity);

        //get the radius of the asteroids collider and saves it in a float variable
        float radius2d = Asteroid.GetComponent<CircleCollider2D>().radius;

        //destroys the spawned in asteroid
        Destroy(Asteroid);

        //gets coordinate of left screen for asteroid to spawn into
        Vector3 screenLeft = new Vector3(ScreenUtils.ScreenLeft - radius2d, 
            ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom, ScreenUtils.ZScreen);

        //gets coordinate of right screen for asteroid to spawn into
        Vector3 screenRight = new Vector3(ScreenUtils.ScreenRight + radius2d, 
            ScreenUtils.ScreenTop + ScreenUtils.ScreenBottom, ScreenUtils.ZScreen);

        //gets coordinate of top screen for asteroid to spawn into
        Vector3 screenTop = new Vector3(ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft, 
            ScreenUtils.ScreenTop + radius2d, ScreenUtils.ZScreen);

        //gets coordinate of bottom screen for asteroid to spawn into
        Vector3 screenBottom = new Vector3(ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft, 
            ScreenUtils.ScreenBottom - radius2d, ScreenUtils.ZScreen);

        //this for loop is to ensure one asteroid spawns in on each side of the screen
        for (int spawnSide = 0; spawnSide <= 3; spawnSide++)
        {
            if (spawnSide == 0)
            {
                //change location and direction
                location = screenLeft;
                dir = Direction.Right;

                //spawn in new asteroid
                SpawnAsteroid();
            }
            else if (spawnSide == 1)
            {
                //change location and direction
                location = screenBottom;
                dir = Direction.Up;

                //spawn in new asteroid
                SpawnAsteroid();
            }
            else if (spawnSide == 2)
            {
                //change location and direction
                location = screenRight;
                dir = Direction.Left;

                //spawn in new asteroid
                SpawnAsteroid();
            }
            else
            {
                //change location and direction
                location = screenTop;
                dir = Direction.Down;

                //spawn in new asteroid
                SpawnAsteroid();
            }
        }
    }

    /// <summary>
    /// Spawns a new asteroid, finds the asteroid scrpit attached, 
    /// and uses the Initialze method on it to tell the asteroid
    /// where to go and what direction to go
    /// </summary>
    public void SpawnAsteroid()
    {
        //spawn asteroid at the location
        GameObject Asteroid = Instantiate(prefabAsteroid, location, Quaternion.identity);

        //get the asteroid class
        Asteroid asteroidDir = Asteroid.GetComponent<Asteroid>();

        //run initalize method for asteroid
        asteroidDir.Initialize(dir, location);

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
