using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
	#region Fields

	[SerializeField]
	GameObject rightPaddle;

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

		GameObject paddle = Instantiate(rightPaddle);
		// this checks if the gametype is one or two players
		if (GameTypeUtils.PlayerNumber == GameType.OnePlayer)
		{
			// makes rightPaddle a computer paddle if one player
			paddle.AddComponent<ComputerPaddle>();
			ComputerPaddle computerPaddle = paddle.GetComponent<ComputerPaddle>();
			computerPaddle.Side = ScreenSide.Right;
		}
		else if (GameTypeUtils.PlayerNumber == GameType.TwoPlayer)
		{
            // makes rightPaddle a human if two player
            paddle.AddComponent<HumanPaddle>();
            HumanPaddle humanPaddle = paddle.GetComponent<HumanPaddle>();
            humanPaddle.Side = ScreenSide.Right;
        }
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

	/// <summary>
	/// this is the listener to the playerwon event
	/// </summary>
	/// <param name="winner">winner</param>
	/// <param name="notused"></param>
	void EndGame(ScreenSide winner, int notused) 
	{
		GameObject gameOverMessage = Instantiate(gameOverMessagePrefab);
		GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
		gameOverMessageScript.SetWinner(winner);
    }

	#endregion
}
