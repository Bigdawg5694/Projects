using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectBall : Ball
{
    #region Fields

    float duration;

    // setting a field for freezer effect activated
    FreezerEffectActivatedEvent freezeActive = new FreezerEffectActivatedEvent();

    // setting a field for speedup effect activated
    SpeedupEventActivatedEvent speedupActive = new SpeedupEventActivatedEvent();

    #endregion

    #region public Methods

    /// <summary>
    /// method the effect ball will run when spawned in
    /// </summary>
    new public virtual void Start()
    {
        // call the parent start method for movement
        base.Start();

        // setting all events and timers for freeze effect
        // if the balltype is freeze
        if (type == BallType.Freeze)
        {
            duration = ConfigurationUtils.FreezeDuration;
            // add this script as an event invoker for freeze
            EventManager.AddFreezeEffectEventInvoker(this);
        }
        // setting all events and timers to speedup effect
        // if the balltype is speedup
        else if (type == BallType.SpeedUp)
        {
            duration = ConfigurationUtils.SpeedupDuration;
            // add this script as an event invoker for speedup
            EventManager.AddSpeedupEffectEventInvoker(this);
        }
    }

    /// <summary>
    /// method for adding a listener for the freeze activated event
    /// </summary>
    /// <param name="handler"></param>
    public void AddFreezeEffectListener(UnityAction<ScreenSide, float> handler)
    {
        freezeActive.AddListener(handler);
    }

    /// <summary>
    /// adds a listener to the speedup activated event
    /// </summary>
    /// <param name="handler"></param>
    public void AddSpeedupEffectListener(UnityAction<float, float> handler)
    {
        speedupActive.AddListener(handler);
    }

    /// <summary>
    /// initiates the balls effect when colliding with a paddle
    /// </summary>
    /// <param name="col">collision of effectball</param>
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LeftPaddle" || col.gameObject.tag == "RightPaddle")
        {
            // checks if type is freeze
            if (type == BallType.Freeze)
            {
                // checks which side collided with te effect ball
                if (col.gameObject.tag == "LeftPaddle")
                {
                    // invoke freezeactive event for right paddle
                    freezeActive.Invoke(ScreenSide.Right, duration);
                }
                if (col.gameObject.tag == "RightPaddle")
                {
                    // invoke freezeactive event for left paddle
                    freezeActive.Invoke(ScreenSide.Left, duration);

                }
                AudioManager.Play(AudioClipName.FreezerSound);
            }
            //checks if type is speedup
            else if (type == BallType.SpeedUp)
            {
                // invoke speedup event
                speedupActive.Invoke(duration, ConfigurationUtils.SpeedupFactor);
                AudioManager.Play(AudioClipName.SpeedupSound);
            }
            // invoke balldied event
            ballDiedEvent.Invoke();

            //Destroy self
            Destroy(gameObject);
        }
    }

    #endregion
}
