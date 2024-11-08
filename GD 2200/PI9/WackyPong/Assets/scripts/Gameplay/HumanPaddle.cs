using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HumanPaddle : Paddle
{
    /// <summary>
    /// this is for a human player on the right paddle
    /// </summary>
    protected override void UpdatePaddle()
    {
        // get side-specific input
        float input;
        if (side == ScreenSide.Left)
        {
            input = Input.GetAxis("LeftPaddle");
        }
        else
        {
            input = Input.GetAxis("RightPaddle");
        }
        // move paddle as appropriate
        if (input != 0)
        {
            Move(input);
        }
    }
}
