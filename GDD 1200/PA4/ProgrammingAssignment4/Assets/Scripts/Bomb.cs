using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //made a serializefield for easier addition of Explosion sprite
    [SerializeField]
    GameObject prefabExplosion;

    private void OnCollisionEnter2D(Collision2D col)
    {
        //if a collision happens, check the tag to ensure it is a
        //bear colliding with it
        if(col.gameObject.tag == "bear")
        {
            //saves the bombs position, replaces it with an explosion,
            //and destroys bomb
            Vector2 position = transform.position;
            Instantiate(prefabExplosion, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
