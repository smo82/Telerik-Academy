using System;

public class SquareRootMethods
{
    public static float SquareRootFloat(float value)
    {
        return (float)Math.Sqrt(value);
    }

    public static double SquareRootDouble(double value)
    {
        return Math.Sqrt(value);
    }

    public static decimal SquareRootDecimal(decimal value)
    {
        return (decimal)Math.Sqrt((double)value);
    }
}