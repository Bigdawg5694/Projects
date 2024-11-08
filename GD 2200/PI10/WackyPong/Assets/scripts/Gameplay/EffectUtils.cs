using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{

    #region Properties

    /// <summary>
    /// gets whether speedup is active or not
    /// </summary>
    public static bool SpeedupActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupActive; }
    }

    /// <summary>
    /// gets the speedup factor for the balls
    /// </summary>
    public static float SpeedupFactor
    {
        get { return GetSpeedupEffectMonitor().SpeedupFactor; }
    }

    /// <summary>
    /// gets the remaining time on the speedup timer
    /// </summary>
    public static float RemainingTime
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectSecondsLeft; }
    }

    #endregion

    #region Methods

    static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }

    #endregion
}
