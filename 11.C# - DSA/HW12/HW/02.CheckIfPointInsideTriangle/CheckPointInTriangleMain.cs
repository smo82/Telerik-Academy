/*
 * Task02
 * 
 * You are given 3 points A, B and C, forming triangle, and a point P. Check if the point P is in the triangle or not.
 * 
 * Note: If the point is on some of the border lines we consider it to be inside the triangle
 */

using System;

class CheckPointInTriangleMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the coordinates of point A in the format: x y");
        Point a = ReadPoint();
        Console.WriteLine("Please enter the coordinates of point B in the format: x y");
        Point b = ReadPoint();
        Console.WriteLine("Please enter the coordinates of point C in the format: x y");
        Point c = ReadPoint();
        Console.WriteLine("Please enter the coordinates of the point we check (P) in the format: x y");
        Point p = ReadPoint();

        double areaABC = CalcTriangleArea(a, b, c);

        double areaABP = CalcTriangleArea(a, b, p);
        double areaBCP = CalcTriangleArea(b, c, p);
        double areaACP = CalcTriangleArea(a, c, p);

        if ((areaABP + areaACP + areaBCP) == areaABC)
        {
            Console.WriteLine("The point is inside the triangle");
        }
        else
        {
            Console.WriteLine("The point is outside the triangle");
        }
    }

    private static double CalcTriangleArea(Point a, Point b, Point c)
    {
        double doubleArea = a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
        return Math.Abs(doubleArea / 2);
    }

    private static Point ReadPoint()
    {
        string[] pointCoord = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries) ;

        double x = double.Parse(pointCoord[0]);
        double y = double.Parse(pointCoord[1]);

        return new Point(x, y);
    }
}