using System;
using System.IO;

class ReplaceString
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
                StreamWriter outputFile = new StreamWriter(pathOutputFile);

                using (outputFile)
                {
                    string line = inputFile.ReadLine();

                    while (line != null)
                    {
                        line = line.Replace("start", "finish");
                        outputFile.WriteLine(line);
                        line = inputFile.ReadLine();
                    }
                }

                Console.WriteLine("The string was successfully replaced!");
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
