namespace GradedExercise13
{
    /// <summary>
    /// Graded Exercise 13 solution
    /// </summary>
    public class ForLooper
    {
        #region Fields

        // inputs for problems
        int problem1Range;
        int problem2Width;
        int problem3Width;
        int problem3NumRows;
        int problem4MaxWidth;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">input string</param>
        public ForLooper(string input)
        {
            // extract point coordinates from string
            GetInputValuesFromString(input);

            // STUDENTS: Add your code below
            //Calculate problem1Range
            for (int i = 0; i <= problem1Range; i++)
            {
                //Make a number to compare if it's even or odd
                for (int j = 0; j <= i; j++)
                {
                    //Basically "skip" over 0
                    if (i == 0)
                    {
                        Console.WriteLine(i);
                    }
                    else if (i > 0)
                    {
                        //Check if int i is twice as much as int j exatcly
                        //(which should only happen once per nested for loop)
                        if (i == 2 * j)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
            Console.WriteLine();
            //Make our next for loop to print out * based on Prob2Width
            for (int i = problem2Width; i > 0; i--)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();
            //next is to print specified rows of * at a specified width
            for (int i = problem3NumRows; i > 0; i--)
            {
                for (int j = problem3Width; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //final problem is to print rows of * up to user set max
            for (int i = 1; i <= problem4MaxWidth; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        #endregion

        #region Helper method

        /// <summary>
        /// Extracts point coordinates from the given input string
        /// </summary>
        /// <param name="input">input string</param>
        void GetInputValuesFromString(string input)
        {
            string[] values = input.Split(' ');
            problem1Range = int.Parse(values[0]);
            problem2Width = int.Parse(values[1]);
            problem3Width = int.Parse(values[2]);
            problem3NumRows = int.Parse(values[3]);
            problem4MaxWidth = int.Parse(values[4]);
        }

        #endregion
    }
}