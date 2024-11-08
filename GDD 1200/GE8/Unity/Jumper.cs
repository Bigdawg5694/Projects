using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jumps the game object to a new location every second
/// </summary>
public class Jumper : MonoBehaviour
{
    // move location support
    const int MoveBorderSize = 100;
    int minMoveX;
    int maxMoveX;
    int minMoveY;
    int maxMoveY;

    // timer support
    const float TotalMoveDelaySeconds = 1;
    float elapsedMoveDelaySeconds = 0;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        // save move boundaries for efficiency

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // update timer and check if it's done

            // reset timer and move game object
            // to move the game object, generate a random
            // position in screen coordinates, convert those
            // screen coordinates to world coordinates, and
            // set the game object position to those world 
            // coordinates

    }
}
