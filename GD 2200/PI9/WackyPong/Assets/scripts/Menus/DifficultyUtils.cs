using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DifficultyUtils
{
    #region Fields

    // the difficulty enum used in this script
    static Difficulty difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving
    /// </summary>
    public static float BallImpulseForce
    {
        get
        {
            if (difficulty == Difficulty.Easy)
            {
                return ConfigurationUtils.EasyImpulse;
            }
            else if (difficulty == Difficulty.Medium)
            {
                return ConfigurationUtils.MediumImpulse;
            }
            else if (difficulty == Difficulty.Hard)
            {
                return ConfigurationUtils.HardImpulse;
            }
            else
            {
                return ConfigurationUtils.EasyImpulse;
            }
        }
    }

    /// <summary>
	/// Gets minimum spawn time for ball
	/// </summary>
	public static float MinSpawnTime
    {
        get 
        {
            if (difficulty == Difficulty.Easy)
            {
                return ConfigurationUtils.EasyMinSpawn;
            }
            else if (difficulty == Difficulty.Medium)
            {
                return ConfigurationUtils.MediumMinSpawn;
            }
            else if (difficulty == Difficulty.Hard)
            {
                return ConfigurationUtils.HardMinSpawn;
            }
            else
            {
                return ConfigurationUtils.EasyMinSpawn;
            }
        }
    }

    /// <summary>
	/// Gets maximum spawn time for ball
	/// </summary>
	public static float MaxSpawnTime
    {
        get 
        {
            if (difficulty == Difficulty.Easy)
            {
                return ConfigurationUtils.EasyMaxSpawn;
            }
            else if (difficulty == Difficulty.Medium)
            {
                return ConfigurationUtils.MediumMaxSpawn;
            }
            else if (difficulty == Difficulty.Hard)
            {
                return ConfigurationUtils.HardMaxSpawn;
            }
            else
            {
                return ConfigurationUtils.EasyMaxSpawn;
            }
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddGameStartedEventListener(HandleGameStartedEvent);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sets the difficulty and starts the game
    /// </summary>
    /// <param name="handler">game difficulty</param>
    static void HandleGameStartedEvent(Difficulty handler)
    {
        // sets the difficulty to the
        // difficulty enum that is being input
        // into this method
        difficulty = handler;

        // load the gameplay scene
        SceneManager.LoadScene("gameplay");
    }

    #endregion
}
