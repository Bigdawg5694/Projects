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
        // create and start timer

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // check for time to spawn a new rock

            // only spawn new rock if fewer than max rocks in scene


            // restart spawn timer


    }

    /// <summary>
    /// Spawns a new rock at the center of the screen
    /// </summary>
    void SpawnRock()
    {
        // create new rock at spawn location


        // set random sprite for new rock

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
