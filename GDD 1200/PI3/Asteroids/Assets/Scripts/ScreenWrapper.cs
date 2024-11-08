using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    CircleCollider2D radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {

        if (transform.position.x + radius.radius < ScreenUtils.ScreenLeft)
        {
            transform.position = new Vector3(ScreenUtils.ScreenRight, transform.position.y, transform.position.z);
        }
        if (transform.position.x - radius.radius > ScreenUtils.ScreenRight)
        {
            transform.position = new Vector3(ScreenUtils.ScreenLeft, transform.position.y, transform.position.z);
        }
        if (transform.position.y + radius.radius < ScreenUtils.ScreenBottom)
        {
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenTop, transform.position.z);
        }
        if (transform.position.y - radius.radius > ScreenUtils.ScreenTop)
        {
            transform.position = new Vector3(transform.position.x, ScreenUtils.ScreenBottom, transform.position.z);
        }
    }
}
