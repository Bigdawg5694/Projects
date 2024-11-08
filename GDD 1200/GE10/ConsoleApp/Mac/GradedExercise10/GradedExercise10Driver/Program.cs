using System;
using UnityEngine;

namespace GradedExercise10
{
    /// <summary>
    /// Graded Exercise 10
    /// </summary>
    class Program
    {
        // test object
        static NonFollower nonFollower = null;

        // BoxCollider2D component
        const float BoxColliderWidth = 0.25f;
        const float BoxColliderHeight = 0.5f;
        static BoxCollider2D boxCollider;

        // testing support
        const int BorderSize = 100;
        static float colliderHalfWidth;
        static float colliderHalfHeight;
        static Vector3 mousePosition = Vector3.zero;

        // test results
        static bool invalidPosition = false;

        /// <summary>
        /// Tests the NonFollower script
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // initialize screen utils for clamping
            ScreenUtils.Initialize();

            // set up UnityEngine delegates
            // have to do this after a game object is added to the test object
            GameObject.AddAddComponentDelegate(typeof(BoxCollider2D), AddBoxCollider2D);
            GameObject.AddGetComponentDelegate(typeof(BoxCollider2D), GetBoxCollider2D);

            // set up test object
            nonFollower = new NonFollower();
            nonFollower.gameObject = new GameObject(0,
                new Transform(Vector3.zero));
            nonFollower.gameObject.AddComponent<BoxCollider2D>();
            nonFollower.Start();

            // save collider info
            colliderHalfWidth = nonFollower.ColliderHalfWidth;
            colliderHalfHeight = nonFollower.ColliderHalfHeight;

            // run selected test case
            int testCaseNumber = int.Parse(Console.ReadLine());
            switch (testCaseNumber)
            {
                case 1:
                    ColliderInfoTest();
                    break;
                case 2:
                    CorrectPositionTest();
                    break;
                case 3:
                    CorrectClampingTest();
                    break;
            }
        }

        /// <summary>
        /// Tests that the NonFollower caches collider info properly
        /// </summary>
        static void ColliderInfoTest()
        {
            // print collider info test results
            if (WithinOneHundredth(colliderHalfWidth, BoxColliderWidth / 2) &&
                WithinOneHundredth(colliderHalfHeight, BoxColliderHeight / 2))
            {
                Console.WriteLine("Collider info test passed");
            }
            else
            {
                Console.WriteLine("Collider info TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests to make sure the NonFollower moves to the correct
        /// position when no clamping is required
        /// </summary>
        static void CorrectPositionTest()
        {
            // change game object position 50 times
            for (int i = 0; i < 50; i++)
            {
                ChangeGameObjectPosition();
            }

            // print position results
            if (!invalidPosition)
            {
                Console.WriteLine("Position test passed");
            }
            else
            {
                Console.WriteLine("Position TEST FAILED!");
            }
        }

        /// <summary>
        /// Changes the game object position to test position
        /// </summary>
        /// <returns></returns>
        static void ChangeGameObjectPosition()
        {
            // generate and set random mouse position with no clamping required
            mousePosition.x = UnityEngine.Random.Range(BorderSize, Screen.width - BorderSize);
            mousePosition.y = UnityEngine.Random.Range(BorderSize, Screen.height - BorderSize);
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;

            // convert mouse position to world position
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // update game object and check position
            nonFollower.Update();
            Vector3 position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, -mouseWorldPosition.x) ||
                !WithinOneHundredth(position.y, -mouseWorldPosition.y) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidPosition = true;
            }
        }

        /// <summary>
        /// Sets mouse position to all 4 sides and corners to test clamping
        /// </summary>
        static void CorrectClampingTest()
        {
            bool invalidClamp = false;
            Vector3 mouseWorldPosition;
            Vector3 position;

            // mouse lower left corner, object upper right corner
            mousePosition.x = 0;
            mousePosition.y = 0;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenRight - colliderHalfWidth) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenTop - colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse left edge, object right edge
            mousePosition.x = 0;
            mousePosition.y = Screen.height / 2;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenRight - colliderHalfWidth) ||
                !WithinOneHundredth(position.y, -mouseWorldPosition.y) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse top left corner, object lower right corner
            mousePosition.x = 0;
            mousePosition.y = Screen.height;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenRight - colliderHalfWidth) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenBottom + colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse top edge, object bottom edge
            mousePosition.x = Screen.width / 2;
            mousePosition.y = Screen.height;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, -mouseWorldPosition.x) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenBottom + colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse top right corner, object lower left corner
            mousePosition.x = Screen.width;
            mousePosition.y = Screen.height;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenLeft + colliderHalfWidth) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenBottom + colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse right edge, object left edge
            mousePosition.x = Screen.width;
            mousePosition.y = Screen.height / 2;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenLeft + colliderHalfWidth) ||
                !WithinOneHundredth(position.y, -mouseWorldPosition.y) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse bottom right corner, object upper left corner
            mousePosition.x = Screen.width;
            mousePosition.y = 0;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, ScreenUtils.ScreenLeft + colliderHalfWidth) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenTop - colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // mouse bottom edge, object top edge
            mousePosition.x = Screen.width / 2;
            mousePosition.y = 0;
            mousePosition.z = -Camera.main.transform.position.z;
            Input.mousePosition = mousePosition;
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            nonFollower.Update();
            position = nonFollower.Position;
            if (!WithinOneHundredth(position.x, -mouseWorldPosition.x) ||
                !WithinOneHundredth(position.y, ScreenUtils.ScreenTop - colliderHalfHeight) ||
                !WithinOneHundredth(position.z, 0))
            {
                invalidClamp = true;
            }

            // print clamp results
            if (!invalidClamp)
            {
                Console.WriteLine("Clamp test passed");
            }
            else
            {
                Console.WriteLine("Clamp TEST FAILED!");
            }
        }

        /// <summary>
        /// Checks if the two numbers are within one hundredth
        /// of each other
        /// </summary>
        /// <param name="num1">first number</param>
        /// <param name="num2">second number</param>
        /// <returns>true if the numbers are within one hundredth, false otherwise</returns>
        static bool WithinOneHundredth(float num1, float num2)
        {
            return Mathf.Abs(num1 - num2) <= 0.01f;
        }

        #region GameObject delegates

        /// <summary>
        /// Delegate for adding a BoxCollider2D component
        /// </summary>
        /// <param name="unused">unused</param>
        static BoxCollider2D AddBoxCollider2D(GameObject unused)
        {
            boxCollider = new BoxCollider2D(nonFollower.gameObject);
            Vector2 size = new Vector2(BoxColliderWidth, BoxColliderHeight);
            boxCollider.size = size;
            return boxCollider;
        }

        /// <summary>
        /// Delegate for getting a BoxCollider2D component
        /// </summary>
        /// <param name="unused">unused</param>
        /// <returns>the static box collider 2d component</returns>
        static BoxCollider2D GetBoxCollider2D(GameObject unused)
        {
            return boxCollider;
        }

        #endregion
    }
}
