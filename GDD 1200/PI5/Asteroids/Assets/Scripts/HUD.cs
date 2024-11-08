using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    /// <summary>
    /// getting our text component into a serialzefield
    /// </summary>
    /// 
    [SerializeField]
    TextMeshProUGUI hud;
    float elapsedseconds = 0;
    bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        hud.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedseconds += Time.deltaTime;
            hud.text = ((int)elapsedseconds).ToString();
        }
    }
    public void StopGameTimer()
    {
        if (running)
        {
            running = false;
            hud.text = ((int)elapsedseconds).ToString();
        }
    }
}
