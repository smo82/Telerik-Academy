using System;

class CalculateAge
{
    static void Main()
    {
        Console.WriteLine("Please enter your age:");
        int age = Convert.ToInt32(Console.ReadLine());
        age += 10;
        Console.WriteLine("Your age after 10 years will be: " + age);
    }
}