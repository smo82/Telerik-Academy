using System;
using System.Text;

class Reverse
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        StringBuilder userStringReversed = new StringBuilder(userString.Length);

        for (int i = userString.Length-1; i >= 0; i--)
        {
            userStringReversed.Append(userString[i]);
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your string reversed is:" + userStringReversed);
    }
}
