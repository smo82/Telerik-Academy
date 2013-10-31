using System;

class CheckPointInCircle
{
    static void Main()
    {
        Console.Write("Enter x coordinate:");
        int xCoordinate = int.Parse(Console.ReadLine());

        Console.Write("Enter y coordinate:");
        int yCoordinate = int.Parse(Console.ReadLine());

        float hypotenuse;

        xCoordinate = Math.Abs(xCoordinate);
        yCoordinate = Math.Abs(yCoordinate);

        hypotenuse = (float)(Math.Sqrt(xCoordinate * xCoordinate + yCoordinate * yCoordinate));

        if (hypotenuse > 5)
        {
            Console.WriteLine("The point is out of the circle");
        }
        else
        {
            Console.WriteLine("The point is in the circle");
        }
    }
}
