using System;
using System.Collections.Generic;
using System.IO;

public class CountWordsMain
{
    public static void Main(string[] args)
    {
        Trie searchedWords = new Trie();

        FillSearchedWords(searchedWords);
        
        Dictionary<string, int> wordsCount = CountWords(searchedWords);

        PrintWordsCount(wordsCount);
    }

    private static void PrintWordsCount(Dictionary<string, int> wordsCount)
    {
        foreach (KeyValuePair<string, int> wordCount in wordsCount)
        {
            Console.WriteLine("{0, -20} : {1}", wordCount.Key, wordCount.Value);
        }
    }

    private static Dictionary<string, int> CountWords(Trie searchedWords)
    {
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        using (StreamReader inputReader = new StreamReader("wordsPool.txt"))
        {
            string line = inputReader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split(
                    new char[] { ' ', '.', ',', '-', '!', '?', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in lineWords)
                {
                    if (searchedWords.FoundWord(word))
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                        else
                        {
                            wordsCount[word] = 1;
                        }
                    }
                }

                line = inputReader.ReadLine();
            }
        }

        return wordsCount;
    }

    private static void FillSearchedWords(Trie searchedWords)
    {
        using (StreamReader inputReader = new StreamReader("searchedWords.txt"))
        {
            string line = inputReader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split(
                    new char[] { ' ', '.', ',', '-', '!', '?', '(', ')' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in lineWords)
                {
                    searchedWords.AddWord(word);
                }

                line = inputReader.ReadLine();
            }
        }
    }
}