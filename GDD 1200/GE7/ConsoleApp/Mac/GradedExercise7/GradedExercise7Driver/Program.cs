using System;
using UnityEngine;

namespace GradedExercise7
{
    /// <summary>
    /// Graded Exercise 7
    /// </summary>
    class Program
    {
        /// <summary>
        /// Tests the Mover class
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // set up test object
            Mover mover = new Mover();
            mover.gameObject = new GameObject(0,
                new Transform(Vector3.zero));

            // make sure correct force is applied
            mover.Start();
            List<Vector2> pastImpulseForces =
                mover.gameObject.GetComponent<Rigidbody2D>().GetPastForces(ForceMode2D.Impulse);
            if (pastImpulseForces.Count == 1 &&
                pastImpulseForces[0] == new Vector2(0, 5))
            {
                Console.WriteLine("Mover test passed");
            }
            else
            {
                Console.WriteLine("MOVER TEST FAILED!");
            }
        }
    }
}
