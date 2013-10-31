using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>() { 
            {".NET", "platform for applications from Microsoft"},
            {"CLR", "managed execution environment for .NET namespace – hierarchical organization of classes"}
        };

        Console.Write("Enter the word you search:");
        string userWord = Console.ReadLine();

        Console.WriteLine(new String('*', 20));
        if (dictionary.ContainsKey(userWord))
        {
            Console.WriteLine(dictionary[userWord]);
        }
        else
        {
            Console.WriteLine("Unknown word!");
        }
    }
}
