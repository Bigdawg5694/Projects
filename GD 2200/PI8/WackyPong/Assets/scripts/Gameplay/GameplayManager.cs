using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
	#region Fields

	EffectBall freezerEffect;
	EffectBall speedupEffect;

	// this is for the gameovermessageprefab
	public GameObject gameOverMessagePrefab;

	#endregion

	#region Methods

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// add endgame method as listener to playerwon event
		EventManager.AddPlayerWonEventListener(EndGame);
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		//pause game on escape key
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuManager.GoToMenu(MenuName.Pause);
		}
	}

	void Freeze(ScreenSide side, Timer duration)
	{

	}
	void Speedup(Timer duration)
	{

	}

	/// <summary>
	/// this is the listener to the playerwon event
	/// </summary>
	/// <param name="side"></param>
	/// <param name="score"></param>
	void EndGame(ScreenSide unused, int notused) 
	{
        Object.Instantiate(gameOverMessagePrefab);
    }
	#endregion
}
