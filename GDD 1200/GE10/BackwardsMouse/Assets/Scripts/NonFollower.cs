using UnityEngine;

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
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        // save collider half width and half height for efficiency
        colliderHalfHeight = collider.size.x / 2;
        colliderHalfWidth = collider.size.y / 2;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // convert mouse position to world position
        Vector3 position = -Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);

        // move character to opposite of mouse position and clamp in screen
        transform.position = position;
        ClampInScreen();
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Clamps the character in the screen
    /// </summary>
    void ClampInScreen()
    {
        // clamp position as necessary
        Vector3 position = transform.position;

        //clamp the game obj horizontally
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }

        //clamp the game obj vertically
        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }

        transform.position = position;
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
