using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A rock
/// </summary>
public class Rock : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
    {
        // randomly select impulse force to apply
        int forceDirection = (int)Random.Range(0, 4);

        if (forceDirection == 0)
        {
            // apply impulse force to get rock moving
            GetComponent<Rigidbody2D>().AddForce(
                new Vector2(5, 5),
                ForceMode2D.Impulse);
        } 
        else if (forceDirection == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(
                new Vector2(-5, 5),
                ForceMode2D.Impulse);
        }
        else if (forceDirection == 2)
        {
            GetComponent<Rigidbody2D>().AddForce(
                new Vector2(-5, -5),
                ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(
                new Vector2(5, -5),
                ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Called when the rock becomes invisible
    /// </summary>
    public void OnBecameInvisible()
    {
        // destroy rock
        Destroy(gameObject);
    }

    #region Autograder support



    #endregion
}
