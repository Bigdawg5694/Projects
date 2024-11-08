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

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static int standardPoints = 1;
    static int standardHits = 1;
    static float ballLifeSeconds = 10;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;

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
    }
}
