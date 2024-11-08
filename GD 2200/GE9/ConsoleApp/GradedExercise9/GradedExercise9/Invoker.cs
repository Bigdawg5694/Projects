using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event invoker
/// </summary>
public class Invoker : MonoBehaviour
{
    // add your fields for your message event support here
    MessageEvent messageEvent;

    // add your fields for your count message event support here
    int countMessage;
    CountMessageEvent countMessageEvent;

    //timer
    Timer timer;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    public void Awake()
    {
		// add your code here
		messageEvent = new MessageEvent();
        countMessageEvent = new CountMessageEvent();
	}

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
	{
        // add self as event invoker
        EventManager.AddNoArgumentInvoker(this);
        EventManager.AddIntArgumentInvoker(this);

        // add a timer component
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1.0f;
        timer.Run();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// check to see if timer is finished
		if (timer.Finished)
        {
            // invoke no argument event
            InvokeNoArgumentEvent();

            // invoke count argument event
            InvokeOneArgumentEvent(countMessage++);

            //run timer again
            timer.Run();
        }
	}

    /// <summary>
    /// Adds the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddNoArgumentListener(UnityAction listener)
    {
        // add your code here to add the given listener for
        // the message event
        messageEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddOneArgumentListener(UnityAction<int> listener)
    {
        // add your code here to add the given listener for
        // the count message event
        countMessageEvent.AddListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveNoArgumentListener(UnityAction listener)
    {
        // remove the given listener from the
        // message event
        messageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveOneArgumentListener(UnityAction<int> listener)
    {
        // remove the given listener from the
        // count message event
        countMessageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Invokes the no argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    public void InvokeNoArgumentEvent()
    {
        // add your code here to invoke the message event
        messageEvent.Invoke();
    }

    /// <summary>
    /// Invokes the one argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    /// <param name="argument">argument to use for the Invoke</param>
    public void InvokeOneArgumentEvent(int argument)
    {
        // add your code here to invoke the count message event
        // with the given argument
        countMessageEvent.Invoke(argument);
    }
}
