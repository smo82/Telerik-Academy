using System;

public class SinusMethods
{
    public static float SinusFloat(float value)
    {
        return (float)Math.Sin(value);
    }

    public static double SinusDouble(double value)
    {
        return Math.Sin(value);
    }

    public static decimal SinusDecimal(decimal value)
    {
        return (decimal)Math.Sin((double)value);
    }
}