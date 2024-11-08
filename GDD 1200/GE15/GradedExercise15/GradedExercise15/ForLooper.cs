namespace GradedExercise15
{
    /// <summary>
    /// Graded Exercise 15 solution
    /// </summary>
    public class ForLooper
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ForLooper()
        {
            // create and populate list
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(4);

            // STUDENTS: Add your code here
            for(int i = 0; i <= numbers.Count - 1; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int even = numbers[i] / 2;
                if (numbers[i] == even * 2)
                {
                    numbers.RemoveAt(i);
                }
            }
            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();
            numbers.Clear();
            for (int i = 1; i <= 5; i++)
            {
                numbers.Add(i * 2);
            }
            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                if (numbers[i] < 8)
                {
                    numbers.RemoveAt(i);
                }
            }
            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                Console.WriteLine(numbers[i]);
            }

        }

        #endregion
    }
}