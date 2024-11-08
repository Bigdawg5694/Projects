using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
//script for our Ship, includes thurst, direction, and wrap mechanics for game
public class Ship : MonoBehaviour
{
    Rigidbody2D thrust;
    const int ThrustForce = 1;
    Vector2 thrustDirection = new Vector2(0, 0);
    const float RotateDegreesPerSecond = 45;

    // Start is called before the first frame update
    void Start()
    {
        thrust = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate rotation and apply it
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        var thrustRotation = transform.eulerAngles.z;
        if (Input.GetAxis("Rotate") > 0)
        {
            rotationAmount *= 1;
            thrustRotation *= Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(thrustRotation);
            thrustDirection.y = Mathf.Sin(thrustRotation);
            thrustDirection = new Vector2(thrustDirection.x, thrustDirection.y);
        }
        else if (Input.GetAxis("Rotate") < 0)
        {
            rotationAmount *= -1;
            thrustRotation *= Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(thrustRotation);
            thrustDirection.y = Mathf.Sin(thrustRotation);
            thrustDirection = new Vector2(thrustDirection.x, thrustDirection.y);
        }
        else if(Input.GetAxis("Rotate") == 0)
        {
            rotationAmount = 0;
        }
        transform.Rotate(Vector3.forward, rotationAmount);
    }

    //this is going to be the thrust application to our ship
    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            thrust.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
    }
}
