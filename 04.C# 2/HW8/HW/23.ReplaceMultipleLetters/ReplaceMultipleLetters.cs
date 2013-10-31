using System;
using System.Text.RegularExpressions;

class ReplaceMultipleLetters
{
    static void Main()
    {
        Console.Write("Enter your text:");
        string userText = Console.ReadLine();

        userText = Regex.Replace(userText, @"(\w)(\1)+", "$1");

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("The result string is: {0}", userText);
    }
}
