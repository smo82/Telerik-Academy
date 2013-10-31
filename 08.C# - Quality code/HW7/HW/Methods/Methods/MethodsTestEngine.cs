using System;

public class MethodsTestEngine
{
    public static void Main()
    {
        Console.WriteLine("The area of a triangle with sides a=3, b=4, c=5 is: {0}", Methods.CalcTriangleArea(3, 4, 5));

        Console.WriteLine("The digit 5 translated to a word is: {0}", Methods.NumberToDigit(5));

        Console.WriteLine("The maximal number in the collection [5, -1, 3, 2, 14, 2, 3] is: {0}", Methods.FindMax(5, -1, 3, 2, 14, 2, 3));

        Console.WriteLine("The number 1.3 formatted with 2 decimal points precision is: {0}", Methods.FormatNumberAsFixedPoint(1.3));
        Console.WriteLine("The number 0.75 formatted as a percent with 2 decimal points precision is: {0}", Methods.FormatNumberAsPercent(0.75, 0));
        Console.WriteLine("The number 2.30 formatted with 8 positions to the right: {0}", Methods.FormatNumberWithIndentation(2.30, 8));

        Console.WriteLine("What is the distance between pointA(3, -1) and pointB(3, 2.5): {0}", Methods.CalcPointsDistance(3, -1, 3, 2.5));
        Console.WriteLine("Is the line from pointA(3, -1) to pointB(3, 2.5) horizontal: {0}", Methods.AreCoordinatesEqual(-1, 2.5));
        Console.WriteLine("Is the line from pointA(3, -1) to pointB(3, 2.5) vertical: {0}", Methods.AreCoordinatesEqual(3, 3));

        Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
        peter.TownOfBirth = "Sofia";
        peter.DateOfBirth = DateTime.Parse("17.03.1992");

        Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
        peter.TownOfBirth = "Vidin";
        peter.DateOfBirth = DateTime.Parse("03.11.1993");

        stella.IsOlderThan(null);
        

        Console.WriteLine("Is {0} older than {1}: {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
    }
}