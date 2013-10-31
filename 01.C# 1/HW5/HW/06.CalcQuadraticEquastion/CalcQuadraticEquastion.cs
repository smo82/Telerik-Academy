using System;

class CalcQuadraticEquastion
{
    static void Main()
    {
        Console.Write("Enter cuefficient a:");
        double a;

        while ((!double.TryParse(Console.ReadLine(), out a)) || (a == 0))
        {
            Console.Write("Incorrect cuefficient a, please enter it again:");
        }

        Console.Write("Enter cuefficient b:");
        double b;

        while (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Incorrect cuefficient b, please enter it again:");
        }

        Console.Write("Enter cuefficient c:");
        double c;

        while (!double.TryParse(Console.ReadLine(), out c))
        {
            Console.Write("Incorrect cuefficient c, please enter it again:");
        }

        double discriminant = (b * b) - (4 * a * c);

        double x1;
        double x2;

        if (discriminant < 0)
        {
            Console.WriteLine("The equasion has no real roots.");
        }
        else if (discriminant == 0)
        {
            x1 = (-b) / (2 * a);
            Console.WriteLine("The real roots are x1 = x2 = {0}", x1);
        }
        else
        {
            x1 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
            x2 = ((-b) - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine("The real roots are x1 = {0} and x2 = {1}", x1, x2);
        }
    }
}
