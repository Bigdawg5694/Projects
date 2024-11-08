using System;
using UnityEngine;

namespace GradedExercise9
{
    /// <summary>
    /// Graded Exercise 9
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the Resizer class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // set up test object
            Resizer resizer = new Resizer();
            resizer.gameObject = new GameObject(0,
                new Transform(Vector3.zero));
            resizer.transform.localScale = Vector3.one;

            // testing support
            Vector3 previousLocalScale = new Vector3(
                resizer.transform.localScale.x,
                resizer.transform.localScale.y,
                resizer.transform.localScale.z);

            // grow for 1 second and check local scale
            for (int i = 0; i < 61; i++)
            {
                resizer.Update();
            }
            if (WithinTwoHundredths(resizer.transform.localScale.x, previousLocalScale.x * 2) &&
                WithinTwoHundredths(resizer.transform.localScale.y, previousLocalScale.y * 2) &&
                WithinTwoHundredths(resizer.transform.localScale.z, previousLocalScale.z))
            {
                Console.WriteLine("Resizer first grow passed");
            }
            else
            {
                Console.WriteLine("Resizer FIRST GROW FAILED");
            }

            // shrink for 1 second and check local scale
            previousLocalScale.x = resizer.transform.localScale.x;
            previousLocalScale.y = resizer.transform.localScale.y;
            previousLocalScale.z = resizer.transform.localScale.z;
            for (int i = 0; i < 61; i++)
            {
                resizer.Update();
            }
            if (WithinTwoHundredths(resizer.transform.localScale.x, previousLocalScale.x / 2) &&
                WithinTwoHundredths(resizer.transform.localScale.y, previousLocalScale.y / 2) &&
                WithinTwoHundredths(resizer.transform.localScale.z, previousLocalScale.z))
            {
                Console.WriteLine("Resizer first shrink passed");
            }
            else
            {
                Console.WriteLine("Resizer FIRST SHRINK FAILED");
            }

            // grow for 1 second and check local scale
            previousLocalScale.x = resizer.transform.localScale.x;
            previousLocalScale.y = resizer.transform.localScale.y;
            previousLocalScale.z = resizer.transform.localScale.z;
            for (int i = 0; i < 61; i++)
            {
                resizer.Update();
            }
            if (WithinTwoHundredths(resizer.transform.localScale.x, previousLocalScale.x * 2) &&
                WithinTwoHundredths(resizer.transform.localScale.y, previousLocalScale.y * 2) &&
                WithinTwoHundredths(resizer.transform.localScale.z, previousLocalScale.z))
            {
                Console.WriteLine("Resizer second grow passed");
            }
            else
            {
                Console.WriteLine("Resizer SECOND GROW FAILED");
            }

            // shrink for 1 second and check local scale
            previousLocalScale.x = resizer.transform.localScale.x;
            previousLocalScale.y = resizer.transform.localScale.y;
            previousLocalScale.z = resizer.transform.localScale.z;
            for (int i = 0; i < 61; i++)
            {
                resizer.Update();
            }
            if (WithinTwoHundredths(resizer.transform.localScale.x, previousLocalScale.x / 2) &&
                WithinTwoHundredths(resizer.transform.localScale.y, previousLocalScale.y / 2) &&
                WithinTwoHundredths(resizer.transform.localScale.z, previousLocalScale.z))
            {
                Console.WriteLine("Resizer second shrink passed");
            }
            else
            {
                Console.WriteLine("Resizer SECOND SHRINK FAILED");
            }
        }

        /// <summary>
        /// Returns whether num1 and num2 are within one hundredth
        /// of each other
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2">second number</param>
        /// <returns>true if the numbers are within one hundredth, false otherwise</returns>
        static bool WithinTwoHundredths(float num1, float num2)
        {
            return (Mathf.Abs(num1 - num2) <= 0.02f);
        }
    }
}
