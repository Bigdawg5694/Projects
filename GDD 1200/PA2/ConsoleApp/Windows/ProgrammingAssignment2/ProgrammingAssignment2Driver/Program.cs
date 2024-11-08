using UnityEngine;

namespace ProgrammingAssignment2Driver
{
    /// <summary>
    /// Programming Assignment 2
    /// </summary>
    internal class Program
    {
        // mapping between game object ids and scripts
        static Dictionary<int, MovingGameObject> gameObjectIdsScripts =
            new Dictionary<int, MovingGameObject>();

        // keep track of game objects in game
        static List<GameObject> gameObjects = new List<GameObject>();
        static List<int> instantiatedGameObjectIds = new List<int>();

        // flag for invalid destroy
        static bool invalidDestroy = false;

        // test objects
        static RandomMovingGameObjects randomMovingGameObjects;
        static MovingGameObject prefab0Script;
        static MovingGameObject prefab1Script;
        static MovingGameObject prefab2Script;

        // prefabs
        static GameObject prefab0;
        static GameObject prefab1;
        static GameObject prefab2;

        /// <summary>
        /// Tests the MovingGameObject and RandomMovingGameObjects classes
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // set up FindGameObjectByTag delegate
            GameObject.AddFindObjectByTagDelegate(FindGameObjectByTag);

            // set up listeners for instantiate and destroy events
            GameObject.AddInstantiateListener(HandleInstantiateEvent);
            GameObject.AddDestroyListener(HandleDestroyEvent);

            // set up test object
            randomMovingGameObjects =
                new RandomMovingGameObjects();
            randomMovingGameObjects.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero));

            // create prefabs for moving game objects and add to 
            // RandomMovingGameObjects
            prefab0Script = new MovingGameObject();
            prefab0Script.gameObject = new GameObject(0,
                new Transform(Vector3.zero), "MovingGameObject");
            prefab0 = prefab0Script.gameObject;
            gameObjectIdsScripts.Add(prefab0.id, prefab0Script);
            prefab1Script = new MovingGameObject();
            prefab1Script.gameObject = new GameObject(1,
                new Transform(Vector3.zero), "MovingGameObject");
            prefab1 = prefab1Script.gameObject;
            gameObjectIdsScripts.Add(prefab1.id, prefab1Script);
            prefab2Script = new MovingGameObject();
            prefab2Script.gameObject = new GameObject(2,
                new Transform(Vector3.zero), "MovingGameObject");
            prefab2 = prefab2Script.gameObject;
            gameObjectIdsScripts.Add(prefab2.id, prefab2Script);
            randomMovingGameObjects.SetPrefabs(prefab0, prefab1,
                prefab2);

            // run selected test case
            int testCaseNumber = int.Parse(Console.ReadLine());
            switch (testCaseNumber)
            {
                case 1:
                    InitializeTestCase();
                    FirstInstantiationTest();
                    break;
                case 2:
                    InitializeTestCase();
                    MultipleInstantiationsTest();
                    break;
                case 3:
                    InitializeTestCase();
                    AllThreePrefabsTest();
                    break;
                case 4:
                    InitializeTestCase();
                    InvalidDestroysTest();
                    break;
                case 5:
                    InitializeTestCase();
                    RandomImpulseForceTest();
                    break;
            }
        }

        /// <summary>
        /// Clears all lists associated with testing
        /// </summary>
        static void InitializeTestCase()
        {
            gameObjects.Clear();
            instantiatedGameObjectIds.Clear();
        }

        /// <summary>
        /// Tests to make the first game object is instantiated after
        /// a second
        /// </summary>
        static void FirstInstantiationTest()
        {
            // run the game for a second and make sure a game object was instantiated
            for (int i = 0; i < 61; i++)
            {
                randomMovingGameObjects.Update();
            }
            if (gameObjects.Count == 1)
            {
                Console.WriteLine("First instantiation test passed");
            }
            else
            {
                Console.WriteLine("First instantiation TEST FAILED!");
            }
        }

        /// <summary>
        /// Runs the game 20 times making sure only 1 game object is in the
        /// scene at a time
        /// </summary>
        static void MultipleInstantiationsTest()
        {
            bool testPassed = true;

            // run game for 10 seconds
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    randomMovingGameObjects.Update();
                }
                if (gameObjects.Count != 1)
                {
                    testPassed = false;
                }
            }

            if (testPassed)
            {
                Console.WriteLine("Multiple Instantiations test passed");
            }
            else
            {
                Console.WriteLine("Multiple Instantiations TEST FAILED!");
            }
        }

        /// <summary>
        /// Test that all 3 prefabs were instantiated
        /// </summary>
        static void AllThreePrefabsTest()
        {
            bool testPassed = true;

            // run game for 30 seconds
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    randomMovingGameObjects.Update();
                }
            }

            // make sure all 3 prefabs were instantiated at least once
            if (instantiatedGameObjectIds.Contains(prefab0.id) &&
                instantiatedGameObjectIds.Contains(prefab1.id) &&
                instantiatedGameObjectIds.Contains(prefab2.id))
            {
                Console.WriteLine("All three prefabs instantiated test passed");
            }
            else
            {
                Console.WriteLine("All three prefabs instantiated TEST FAILED!");
            }
        }

        /// <summary>
        /// Test that only game objects in the game are destroyed
        /// </summary>
        static void InvalidDestroysTest()
        {
            // run game for 30 seconds
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    randomMovingGameObjects.Update();
                }
            }

            // check for any invalid destroys
            if (!invalidDestroy)
            {
                Console.WriteLine("Invalid destroys test passed");
            }
            else
            {
                Console.WriteLine("Invalid destroys TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests that random impulse forces are applied
        /// </summary>
        static void RandomImpulseForceTest()
        {
            // keep track of added impulse forces in the game
            List<Vector2> addedImpulseForces = new List<Vector2>();

            // run game for 30 seconds
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    randomMovingGameObjects.Update();
                }

                // save impulse force for later checking
                if (gameObjects.Count > 0)
                {
                    addedImpulseForces.Add(GetLastAddedImpulseForce(gameObjects[0]));
                }
            }

            // make sure there was a variety of impulse forces added
            int differentImpulseForceCount = 0;
            for (int i = 1; i < addedImpulseForces.Count; i++)
            {
                if (addedImpulseForces[i] != addedImpulseForces[i - 1])
                {
                    differentImpulseForceCount++;
                }
            }
            if (differentImpulseForceCount >= 15)
            {
                Console.WriteLine("Random impulse force test passed");
            }
            else
            {
                Console.WriteLine("Random impulse force TEST FAILED!");
            }
        }

        /// <summary>
        /// Because there's only zero or one game objects in the game at a time,
        /// simply returns null if there are zero and the game object if there's one 
        /// </summary>
        /// <param name="tag">tag</param>
        /// <returns>game object</returns>
        static GameObject FindGameObjectByTag(string tag)
        {
            if (gameObjects.Count == 0)
            {
                return null;
            }
            else
            {
                return gameObjects[0];
            }
        }

        /// <summary>
        /// Adds the instantiated game object to the game and to the list
        /// of game object ids that have been instantiated as the game ran.
        /// Also calls the Start method for the MonoBehaviour attached to
        /// the instantiated game object
        /// </summary>
        /// <param name="gameObject">instantiated game object</param>
        static void HandleInstantiateEvent(GameObject gameObject)
        {
            instantiatedGameObjectIds.Add(gameObject.id);
            if (gameObjectIdsScripts.ContainsKey(gameObject.id))
            {
                gameObjectIdsScripts[gameObject.id].Start();
            }
            gameObjects.Add(gameObjectIdsScripts[gameObject.id].gameObject);
        }

        /// <summary>
        /// Checks to make sure the object being destroyed is the object
        /// that's currently in the game and removes the game object from 
        /// the game
        /// </summary>
        /// <param name="gameObject"></param>
        static void HandleDestroyEvent(GameObject gameObject)
        {
            if (gameObjects.Count == 0 ||
                gameObject.id != gameObjects[0].id)
            {
                invalidDestroy = true;
            }
            else
            {
                gameObjects.Remove(gameObject);
            }
        }

        /// <summary>
        /// Gets the last added impulse force for the given game object. Returns
        /// Vector2.zero if there weren't any impulse forces added
        /// The last impulse force is the most recent one; that's what we need
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        static Vector2 GetLastAddedImpulseForce(GameObject gameObject)
        {
            Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
            List<Vector2> pastImpulseForces = rb2d.GetPastForces(ForceMode2D.Impulse);
            if (pastImpulseForces.Count > 0)
            {
                return pastImpulseForces[pastImpulseForces.Count - 1];
            }
            else
            {
                return Vector2.zero;
            }
			
        }
    }
}
