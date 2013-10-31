using System;
using System.Text.RegularExpressions;
using System.Text;

class ReverseSentence
{
    static void Main()
    {
        Console.Write("Enter your sentance:");
        string userSentance = Console.ReadLine();

        string[] sentanceWords = Regex.Split(userSentance, @"([ |,]+)");

        string sentenceEnd = sentanceWords[sentanceWords.Length - 1];

        sentanceWords[sentanceWords.Length - 1] = sentenceEnd.Substring(0, sentenceEnd.Length - 1);
        sentenceEnd = sentenceEnd.Substring(sentenceEnd.Length - 1, 1);

        StringBuilder reverseString = new StringBuilder();

        for (int i = sentanceWords.Length - 1; i >= 0; i = i-2)
        {
            reverseString.Append(sentanceWords[i]);
            if (i > 0)
            {
                reverseString.Append(sentanceWords[sentanceWords.Length - i]);
            }
        }

        reverseString.Append(sentenceEnd);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your reversed sentance is:");
        Console.WriteLine(reverseString);
    }
}