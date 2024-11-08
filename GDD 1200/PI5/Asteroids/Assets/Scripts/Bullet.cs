using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this script is going to make our bullet move
/// </summary>
public class Bullet : MonoBehaviour
{
    ///<summary>
    ///setting our rb2d component and gameobject component
    /// </summary>
    Rigidbody2D rb2d;
    Timer deathTimer;
    const float timeDeath = 1f;

    ///<sumamry>
    ///retreiving the rigidbody2d compnent from the object
    ///getting and setting the "death timer" for our bullet
    /// </sumamry>
    public void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();

        //timer details
        deathTimer = GetComponent<Timer>();
        deathTimer.Duration = timeDeath;
        deathTimer.Run();
    }

    /// <summary>
    /// here, were gonna check if the timer is done
    /// and destroy the bullet if it is
    /// </summary>
    public void Update()
    {
        if (deathTimer.Finished == true)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// this is going to be the moethod to apply force to
    /// the bullet based on the direction its facing
    /// </summary>
    /// <param name="direction">the direction the bullet faces</param>
    public void ApplyForce(Vector2 direction)
    {
        //have a constant int for how fast our bullet goes
        const int magnitude = 10;

        //use addforce method for rb2d to get bullet moving
        rb2d.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }
}
