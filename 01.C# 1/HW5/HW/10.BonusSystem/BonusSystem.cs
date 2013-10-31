using System;

class BonusSystem
{
    static void Main()
    {
        Console.Write("Enter your score:");
        ConsoleKeyInfo userInput = Console.ReadKey();
        Console.WriteLine();

        int result = 0;
        switch (userInput.KeyChar)
        {
            case '1':
            case '2':
            case '3':
                result = (int) Char.GetNumericValue(userInput.KeyChar) * 10;
                break;
            case '4':
            case '5':
            case '6':
                result = (int)Char.GetNumericValue(userInput.KeyChar) * 100;
                break;
            case '7':
            case '8':
            case '9':
                result = (int)Char.GetNumericValue(userInput.KeyChar) * 1000;
                break;
            default:
                Console.WriteLine("Wrong digit!");
                break;
        }

        if (result !=0)
        {
            Console.WriteLine("Your bonus is: {0}", result);
        }
    }
}
