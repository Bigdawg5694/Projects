using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyMenu : MonoBehaviour
{
    #region Fields

    // make a game started event field
    GameStartedEvent gameStartedEvent;

    #endregion

    #region Public Methods

    /// <summary>
    /// start method for this script
    /// </summary>
    public void Start()
    {
        gameStartedEvent = new GameStartedEvent();
        EventManager.AddGameStartedEventInvoker(this);
    }

    #endregion

    #region Start Game Methods

    /// <summary>
    /// Starts an easy game
    /// </summary>
    public void StartEasyGame()
    {
        gameStartedEvent.Invoke(Difficulty.Easy);
        AudioManager.Play(AudioClipName.ButtonSound);
    }

    /// <summary>
    /// starts a medium game
    /// </summary>
    public void StartMediumGame()
    {
        gameStartedEvent.Invoke(Difficulty.Medium);
        AudioManager.Play(AudioClipName.ButtonSound);
    }

    /// <summary>
    /// starts a hard game
    /// </summary>
    public void StartHardGame()
    {
        gameStartedEvent.Invoke(Difficulty.Hard);
        AudioManager.Play(AudioClipName.ButtonSound);
    }

    #endregion

    #region Event Support

    /// <summary>
    /// adds a listener to the game started event
    /// </summary>
    /// <param name="handler">the event for game started event</param>
    public void AddGameStartedEventListener(UnityAction<Difficulty> handler)
    {
        gameStartedEvent.AddListener(handler);
    }

    #endregion
}
