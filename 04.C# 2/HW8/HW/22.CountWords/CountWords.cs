using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class CountWords
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection words = Regex.Matches(userText, @"\b\w+\b");

        Dictionary<string, int> letterDictionary = new Dictionary<string, int>();

        foreach (Match word in words)
	    {
            if (letterDictionary.ContainsKey(word.ToString()))
            {
                letterDictionary[word.ToString()]++;
            }
            else
            {
                letterDictionary.Add(word.ToString(), 1);
            }
	    }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The words count is:");

        foreach (KeyValuePair<string,int> pair in letterDictionary)
	    {
            Console.WriteLine("{0,-10} : {1,2}", pair.Key, pair.Value);
	    }
    }
}

