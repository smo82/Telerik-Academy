using System;

public class LnMethods
{
    public static float LnFloat(float value)
    {
        return (float)Math.Log(value, Math.E);
    }

    public static double LnDouble(double value)
    {
        return Math.Log(value, Math.E);
    }

    public static decimal LnDecimal(decimal value)
    {
        return (decimal)Math.Log((double)value, Math.E);
    }
}