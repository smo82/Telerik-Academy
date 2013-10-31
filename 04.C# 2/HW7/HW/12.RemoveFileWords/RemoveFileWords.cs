using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class RemoveFileWords
{
    static List<string> GetWordsList(string pathWordFile)
    {
        List<string> result = new List<string>();

        StreamReader wordFile = new StreamReader(pathWordFile);

        using (wordFile)
        {
            string line = wordFile.ReadLine();

            while (line != null)
            {
                result.AddRange(line.Split(' '));
                line = wordFile.ReadLine();
            }
        }

        return result;
    }

    static void DeleteWordsFromFile (List<string> words, string pathInputFile)
    {
        string pathTempOutputFile = "temp.txt";

        StreamReader inputFile = new StreamReader(pathInputFile);

        using (inputFile)
        {
            StreamWriter tempOutputFile = new StreamWriter(pathTempOutputFile);

            using (tempOutputFile)
            {
                string line = inputFile.ReadLine();

                while (line != null)
                {
                    string[] fileWords = line.Split(' ');

                    StringBuilder newLine = new StringBuilder();

                    foreach (string word in fileWords)
                    {
                        if (words.IndexOf(word) < 0)
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

        File.Delete(pathInputFile);
        File.Move(pathTempOutputFile, pathInputFile);
    }

    static void Main()
    {
        string pathInputFile = "input.txt";
        string pathWordFile = "words.txt";

        List<string> words = new List<string>();
        try
        {
            words = GetWordsList(pathWordFile);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path for words file is null!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path for words file is an empty string!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Words file not found!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory for words file not found!");
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the words file Input/Output!");
        }
        catch (Exception ex)
        {
            if ((ex is StackOverflowException) ||
                (ex is OutOfMemoryException))
            {
                Console.WriteLine("Too big words file!");
            }
            else
            {
                throw;
            }
        }

        //If there are any words to be removed we continue with the target file
        if (words.Count > 0)
        {
            try
            {
                DeleteWordsFromFile(words, pathInputFile);
                Console.WriteLine("The words were deleted successfully!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path for input file is null!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path for input file is an empty string!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Input file not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory for input file not found!");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with the input file Input/Output!");
            }
        }
        else
        {
            Console.WriteLine("No words to be removed!");
        }
    }
}
