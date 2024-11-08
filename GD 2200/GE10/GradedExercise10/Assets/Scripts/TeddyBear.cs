using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeddyBear : MonoBehaviour
{
	#region Methods

	public void Awake()
	{
		EventManager.AddDestroyEventListener(HandleDestroyEvent);
	}

	void HandleDestroyEvent()
	{
		Destroy(gameObject);
	}

	#endregion
}
