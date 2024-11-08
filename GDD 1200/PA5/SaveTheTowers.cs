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
            // STUDENTS: fix this
            return null;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Adds the given teddy bear to the list
    /// </summary>
    /// <param name="teddyBear">teddy bear to add</param>
    public void AddTeddyBear(GameObject teddyBear)
    {

    }

    /// <summary>
    /// Removes the given teddy bear from the game
    /// </summary>
    /// <param name="teddyBear">teddy bear to remove</param>
    public void RemoveTeddyBear(GameObject teddyBear)
    {

    }

    #endregion
}
