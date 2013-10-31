/*
 * Task03
 * 
 * Write a program that counts how many times each word from given text file words.txt appears in it. 
 * The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text.
 * 
 * Example:
 * This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
 * 
 * is -> 2
 * the -> 2
 * this -> 3
 * text -> 6
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class CountWordsMain
{
    static void Main(string[] args)
    {
        List<string> words = new List<string>();
        using (StreamReader inputReader = new StreamReader("input.txt"))
        {
            String line = inputReader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split(new char[] { ' ', '.', ',', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                words.AddRange(lineWords.Select(s => s.ToLowerInvariant()));
                line = inputReader.ReadLine();
            }
        }

        Dictionary<string, int> wordsCount = FunctionCollection.CountValues<string>(words);

        wordsCount = wordsCount.OrderBy(keyPair => keyPair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        Console.Clear();
        Console.WriteLine("The sorted words are:");

        foreach (KeyValuePair<string, int> wordPair in wordsCount)
        {
            Console.WriteLine("{0} : {1}", wordPair.Key, wordPair.Value);
        }
    }
}