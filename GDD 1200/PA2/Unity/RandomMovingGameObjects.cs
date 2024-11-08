using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager
/// </summary>
public class RandomMovingGameObjects : MonoBehaviour
{
    [SerializeField]
    GameObject prefabMovingGameObject0;
    [SerializeField]
    GameObject prefabMovingGameObject1;
    [SerializeField]
    GameObject prefabMovingGameObject2;

    // timing support
    const float ChangeDelaySeconds = 1;
    float elapsedSeconds = 0;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        elapsedSeconds += Time.deltaTime;
        if (elapsedSeconds > ChangeDelaySeconds)
        {
            elapsedSeconds = 0;

            // destroy current moving game object
            GameObject currentMovingGameObject = 
                GameObject.FindGameObjectWithTag("MovingGameObject");
            if (currentMovingGameObject != null)
            {
                Destroy(currentMovingGameObject);
            }

            // STUDENTS: uncomment the code below and make it generate a random number 
            // with a value of 0, 1, or 2 using the UnityEngine Random class and 
            // appropriate type casting
            //int prefabNumber = ;
            
            // STUDENTS: uncomment the lines below and implement
            // the required code
            //if (prefabNumber == 0)
            //{
            //    // STUDENTS: instantiate a new instance of the prefab
            //    // for MovingGameObject0 at location(0, 0, 0)
            //    Instantiate(prefabMovingGameObject0, Vector3.zero,
            //        Quaternion.identity);
            //}
            //else if (prefabNumber == 1)
            //{
            //    // STUDENTS: instantiate a new instance of the prefab
            //    // for MovingGameObject1 at location(0, 0, 0)
            //    Instantiate(prefabMovingGameObject1, Vector3.zero,
            //        Quaternion.identity);
            //}
            //else
            //{
            //    // STUDENTS: instantiate a new instance of the prefab
            //    // for MovingGameObject2 at location(0, 0, 0)
            //    Instantiate(prefabMovingGameObject2, Vector3.zero,
            //        Quaternion.identity);
            //}
        }
    }

    #region Autograder support

    /// <summary>
    /// Sets the prefabs for the moving game objects. The autograder
    /// needs this method because the prefabs can't be populated in
    /// the Unity editor in a console app
    /// </summary>
    /// <param name="prefab0">prefab 0</param>
    /// <param name="prefab1">prefab 1</param>
    /// <param name="prefab2">prefab 2</param>
    public void SetPrefabs(GameObject prefab0, GameObject prefab1, GameObject prefab2)
    {
        prefabMovingGameObject0 = prefab0;
        prefabMovingGameObject1 = prefab1;
        prefabMovingGameObject2 = prefab2;
    }

    #endregion
}

