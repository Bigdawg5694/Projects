using System;

namespace GradedExercise1
{
    /// <summary>
    /// Demonstrates exceptions and exception handling
    /// </summary>
    class Program
    {
        /// <summary>
        /// Lets us practice with exceptions
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            args = new string[] { null, "1,390,146", "-2147483649" };
            foreach (string arg in args)
            {
                try
                {
                    int number = int.Parse(arg);
                    Console.WriteLine(number);
                }
                catch(ArgumentNullException ne)
                {
                    Console.WriteLine(ne.Message);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch(OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
            }
        }
    }
}
