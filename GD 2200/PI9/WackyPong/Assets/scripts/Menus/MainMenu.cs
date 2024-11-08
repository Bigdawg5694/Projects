using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    OnePlayerEvent onePlayer;
    TwoPlayerEvent twoPlayer;

    /// <summary>
    /// to add the new events and
    /// make this script the invoker for those events
    /// </summary>
    private void Start()
    {
        onePlayer = new OnePlayerEvent();
        twoPlayer = new TwoPlayerEvent();
        EventManager.AddOnePlayerEventInvoker(this);
        EventManager.AddTwoPlayerEventInvoker(this);
    }

    /// <summary>
    /// goes to the help menu
    /// </summary>
    public void ShowHelp()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// takes player to gameplay scene
    /// </summary>
    public void StartTwoPlayerGame()
    {
        twoPlayer.Invoke();
    }

    /// <summary>
    /// takes player to the difficulty menu
    /// </summary>
    public void StartOnePlayerGame()
    {
        onePlayer.Invoke();
    }

    /// <summary>
    /// quits the game
    /// </summary>
    public void ExitGame()
    {
        MenuManager.GoToMenu(MenuName.Quit);
    }

    /// <summary>
    /// Takes player back to main menu
    /// </summary>
    public void GoToMainMenu()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }

    /// <summary>
    /// adds listener to one player event
    /// </summary>
    /// <param name="handler">listener</param>
    public void AddOnePlayerEventListener(UnityAction handler)
    {
        onePlayer.AddListener(handler);
    }

    /// <summary>
    /// adds listener to two player event
    /// </summary>
    /// <param name="handler">listener</param>
    public void AddTwoPlayerEventListener(UnityAction handler)
    {
        twoPlayer.AddListener(handler);
    }
}
