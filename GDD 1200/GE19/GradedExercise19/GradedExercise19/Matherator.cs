namespace GradedExercise19
{
    /// <summary>
    /// Provides a variety of numeric methods
    /// </summary>
    public class Matherator
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Matherator()
        {
            
        }

        #endregion

        #region Methods

        public void PrintOneToTen()
        {
            PrintMToN(1, 10);
        }

        public void PrintMToN (int m, int n)
        {
            for (int i = m; i <= n; i++)
            {
                Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        public int GetNthEvenNumber(int n)
        {
            int even = n * 2;
            return even;
        }

        public int GetTenthEvenNumber()
        {
            return GetNthEvenNumber(10);
        }

        #endregion
    }
}