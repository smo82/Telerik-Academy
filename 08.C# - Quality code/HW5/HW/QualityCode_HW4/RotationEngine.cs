using System;

class RotationEngine
{
    public static Size GetRotatedSize(Size size, double angle)
    {
        double angleAbsCos = Math.Abs(Math.Cos(angle));
        double angleAbsSin = Math.Abs(Math.Sin(angle));
        double rotatedWidth = angleAbsCos * size.Width + angleAbsSin * size.Height;
        double rotatedHeight = angleAbsSin * size.Width + angleAbsCos * size.Height;

        return new Size(rotatedWidth, rotatedHeight);
    }

    static void Main(string[] args)
    {
        Size testSize = new Size(1, 2);
        Size rotatedSize = GetRotatedSize(testSize, 10);
        Console.WriteLine("Rotated size: Size({0}, {1})", rotatedSize.Width, rotatedSize.Height);
    }
}