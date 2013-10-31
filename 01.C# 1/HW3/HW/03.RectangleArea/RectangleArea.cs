using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Enter rectangle width:");
        int rectangleWidth = int.Parse(Console.ReadLine());

        Console.Write("Enter rectangle heigth:");
        int rectangleHeigth = int.Parse(Console.ReadLine());

        Console.WriteLine("The rectangle area is: {0}", rectangleWidth * rectangleHeigth);
    }
}
