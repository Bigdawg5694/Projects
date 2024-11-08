using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Explosion script to make animation play once
/// </summary>

public class Explosion : MonoBehaviour
{
    // cached for efficiency
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //make a variable set to the animator, to recall for later uses
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the game object if the explosion finished
        //the if statement checks our animator variable, and
        //makes sure that it only plays once
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
