using System;

class HelloWorldString
{
    static void Main()
    {
        string hello = "Hello";
        string world = "world";

        object stringConcat = hello + " " + world;

        string helloWorld = (string) stringConcat;

        Console.WriteLine(helloWorld);
    }
}

