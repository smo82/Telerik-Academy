using System;
using System.Text.RegularExpressions;

class FindPalindrome
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        MatchCollection matches = Regex.Matches(userText, @"\b[a-zA-Z0-9]+\b");

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The found palindromes are:");

        foreach (Match match in matches)
        {
            char [] matchChars = match.ToString().ToCharArray();
            Array.Reverse(matchChars);
            string reverseMatch = new string(matchChars);
            if (match.ToString() == reverseMatch)
            {
                Console.WriteLine(match);
            }
        }
    }
}

