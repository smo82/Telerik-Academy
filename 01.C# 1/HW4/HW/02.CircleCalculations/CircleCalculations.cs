using System;
using System.Threading;
using System.Globalization;

class CircleCalculations
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter the circle radius:");
        decimal radius;
        while (!decimal.TryParse(Console.ReadLine(), out radius))
        {
            Console.Write("Incorrect decimal number, please enter the circle radius:");
        }

        Console.WriteLine("The circle perimeter is {0:F2}", 2 * (decimal) Math.PI * radius);
    }
}