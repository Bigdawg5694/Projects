using System;
using System.Diagnostics;

namespace GradedExercise2
{
    /// <summary>
    /// Prints difference between two ages
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Prints differences between two ages
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // constants for Problems 1 and 2

            const int CurrentYear = 2023;
            const int YoungAgeYear = 2003;
            const int OldAgeYear = 1963;

            // Problem 1: Output young age

            int youngAge = CurrentYear - YoungAgeYear;
            Console.WriteLine(youngAge);

            // Problem 2: Output old age

            int oldAge = CurrentYear - OldAgeYear;
            Console.WriteLine(oldAge);

            // Problem 3: Output difference in ages 

            int ageDifference = oldAge - youngAge;
            Console.WriteLine(ageDifference);

        }
    }
}
