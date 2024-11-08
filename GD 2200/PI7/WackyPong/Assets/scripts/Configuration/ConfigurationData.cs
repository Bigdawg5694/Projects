using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "WackyPongData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static int standardPoints = 1;
    static int standardHits = 1;
    static float ballLifeSeconds = 10;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;
    static int bonusPoints = 2;
    static int bonusHits = 2;
    static int standardPercent = 60;
    static int bonusPercent = 20;
    static int freezePercent = 10;
    static int speedupPecent = 10;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the number of points a standard ball is worth
    /// </summary>
    public int StandardPoints
    {
        get { return standardPoints; }
    }

    /// <summary>
    /// Gets the number of hits a standard ball is worth
    /// </summary>
    public int StandardHits
    {
        get { return standardHits; }
    }

    /// <summary>
    /// Gets how many seconds a ball stays alive
    /// </summary>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

	/// <summary>
	/// Gets minimum spawn time for ball
	/// </summary>
	public float MinSpawnTime
	{
		get { return minSpawnTime; }
	}

	/// <summary>
	/// Gets maximum spawn time for ball
	/// </summary>
	public float MaxSpawnTime
	{
		get { return maxSpawnTime; }
	}

    /// <summary>
    /// Gets the number of hits a bonus ball is worth
    /// </summary>
    public int BonusHits
    {
        get { return bonusHits; }
    }

    /// <summary>
    /// Gets the number of points a bonus ball is worth
    /// </summary>
    public int BonusPoints
    {
        get { return bonusPoints; }
    }

    /// <summary>
    /// This is for the percentage a standard ball will spawn
    /// </summary>
    public int StandardPercent
    {
        get { return standardPercent; }
    }

    /// <summary>
    /// This is for the percentage a bonus ball will spawn
    /// </summary>
    public int BonusPercent
    {
        get { return bonusPercent; }
    }

    /// <summary>
    /// This is for the percentage a freeze ball will spawn
    /// </summary>
    public int FreezePercent
    {
        get { return freezePercent; }
    }

    /// <summary>
    /// This is for the percentage a speedup ball will spawn
    /// </summary>
    public int SpeedupPercent
    {
        get { return speedupPecent; }
    }

	#endregion

	#region Constructor

	/// <summary>
	/// Constructor
	/// Reads configuration data from a file. If the file
	/// read fails, the object contains default values for
	/// the configuration data
	/// </summary>
	public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

	#endregion

	#region SetDataFields

	/// <summary>
	/// Sets the configuration data fields from the provided
	/// csv string
	/// </summary>
	/// <param name="csvValues">csv string of values</param>
	void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        standardPoints = int.Parse(values[2]);
        standardHits = int.Parse(values[3]);
        ballLifeSeconds = float.Parse(values[4]);
        minSpawnTime = float.Parse(values[5]);
        maxSpawnTime = float.Parse(values[6]);
        bonusPoints = int.Parse(values[7]);
        bonusHits = int.Parse(values[8]);
        standardPercent = int.Parse(values[9]);
        bonusPercent = int.Parse(values[10]);
        freezePercent = int.Parse(values[11]);
        speedupPecent = int.Parse(values[12]);
    }

	#endregion
}
