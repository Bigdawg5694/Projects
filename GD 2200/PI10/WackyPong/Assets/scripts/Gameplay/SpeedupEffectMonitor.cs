using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{

    #region Fields

    // make a timer field for this class
    Timer speedupEffectTimer;

    // make an int for the speedup factor found through our config files
    float speedupFactor = 1;

    #endregion

    #region Properties

    /// <summary>
    /// gets whether our speedup effect is active or not
    /// </summary>
    public bool SpeedupActive
    {
        get { return speedupEffectTimer.Running; }
    }

    /// <summary>
    /// gets the speedup factor
    /// </summary>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// gets the remaining time on the timer
    /// </summary>
    public float SpeedupEffectSecondsLeft
    {
        get { return speedupEffectTimer.RemainingTime; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // makes a timer for the speedupEffect
        speedupEffectTimer = gameObject.AddComponent<Timer>();

        // this adds the event listener for the effect timer
        // when it is done
        speedupEffectTimer.AddTimerFinishedEventListener(SpeedupEffectTimerFinished);

        // use event manager to add SpeedupEffectTimer as a listener
        // to SpeedupEffectEvent
        EventManager.AddSpeedupEffectEventListener(SpeedupEffect);
    }

    /// <summary>
    /// this is a timer for the Speedup Effect,
    /// and it will keep track of how long the effect
    /// has left
    /// </summary>
    /// <param name="duration">timer duration</param>
    /// <param name="speedup">speedup factor</param>
    void SpeedupEffect(float duration, float speedup)
    {
        if (!speedupEffectTimer.Running)
        {
            // sets the speedupfactor to the float provided in the event
            this.speedupFactor = speedup;

            // set the duratiopin of our timer
            speedupEffectTimer.Duration = duration;

            // run the timer
            speedupEffectTimer.Run();
        }
        else
        {
            // adds time if effect is active
            speedupEffectTimer.AddTime(duration);
        }

    }

    /// <summary>
    /// This is the listener for when the timer is finished
    /// </summary>
    void SpeedupEffectTimerFinished()
    {
        // returns ball to normal speed
        speedupEffectTimer.Stop();
        speedupFactor = 1;
        AudioManager.Play(AudioClipName.SpeedupDeactivateSound);
    }

    #endregion
}
