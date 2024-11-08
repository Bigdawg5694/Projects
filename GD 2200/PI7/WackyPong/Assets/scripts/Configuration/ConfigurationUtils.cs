using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

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
        get { return configurationData.BallImpulseForce; }
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
		get { return configurationData.MinSpawnTime; }
	}

	/// <summary>
	/// Gets maximum spawn time for ball
	/// </summary>
	public static float MaxSpawnTime
	{
		get { return configurationData.MaxSpawnTime; }
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
