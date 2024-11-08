using System;
using UnityEngine;

namespace GradedExercise11
{
    /// <summary>
    /// Graded Exercise 11
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the Jumper class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // set up test object
            Jumper jumper = new Jumper();
            jumper.gameObject = new GameObject(0,
                new Transform(Vector3.zero));

            // generate and set mouse position
            Vector3 mousePosition = new Vector3(
                Screen.width / 4, Screen.height / 4,
                -Camera.main.transform.position.z);
            Input.mousePosition = mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // start click and make sure jumper doesn't move
            Input.SetAxis("JumpToMouse", 1);
            jumper.Update();
            Vector3 position = jumper.Position;
            if (WithinOneHundredth(position.x, 0) &&
                WithinOneHundredth(position.y, 0) &&
                WithinOneHundredth(position.z, 0))
            {
                Console.WriteLine("First mouse press test passed");
            }
            else
            {
                Console.WriteLine("First mouse press TEST FAILED!");
            }

            // finish click and make sure jumper moves
            Input.SetAxis("JumpToMouse", 0);
            jumper.Update();
            position = jumper.Position;
            if (WithinOneHundredth(position.x, mouseWorldPosition.x) &&
                WithinOneHundredth(position.y, mouseWorldPosition.y) &&
                WithinOneHundredth(position.z, 0))
            {
                Console.WriteLine("First mouse click test passed");
            }
            else
            {
                Console.WriteLine("First mouse click TEST FAILED!");
            }
            Vector3 firstClickPosition = new Vector3(
                position.x, position.y, position.z);

            // move mouse
            mousePosition = new Vector3(
                Screen.width * 3 / 4, Screen.height * 3 / 4,
                -Camera.main.transform.position.z);
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // start click and make sure jumper doesn't move
            Input.SetAxis("JumpToMouse", 1);
            jumper.Update();
            position = jumper.Position;
            if (WithinOneHundredth(position.x, firstClickPosition.x) &&
                WithinOneHundredth(position.y, firstClickPosition.y) &&
                WithinOneHundredth(position.z, firstClickPosition.z))
            {
                Console.WriteLine("Second mouse press test passed");
            }
            else
            {
                Console.WriteLine("Second mouse press TEST FAILED!");
            }

            // finish click and make sure jumper moves
            Input.SetAxis("JumpToMouse", 0);
            jumper.Update();
            position = jumper.Position;
            if (WithinOneHundredth(position.x, mouseWorldPosition.x) &&
                WithinOneHundredth(position.y, mouseWorldPosition.y) &&
                WithinOneHundredth(position.z, 0))
            {
                Console.WriteLine("Second mouse click test passed");
            }
            else
            {
                Console.WriteLine("Second mouse click TEST FAILED!");
            }
        }

        /// <summary>
        /// Checks if the two numbers are within one hundredth
        /// of each other
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2">second number</param>
        /// <returns>true if the numbers are within one hundredth, false otherwise</returns>
        static bool WithinOneHundredth(float num1, float num2)
        {
            return Mathf.Abs(num1 - num2) <= 0.01f;
        }
    }
}
