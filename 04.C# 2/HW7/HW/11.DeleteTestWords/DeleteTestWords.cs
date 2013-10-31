using System;
using System.IO;
using System.Text;

class DeleteTestWords
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

                    while (line != null)
                    {
                        string[] words = line.Split(' ');

                        StringBuilder newLine = new StringBuilder();

                        foreach (string word in words)
                        {
                            if ((word.Length < 4) || (word.Substring(0, 4) != "test"))
                            {
                                newLine.Append(word + ' ');
                            }
                        }
                        newLine.Remove(newLine.Length - 1, 1);

                        tempOutputFile.WriteLine(newLine);
                        line = inputFile.ReadLine();
                    }
                }
            }

            Console.WriteLine("The \"test\" words were deleted successfully!");
            File.Delete(pathInputFile);
            File.Move(pathTempOutputFile, pathInputFile);
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
