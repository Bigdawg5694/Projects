﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force for the ball
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    ///<summary>
    ///Gets the standard hits for the ball
    /// </summary>
    public static int StandardBall
    {
        get { return configurationData.StandardBall;}
    }

    /// <summary>
    /// Gets the number for the total lifetime of the ball
    /// </summary>
    public static float BallLifetime
    {
        get { return configurationData.BallLifetime; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
