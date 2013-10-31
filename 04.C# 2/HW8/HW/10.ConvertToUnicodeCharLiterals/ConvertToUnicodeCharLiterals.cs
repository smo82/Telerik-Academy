using System;
using System.Text;

class ConvertToUnicodeCharLiterals
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < userString.Length; i++)
        {
            result.Append(String.Format("\\u{0:x4}", (int)userString[i]));
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is:");
        Console.WriteLine(result);
    }
}