using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
	#region Fields

	// these are the lists for the invokers and listeners
	static List<Ball> ballLostInvokerList
		= new List<Ball>();
	static List<UnityAction<int, ScreenSide>> ballLostListenerList
		= new List<UnityAction<int, ScreenSide>>();

	// this is going to make a list for the paddles
	// (since we have more than one)
	static List<Paddle> hitsAddedInvokerList = new List<Paddle>();
	static List<UnityAction<ScreenSide, int>> hitsAddedListenerList = new List<UnityAction<ScreenSide, int>>();
	
	#endregion

	#region Methods

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

}
