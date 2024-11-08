using ProgrammingAssignment1;

namespace ProgrammingAssignment1Driver
{
    /// <summary>
    /// Programming Assignment 1
    /// </summary>
    internal class Program
    {
        // x and y coordinates for points
        static float point1X;
        static float point1Y;
        static float point2X;
        static float point2Y;

        /// <summary>
        /// Programming Assignment 1
        /// </summary>
        /// <param name="args">command-line args</param>

        static void Main(string[] args)
        {
            // extract point coordinates from string
            GetInputValuesFromString(Console.ReadLine());

            // do calculations
            Calculator calculator = new Calculator(point1X,
                point1Y, point2X, point2Y);
        }

        /// <summary>
        /// Extracts point coordinates from the given input string
        /// </summary>
        /// <param name="input">input string</param>
        static void GetInputValuesFromString(string input)
        {
            string[] values = input.Split(' ');
            point1X = float.Parse(values[0]);
            point1Y = float.Parse(values[1]);
            point2X = float.Parse(values[2]);
            point2Y = float.Parse(values[3]);
        }

    }
}