using GradedExercise13;

namespace GradedExercise13Driver
{
    /// <summary>
    /// Graded Exercise 13 driver
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Runs Graded Exercise 13 solution
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Console.Write("Enter input values, separated by spaces: ");
            string input = Console.ReadLine();
            ForLooper forLooper = new ForLooper(input);
        }
    }
}