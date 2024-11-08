using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// The HUD
/// </summary>
public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI leftHitsText;
    [SerializeField]
    TextMeshProUGUI rightHitsText;

    // score text support
    const string ScoreSeparator = " - ";
    public int leftScore = 0;
    public int rightScore = 0;

    // hits text support
    const string HitsPrefix = "Hits: ";
    int leftHits = 0;
    int rightHits = 0;

    // makes a playerwon event for the HUD
    PlayerWonEvent playerWonEvent;
	#endregion

	#region Public methods

    /// <summary>
    /// adds listeners to BallLostEvent
    /// and HitsAddedEvent
    /// </summary>
	public void Start()
	{
        playerWonEvent = new PlayerWonEvent();
        EventManager.AddBallLostEventListener(AddPoints);
        EventManager.AddHitsAddedEventListener(AddHits);
        EventManager.AddPlayerWonEventInvoker(this);
	}
	/// <summary>
	/// Adds the given points to the given side
	/// </summary>
	/// <param name="side">screen side</param>
	/// <param name="points">points to add</param>
	void AddPoints(int points, ScreenSide side)
    {
        // add points and change text
        if (side == ScreenSide.Left)
        {
            leftScore += points;
            // checks to see if score limit is reached
            if (leftScore >= 5)
            {
                // calls method to invoke playerwon event
                PlayerWon(ScreenSide.Left, leftScore);
            }
        }
        else
        {
            rightScore += points;
            if (rightScore >= 5)
            {
                PlayerWon(ScreenSide.Right, rightScore);
            }
        }
        scoreText.text = leftScore + ScoreSeparator + rightScore;
    }

    /// <summary>
    /// Adds the given hits to the given side
    /// </summary>
    /// <param name="side">screen side</param>
    /// <param name="hits">hits to add</param>
    void AddHits(ScreenSide side, int hits)
    {
        // add hits and change text
        if (side == ScreenSide.Left)
        {
            leftHits += hits;
            leftHitsText.text = HitsPrefix + leftHits;
        }
        else
        {
            rightHits += hits;
            rightHitsText.text = HitsPrefix + rightHits;
        }
    }

    /// <summary>
    /// adds a listener to playerwon event
    /// </summary>
    /// <param name="handler"></param>
    public void AddPlayerWonEventListener(UnityAction<ScreenSide, int> handler)
    {
        playerWonEvent.AddListener(handler);
    }

    /// <summary>
    /// this is to invoke the playerwon event when the score is reached
    /// </summary>
    /// <param name="side"></param>
    /// <param name="score"></param>
    public void PlayerWon(ScreenSide side, int score)
    {
        // invokes playerwon event
        playerWonEvent.Invoke(side, score);
        AudioManager.Play(AudioClipName.GameLostSound);
    }

    #endregion
}
