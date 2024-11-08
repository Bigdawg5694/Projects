using System;
using UnityEngine;

namespace GradedExercise12
{
    /// <summary>
    /// Graded Exercise 12
    /// </summary>
    class Program
    {
        // test object
        static Driver driver;

        // test support
        static float frameMoveAmount;
        static Vector3 previousPosition;

        /// <summary>
        /// Tests the Driver class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Vector3 currentPosition;
            Vector3 correctPosition;

            // save for efficiency
            frameMoveAmount = Driver.MoveUnitsPerSecond * Time.deltaTime;

            // set up test object
            driver = new Driver();
            driver.gameObject = new GameObject(0,
                new Transform(Vector3.zero));
            Vector3 position = driver.Position;
            previousPosition = new Vector3(position.x,
                position.y, position.z);

            // execute selected test case
            int testCaseNumber = int.Parse(Console.ReadLine());
            switch (testCaseNumber)
            {
                case 1:
                    HorizontalRightTest();
                    break;
                case 2:
                    HorizontalLeftTest();
                    break;
                case 3:
                    VerticalUpTest();
                    break;
                case 4:
                    VerticalDownTest();
                    break;
                case 5:
                    NoInputTest();
                    break;
                case 6:
                    DoomStrafe40Test();
                    break;
            }
        }

        /// <summary>
        /// Tests horizontal movement to the right
        /// </summary>
        static void HorizontalRightTest()
        {
            Input.SetAxis("Horizontal", 1);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x + frameMoveAmount,
                previousPosition.y, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("Horizontal right test passed");
            }
            else
            {
                Console.WriteLine("Horizontal right TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
            Input.SetAxis("Horizontal", 0);
        }

        /// <summary>
        /// Tests horizontal movement to the left
        /// </summary>
        static void HorizontalLeftTest()
        {
            Input.SetAxis("Horizontal", -1);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x - frameMoveAmount,
                previousPosition.y, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("Horizontal left test passed");
            }
            else
            {
                Console.WriteLine("Horizontal left TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
            Input.SetAxis("Horizontal", 0);
        }

        /// <summary>
        /// Tests vertical movement up
        /// </summary>
        static void VerticalUpTest()
        {
            Input.SetAxis("Vertical", 1);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x,
                previousPosition.y + frameMoveAmount, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("Vertical up test passed");
            }
            else
            {
                Console.WriteLine("Vertical up TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
            Input.SetAxis("Vertical", 0);
        }

        /// <summary>
        /// Tests vertical movement down
        /// </summary>
        static void VerticalDownTest()
        {
            Input.SetAxis("Vertical", -1);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x,
                previousPosition.y - frameMoveAmount, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("Vertical down test passed");
            }
            else
            {
                Console.WriteLine("Vertical down TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
            Input.SetAxis("Vertical", 0);
        }

        /// <summary>
        /// Tests for no movement with no input
        /// </summary>
        static void NoInputTest()
        {
            Input.SetAxis("Horizontal", 0);
            Input.SetAxis("Vertical", 0);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x,
                previousPosition.y, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("No input test passed");
            }
            else
            {
                Console.WriteLine("No input stop TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
        }

        /// <summary>
        /// Tests diagonal movement
        /// </summary>
        static void DoomStrafe40Test()
        {
            Input.SetAxis("Horizontal", 1);
            Input.SetAxis("Vertical", 1);
            driver.Update();
            Vector3 currentPosition = driver.Position;
            Vector3 correctPosition = new Vector3(previousPosition.x + frameMoveAmount,
                previousPosition.y + frameMoveAmount, previousPosition.z);
            if (PositionsEqual(currentPosition, correctPosition))
            {
                Console.WriteLine("Doom Strafe 40 bug test passed");
            }
            else
            {
                Console.WriteLine("Doom Strafe 40 bug TEST FAILED!");
            }
            previousPosition.x = currentPosition.x;
            previousPosition.y = currentPosition.y;
            previousPosition.z = currentPosition.z;
            Input.SetAxis("Horizontal", 0);
            Input.SetAxis("Vertical", 0);
        }

        /// <summary>
        /// Compares two positions to see if they're equal
        /// </summary>
        /// <param name="position1">first position</param>
        /// <param name="position2">second position</param>
        /// <returns>true if the positions are equal, false otherwise</returns>
        static bool PositionsEqual(Vector3 position1, Vector3 position2)
        {
            return WithinOneHundredth(position1.x, position2.x) &&
                WithinOneHundredth(position1.y, position2.y) &&
                WithinOneHundredth(position1.z, position2.z);
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
