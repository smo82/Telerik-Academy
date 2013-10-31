using System;

public class Hello
{
    public static string HelloPerson (string name)
    {
        if (name != "")
        {
            return "Hello, " + name + "!";
        }
        else 
        {
            return "";
        }
    }

    static void Main()
    {
        Console.Write("Please enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine(HelloPerson(name));
    }
}
