using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves game object based on keyboard input
/// </summary>
public class Driver : MonoBehaviour
{
    public const float MoveUnitsPerSecond = 5;
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	public void Update()
	{
        // move horizontally as appropriate
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
        }

        // move vertically as appropriate
        if (verticalInput != 0)
        {
            position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
        }
        transform.position = position;
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
