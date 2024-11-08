using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //calls rigidbody2d comp for easier access
    Rigidbody2D rb2d;

    /// <summary>
    /// Get our rigidbody component from game object
    /// </summary>
    public void Start()
    {
        //set our rb2d to the game objects rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Applies force to our bullets
    /// </summary>
    /// <param name="direction"></param>
    public void ApplyForce(Vector2 direction)
    {
        //setting our magnitude
        float magnitude = 5f;

        //adding force to the bullet itself, can be called in other scripts
        rb2d.AddForce(direction * magnitude, ForceMode2D.Impulse);
    }
    /// <summary>
    /// Collision for our bullet
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        //checks the tag of whatever we hit
        if (col.gameObject.tag == "TeddyBear")
        {
            //if its a bear, destroy both bullet and bear
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "MainCamera")
        {
            //destroys itself when colliding with our screen edge
            Destroy(gameObject);
        }
    }
}
