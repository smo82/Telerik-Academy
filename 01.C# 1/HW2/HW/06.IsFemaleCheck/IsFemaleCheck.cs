using System;

class IsFemaleCheck
{
    static void Main()
    {
        bool isFemale;

        Console.Write("Please enter your gender (m/f): ");
        char genderChar = char.Parse(Console.ReadLine());

        isFemale = (genderChar == 'f');

        Console.WriteLine("Are you a female? {0}", isFemale);
    }
}

