using UnityEngine;

namespace GradedExercise8
{
    /// <summary>
    /// Graded Exercise 8
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the Jumper class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // set up test object
            Jumper jumper = new Jumper();
            jumper.gameObject = new GameObject(0, new Transform(Vector3.zero));
            jumper.Start();

            // "run" 5 seconds of 60 fps game time and count how many times
            // the jumper position changes
            int changedPositionCount = 0;
            Vector3 previousPosition = jumper.transform.position;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    jumper.Update();
                }

                // check for changed position and save new position
                if (jumper.transform.position != previousPosition)
                {
                    changedPositionCount++;
                }
                previousPosition = jumper.transform.position;
            }

            // print results, allowing for 1 duplicate position because
            // of randomness
            if (changedPositionCount >= 4)
            {
                Console.WriteLine("Jumper test passed");
            }
            else
            {
                Console.WriteLine("Jumper TEST FAILED!");
            }
        }
    }
}
