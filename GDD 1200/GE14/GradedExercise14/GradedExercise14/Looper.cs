using System.Collections.Generic;
using System.Reflection.Metadata;

namespace GradedExercise14
{
    /// <summary>
    /// Graded Exercise 14 solution
    /// </summary>
    public class Looper
    {
        #region Fields

        // input processing support
        List<int> values = new List<int>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">input values</param>
        public Looper(string inputString)
        {
            // extract input values from string
            BuildListFromString(inputString);
            // STUDENTS: Add your code here
            //adding int to have the lowest integer possible for intitial maxValue
            //this is done to ensure that even when we enter negative numbers, our program
            //will still be able to find the biggest value in the list (besides -1 of course)
            int maxValue = int.MinValue;
            int number = 0;
            // Call the GetValue method to get
            // each input value
            number = GetValue();
            while (number != -1)
            {
                //checks if number is greater than maxValue, and sets maxValue equal to that number if so
                if (number > maxValue)
                {
                    maxValue = number;
                }
                number = GetValue();
            }
            Console.WriteLine();
            Console.WriteLine(maxValue);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Builds a list of input values from provided string
        /// </summary>
        /// <param name="input">input string</param>
        void BuildListFromString(string input)
        {
            // add input values to list
            string[] arrayValues = input.Split(' ');
            foreach (string value in arrayValues)
            {
                values.Add(int.Parse(value));
            }
        }

        /// <summary>
        /// Get a value from the list. If the list
        /// is empty, returns -1
        /// </summary>
        /// <returns>value or -1 if list is empty</returns>
        int GetValue()
        {
            // check for empty list
            int value;
            if (values.Count > 0)
            {
                // save value at front of list and remove
                value = values[0];
                values.RemoveAt(0);
            }
            else
            {
                // empty list
                value = -1;
            }
            return value;
        }

        #endregion
    }
}