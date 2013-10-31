using System;
using System.IO;

class ConcatenateTwoFiles
{
    static void Main()
    {
        string pathInputFile1 = "input1.txt";
        string pathInputFile2 = "input2.txt";
        string pathOutputFile = "output.txt";
        
        try
        {
            StreamReader inputFile1 = new StreamReader(pathInputFile1);
            using (inputFile1)
            {
                StreamReader inputFile2 = new StreamReader(pathInputFile2);
                using (inputFile2)
                {
                    StreamWriter outputFile = new StreamWriter(pathOutputFile);

                    using (outputFile)
                    {
                        string inputContent = inputFile1.ReadToEnd();
                        outputFile.Write(inputContent);

                        outputFile.WriteLine();

                        inputContent = inputFile2.ReadToEnd();
                        outputFile.Write(inputContent);

                        Console.WriteLine("The files were concatenated successfully!");
                    }
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}