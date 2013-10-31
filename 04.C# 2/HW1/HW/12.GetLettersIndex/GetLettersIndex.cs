using System;

class GetLettersIndex
{
    static void Main()
    {
        string englishLetters = "";

        for (int i = 65; i < 91; i++)
        {
            englishLetters += (char)i;
        }

        Console.Write("Please enter your word: ");
        string word = Console.ReadLine().ToUpper();

        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine(englishLetters.IndexOf(word[i]));
        }
    }
}
