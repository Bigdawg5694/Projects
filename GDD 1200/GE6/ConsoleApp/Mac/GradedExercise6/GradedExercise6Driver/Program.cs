using System;
using UnityEngine;

namespace GradedExercise6
{
    /// <summary>
    /// Graded Exercise 6
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the YellowTeddyBear, GreenTeddyBear, and PurpleTeddyBear classes
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // read in test case number
            int testCaseNumber = int.Parse(Console.ReadLine());

            // execute selected test case
            switch (testCaseNumber)
            {
                case 1:
                    YellowTeddyBearTest();
                    break;
                case 2:
                    GreenTeddyBearTest();
                    break;
                case 3:
                    PurpleTeddyBearTest();
                    break;
            }
        }

        /// <summary>
        /// Tests the YellowTeddyBear class
        /// </summary>
        static void YellowTeddyBearTest()
        {
            // create test object
            YellowTeddyBear yellowTeddyBear = new YellowTeddyBear();
            Vector3 yellowTeddyBearOriginalScale = new Vector3(1, 2, 3);
            yellowTeddyBear.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero,
                    new Vector3(yellowTeddyBearOriginalScale.x,
                        yellowTeddyBearOriginalScale.y,
                        yellowTeddyBearOriginalScale.z)));

            // run test
            yellowTeddyBear.Start();
            if (WithinOneHundredth(yellowTeddyBearOriginalScale.x * 4, yellowTeddyBear.transform.localScale.x) &&
                WithinOneHundredth(yellowTeddyBearOriginalScale.y * 4, yellowTeddyBear.transform.localScale.y) &&
                WithinOneHundredth(yellowTeddyBearOriginalScale.z, yellowTeddyBear.transform.localScale.z))
            {
                Console.WriteLine("Yellow teddy bear test case passed");
            }
            else
            {
                Console.WriteLine("YELLOW TEDDY BEAR TEST CASE FAILED!");
            }
        }

        /// <summary>
        /// Tests the GreenTeddyBear class
        /// </summary>
        static void GreenTeddyBearTest()
        {
            // create test object
            GreenTeddyBear greenTeddyBear = new GreenTeddyBear();
            Vector3 greenTeddyBearOriginalScale = new Vector3(3, 2, 1);
            greenTeddyBear.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero,
                    new Vector3(greenTeddyBearOriginalScale.x,
                        greenTeddyBearOriginalScale.y,
                        greenTeddyBearOriginalScale.z)));

            // run test
            greenTeddyBear.Start();
            if (WithinOneHundredth(greenTeddyBearOriginalScale.x, greenTeddyBear.transform.localScale.x) &&
                WithinOneHundredth(greenTeddyBearOriginalScale.y * 3, greenTeddyBear.transform.localScale.y) &&
                WithinOneHundredth(greenTeddyBearOriginalScale.z, greenTeddyBear.transform.localScale.z))
            {
                Console.WriteLine("Green teddy bear test case passed");
            }
            else
            {
                Console.WriteLine("GREEN TEDDY BEAR TEST CASE FAILED!");
            }
        }

        /// <summary>
        /// Tests the PurpleTeddyBear class
        /// </summary>
        static void PurpleTeddyBearTest()
        {
            // create test object
            PurpleTeddyBear purpleTeddyBear = new PurpleTeddyBear();
            Vector3 purpleTeddyBearOriginalScale = Vector3.one;
            purpleTeddyBear.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero,
                    new Vector3(purpleTeddyBearOriginalScale.x,
                        purpleTeddyBearOriginalScale.y,
                        purpleTeddyBearOriginalScale.z)));

            // run test
            purpleTeddyBear.Start();
            if (WithinOneHundredth(purpleTeddyBearOriginalScale.x * 3, purpleTeddyBear.transform.localScale.x) &&
                WithinOneHundredth(purpleTeddyBearOriginalScale.y, purpleTeddyBear.transform.localScale.y) &&
                WithinOneHundredth(purpleTeddyBearOriginalScale.z, purpleTeddyBear.transform.localScale.z))
            {
                Console.WriteLine("Purple teddy bear test case passed");
            }
            else
            {
                Console.WriteLine("PURPLE TEDDY BEAR TEST CASE FAILED!");
            }
        }

        /// <summary>
        /// Tells whether the two given numbers are within 1/100th of each other
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2">second number</param>
        /// <returns>true if the numbers are within 1/100th of each other,
        ///     false otherwise</returns>
        static bool WithinOneHundredth(float num1, float num2)
        {
            return Mathf.Abs(num1 - num2) <= 0.01f;
        }
    }
}

