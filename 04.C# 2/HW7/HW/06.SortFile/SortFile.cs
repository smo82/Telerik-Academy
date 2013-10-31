using System;
using System.IO;
using System.Collections.Generic;

class SortFile
{
    static void Main()
    {
        string pathInputFile = "input.txt";
        string pathOutputFile = "output.txt";

        try
        {
            StreamReader inputFile = new StreamReader(pathInputFile);

            using (inputFile)
            {
                string line = inputFile.ReadLine();

                List<string> fileContent = new List<string>();

                while (line != null)
                {
                    fileContent.Add(line);
                    line = inputFile.ReadLine();
                }

                string[] fileContentArr = fileContent.ToArray();

                Array.Sort(fileContentArr);

                StreamWriter outputFile = new StreamWriter(pathOutputFile);

                using (outputFile)
                {
                    for (int i = 0; i < fileContentArr.Length; i++)
                    {
                        outputFile.WriteLine(fileContentArr[i]);
                    }
                }

                Console.WriteLine("The file was sorted successfully!");
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
