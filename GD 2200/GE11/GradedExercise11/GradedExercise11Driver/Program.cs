using GradedExercise11;

namespace GradedExercise11Driver
{
    /// <summary>
    /// Graded Exercise 11 driver
    /// </summary>
    internal class Program
    {
		
        /// <summary>
        /// Tests the Digitizer class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            Digitizer digitizer = new Digitizer();

            // loop while there's more input
            string input = Console.ReadLine();
            while (input[0] != 'q')
            {
                // convert word to digit and print
                Console.WriteLine(digitizer.ConvertWordToDigit(input));

                input = Console.ReadLine();
            }
        }
    }
}
