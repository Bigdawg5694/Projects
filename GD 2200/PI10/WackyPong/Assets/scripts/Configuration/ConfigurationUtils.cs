using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    // makes an object for our config data
    static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving
    /// </summary>
    public static float BallImpulseForce
    {
        get { return DifficultyUtils.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the number of points a standard ball is worth
    /// </summary>
    public static int StandardPoints
    {
        get { return configurationData.StandardPoints; }
    }

    /// <summary>
    /// Gets the number of hits a standard ball is worth
    /// </summary>
    public static int StandardHits
    {
        get { return configurationData.StandardHits; }
    }

    /// <summary>
    /// Gets how many seconds a ball stays alive
    /// </summary>
    public static float BallLifeSeconds
    {
        get { return configurationData.BallLifeSeconds; }
    }

	/// <summary>
	/// Gets minimum spawn time for ball
	/// </summary>
	public static float MinSpawnTime
	{
		get { return DifficultyUtils.MinSpawnTime; }
	}

	/// <summary>
	/// Gets maximum spawn time for ball
	/// </summary>
	public static float MaxSpawnTime
	{
		get { return DifficultyUtils.MaxSpawnTime; }
	}

    /// <summary>
    /// Gets the number of hits a bonus ball is worth
    /// </summary>
    public static int BonusHits
    {
        get { return configurationData.BonusHits; }
    }

    /// <summary>
    /// Gets the number of points a bonus ball is worth
    /// </summary>
    public static int BonusPoints
    {
        get { return configurationData.BonusPoints; }
    }

    /// <summary>
    /// Gets the percentage a standard ball will spawn
    /// </summary>
    public static int StandardPercent
    {
        get { return configurationData.StandardPercent; }
    }

    /// <summary>
    /// Gets the percentage a bonus ball will spawn
    /// </summary>
    public static int BonusPercent
    {
        get { return configurationData.BonusPercent; }
    }

    /// <summary>
    /// Gets the percentage a freeze ball will spawn
    /// </summary>
    public static int FreezePercent
    {
        get { return configurationData.FreezePercent; }
    }

    /// <summary>
    /// Gets the percentage a speedup ball will spawn
    /// </summary>
    public static int SpeedupPercent
    {
        get { return configurationData.SpeedupPercent; }
    }

    /// <summary>
    /// Gets the duration for our freeze effect
    /// </summary>
    public static float FreezeDuration
    {
        get { return configurationData.FreezeDuration; }
    }

    /// <summary>
    /// Gets the speedupfactor for our balls
    /// </summary>
    public static int SpeedupFactor
    {
        get { return configurationData.SpeedupFactor;}
    }

    /// <summary>
    /// Gets how long the speedup effect will last
    /// </summary>
    public static float SpeedupDuration
    {
        get { return configurationData.SpeedupDuration; }
    }

    /// <summary>
    /// gets the easy impulse for the ball
    /// </summary>
    public static float EasyImpulse
    {
        get { return configurationData.EasyImpulse; }
    }

    /// <summary>
    /// gets the medium impulse for the ball
    /// </summary>
    public static float MediumImpulse
    {
        get { return configurationData.MediumImpulse; }
    }

    /// <summary>
    /// gets the hard impulse for the ball
    /// </summary>
    public static float HardImpulse
    {
        get { return configurationData.HardImpulse; }
    }

    /// <summary>
    /// gets the easy min spawn time
    /// </summary>
    public static float EasyMinSpawn
    {
        get { return configurationData.EasyMinSpawn; }
    }

    /// <summary>
    /// gets the medium min spawn time
    /// </summary>
    public static float MediumMinSpawn
    {
        get { return configurationData.MediumMinSpawn; }
    }

    /// <summary>
    /// gets the hard min spawn time
    /// </summary>
    public static float HardMinSpawn
    {
        get { return configurationData.HardMinSpawn; }
    }

    /// <summary>
    /// gets the easy max spawn time
    /// </summary>
    public static float EasyMaxSpawn
    {
        get { return configurationData.EasyMaxSpawn; }
    }

    /// <summary>
    /// gets the medium max spawn time
    /// </summary>
    public static float MediumMaxSpawn
    {
        get { return configurationData.MediumMaxSpawn; }
    }

    /// <summary>
    /// gets the hard max spawn time
    /// </summary>
    public static float HardMaxSpawn
    {
        get { return configurationData.HardMaxSpawn; }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
	#endregion
}
