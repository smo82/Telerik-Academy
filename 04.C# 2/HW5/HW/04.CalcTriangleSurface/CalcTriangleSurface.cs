using System;

class CalcTriangleSurface
{
    static int ReadInt(string message = "Enter N:", int minValue = 0, int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static double ReadDouble(string message = "Enter N:", double minValue = 0, double maxValue = int.MaxValue)
    {
        Console.Write(message);

        double resultDouble;
        while ((!double.TryParse(Console.ReadLine(), out resultDouble)) || (resultDouble < minValue) || (resultDouble > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultDouble;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Choose input:");
        Console.WriteLine("1 - Side and altitude to it;");
        Console.WriteLine("2 - Three sides;");
        Console.WriteLine("3 - Two sides and angle between them.");

        int choise = ReadInt("Enter your choise:", 1, 3);

        double surface = 0;

        Console.WriteLine(new String('*',20));
        switch (choise)
        {
            case 1:
                double side = ReadDouble("Enter your side:");
                double altitude = ReadDouble("Enter your altitude:");
                surface = side * altitude;
                break;
            case 2:
                double firstSide = ReadDouble("Enter your first side:");
                double secondSide = ReadDouble("Enter your second side:");
                double thirdSide = ReadDouble("Enter your third side:");
                double perimeter = (firstSide + secondSide + thirdSide)/2;
                surface = Math.Sqrt(perimeter * (perimeter - firstSide) * (perimeter - secondSide) * (perimeter - thirdSide));
                break;
            case 3:
                firstSide = ReadDouble("Enter your first side:");
                secondSide = ReadDouble("Enter your second side:");
                double engle = ReadDouble("Enter the engle between the two sides in degrees:");
                surface = (firstSide * secondSide * Math.Sin(engle * Math.PI/180)) / 2;
                break;
        }

        Console.WriteLine("The triangle surface is: {0}", surface);
    }
}
