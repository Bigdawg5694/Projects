using GradedExercise21;

namespace GradedExercise21Driver
{
    /// <summary>
    /// Graded Exercise 21 driver
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Tests Parser Parse method
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            // prompt for and get int from user
            Console.Write("Enter a whole number: ");
            string inputString = Console.ReadLine();

            // parse and output int
            int inputInt = parser.Parse(inputString);
            Console.WriteLine("Int input: " + inputInt);
        }
    }
}