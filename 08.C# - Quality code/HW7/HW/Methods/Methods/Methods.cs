/*
Take the VS solution "Methods" and refactor its code to follow the guidelines of high-quality methods. Ensure you handle errors correctly: when the methods cannot do what their name says, throw an exception (do not return wrong result).Ensure good cohesion and coupling, good naming, no side effects, etc.
 */

using System;

public class Methods
{
    public static double CalcTriangleArea(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0)
        {
            throw new ArgumentOutOfRangeException("Side 'a' should be bigger then 0!");
        }

        if (sideB <= 0)
        {
            throw new ArgumentOutOfRangeException("Side 'b' should be bigger then 0!");
        }

        if (sideC <= 0)
        {
            throw new ArgumentOutOfRangeException("Side 'c' should be bigger then 0!");
        }

        if ((sideA + sideB) <= sideC)
        {
            throw new ArgumentOutOfRangeException("The sum 'a' + 'b' should be bigger then 'c'!");
        }

        if ((sideB + sideC) <= sideA)
        {
            throw new ArgumentOutOfRangeException("The sum 'b' + 'c' should be bigger then 'a'!");
        }

        if ((sideA + sideC) <= sideB)
        {
            throw new ArgumentOutOfRangeException("The sum 'a' + 'c' should be bigger then 'b'!");
        }

        double semiParameter = (sideA + sideB + sideC) / 2;
        double area = Math.Sqrt(semiParameter * (semiParameter - sideA) * (semiParameter - sideB) * (semiParameter - sideC));
        return area;
    }

    public static string NumberToDigit(int number)
    {
        switch (number)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: throw new ArgumentOutOfRangeException("Invalid digit!");
        }
    }

    public static int FindMax(params int[] elements)
    {
        if (elements == null || elements.Length == 0)
        {
            throw new ArgumentOutOfRangeException("The elements collection should contain at least one element!");
        }

        var maxElement = elements[0];
        for (int i = 1; i < elements.Length; i++)
        {
            if (elements[i] > maxElement)
            {
                maxElement = elements[i];
            }
        }

        return maxElement;
    }

    public static string FormatNumberAsFixedPoint(double number, int precision = 2)
    {
        if (precision < 0)
        {
            throw new ArgumentOutOfRangeException("The format precision should not be smaller then zero!");
        }

        return string.Format("{0:f" + precision + "}", number);
    }

    public static string FormatNumberAsPercent(double number, int precision = 2)
    {
        if (precision < 0)
        {
            throw new ArgumentOutOfRangeException("The format precision should not be smaller then zero!");
        }

        return string.Format("{0:p" + precision + "}", number);
    }

    public static string FormatNumberWithIndentation(double number, int indentation = 0)
    {
        return string.Format("{0," + indentation + "}", number);
    }

    public static bool AreCoordinatesEqual(double coord1, double coord2)
    {
        return coord1 == coord2;
    }

    public static double CalcPointsDistance(double x1, double y1, double x2, double y2)
    {
        double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        return distance;
    }

    /*public static bool IsDateBigger(string firstDate, string secondDate)
    {

    }*/
}
