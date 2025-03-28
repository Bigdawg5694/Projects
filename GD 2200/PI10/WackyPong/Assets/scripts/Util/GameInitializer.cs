﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen, configuration, difficulty, and gametype utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
        DifficultyUtils.Initialize();
        GameTypeUtils.Initialize();
    }
}
