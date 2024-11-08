using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
	int leftScore = 0;
	int rightScore = 0;

	// hits text support
	const string HitsPrefix = "Hits: ";
	int leftHits = 0;
	int rightHits = 0;

	#endregion

	#region Public methods

	/// <summary>
	/// Adds the given points to the given side
	/// </summary>
	/// <param name="side">screen side</param>
	/// <param name="points">points to add</param>
	public void AddPoints(ScreenSide side, int points)
	{
		// add points and change text
		if (side == ScreenSide.Left)
		{
			leftScore += points;
		}
		else
		{
			rightScore += points;
		}
		scoreText.text = leftScore + ScoreSeparator + rightScore;
	}

	/// <summary>
	/// Adds the given hits to the given side
	/// </summary>
	/// <param name="side">screen side</param>
	/// <param name="hits">hits to add</param>
	public void AddHits(ScreenSide side, int hits)
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

	#endregion
}