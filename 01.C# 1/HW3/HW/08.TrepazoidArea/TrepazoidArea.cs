using System;

class TrepazoidArea
{
    static void Main()
    {
        Console.Write("Enter side A:");
        int sideA = int.Parse(Console.ReadLine());

        Console.Write("Enter side B:");
        int sideB = int.Parse(Console.ReadLine());

        Console.Write("Enter side heigth:");
        int heigth = int.Parse(Console.ReadLine());

        float medianLength = (float)(sideA + sideB)/2;
        float area = heigth * medianLength;

        Console.WriteLine("The trepazoid area is: {0}", area);
    }
}
