using UnityEngine;

namespace GradedExercise2
{
    /// <summary>
    /// Graded Exercise 2
    /// </summary>
    internal class Program
    {
        // test case to run
        static int testCaseNumber;

        // test support
        static List<string> outputLines = new List<string>();

        /// <summary>
        /// Tests the FileWriter and FileReader classes
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // add delegate for debug output
            Debug.LogEvent.AddListener(PrintDebugOutput);

            // loop while there's more input
            string input = Console.ReadLine();
            while (input[0] != 'q')
            {
                // extract test case number from string
                GetInputValueFromString(input);

                // execute selected test case
                switch (testCaseNumber)
                {
                    case 1:
                        FileWriterTest();
                        break;
                    case 2:
                        FileReaderTest();
                        break;
                }

                input = Console.ReadLine();
            }
        }

        /// <summary>
        /// Extracts the test case number from the given input string
        /// </summary>
        /// <param name="input">input string</param>
        static void GetInputValueFromString(string input)
        {
            testCaseNumber = int.Parse(input);
        }

        /// <summary>
        /// Tests the FileWriter class
        /// </summary>
        static void FileWriterTest()
        {
            // set up test object
            FileWriter fileWriter = new FileWriter();
            fileWriter.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero));

            // run test
            fileWriter.Start();
            StreamReader input = null;
            try
            {
                // create stream reader object
                input = File.OpenText("OneStepCloser.txt");

                // check 3 output lines
                string line = input.ReadLine();
                if (!LinesMatch(line, "Everything you say to me"))
                {
                    throw new Exception();
                }
                line = input.ReadLine();
                if (!LinesMatch(line, "Takes me one step closer to the edge"))
                {
                    throw new Exception();
                }
                line = input.ReadLine();
                if (!LinesMatch(line, "And I'm about to break"))
                {
                    throw new Exception();
                }

                // make sure there are no extra lines in file
                line = input.ReadLine();
                if (line != null)
                {
                    throw new Exception();
                }

                // test case passed
                Console.WriteLine("FileWriter test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("FileWriter TEST FAILED!");
            }
            finally
            {
                // always close input file
                if (input != null)
                {
                    input.Close();
                }
            }
        }

        /// <summary>
        /// Tests the FileReader class
        /// </summary>
        static void FileReaderTest()
        {
            // set up test object
            FileReader fileReader = new FileReader();
            fileReader.gameObject = new GameObject(int.MaxValue,
                new Transform(Vector3.zero));

            // run test
            // SHOULD COMPARE OUTPUT LINES TO CORRECT LINES
            fileReader.Start();

            // print results
            if (outputLines.Count == 3 &&
                LinesMatch(outputLines[0], "Everything you say to me") &&
                LinesMatch(outputLines[1], "Takes me one step closer to the edge") &&
                LinesMatch(outputLines[2], "And I'm about to break"))
            {
                Console.WriteLine("FileReader test passed");
            }
            else
            {
                Console.WriteLine("FileReader TEST FAILED!");
            }
        }

        /// <summary>
        /// Returns true if the lines match, false otherwise
        /// </summary>
        /// <param name="testLine">test line</param>
        /// <param name="correctLine">correct line</param>
        /// <returns>true if lines match, false otherwise</returns>
        static bool LinesMatch(string testLine, string correctLine)
        {
            if (testLine == null)
            {
                return false;
            }
            else if (testLine != correctLine)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Delegate for printing debug output
        /// </summary>
        /// <param name="message">message to print</param>
        static void PrintDebugOutput(string message)
        {
            outputLines.Add(message);
        }
    }
}
