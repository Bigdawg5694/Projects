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
			//create stream reader object
			input = File.OpenText(Path.Combine(
				Application.streamingAssetsPath, ConfigurationDataFileName));

			//reads both lines, and outs them into their respective lists
			string names = input.ReadLine();
			string values = input.ReadLine();

			//set config data fields
			SetConfigurationDataFields(values);
		}
		catch (Exception e)
		{
		}
		finally
		{
			if (input != null)
			{
				input.Close();
			}
		}
	}

	/// <summary>
	/// Sets the configuration data fields from the provided
	/// csv string
	/// </summary>
	/// <param name="csvValues">csv string of values</param>
	static void SetConfigurationDataFields(string csvValues)
	{
		// this code uses the split method to get our values
		string[] values = csvValues.Split(',');

		//this code applies our values to their respective variables
		paddleMoveUnitsPerSecond = float.Parse(values[0]);
		ballImpulseForce = float.Parse(values[1]);
	}
	#endregion
}
