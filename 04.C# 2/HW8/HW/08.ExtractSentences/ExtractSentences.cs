using System;
using System.Text.RegularExpressions;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        Console.Write("Enter your word:");
        string userWord = Console.ReadLine();

        string[] sentences = userString.Split('.');
        StringBuilder resultText = new StringBuilder();

        for (int i = 0; i < sentences.Length; i++)
        {
            Match match = Regex.Match(sentences[i], "\\b" + userWord + "\\b");
            if (match.Success)
            {
                resultText.AppendLine(sentences[i].Trim() + ".");
            }
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is:");
        Console.WriteLine(resultText);
    }
}
