using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombingBears : MonoBehaviour
{
    //making this to show Unity which sprite to use
    [SerializeField]
    GameObject prefabBomb;
    //set a variable for previous input, to ensure object gets placed only once
    bool previousInputProvided = false;

    // Update is called once per frame
    void Update()
    {
        //on left click, make a bomb
        if (Input.GetAxis("bombPlace") == 0)
        {
            if (!previousInputProvided)
            {
                // convert mouse position to world position
                Vector3 position = Input.mousePosition;
                position.z = -Camera.main.transform.position.z;
                Vector3 position1 = Camera.main.ScreenToWorldPoint(position);
                GameObject bomb = Instantiate(prefabBomb, position1, Quaternion.identity);

                //changes previousinput to true, to only have the click work once
                previousInputProvided = true;
            }
        }
        else
        {
            //changes previousinput to false when button is released
            previousInputProvided = false;
        }
    }
}
