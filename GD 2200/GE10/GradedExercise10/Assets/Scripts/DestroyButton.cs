using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DestroyButton : MonoBehaviour
{
	#region Fields

	DestroyEvent destroyEvent;

	#endregion

	#region Methods

	void Awake()
	{
		destroyEvent = new DestroyEvent();
		EventManager.AddDestroyEventInvoker(this);
	}

	public void AddDestroyEventListener(UnityAction listener)
	{
		destroyEvent.AddListener(listener);
	}

	public void HandleButtonClicked()
	{
		destroyEvent.Invoke();
	}

	#endregion
}
