using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        string pathInputFile = "input.txt";
        string pathTempOutputFile = "temp.txt";
       
        try
            {
            StreamReader inputFile = new StreamReader(pathInputFile);

            using (inputFile)
            {
                StreamWriter tempOutputFile = new StreamWriter(pathTempOutputFile);

                using (tempOutputFile)
                {
                    string line = inputFile.ReadLine();

                    int count = 1;
                    while (line != null)
                    {
                        if ((count & 1) == 0)
                        {
                            tempOutputFile.WriteLine(line);
                        }
                        
                        line = inputFile.ReadLine();
                        count++;
                    }
                }
            }

            Console.WriteLine("The odd lines were deleted successfully!");
            File.Delete(pathInputFile);
            File.Move(pathTempOutputFile, pathInputFile);
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
