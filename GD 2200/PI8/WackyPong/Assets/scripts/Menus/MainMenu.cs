using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        MenuManager.GoToMenu(MenuName.Mulitplayer);
    }
    public void GoToDifficultyMenu()
    {

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
}
