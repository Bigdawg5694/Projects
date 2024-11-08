using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jumps the game object to the mouse location on left click
/// </summary>
public class Jumper : MonoBehaviour
{
    bool previousInputProvided = false;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // add your code here
    }

    #region Autograder properties

    /// <summary>
    /// Gets the position of the game object
    /// </summary>
    public Vector3 Position
    {
        get { return transform.position; }
    }

    #endregion
}
