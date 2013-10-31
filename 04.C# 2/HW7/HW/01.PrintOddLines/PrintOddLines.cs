using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        string pathInputFile = "input.txt";

        try
            {
            StreamReader inputFile = new StreamReader(pathInputFile);

            using (inputFile)
            {
            
                int index = 1;
                string line = inputFile.ReadLine();

                while (line != null)
                {
                    if ((index & 1) == 1)
                    {
                        Console.WriteLine("Line {0}: {1}", index, line);
                    }

                    line = inputFile.ReadLine();
                    index++;
                }
            }   
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
