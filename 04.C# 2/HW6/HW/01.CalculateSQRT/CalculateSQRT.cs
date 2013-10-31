using System;

class CalculateSQRT
{
    static void Main()
    {
        Console.Write("Enter your integer number:");
        try
        {
            int userNumber = int.Parse(Console.ReadLine());

            if (userNumber < 0)
            {
                throw new ArgumentException();
            }

            double squareRootNumber = Math.Sqrt(userNumber);
            Console.WriteLine("The square root of your number is: {0}", squareRootNumber);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
