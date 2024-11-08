using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //we are setting a field so that we can change what our bullet will be
    //without having to come back into the code
    [SerializeField]
    GameObject prefabBullet;

    #region Methods
    /// <summary>
    /// we are turning our turret based on where the mouse is
    /// and spawning in bullets when we click
    /// </summary>
    void Update()
    {
        //get mouse to world position and turret position
        Vector3 worldPos = MouseToWorld();
        Vector3 turretPos = transform.position;

        //calculate direction
        float angleDeg = Direction(worldPos.y, worldPos.x, turretPos.y, turretPos.x);

        //make our transform.rotation into a Quaternion
        transform.rotation = Quaternion.identity;

        //reset turret direction
        transform.Rotate(Vector3.forward, angleDeg);

        //make the turret point towards the mouse
        Quaternion target = Quaternion.Euler(0, 0, angleDeg);
        transform.rotation = target;

        //checks to see if you are pushing mouse 0 (left click)
        if (Input.GetMouseButtonDown(0) == true)
        {
            //spawns in a bullet
            GameObject bullet = Instantiate(prefabBullet, turretPos, Quaternion.identity);

            //make the bullet position our turret position
            Vector3 bulletPos = turretPos;

            //find the angle that the bullet is facing based on where the mouse is
            float bulletAng = Direction(worldPos.y, worldPos.x, bulletPos.y, bulletPos.x);

            //convert our angle from deg to rad (for the sin and cos functions)
            bulletAng *= Mathf.PI / 180;

            //get our direction based on the angle the mouse is from the bullet
            Vector2 direction = new Vector2(Mathf.Cos(bulletAng), Mathf.Sin(bulletAng));

            //use the bullets Start method to get rb2d component
            bullet.GetComponent<Bullet>().Start();

            //apply force to the rb2d component
            bullet.GetComponent<Bullet>().ApplyForce(direction);
        }   
    }
    /// <summary>
    /// This is used to calculate our angle for the turret and bullets
    /// </summary>
    /// <param name="point2Y"></param>
    /// <param name="point2X"></param>
    /// <param name="point1Y"></param>
    /// <param name="point1X"></param>
    /// <returns></returns>
    public float Direction(float point2Y, float point2X, float point1Y, float point1X)
    {
        //Calculate deltaX and deltaY
        float deltaY = point2Y - point1Y;
        float deltaX = point2X - point1X;

        //Calcuate the angle in radians
        float angleRad = Mathf.Atan2(deltaY, deltaX);

        //convert to degrees
        float angleDeg = angleRad * (180 / MathF.PI);

        //returns the angle in degrees
        return angleDeg;
    }
    public Vector3 MouseToWorld()
    {
        //transform mouse position to world position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        //returns the result calculated
        return worldPos;
    }
    #endregion
}