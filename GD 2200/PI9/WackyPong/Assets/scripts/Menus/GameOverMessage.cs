using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameOverMessage : MonoBehaviour
{
    #region Fields

    // this is to set an TMPro to show the winner text
    [SerializeField]
    public TextMeshProUGUI winnerText;

    string winnerName;
    #endregion

    #region Methods

    // Start is called before the first frame update
    public void Start()
    {
        // stops the game and gets GameOver screen to appear
        Time.timeScale = 0;
    }

    /// <summary>
    /// finds out who is the winner of the game,
    /// and sets it for the message
    /// </summary>
    public void SetWinner(ScreenSide winningSide)
    {
        // display the winners name/description in winnerText
        if (winningSide == ScreenSide.Left)
        {
            winnerName = "Player 1";
        }
        else
        {
            winnerName = "Player 2";
        }
        winnerText.text = "Winner: " + winnerName;
    }

    /// <summary>
    /// quits to the main menu from game over screen
    /// </summary>
    public void QuitButtonPress()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
    #endregion
}
