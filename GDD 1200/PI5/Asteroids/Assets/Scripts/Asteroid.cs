using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    ///<summary>
    ///we are setting a rb2d var to rigidbody2d
    /// </summary>

    //set our rigidbidy2d var
    Rigidbody2D rb2d;

    //set our moveDirection to 0 to refernce later in code
    Vector2 moveDirection = new Vector2(0, 0);

    //make constants for magnitude randomizer
    const float MinImpulseForce = 1f;
    const float MaxImpulseForce = 1.5f;

    /// <summary>
    /// this method allows us to get a random directiton and force
    /// and apply it to the asteroid
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="location"></param>
    public void Initialize(Direction dir, Vector3 location)
    {
        //random angle between 75 degrees and 105 degrees (90 degrees is up)
        float angleUp = Random.Range(75f * Mathf.Deg2Rad, 105f * Mathf.Deg2Rad);

        //random angle between 255 and 285 degrees (270 is down)
        float angleDown = Random.Range(255f * Mathf.Deg2Rad, 285f * Mathf.Deg2Rad);

        //random angle between 165 and 195 degrees (180 degrees is left)
        float angleLeft = Random.Range(165f * Mathf.Deg2Rad, 195f * Mathf.Deg2Rad);

        //random angle between -15 and 15 degrees (0 degrees is right)
        float angleRight = Random.Range(-15f * Mathf.Deg2Rad, 15f * Mathf.Deg2Rad);

        //make integer for direction based on where the asteroid spawns
        Direction spawnDirection = dir;

        //moves asteroid to the location given
        gameObject.transform.position = location;

        //spawnDirection determines what direction the asteroid will move
        if (spawnDirection == Direction.Left)
        {
            StartMoving(angleLeft);
        }else if (spawnDirection == Direction.Up)
        {
            StartMoving(angleUp);
        }else if (spawnDirection == Direction.Right)
        {
            StartMoving(angleRight);
        }else
        {
            StartMoving(angleDown);
        }
    }

    ///<summary>
    ///this method is going to be when our asteroid collides with a bullet
    /// </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        //this checks the game object we collide with for the bullet tag
        if (col.gameObject.tag == "Bullet")
        {
            //destroys the bullet
            Destroy(col.gameObject);

            //plays destruction audio
            AudioManager.Play(AudioClipName.AsteroidHit);

            if (transform.localScale.x >= 0.5) 
            {
                //get scale of asteroid in a Vector3 variable
                Vector3 astScale = transform.localScale;

                //set the x and y of that Vector3 to another variable
                float astScaleX = astScale.x;
                float astScaleY = astScale.y;

                //divide those x and y variables by 2
                astScaleX = (astScaleX / 2);
                astScaleY = (astScaleY / 2);

                //set the new number from those variables to our Vector3 variabale
                astScale = new Vector3(astScaleX, astScaleY, astScale.z);

                //set the asteroids scale to that scale
                transform.localScale = astScale;

                //get the radius for the collider
                float radius2d = GetComponent<CircleCollider2D>().radius;

                //divides it in half
                radius2d = (radius2d / 2);

                //applies new radius to the circlecollider2d
                GetComponent<CircleCollider2D>().radius = radius2d;

                //Instantiate another asteroid with same scale size
                GameObject asteroidClone = Instantiate(gameObject, transform.position, transform.rotation);
                GameObject asteroidClone2 = Instantiate(gameObject, transform.position, transform.rotation);

                asteroidClone.transform.localScale = astScale;
                asteroidClone2.transform.localScale = astScale;

                Asteroid asteroid = asteroidClone.GetComponent<Asteroid>();
                Asteroid asteroid2 = asteroidClone2.GetComponent<Asteroid>();

                float astDir = Random.Range(0, 2 * Mathf.PI);

                asteroid.StartMoving(astDir);
                asteroid2.StartMoving(astDir);

                Destroy(gameObject);
            }
            if (transform.localScale.x < 0.5)
            {
                Destroy(gameObject);
            }
        }
    }

    ///<summary>
    ///
    /// </summary>
    /// 
    public void StartMoving(float angle)
    {
        //set our rb2d var to our rigidbody component
        rb2d = GetComponent<Rigidbody2D>();

        //random magnitude btw 1 and 3
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        //set our moveDirection to whatever angle is entered in
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb2d.AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }
}

