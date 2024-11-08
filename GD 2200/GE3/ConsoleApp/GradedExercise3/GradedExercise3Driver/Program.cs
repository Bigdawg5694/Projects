using System;
using GradedExercise3Util;
using UnityEngine;

namespace GradedExercise3
{
    /// <summary>
    /// Graded Exercise 3
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Tests the ConfigurationData and ConfigurationUtils classes
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // extract values from file being used for testing
            float[] values = Util.GetValuesFromFile(ConfigurationData.ConfigurationDataFileName);

            // run selected test case
            int testCaseNumber = int.Parse(Console.ReadLine());
            switch (testCaseNumber)
            {
                case 1:
                    ConfigurationDataTest(values);
                    break;
                case 2:
                    ConfigurationUtilsTest(values);
                    break;
            }
        }

        /// <summary>
        /// Tests the ConfigurationData class
        /// </summary>
        /// <param name="values">correct values</param>
        static void ConfigurationDataTest(float[] values)
        {
            ConfigurationData configurationData = new ConfigurationData();
            if (WithinOneHundredth(configurationData.TeddyBearMoveUnitsPerSecond, values[0]) &&
                WithinOneHundredth(configurationData.CooldownSeconds, values[1]))
            {
                Console.WriteLine("ConfigurationData test passed");
            }
            else
            {
                Console.WriteLine("ConfigurationData TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests the ConfigurationUtils test
        /// </summary>
        /// <param name="values">correct values</param>
        static void ConfigurationUtilsTest(float[] values)
        {
            ConfigurationUtils.Initialize();
            if (WithinOneHundredth(ConfigurationUtils.TeddyBearMoveUnitsPerSecond, values[0]) &&
                WithinOneHundredth(ConfigurationUtils.CooldownSeconds, values[1]))
            {
                Console.WriteLine("ConfigurationUtils test passed");
            }
            else
            {
                Console.WriteLine("ConfigurationUtils TEST FAILED!");
            }
        }

        /// <summary>
        /// Checks to see if the two numbers are within one hundredth of each other
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2">second number</param>
        /// <returns>true if they're within one hundredth, false otherwise</returns>
        static bool WithinOneHundredth(float num1, float num2)
        {
            return (Mathf.Abs(num1 - num2) <= 0.01f);
        }
    }
}
