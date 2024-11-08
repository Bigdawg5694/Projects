using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
	#region Fields

	// fields for our destroy event
	static DestroyButton destroyEventInvoker;
	static UnityAction destroyEventListener;

	#endregion

	#region Methods

	/// <summary>
	/// add destroy event invoker
	/// </summary>
	/// <param name="invoker"></param>
	public static void AddDestroyEventInvoker(DestroyButton invoker)
	{
		destroyEventInvoker = invoker;
		if (destroyEventListener != null)
		{
			destroyEventInvoker.AddDestroyEventListener(destroyEventListener);
		}	
	}

	/// <summary>
	/// add destroy event listener
	/// </summary>
	/// <param name="listener"></param>
	public static void AddDestroyEventListener(UnityAction listener)
	{
		destroyEventListener = listener;
		if (destroyEventListener != null)
		{
			destroyEventInvoker.AddDestroyEventListener(destroyEventListener);
		}
	}
	#endregion
}
