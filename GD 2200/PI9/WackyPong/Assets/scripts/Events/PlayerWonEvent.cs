using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// event for when the score limit is reached
/// </summary>
public class PlayerWonEvent : UnityEvent <ScreenSide, int>
{
}
