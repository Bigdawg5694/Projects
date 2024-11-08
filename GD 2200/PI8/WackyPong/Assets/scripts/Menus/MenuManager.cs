using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	/// <summary>
	/// Goes to the menu with the given name
	/// </summary>
	/// <param name="name">name of the menu to go to</param>
	public static void GoToMenu(MenuName name)
	{
		switch (name)
		{
			case MenuName.Main:

				//go to MainMenu scene
				SceneManager.LoadScene("mainMenu");
				break;
			case MenuName.Help:

				//go to Help scene
				SceneManager.LoadScene("help");
                break;
			case MenuName.SinglePlayer:

                //go to Difficuly scene
                //SceneManager.LoadScene("Difficulty");
                break;
			case MenuName.Pause:

				//instantiate prefab
				Object.Instantiate(Resources.Load("pauseMenu"));
				break;
			case MenuName.Quit:

				//quits the application
				Application.Quit();
				break;
			case MenuName.Mulitplayer:

				//starts the game w/ two players
				SceneManager.LoadScene("gameplay");
				break;
		}
	}
}
