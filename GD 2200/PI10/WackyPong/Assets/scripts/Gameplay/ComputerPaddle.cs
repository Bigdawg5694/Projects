using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComputerPaddle : Paddle
{
    /// <summary>
    /// method if computer is playing right paddle
    /// </summary>
    protected override void UpdatePaddle()
    {
        // create an array and get all the balls in the game
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        // checks if there is any game objects in the array
        if (balls.Length > 0)
        {
            // gets the closest ball to paddle
            GameObject closestBall = FindClosestBall(balls);

            // checks to see if the closestBall gameObject is not null
            if (closestBall != null)
            {
                // moves paddle towards the closest ball
                MoveTowardsBall(closestBall.transform.position.y);
            }
        }
    }

    /// <summary>
    /// this finds the closest ball
    /// </summary>
    /// <param name="balls">the array of balls in play</param>
    /// <returns></returns>
    private GameObject FindClosestBall(GameObject[] balls)
    {
        // set a game object to be the closest ball and set as null
        GameObject closestBall = null;

        // set a float for the closest distance and set it to maxvalue
        float closestDistance = float.MaxValue;
        
        // foreach loop that checks all ball objects in the array
        foreach (GameObject ball in balls)
        {
            // gets the rigidbody2d component for the ball
            Rigidbody2D ballrb2d = ball.GetComponent<Rigidbody2D>();

            // checks if rb2d component isn't null
            if (ballrb2d != null)
            {
                // set a Vector2 for the ball direction
                Vector2 ballDirection = ballrb2d.velocity.normalized;

                // set a Vector2 for the direction from paddle to ball
                Vector2 paddleToBall = ball.transform.position - transform.position;

                // this gets the dot product between the two vectors
                // returns 1 if going to paddle and -1 if going away from paddle
                float dotProduct = Vector2.Dot(paddleToBall.normalized, ballDirection);

                // checks if dot product is pos
                if (dotProduct < 0)
                {
                    // gets the distance between paddle and ball
                    float dotDistance = Vector2.Distance(transform.position, ball.transform.position);

                    // checks to see if distance is less than closest distance
                    if (dotDistance < closestDistance)
                    {
                        // set closest distance to dotdistance
                        closestDistance = dotDistance;

                        // set the closest ball to the ball associated with
                        // the distance
                        closestBall = ball;
                    }
                }
            }
        }
        // return closestBall from this method
        return closestBall;
    }

    /// <summary>
    /// this makes the computer move towards the ball
    /// </summary>
    /// <param name="targetY">y component of closest ball to computer</param>
    private void MoveTowardsBall(float targetY)
    {
        // this gets the movemment amount,
        // like getting the input amount for a human player
        float movementAmount = Mathf.Clamp(targetY - transform.position.y, -1, 1);        
        
        // calls the move method to get paddle
        // moving by amount we just set
        Move(movementAmount);
    }
}
