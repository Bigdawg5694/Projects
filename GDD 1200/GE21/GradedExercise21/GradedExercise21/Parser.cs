namespace GradedExercise21
{
    /// <summary>
    /// A parser
    /// </summary>
    public class Parser
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            
        }

        #endregion

        #region Method
        public int Parse(string intString)
        {
            int number = 0;
            for (int i = 0; i < intString.Length; i++)
            {
                number = int.Parse(intString);
            }
            return number;
        }

        #endregion
    }
}