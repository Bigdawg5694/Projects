using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bouncer
/// </summary>
public class Bouncer : MonoBehaviour
{
    #region Fields

    // damage support
    int health = 100;
    const int CollisionDamage = 10;

    // transparency change support
    SpriteRenderer spriteRenderer;

    //GUI support
    GameObject hud;
    HUD hudScript;

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
		// get the bouncer moving
        GetComponent<Rigidbody2D>().AddForce(
            new Vector2(3, 2), ForceMode2D.Impulse);

        // save for efficiency
        spriteRenderer = GetComponent<SpriteRenderer>();

        //find our hud game object
        hud = GameObject.FindGameObjectWithTag("HUD");

        //call the hud script from hud object
        hudScript = hud.GetComponent<HUD>();
	}

    /// <summary>
    /// Update bounce count
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        // take damage and change transparency
        health -= CollisionDamage;
        Color color = spriteRenderer.color;
        color.a -= 0.1f;
        spriteRenderer.color = color;

        // die if appropriate
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //add a bounce to our UGI
        hudScript.AddBounce();
    }
}
