﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quadruples the width and height of the yellow teddy bear
/// Working with Xscale and Yscale
/// </summary>
public class YellowTeddyBear : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        // quadruple width and height
        Vector3 newScale = transform.localScale;

        newScale.x *= 4;
        newScale.y *= 4;

        transform.localScale = newScale;
    }

}
