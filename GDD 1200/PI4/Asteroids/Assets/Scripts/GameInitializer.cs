using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Initalizes ScreenUitls so that we can use it later in code
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}
