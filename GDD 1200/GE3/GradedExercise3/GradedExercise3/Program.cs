using System;

namespace GradedExercise3
{
    /// <summary>
    /// Demonstrates that math is fun
    /// </summary>
    // Math is amazing
    internal class Program
    {
        /// <summary>
        /// Gives practice using variables and constants
        /// </summary>
        /// <param name="args">command-line args</param>
        // will be doing calc for equation e=mc^2
        static void Main(string[] args)
        {
            const float c = 299_792_458;
            float e;
            float m;

            //setting m and calculating/printing e
            m = 8.56f;
            e = m * (float)Math.Pow(c,2);
            Console.WriteLine(e);
        }
    }
}
