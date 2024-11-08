using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
//script for our Ship, includes thurst, direction, and wrap mechanics for game
public class Ship : MonoBehaviour
{
    ///<summary>
    ///sets variables that are in all our methods, also sets
    ///the serialzefield for the bullet
    /// </summary>
    Rigidbody2D thrust;
    Vector2 thrustDirection = new Vector2(0, 0);
    Bullet bulletDir;

    //set a field in the Unity inspector for the bullet
    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    GameObject HUD;

    //thrust for our ship
    const int ThrustForce = 5;

    //how fast our ship rotates when turning
    const float RotateDegreesPerSecond = 150;

    /// <summary>
    /// Gets the rigidbody component of the ship
    /// </summary>
    void Start()
    {
        //gets the component from the game object (ship) that its attached to
        thrust = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// this method sets how much our ship rotates
    /// and how our ships thrust reacts as well
    /// </summary>
    void Update()
    {
        //sets how much our ship rotates
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;

        //sets how our thrust reacts to the direction the ship is facing
        var thrustRotation = transform.eulerAngles.z;

        //checks if there is input in the rotate axis on our input manager
        if (Input.GetAxis("Rotate") > 0)
        {
            //makes our rotation amount positive (left turning)
            rotationAmount *= 1;

            //changes our thrust angle from degrees to radians
            thrustRotation *= Mathf.Deg2Rad;

            //finds the direction in x coordinate from cosine
            thrustDirection.x = Mathf.Cos(thrustRotation);

            //finds the direction in y coordinates from sin
            thrustDirection.y = Mathf.Sin(thrustRotation);
        }
        else if (Input.GetAxis("Rotate") < 0)
        {

            //makes our rotation amount negative (right turning)
            rotationAmount *= -1;

            //changes our thrust angle from degrees to radians
            thrustRotation *= Mathf.Deg2Rad;

            //finds the direction in x coordinate from cosine
            thrustDirection.x = Mathf.Cos(thrustRotation);

            //finds the direction in y coordinates from sin
            thrustDirection.y = Mathf.Sin(thrustRotation);
        }
        else if(Input.GetAxis("Rotate") == 0)
        {
            //dosent rotate if there isnt any input
            rotationAmount = 0;
        }
        //makes our ship rotate
        transform.Rotate(Vector3.forward, rotationAmount);

        //this is to check if the left crtl key has been pressed
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //play the shooting audio
            AudioManager.Play(AudioClipName.PlayerShot);

            //get our ships position
            Vector3 shipPos = transform.position;

            //get our ships rotation
            Quaternion shipRot = transform.rotation;

            //make a bullet at that position and rotation
            GameObject bullet = Instantiate(prefabBullet, shipPos, shipRot);

            //call the bullet script
            bulletDir = bullet.GetComponent<Bullet>();

            //calls the start method to get rb2d component
            bulletDir.Start();

            //gets bullet moving through method on bullet script
            bulletDir.ApplyForce(thrustDirection);
        }
    }

    /// <summary>
    /// this is going to be the thrust application to our ship
    /// </summary>
    void FixedUpdate()
    {
        //checks to see if the button for thrust is pushed
        if (Input.GetAxis("Thrust") > 0)
        {
            //applies our thrust to the ship based on th direction it's facing
            thrust.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
    }

    /// <summary>
    /// for when our ship collides with an asteroid
    /// </summary>
    private void OnCollisionEnter2D(Collision2D col)
    {
        //checks the object tag
        if (col.gameObject.tag == "Asteroid")
        {
            //play ship death sound
            AudioManager.Play(AudioClipName.PlayerDeath);

            //get hud component
            HUD hudScr = HUD.GetComponent<HUD>();

            //stop the timer
            hudScr.StopGameTimer();

            //we die
            Destroy(gameObject);
        }
    }
}
