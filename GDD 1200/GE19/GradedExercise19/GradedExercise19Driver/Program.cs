using GradedExercise19;

namespace GradedExercise19Driver
{
    /// <summary>
    /// Graded Exercise 19 driver
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Tests the Matherator methods
        /// </summary>
        /// <param name="args">command-line args</param>

        static void Main(string[] args)
        {
            Matherator math = new Matherator();

            // method with no return value, no parameters
            math.PrintOneToTen();
            Console.WriteLine();

            // method with no return value, with parameters
            math.PrintMToN(5, 7);
            Console.WriteLine();

            // method with return value, no parameters
            int tenthEvenNumber = math.GetTenthEvenNumber();
            Console.WriteLine(tenthEvenNumber);
            Console.WriteLine();

            // method with return value, with parameters
            int nthEvenNumber = math.GetNthEvenNumber(4);
            Console.WriteLine(nthEvenNumber);
        }
    }
}