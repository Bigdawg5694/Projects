using System;
using UnityEngine;

namespace ProgrammingAssignment3
{
    /// <summary>
    /// Programming Assignment 3
    /// </summary>
    class Program
    {
        // unique rock id support
        static int currentRockId = -1;

        // mapping between game object ids and scripts
        static Dictionary<int, Rock> gameObjectIdsScripts =
            new Dictionary<int, Rock>();

        // keep track of game objects and sprites in game
        static List<GameObject> gameObjects = new List<GameObject>();
        static List<int> usedSpriteIds = new List<int>();

        // mapping betwen game object ids and added impulse forces in the game
        static Dictionary<int, Vector2> gameObjectIdsAddedImpulseForces =
            new Dictionary<int, Vector2>();

        // mapping betwen game object ids and sprite renderers in the game
        static Dictionary<int, SpriteRenderer> gameObjectIdsSpriteRenderers =
            new Dictionary<int, SpriteRenderer>();

        // timers to run in game
        static List<Timer> timers = new List<Timer>();

        // prefab
        static GameObject prefabRock;

        // sprites
        static Sprite sprite1;
        static Sprite sprite2;
        static Sprite sprite3;

        // test object
        static RockSpawner rockSpawner;

        /// <summary>
        /// Tests the Rock and RockSpawner classes
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // delegate for FindGameObjectsWithTag
            GameObject.AddFindObjectsByTagDelegate(FindObjectsWithTagDelegate);

            // delegate for AddComponent
            GameObject.AddAddComponentDelegate(typeof(SpriteRenderer),
                AddSpriteRendererComponent);

            // listeners for Unity events
            GameObject.AddInstantiateListener(HandleInstantiateEvent);
            GameObject.AddDestroyListener(HandleDestroyEvent);
            GameObject.AddAddComponentEventListener(HandleAddComponentEvent);

            // set up test support objects
            prefabRock = new GameObject(int.MaxValue,
                new Transform(Vector3.zero));
            sprite1 = new Sprite(1);
            sprite2 = new Sprite(2);
            sprite3 = new Sprite(3);

            // set up test objects
            rockSpawner = new RockSpawner();
            rockSpawner.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero));
            rockSpawner.SetSerializedFields(prefabRock, sprite1, sprite2, sprite3);
            rockSpawner.Start();

            // run selected test case
            int testCaseNumber = int.Parse(Console.ReadLine());
            switch (testCaseNumber)
            {
                case 1:
                    InitializeTestCase();
                    OnlyOneRockAfterOneSecondTest();
                    break;
                case 2:
                    InitializeTestCase();
                    OnlyTwoRocksAfterTwoSecondsTest();
                    break;
                case 3:
                    InitializeTestCase();
                    OnlyThreeRocksAfterFiveSecondsTest();
                    break;
                case 4:
                    InitializeTestCase();
                    AllThreeSpritesUsedTest();
                    break;
                case 5:
                    InitializeTestCase();
                    RandomDiagonalImpulseForceTest();
                    break;
            }
        }

        /// <summary>
        /// Resets test configuration
        /// </summary>
        static void InitializeTestCase()
        {
            currentRockId = -1;
            gameObjectIdsScripts.Clear();
            gameObjects.Clear();
            usedSpriteIds.Clear();
            gameObjectIdsSpriteRenderers.Clear();
            gameObjectIdsAddedImpulseForces.Clear();
        }

        /// <summary>
        /// Tests to make sure there's only one rock after one second
        /// of gameplay
        /// </summary>
        static void OnlyOneRockAfterOneSecondTest()
        {
            RunOneSecond();
            if (gameObjects.Count == 1)
            {
                Console.WriteLine("One rock after one second test passed");
            }
            else
            {
                Console.WriteLine("One rock after one second TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests to make sure there's only two rocks after two seconds
        /// of gameplay
        /// </summary>
        static void OnlyTwoRocksAfterTwoSecondsTest()
        {
            RunOneSecond();
            RunOneSecond();
            if (gameObjects.Count == 2)
            {
                Console.WriteLine("Two rocks after two seconds test passed");
            }
            else
            {
                Console.WriteLine("Two rocks after two seconds TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests to make sure there's only three rocks after five seconds
        /// of gameplay
        /// </summary>
        static void OnlyThreeRocksAfterFiveSecondsTest()
        {
            for (int i = 0; i < 5; i++)
            {
                RunOneSecond();
            }
            if (gameObjects.Count == 3)
            {
                Console.WriteLine("Three rocks after five seconds test passed");
            }
            else
            {
                Console.WriteLine("Three rocks after five seconds TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests that all three sprites were used for spawning
        /// </summary>
        static void AllThreeSpritesUsedTest()
        {
            // run game for 120 seconds
            for (int i = 1; i <= 120; i++)
            {
                RunOneSecond();

                // simulate rock leaving screen every 4 seconds
                if (gameObjects.Count > 0)
                {
                    if (i % 4 == 0)
                    {
                        gameObjectIdsScripts[gameObjects[0].id].OnBecameInvisible();
                    }
                }
            }

            // make sure all 3 sprites were used at least once
            if (usedSpriteIds.Contains(sprite1.id) &&
                usedSpriteIds.Contains(sprite2.id) &&
                usedSpriteIds.Contains(sprite3.id))
            {
                Console.WriteLine("All three sprites used test passed");
            }
            else
            {
                Console.WriteLine("All three sprites used TEST FAILED!");
            }
        }

        /// <summary>
        /// Tests that random diagonal impulse forces are applied
        /// </summary>
        static void RandomDiagonalImpulseForceTest()
        {
            // run game for 120 seconds
            for (int i = 1; i <= 120; i++)
            {
                RunOneSecond();

                // simulate rock leaving screen every 4 seconds
                if (gameObjects.Count > 0)
                {
                    if (i % 4 == 0)
                    {
                        gameObjectIdsScripts[gameObjects[0].id].OnBecameInvisible();
                    }
                }
            }

            // make sure there was a variety of diagonal impulse forces added
            int upRightImpulseForceCount = 0;
            int upLeftImpulseForceCount = 0;
            int downLeftImpulseForceCount = 0;
            int downRightImpulseForceCount = 0;
            foreach (int key in gameObjectIdsAddedImpulseForces.Keys)
            {
                Vector2 impulseForce = gameObjectIdsAddedImpulseForces[key];
                if (impulseForce.x > 0)
                {
                    if (impulseForce.y > 0)
                    {
                        upRightImpulseForceCount++;
                    }
                    else if (impulseForce.y < 0)
                    {
                        downRightImpulseForceCount++;
                    }
                }
                else if (impulseForce.x < 0)
                {
                    if (impulseForce.y > 0)
                    {
                        upLeftImpulseForceCount++;
                    }
                    else if (impulseForce.y < 0)
                    {
                        downLeftImpulseForceCount++;
                    }
                }
            }
            if (upRightImpulseForceCount > 0 &&
                upLeftImpulseForceCount > 0 &&
                downLeftImpulseForceCount > 0 &&
                downRightImpulseForceCount > 0)
            {
                Console.WriteLine("Random diagonal impulse force test passed");
            }
            else
            {
                Console.WriteLine("Random diagonal impulse force TEST FAILED!");
            }
        }

        /// <summary>
        /// Updates all the timers attached to game objects in the game
        /// </summary>
        static void UpdateTimers()
        {
            foreach (Timer timer in timers)
            {
                timer.Update();
            }
        }

        /// <summary>
        /// Runs the game for one second
        /// </summary>
        static void RunOneSecond()
        {
            for (int i = 0; i < 61; i++)
            {
                UpdateTimers();
                rockSpawner.Update();
            }
        }

        /// <summary>
        /// Delegate for GameObject FindGameObjectsWithTag method
        /// </summary>
        /// <param name="unused">unused</param>
        /// <returns>array of rocks in game</returns>
        static GameObject[] FindObjectsWithTagDelegate(string unused)
        {
            // simply returns all the game objects in the game, since
            // the only ones we care about are rocks
            return gameObjects.ToArray();
        }

        /// <summary>
        /// Assigns unique id and adds to list of rocks in game
        /// </summary>
        /// <param name="gameObject">new rock</param>
        static void HandleInstantiateEvent(GameObject gameObject)
        {
            // set new rock id and save
            currentRockId++;
            gameObject.id = currentRockId;

            // add rigidbody 2d and sprite renderer to new rock
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.AddComponent<SpriteRenderer>();

            // set up Rock object and call Start
            Rock rock = new Rock();
            rock.gameObject = gameObject;
            rock.Start();

            // save impulse force added to rock by Start method
            gameObjectIdsAddedImpulseForces.Add(rock.gameObject.id,
                GetLastAddedImpulseForce(rock.gameObject));

            // save mapping from game object id to Rock script
            gameObjectIdsScripts.Add(rock.gameObject.id, rock);

            // add to active game objects
            gameObjects.Add(gameObject);
        }

        /// <summary>
        /// Removes from list of rocks in game
        /// </summary>
        /// <param name="rock">rock being destroyed</param>
        static void HandleDestroyEvent(GameObject rock)
        {
            // remove rock from mapping and list
            gameObjectIdsScripts.Remove(rock.id);
            gameObjects.Remove(rock);

            // don't remove from added impulse forces mapping

            // save sprite id for game object
            if (gameObjectIdsSpriteRenderers.ContainsKey(rock.id))
            {
                usedSpriteIds.Add(gameObjectIdsSpriteRenderers[rock.id].sprite.id);
            }
        }

        /// <summary>
        /// Handles the add component event to we can run timers
        /// </summary>
        /// <param name="gameObjectId">game object id</param>
        /// <param name="componentType">component type</param>
        /// <param name="component">added components</param>
        static void HandleAddComponentEvent(int gameObjectId, Type componentType, Object component)
        {
            if (componentType == typeof(Timer))
            {
                timers.Add(component as Timer);
            }
        }

        /// <summary>
        /// Adds a SpriteRenderer to the given game object
        /// </summary>
        static Object AddSpriteRendererComponent(GameObject gameObject)
        {
            // create and save sprite renderer for later reference
            SpriteRenderer spriteRenderer = new SpriteRenderer(sprite1);
            gameObjectIdsSpriteRenderers.Add(gameObject.id,
                spriteRenderer);
            return (spriteRenderer as SpriteRenderer);
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
