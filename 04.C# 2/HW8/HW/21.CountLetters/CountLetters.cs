using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class CountLetters
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection letters = Regex.Matches(userText, "\\w");

        Dictionary<string, int> letterDictionary = new Dictionary<string, int>();

        foreach (Match letter in letters)
	    {
            if (letterDictionary.ContainsKey(letter.ToString()))
            {
                letterDictionary[letter.ToString()]++;
            }
            else
            {
                letterDictionary.Add(letter.ToString(), 1);
            }
	    }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The letters count is:");

        foreach (KeyValuePair<string,int> pair in letterDictionary)
	    {
            Console.WriteLine("\"{0}\" : {1,2}", pair.Key, pair.Value);
	    }
    }
}
