using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SaveTheTowers teddyCount;
    GameObject tower;
    GameObject teddyBear;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        teddyCount = Camera.main.GetComponent<SaveTheTowers>();
        teddyBear = teddyCount.OldestTeddyBear;
        tower = GameObject.FindGameObjectWithTag("Tower");
        bullet = GetComponent<GameObject>();
        float directionX = tower.transform.position.x - teddyBear.transform.position.x;
        float direcctionY = tower.transform.position.y - teddyBear.transform.position.y;
        Vector2 bulletDirection = new Vector2(directionX, direcctionY);
        bulletDirection.Normalize();
        float magnitude = 5;
        GetComponent<Rigidbody2D>().AddForce(
            bulletDirection * magnitude,
            ForceMode2D.Impulse);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bear")
        {
            teddyCount.RemoveTeddyBear(teddyBear);
        }
        else if (col.gameObject.tag == "Tower")
        {
            Destroy(bullet);
        }
    }
}
