using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    /// <summary>
    /// setting all our variables needed in entire script
    /// </summary>
    [SerializeField]
    TextMeshProUGUI TMPro;
    int bounces = 0;

    /// <summary>
    /// sets our int to the text shown in our UGI
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        TMPro.text = bounces.ToString();
    }
    /// <summary>
    /// this method will add to our int bounces
    /// and update the text
    /// </summary>
    public void AddBounce()
    {
        bounces++;
        TMPro.text = bounces.ToString();
    }
}
