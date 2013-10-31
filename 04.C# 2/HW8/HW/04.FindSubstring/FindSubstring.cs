using System;

class FindSubstring
{
    static void Main()
    {
        Console.Write("Enter your string:");
        string userString = Console.ReadLine();
        userString = userString.ToUpper();

        Console.Write("Enter the substring you want to count:");
        string userSubString = Console.ReadLine();
        userSubString = userSubString.ToUpper();

        int counter = 0;
        int index = userString.IndexOf(userSubString);

        while (index >= 0)
        {
            counter++;
            index = userString.IndexOf(userSubString, index+1);
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your substring was found {0} times.", counter);
    }
}
