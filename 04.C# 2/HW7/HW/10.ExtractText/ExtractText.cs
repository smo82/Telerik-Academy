using System;
using System.IO;

class ExtractText
{
    static void Main()
    {
        string pathInputFile = "input.txt";

        try
        {
            StreamReader inputFile = new StreamReader(pathInputFile);

            using (inputFile)
            {

                string line = inputFile.ReadLine();

                while (line != null)
                {
                    int index = 0;
                    while (index < line.Length)
                    {
                        if (line[index] == '<')
                        {
                            if (line.IndexOf('>', index + 1) < 0)
                            {
                                throw new FormatException();
                            }
                            index = line.IndexOf('>', index + 1) + 1;
                        }
                        else
                        {
                            int indexNextTag = line.IndexOf('<', index);
                            if (indexNextTag < 0)
                            {
                                Console.WriteLine(line.Substring(index));
                                index = line.Length;
                            }
                            else
                            {
                                Console.WriteLine(line.Substring(index, indexNextTag - index));
                                index = indexNextTag;
                            }
                        }
                    }

                    line = inputFile.ReadLine();
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong file format!");
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}