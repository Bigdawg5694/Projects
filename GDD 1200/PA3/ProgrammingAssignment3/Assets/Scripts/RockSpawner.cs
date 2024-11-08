using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock spawner
/// </summary>
public class RockSpawner : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabRock;

    // saved for efficiency
    [SerializeField]
    Sprite rockSprite0;
    [SerializeField]
    Sprite rockSprite1;
    [SerializeField]
    Sprite rockSprite2;

    // spawn control
    public const float SpawnSeconds = 1;
    Timer spawnTimer;
    public const int MaxRocksInScene = 3;

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
        
        // check for time to spawn a new rock
        if (spawnTimer.Finished)
        {
            
            // only spawn new rock if fewer than max rocks in scene
            var RockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
            if (RockCount < MaxRocksInScene)
            {
                SpawnRock();
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
    /// Spawns a new rock at the center of the screen
    /// </summary>
    void SpawnRock()
    {
        // create new rock at spawn location
        Vector3 location = new Vector3 (Screen.width / 2, Screen.height / 2, 
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject Rock = Instantiate(prefabRock, worldLocation, Quaternion.identity);

        //set random sprite for new rock
        SpriteRenderer spriteRenderer = Rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0,3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = rockSprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = rockSprite1;
        }
        else
        {
            spriteRenderer.sprite = rockSprite2;
        }
    }

    #region Autograder support

    /// <summary>
    /// Sets the serialized fields. The autograder needs this 
    /// method because the serialized fields can't be populated
    /// in the Unity editor in a console app
    /// </summary>
    /// <param name="prefabRock">the rock prefab</param>
    /// <param name="sprite0">sprite 0</param>
    /// <param name="sprite1">sprite 1</param>
    /// <param name="sprite2">sprite 2</param>
    public void SetSerializedFields(GameObject prefabRock, Sprite sprite0, 
        Sprite sprite1, Sprite sprite2)
    {
        this.prefabRock = prefabRock;
        rockSprite0 = sprite0;
        rockSprite1 = sprite1;
        rockSprite2 = sprite2;
    }

    #endregion
}
