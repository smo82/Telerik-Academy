using System;
using System.Text.RegularExpressions;

class FormatLinks
{
    static void Main(string[] args)
    {
        Console.Write("Enter your HTML:");

        string userHTML = Console.ReadLine();

        string resultHTML = Regex.Replace(userHTML, @"<a href=""(?<url>[^""]*)"">", "[URL=${url}]", RegexOptions.Multiline);
        resultHTML = Regex.Replace(resultHTML, @"</a>", "[/URL]");
        
        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your formatted HTML is:");
        Console.WriteLine(resultHTML);
    }
}
