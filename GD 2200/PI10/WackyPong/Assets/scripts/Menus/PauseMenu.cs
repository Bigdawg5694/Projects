using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        //pause the game when added to scene
        Time.timeScale = 0;
    }
    /// <summary>
    /// handles when player clicks quit button on pause menu
    /// </summary>
    public void QuitGame()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
        AudioManager.Play(AudioClipName.ButtonSound);
    }

    /// <summary>
    /// handles when player clicks resume button 
    /// </summary>
    public void ResumeGame()
    {
        // unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
        AudioManager.Play(AudioClipName.ButtonSound);
    }
}
