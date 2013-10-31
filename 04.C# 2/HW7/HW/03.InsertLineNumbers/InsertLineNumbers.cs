using System;
using System.IO;

class InsertLineNumbers
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
                
                    string inputContent = inputFile.ReadLine();
                    int index = 1;
                    while (inputContent != null)
                    {
                        outputFile.WriteLine("Line {0, 2}: {1}", index, inputContent);
                        index++;
                        inputContent = inputFile.ReadLine();
                    }
                    
                    Console.WriteLine("The file was numbered successfully!");
                } 
            }            
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
