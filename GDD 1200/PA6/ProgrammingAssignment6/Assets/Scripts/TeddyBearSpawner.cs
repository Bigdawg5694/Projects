using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear spawner
/// </summary>
public class TeddyBearSpawner : MonoBehaviour
{
	//this is used so that unity knows what gameobject to spawn in
	[SerializeField]
	GameObject prefabTeddyBear;

	// spawn control
	const float MinSpawnDelay = 1;
	const float MaxSpawnDelay = 3;
	Timer spawnTimer;

	// spawn location support
	const int SpawnBorderSize = 10;
	int minSpawnX;
	int maxSpawnX;
	int minSpawnY;
	int maxSpawnY;

    /// <summary>
    /// In the Start method, we are setting our spawn boundaries
	/// and creating/starting our timer
    /// </summary>
    void Start()
    {	
		// save spawn boundaries for efficiency
		minSpawnX = SpawnBorderSize;
		maxSpawnX = Screen.width - SpawnBorderSize;
		minSpawnY = SpawnBorderSize;
		maxSpawnY = Screen.height - SpawnBorderSize;

		// create timer
		spawnTimer = gameObject.AddComponent<Timer>();

		//randomize duration of timer
		spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);

		//run the timer
		spawnTimer.Run();
    }

    /// <summary>
    /// This Update method is used to check if our timer is done
	/// and once the timer is finished, spawn in a teddybear
    /// </summary>
    void Update()
    {
		// check for time to spawn a new teddy bear
		if (spawnTimer.Finished)
        {
			//calls the method to spawn our bear
			SpawnBear();

			// change spawn timer duration
			spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);

			//run timer again
			spawnTimer.Run();
		}
	}
	
	/// <summary>
	/// Spawns a new teddy bear at a random location
	/// </summary>
	void SpawnBear()
	{
		// generate random location
		Vector3 location = new Vector3 (Random.Range (minSpawnX, maxSpawnX),
            Random.Range (minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);

		//change that location from a screenpoint to a worldpoint
		Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

		//Instantiate our bear through the field at the beginning
		GameObject teddyBear = Instantiate (prefabTeddyBear);

		//move our bear to the random location generated
		teddyBear.transform.position = worldLocation;
	}
}
