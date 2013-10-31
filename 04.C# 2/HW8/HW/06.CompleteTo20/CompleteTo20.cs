using System;
class CompleteTo20
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();

        while (userString.Length > 20)
        {
            Console.Write("Your string is too long, please try again:");
            userString = Console.ReadLine();
        }

        userString = userString + new String('*', 20 - userString.Length);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result string is: {0}", userString);
    }
}
