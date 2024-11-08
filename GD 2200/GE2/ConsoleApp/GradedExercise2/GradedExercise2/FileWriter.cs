using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Writes a text file
/// </summary>
public class FileWriter : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void Start()
	{
        // add your code here
        //write to a txt file
        StreamWriter output = null;
        try
        {
            //create stream writer object
            output = File.CreateText("OneStepCloser.txt");

            //write the text lines
            output.WriteLine("Everything you say to me");
            output.WriteLine("Takes me one step closer to the edge");
            output.WriteLine("And I'm about to break");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            //always close output
            if (output != null)
            {
                output.Close();
            }
        }
    }
}
