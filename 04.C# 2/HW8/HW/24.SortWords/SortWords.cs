using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class SortWords
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection words = Regex.Matches(userText, @"\b\w+\b");

        string [] wordsArray = new string [words.Count];

        int index = 0;
        foreach (Match word in words)
        {
            wordsArray[index] = word.ToString();
            index++;
        }
        Array.Sort(wordsArray);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The sorted words are:");

        foreach (string sortedWord in wordsArray)
        {
            Console.WriteLine(sortedWord);
        }
    }
}

