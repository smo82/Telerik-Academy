using System;

class CheckPointInCircleRectangle
{
    static void Main()
    {
        Console.Write("Enter x coordinate:");
        int xCoordinate = int.Parse(Console.ReadLine());

        Console.Write("Enter y coordinate:");
        int yCoordinate = int.Parse(Console.ReadLine());

        //Check if the point is outside of the rectangle

        if ((xCoordinate < -1) ||
            (xCoordinate > 5) ||
            (yCoordinate < -1) ||
            (yCoordinate > 1))
        {
            //Check if point is in circle
            int xCoordinateShifted = xCoordinate - 1;
            int yCoordinateShifted = yCoordinate - 1;

            float hypotenuse;

            xCoordinateShifted = Math.Abs(xCoordinateShifted);
            yCoordinateShifted = Math.Abs(yCoordinateShifted);

            hypotenuse = (float)(Math.Sqrt(xCoordinateShifted * xCoordinateShifted + yCoordinateShifted * yCoordinateShifted));

            if (hypotenuse <= 3)
            {
                Console.WriteLine("Success: The point is in the circle and outside the rectangle");
            }
            else
            {
                Console.WriteLine("Fail: The point is outside of the circle and outside the rectangle");
            }
        }
        else
        {
            Console.WriteLine("Fail: The point is in the rectangle");
        }
    }
}
