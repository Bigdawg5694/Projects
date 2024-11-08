using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BearSpawner : MonoBehaviour
{
    //made just to simplify and show what our bear is
    [SerializeField]
    GameObject prefabBear;


    public Timer spawnTimer;

    // Start is called before the first frame update
    public void Start()
    {
        //randomizes how many seconds in between spawns
        float SpawnSeconds = Random.Range(1, 4);
        spawnTimer = GetComponent<Timer>();
                
        // create and start timer
        if (!spawnTimer.Running)
        {
            spawnTimer.Duration = SpawnSeconds;
            spawnTimer.Run();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawns a bear when timer is finished
        if (spawnTimer.Finished)
        {
            SpawnBear();
            //reset timer and keep going!
            spawnTimer.Run();
        }
    }

    void SpawnBear()
    {
        //make a random number btw 0 and screen width/height
        float spawnX = Random.Range(0, Screen.width);
        float spawnY = Random.Range(0, Screen.height);

        // create new bear at a random spawn location
        Vector3 location = new Vector3(spawnX, spawnY,
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject Bear = Instantiate(prefabBear, worldLocation, Quaternion.identity);
    }
}
