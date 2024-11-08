using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Non-follows the mouse
/// </summary>
public class NonFollower : MonoBehaviour
{
    #region Fields

    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        // save collider half width and half height for efficiency

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // convert mouse position to world position


        // move character to opposite of mouse position and clamp in screen

    }

    #endregion

    #region Private methods

    /// <summary>
    /// Clamps the character in the screen
    /// </summary>
    void ClampInScreen()
    {
        // clamp position as necessary

    }

    #endregion

    #region Autograder properties

    /// <summary>
    /// Gets the collider half width
    /// </summary>
    public float ColliderHalfWidth
    {
        get { return colliderHalfWidth; }
    }

    /// <summary>
    /// Gets the collider half height
    /// </summary>
    public float ColliderHalfHeight
    {
        get { return colliderHalfHeight; }
    }

    /// <summary>
    /// Gets the position of the game object
    /// </summary>
    public Vector3 Position
    {
        get { return transform.position; }
    }

    #endregion
}
