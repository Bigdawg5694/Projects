﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resizes the game object
/// </summary>
public class Resizer : MonoBehaviour
{
    // timer support
    const float TotalResizeSeconds = 1;
    float elapsedResizeSeconds = 0;

    // resizing control
    const float ScaleFactorPerSecond = 1;
    int scaleFactorSignMultiplier = 1;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // resize the game object
        Vector3 newScale = transform.localScale;

        // update timer and check if it's done
        elapsedResizeSeconds += Time.deltaTime;

        newScale.x += (scaleFactorSignMultiplier * ScaleFactorPerSecond) * Time.deltaTime;
        newScale.y += (scaleFactorSignMultiplier * ScaleFactorPerSecond) * Time.deltaTime;
        transform.localScale = newScale;

        if (elapsedResizeSeconds >= TotalResizeSeconds)
        {
            // reset timer and start resizing the game object
            // in the opposite direction
            elapsedResizeSeconds = 0;
            elapsedResizeSeconds += Time.deltaTime;

            scaleFactorSignMultiplier *= -1;
        }


    }
}
