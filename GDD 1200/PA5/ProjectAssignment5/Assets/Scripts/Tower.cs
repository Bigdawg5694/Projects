using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabBullet;

    SaveTheTowers teddyCount;
    GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        teddyCount = Camera.main.GetComponent<SaveTheTowers>();
        tower = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (teddyCount != null)
        {
            ShootBear();
        }
    }
    void ShootBear()
    {
        //spawn in a bullet
        Vector3 bulletSpawn = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z);
        GameObject bullet = Instantiate(prefabBullet, bulletSpawn, Quaternion.identity);
    }
}
