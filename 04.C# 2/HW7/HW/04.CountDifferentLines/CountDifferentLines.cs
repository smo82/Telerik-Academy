using System;
using System.IO;

class CountDifferentLines
{
    static void Main()
    {
        string pathInputFile1 = "input1.txt";
        string pathInputFile2 = "input2.txt";

        try
        {
            StreamReader inputFile1 = new StreamReader(pathInputFile1);
            using (inputFile1)
            {
                StreamReader inputFile2 = new StreamReader(pathInputFile2);
                using (inputFile2)
                {
                    string inputContentFile1 = inputFile1.ReadLine();
                    string inputContentFile2 = inputFile2.ReadLine();

                    int countDifferences = 0;
                    while (inputContentFile1 != null)
                    {
                        if (inputContentFile1 != inputContentFile2)
                        {
                            countDifferences++;
                        }

                        inputContentFile1 = inputFile1.ReadLine();
                        inputContentFile2 = inputFile2.ReadLine();
                    }

                    Console.WriteLine("The files were compared successfully!");
                    Console.WriteLine("The number of different lines is: {0}", countDifferences);
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
