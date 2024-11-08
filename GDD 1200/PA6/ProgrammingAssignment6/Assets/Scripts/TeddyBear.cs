using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A teddy bear
/// </summary>
public class TeddyBear : MonoBehaviour
{
	/// <summary>
	/// When our teddybear spawns in, this sets 
    /// the force and direction the bear is going
	/// </summary>
    void Start()
    {	
        //we are setting our min and max impulse force
        //to randomize our teddy's speed
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;

        //get a random angle
        float angle = Random.Range(0, 2 * Mathf.PI);

        //this converts our angle into a direction through
        //sin and cos
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));

        //randomize our magnitude through the impulse force variables above
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        //using AddForce to get our bear moving in the randomized direction
        //at a randomized speed
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
    }
    /// <summary>
    /// For when the bear collides with our turret
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        //check if the bear collided with the turret
        if (col.gameObject.tag == "Turret")
        {
            //Destroy the turret
            Destroy(col.gameObject);
        }
    }
}
