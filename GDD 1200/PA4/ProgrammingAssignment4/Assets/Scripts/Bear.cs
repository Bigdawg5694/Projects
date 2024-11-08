using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // randomly select impulse direction to apply
        float directionX = Random.Range(-5, 6);
        float directionY = Random.Range(-5, 6);

        //apply force to bear
        GetComponent<Rigidbody2D>().AddForce(
        new Vector2(directionX, directionY),
        ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //checks to see if bear collided with a bomb
        if (col.gameObject.tag == "bomb")
        {
            //bear gets demolished
            Destroy(gameObject);
        }
    }
}
