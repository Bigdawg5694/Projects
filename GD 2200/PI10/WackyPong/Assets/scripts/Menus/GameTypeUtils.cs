using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameTypeUtils
{

    #region Fields

    static GameType gameType;

    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddOnePlayerEventListener(HandleOnePlayerEvent);
        EventManager.AddTwoPlayerEventListener(HandleTwoPlayerEvent);
    }

    #endregion

    #region Properties

    /// <summary>
    /// gets the number of players
    /// </summary>
    public static GameType PlayerNumber
    {
        get { return gameType; }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles when the oneplayer button is clicked
    /// </summary>
    static void HandleOnePlayerEvent()
    {
        gameType = GameType.OnePlayer;
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    /// <summary>
    /// Handles when the twoplayer button is clicked
    /// </summary>
    static void HandleTwoPlayerEvent()
    {
        gameType = GameType.TwoPlayer;
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    #endregion
}
