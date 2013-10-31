using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class CountWords
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

    static int [] CountFileWords(List<string> words, string pathInputFile)
    {
        int[] result = new int[words.Count];
        StreamReader inputFile = new StreamReader(pathInputFile);

        using (inputFile)
        {
            
            string line = inputFile.ReadLine();

            while (line != null)
            {
                string[] fileWords = line.Split(' ');

                foreach (string word in fileWords)
                {
                    int indexWord = words.IndexOf(word);
                    if (indexWord >= 0)
                    {
                        result[indexWord]++;
                    }
                }
                line = inputFile.ReadLine();
            }
        }

        return result;
    }

    static void SortWordList(List<string> words, int[] countWords, out List<string> wordsSorted, out int[] countWordsSorted)
    {
        wordsSorted = new List<string>();
        var wordsCountSorted = countWords
            .Select((x, i) => new KeyValuePair<int, int>(x, i))
            .OrderByDescending(x => x.Key)
            .ToList();

        countWordsSorted = wordsCountSorted.Select(x => x.Key).ToArray();
        int[] indexSortedCount = wordsCountSorted.Select(x => x.Value).ToArray();

        foreach (int index in indexSortedCount)
        {
            wordsSorted.Add(words[index]);
        }
    }

    static void Main()
    {
        string pathTestFile = "test.txt";
        string pathWordFile = "words.txt";
        string pathOutputFile = "result.txt";

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
            int[] countWords = null;
            try
            {
                countWords = CountFileWords(words, pathTestFile);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Path for test file is null!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Path for test file is an empty string!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Input test not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory for test file not found!");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with the test file Input/Output!");
            }

            if (countWords != null)
            {

                SortWordList(words, countWords, out words, out countWords);

                try
                {
                    StreamWriter outputFile = new StreamWriter(pathOutputFile);

                    using (outputFile)
                    {
                        for (int i = 0; i < countWords.Length; i++)
                        {
                            outputFile.WriteLine("{0, 2} - {1}", countWords[i], words[i]);
                        }
                    }
                    Console.WriteLine("The words were counted successfully!");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Not authorized access to result file!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Path for result file is null!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong path to result file!");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Directory to the result file not found!");
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine("Path to the result file too long!");
                }
                catch (IOException)
                {
                    Console.WriteLine("Input/Output exception for the result file!");
                }
                catch (System.Security.SecurityException)
                {
                    Console.WriteLine("You don't have the required permission to access the result file!");
                }
            }
        }
        else
        {
            Console.WriteLine("No words to count!");
        }
    }
}
