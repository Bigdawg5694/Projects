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

    Dictionary<ConfiguartionDataValueName, float> values = 
        new Dictionary<ConfiguartionDataValueName, float>();
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return values[ConfiguartionDataValueName.PaddleMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return values[ConfiguartionDataValueName.BallImpulseForce]; }    
    }

    /// <summary>
    /// Gets the number of points a standard ball is worth
    /// </summary>
    public int StandardPoints
    {
        get { return (int)values[ConfiguartionDataValueName.StandardPoints]; }
    }

    /// <summary>
    /// Gets the number of hits a standard ball is worth
    /// </summary>
    public int StandardHits
    {
        get { return (int)values[ConfiguartionDataValueName.StandardHits]; }
    }

    /// <summary>
    /// Gets how many seconds a ball stays alive
    /// </summary>
    public float BallLifeSeconds
    {
        get { return values[ConfiguartionDataValueName.BallLifetime]; }
    }

	/// <summary>
	/// Gets minimum spawn time for ball
	/// </summary>
	public float MinSpawnTime
	{
		get { return values[ConfiguartionDataValueName.MinSpawnTime]; }
	}

	/// <summary>
	/// Gets maximum spawn time for ball
	/// </summary>
	public float MaxSpawnTime
	{
		get { return values[ConfiguartionDataValueName.MaxSpawnTime]; }
	}

    /// <summary>
    /// Gets the number of hits a bonus ball is worth
    /// </summary>
    public int BonusHits
    {
        get { return (int)values[ConfiguartionDataValueName.BonusHits]; }
    }

    /// <summary>
    /// Gets the number of points a bonus ball is worth
    /// </summary>
    public int BonusPoints
    {
        get { return (int)values[ConfiguartionDataValueName.BonusPoints]; }
    }

    /// <summary>
    /// This is for the percentage a standard ball will spawn
    /// </summary>
    public int StandardPercent
    {
        get { return (int)values[ConfiguartionDataValueName.StandardPercent]; }
    }

    /// <summary>
    /// This is for the percentage a bonus ball will spawn
    /// </summary>
    public int BonusPercent
    {
        get { return (int)values[ConfiguartionDataValueName.BonusPercent]; }
    }

    /// <summary>
    /// This is for the percentage a freeze ball will spawn
    /// </summary>
    public int FreezePercent
    {
        get { return (int)values[ConfiguartionDataValueName.FreezePercent]; }
    }

    /// <summary>
    /// This is for the percentage a speedup ball will spawn
    /// </summary>
    public int SpeedupPercent
    {
        get { return (int)values[ConfiguartionDataValueName.FreezePercent]; }
    }

    /// <summary>
    /// This is the duration of our freeze effect
    /// </summary>
    public float FreezeDuration
    {
        get { return values[ConfiguartionDataValueName.FreezeDuration]; }
    }

    /// <summary>
    /// this is how much our balls will speed up
    /// </summary>
    public int SpeedupFactor
    {
        get { return (int)values[ConfiguartionDataValueName.SpeedupFactor]; }
    }

    /// <summary>
    /// this is how long the speedup effect lasts
    /// </summary>
    public float SpeedupDuration
    {
        get { return values[ConfiguartionDataValueName.SpeedupDuration]; }
    }

    /// <summary>
    /// easy impulse value
    /// </summary>
    public float EasyImpulse
    {
        get { return values[ConfiguartionDataValueName.EasyImpulse]; }
    }

    /// <summary>
    /// medium impulse value
    /// </summary>
    public float MediumImpulse
    {
        get { return values[ConfiguartionDataValueName.MediumImpulse]; }
    }

    /// <summary>
    /// hard impulse value
    /// </summary>
    public float HardImpulse
    {
        get { return values[ConfiguartionDataValueName.HardImpulse]; }
    }

    /// <summary>
    /// easy max spawn value
    /// </summary>
    public float EasyMaxSpawn
    {
        get { return values[ConfiguartionDataValueName.EasyMaxSpawn]; }
    }

    /// <summary>
    /// medium max spawn value
    /// </summary>
    public float MediumMaxSpawn
    {
        get { return values[ConfiguartionDataValueName.MediumMaxSpawn]; }
    }

    /// <summary>
    /// hard max spawn value
    /// </summary>
    public float HardMaxSpawn
    {
        get { return values[ConfiguartionDataValueName.HardMaxSpawn]; }
    }

    /// <summary>
    /// easy min spawn value
    /// </summary>
    public float EasyMinSpawn
    {
        get { return values[ConfiguartionDataValueName.EasyMinSpawn]; }
    }

    /// <summary>
    /// medium min spawn value
    /// </summary>
    public float MediumMinSpawn
    {
        get { return values[ConfiguartionDataValueName.MediumMinSpawn]; }
    }

    /// <summary>
    /// hard min spawn value
    /// </summary>
    public float HardMinSpawn
    {
        get { return values[ConfiguartionDataValueName.HardMinSpawn]; }
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
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                // gets the name of vale in our csv file and adds it to the dictionary
                string[] tokens = currentLine.Split(",");
                ConfiguartionDataValueName valueName =
                    (ConfiguartionDataValueName)Enum.Parse(
                        typeof(ConfiguartionDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1])); ;
                currentLine = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            // set defualt values if something went wrong
            SetDefaultValues();
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
	/// Sets the configuration data fields to default values
	/// </summary>
	void SetDefaultValues()
    {
        // clear the dictionary and add default values
        values.Clear();
        values.Add(ConfiguartionDataValueName.PaddleMoveUnitsPerSecond, 10);
        values.Add(ConfiguartionDataValueName.BallImpulseForce, 5);
        values.Add(ConfiguartionDataValueName.StandardPoints, 1);
        values.Add(ConfiguartionDataValueName.StandardHits, 1);
        values.Add(ConfiguartionDataValueName.BallLifetime, 5);
        values.Add(ConfiguartionDataValueName.MinSpawnTime, 5);
        values.Add(ConfiguartionDataValueName.MaxSpawnTime, 10);
        values.Add(ConfiguartionDataValueName.BonusPoints, 2);
        values.Add(ConfiguartionDataValueName.BonusHits, 2);
        values.Add(ConfiguartionDataValueName.StandardPercent, 60);
        values.Add(ConfiguartionDataValueName.BonusPercent, 20);
        values.Add(ConfiguartionDataValueName.FreezePercent, 10);
        values.Add(ConfiguartionDataValueName.SpeedupPercent, 10);
        values.Add(ConfiguartionDataValueName.FreezeDuration, 2);
        values.Add(ConfiguartionDataValueName.SpeedupFactor, 2);
        values.Add(ConfiguartionDataValueName.SpeedupDuration, 2);
        values.Add(ConfiguartionDataValueName.EasyImpulse, 1);
        values.Add(ConfiguartionDataValueName.MediumImpulse, 2);
        values.Add(ConfiguartionDataValueName.HardImpulse, 3);
        values.Add(ConfiguartionDataValueName.EasyMaxSpawn, 10);
        values.Add(ConfiguartionDataValueName.MediumMaxSpawn, 5);
        values.Add(ConfiguartionDataValueName.HardMaxSpawn, 3);
        values.Add(ConfiguartionDataValueName.EasyMinSpawn, 5);
        values.Add(ConfiguartionDataValueName.MediumMinSpawn, 3);
        values.Add(ConfiguartionDataValueName.HardMinSpawn, 1);
    }

	#endregion
}
