using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

/// <summary>
/// Reads a text file
/// </summary>
public class FileReader : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
	{
        // add your code here
        StreamReader input = null;
        try
        {
            //create stream reader object
            input = File.OpenText("OneStepCloser.txt");

            //read and echo lines until end of file
            string line = input.ReadLine();
            while (line != null)
            {
                UnityEngine.Debug.Log(line);
                line = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log(e.Message);
        }
        finally
        {
            //always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
