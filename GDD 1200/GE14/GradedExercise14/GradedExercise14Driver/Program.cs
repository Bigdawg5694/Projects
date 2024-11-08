using GradedExercise14;

namespace GradedExercise14Driver
{
    /// <summary>
    /// Graded Exercise 14 driver
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Creates Looper object
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Console.Write("Enter input values, separated by spaces: ");
            string input = Console.ReadLine();
            Looper looper = new Looper(input);
			
        }
    }
}