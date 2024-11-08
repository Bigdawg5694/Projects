using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
	#region Fields

	// these are the lists for the ballLost invokers and listeners
	static List<Ball> ballLostInvokerList
		= new List<Ball>();
	static List<UnityAction<int, ScreenSide>> ballLostListenerList
		= new List<UnityAction<int, ScreenSide>>();

	// these are the lists for the ballDied invokers and listeners
	static List<Ball> ballDiedInvokerList 
		= new List<Ball>();
	static List <UnityAction> ballDiedListenerList 
		= new List<UnityAction>();

	// this is going to make a list for the paddles
	// (since we have more than one)
	static List<Paddle> hitsAddedInvokerList = new List<Paddle>();
	static List<UnityAction<ScreenSide, int>> hitsAddedListenerList = new List<UnityAction<ScreenSide, int>>();

	// makes an invoker and listener for playerwon event
	static HUD playerWonInvoker;
	static UnityAction<ScreenSide, int> playerWonListener;

	// makes a list of invokers and listeners for freezeeffect event
	static List<EffectBall> freezeBallInvokerList = new List<EffectBall>();
	static List<UnityAction<ScreenSide, float>> freezeBallListenerList =
		new List<UnityAction<ScreenSide, float>>();

	// makes a list of invokers and listeners for the speedup event
	static List<EffectBall> speedupBallInvokerList = new List<EffectBall>();
	static List<UnityAction<float, float>> speedupBallListenerList
		= new List<UnityAction <float, float>>();

	#endregion

	#region BallLostEvent support

	/// <summary>
	/// adds invokers for lost ball event
	/// </summary>
	/// <param name="invoker">invoker for event</param>
	public static void AddBallLostEventInvoker(Ball invoker)
	{
		// add invoker to list
        ballLostInvokerList.Add(invoker);

		// add listeners to every invoker
        foreach (UnityAction<int, ScreenSide> ballLostListener in ballLostListenerList)
		{
			invoker.AddBallLostEventListener(ballLostListener);
		}
	}

	/// <summary>
	/// adds listener for last ball event
	/// </summary>
	/// <param name="handler">listener for event</param>
	public static void AddBallLostEventListener(UnityAction<int, ScreenSide> handler)
	{
		// add listener to list
        ballLostListenerList.Add(handler);

		// adds listeners to each invoker
        foreach (Ball ballLostInvoker in ballLostInvokerList)
        {
			ballLostInvoker.AddBallLostEventListener(handler);
		}
	}

    #endregion

    #region BallDiedEvent support

    /// <summary>
    /// adds invokers for lost ball event
    /// </summary>
    /// <param name="invoker">invoker for event</param>
    public static void AddBallDiedEventInvoker(Ball invoker)
    {
        // add invoker to list
        ballDiedInvokerList.Add(invoker);

        // add listeners to every invoker
        foreach (UnityAction ballDiedListener in ballDiedListenerList)
        {
            invoker.AddBallDiedEventListener(ballDiedListener);
        }
    }

    /// <summary>
    /// adds listener for last ball event
    /// </summary>
    /// <param name="handler">listener for event</param>
    public static void AddBallDiedEventListener(UnityAction handler)
    {
        // add listener to list
        ballDiedListenerList.Add(handler);

        // adds listeners to each invoker
        foreach (Ball ballDiedInvoker in ballDiedInvokerList)
        {
            ballDiedInvoker.AddBallDiedEventListener(handler);
        }
    }

    #endregion

    #region HitsAddedEvent support

    /// <summary>
    /// adds invoker for addhits event
    /// </summary>
    /// <param name="invoker">invoker for event</param>
    public static void AddHitsAddedEventInvoker(Paddle invoker)
	{
		// add invoker to list
        hitsAddedInvokerList.Add(invoker);

		// add listeners to each invoker
        foreach (UnityAction<ScreenSide, int> hitsAddedListener in hitsAddedListenerList)
        {
            invoker.AddHitsAddedEventListener(hitsAddedListener);
        }
    }

	/// <summary>
	/// adds listener for addhits event
	/// </summary>
	/// <param name="handler">listener for event</param>
	public static void AddHitsAddedEventListener(UnityAction<ScreenSide, int> handler)
	{
		// add listeners to list
        hitsAddedListenerList.Add(handler);

		// adds invokers to each listener
        foreach (Paddle hitsAddedInvoker in hitsAddedInvokerList)
        {
            hitsAddedInvoker.AddHitsAddedEventListener(handler);
        }
    }

    #endregion

    #region PlayerWonEvent support

    /// <summary>
    /// adds an invoker to playerwon event
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPlayerWonEventInvoker(HUD invoker)
	{
		playerWonInvoker = invoker;
		if (playerWonListener != null)
		{
			invoker.AddPlayerWonEventListener(playerWonListener);
		}
	}

	/// <summary>
	/// adds a listener to playerwon event
	/// </summary>
	/// <param name="listener"></param>
	public static void AddPlayerWonEventListener(UnityAction<ScreenSide, int> listener)
	{
		playerWonListener = listener;
        if (playerWonInvoker != null)
        {
            playerWonInvoker.AddPlayerWonEventListener(listener);
        }
    }

    #endregion

    #region FreezeEffectEvent support

	/// <summary>
	/// adds freezeeffect invoker to list
	/// </summary>
	/// <param name="invoker"></param>
    public static void AddFreezeEffectEventInvoker(EffectBall invoker)
	{
		freezeBallInvokerList.Add(invoker);
		foreach (UnityAction<ScreenSide, float> freezeBallListener in freezeBallListenerList)
		{
			invoker.AddFreezeEffectListener(freezeBallListener);
		}
	}

	/// <summary>
	/// adds freezeeffect listener to list
	/// </summary>
	/// <param name="listener"></param>
	public static void AddFreezeEffectEventListener(UnityAction<ScreenSide, float> listener)
	{
		freezeBallListenerList.Add(listener);
		foreach (EffectBall freezeBallInvoker in freezeBallInvokerList)
		{
			freezeBallInvoker.AddFreezeEffectListener(listener);
		}
	}

    #endregion

    #region SpeedupEffectEvent support

	/// <summary>
	/// add speedupeffect invoker to list
	/// </summary>
	/// <param name="invoker"></param>
    public static void AddSpeedupEffectEventInvoker(EffectBall invoker)
    {
        speedupBallInvokerList.Add(invoker);
        foreach (UnityAction<float, float> speedupBallListener in speedupBallListenerList)
        {
            invoker.AddSpeedupEffectListener(speedupBallListener);
        }
    }

	/// <summary>
	/// add speedupeffect listener to list
	/// </summary>
	/// <param name="listener"></param>
    public static void AddSpeedupEffectEventListener(UnityAction<float, float> listener)
    {
        speedupBallListenerList.Add(listener);
        foreach (EffectBall speedupBallInvoker in speedupBallInvokerList)
        {
            speedupBallInvoker.AddSpeedupEffectListener(listener);
        }
    }

    #endregion

}
