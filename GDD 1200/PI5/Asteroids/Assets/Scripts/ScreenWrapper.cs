using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    /// <summary>
    /// this gets the CircleCollider2d component attahced to
    /// the object in unity
    /// </summary>
    CircleCollider2D radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>();
    }
    /// <summary>
    /// this is when the object is out of the screen on the main
    /// camera, this just puts our transform.position for the object
    /// to the opposite side of the screen
    /// </summary>
    private void OnBecameInvisible()
    {
        //check if the position of our object is off the left screen
        if (transform.position.x + radius.radius < ScreenUtils.ScreenLeft)
        {
            //put our objecton the right side of the screen
            transform.position = new Vector3(ScreenUtils.ScreenRight, transform.position.y, transform.position.z);
        }
        //check if our object is off the right side
        if (transform.position.x - radius.radius > ScreenUtils.ScreenRight)
        {
            //put our object on the left side
            transform.position = new Vector3(ScreenUtils.ScreenLeft, transform.position.y, transform.position.z);
        }
        //check if our object is off the bottom side
        if (transform.position.y + radius.radius < ScreenUtils.ScreenBottom)
        {
            //put it on the top
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenTop, transform.position.z);
        }
        //check if our object is off the top side
        if (transform.position.y - radius.radius > ScreenUtils.ScreenTop)
        {
            //put it on the bottom
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenBottom, transform.position.z);
        }
    }
}
