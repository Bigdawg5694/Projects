using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public void Initialize(Direction dir, Vector3 location)
    {
        //make constants for magnitude randomizer
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 3f;

        //make integer for direction based on where the asteroid spawns
        Direction spawnDirection = dir;

        //moves asteroid to the location given
        gameObject.transform.position = location;

        //random magnitude btw 1 and 3
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        //random angle between 75 degrees and 105 degrees (90 degrees is up)
        float angleUp = Random.Range(75f * Mathf.Deg2Rad, 105f * Mathf.Deg2Rad);

        //random angle between 255 and 285 degrees (270 is down)
        float angleDown = Random.Range(255f * Mathf.Deg2Rad, 285f * Mathf.Deg2Rad);

        //random angle between 165 and 195 degrees (180 degrees is left)
        float angleLeft = Random.Range(165f * Mathf.Deg2Rad, 195f * Mathf.Deg2Rad);

        //random angle between -15 and 15 degrees (0 degrees is right)
        float angleRight = Random.Range(-15f * Mathf.Deg2Rad, 15f * Mathf.Deg2Rad);

        //set our moveDirection to 0 to refernce later in code
        Vector2 moveDirection = new Vector2 (0, 0);

        //spawnDirection determines what direction the asteroid will move
        if (spawnDirection == Direction.Left)
        {
            //sets the direction for our asteroid
            moveDirection = new Vector2(Mathf.Cos(angleLeft), Mathf.Sin(angleLeft));

            //adds force to the asteroid so it moves in the direction set
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }else if (spawnDirection == Direction.Up)
        {
            //sets the direction for our asteroid
            moveDirection = new Vector2(Mathf.Cos(angleUp), Mathf.Sin(angleUp));

            //adds force to the asteroid so it moves in the direction set
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);

        }else if (spawnDirection == Direction.Right)
        {
            //sets the direction for our asteroid
            moveDirection = new Vector2(Mathf.Cos(angleRight), Mathf.Sin(angleRight));

            //adds force to the asteroid so it moves in the direction set
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);

        }else
        {
            //sets the direction for our asteroid
            moveDirection = new Vector2(Mathf.Cos(angleDown), Mathf.Sin(angleDown));

            //adds force to the asteroid so it moves in the direction set
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
    }
}

