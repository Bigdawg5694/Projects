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


        if (Input.GetAxis("JumpToMouse") == 0)
        {
            if (!previousInputProvided)
            {
                // convert mouse position to world position
                Vector3 position = Input.mousePosition;
                position.z = -Camera.main.transform.position.z;
                Vector3 position1 = Camera.main.ScreenToWorldPoint(position);
                transform.position = position1;
                
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
