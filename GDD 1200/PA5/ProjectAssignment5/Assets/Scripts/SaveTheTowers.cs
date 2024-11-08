using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager
/// </summary>
public class SaveTheTowers : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabTower;

    List<GameObject> teddyBears = new List<GameObject>();

    bool previousInputProvided = false;


    #endregion

    #region Properties

    /// <summary>
    /// Gets the oldest teddy bear in the game
    /// </summary>
    /// <value>oldest teddy bear or null if the list is empty</value>
    public GameObject OldestTeddyBear
    {
        get
        {
            int x = teddyBears.Count - 1;
            if(x >= 0)
            {
                return teddyBears[x];
            }else return null;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //on left click, make a tower
        if (Input.GetAxis("TowerSpawn") == 0)
        {
            if (!previousInputProvided)
            {
                // convert mouse position to world position
                Vector3 position = Input.mousePosition;
                position.z = -Camera.main.transform.position.z;
                Vector3 position1 = Camera.main.ScreenToWorldPoint(position);
                GameObject bomb = Instantiate(prefabTower, position1, Quaternion.identity);

                //changes previousinput to true, to only have the click work once
                previousInputProvided = true;
            }
        }
        else
        {
            //changes previousinput to false when button is released
            previousInputProvided = false;
        }
    }

    /// <summary>
    /// Adds the given teddy bear to the list
    /// </summary>
    /// <param name="teddyBear">teddy bear to add</param>
    public void AddTeddyBear(GameObject teddyBear)
    {
        teddyBears.Add(teddyBear);
    }

    /// <summary>
    /// Removes the given teddy bear from the game
    /// </summary>
    /// <param name="teddyBear">teddy bear to remove</param>
    public void RemoveTeddyBear(GameObject teddyBear)
    {
        teddyBears.Remove(teddyBear);
        Destroy(teddyBear);
    }
    #endregion
}
