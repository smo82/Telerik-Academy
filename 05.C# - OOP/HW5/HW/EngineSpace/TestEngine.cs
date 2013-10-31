using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesSpace;

namespace EngineSpace
{
    public class TestEngine
    {
        static int CustomParseInt(string value, int minValue, int maxValue)
        {
            int result = int.Parse(value);
            if (result < minValue || result > maxValue)
                throw new InvalidRangeException<int>(minValue, maxValue);
            return result;
        }

        static DateTime CustomParseDate(string value, DateTime minValue, DateTime maxValue)
        {
            DateTime result = DateTime.Parse(value);
            if (result < minValue || result > maxValue)
                throw new InvalidRangeException<DateTime>(minValue, maxValue);
            return result;
        }

        static void Main()
        {
            //Test Task01
            Shape[] allShapes = new Shape[5]{
				new Triangle (2,3),
				new Triangle (5,5),
				new Rectangle (2,3),
				new Rectangle (5,3),
				new Circle (4)
			};

            Console.WriteLine("The area of the shapes is:");
            Console.WriteLine(new String('*', 20));

            double totalSurface = 0;
            for (int i = 0; i < allShapes.Length; i++)
            {
                Console.WriteLine("{0} - {1}", allShapes[i], allShapes[i].CalculateSurface());
                totalSurface += allShapes[i].CalculateSurface();
            }
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Total area of all the shapes: {0}", totalSurface);

            //Test Task02
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Enter an integer number in the range [0, 1000]");
            int intNumber = 0;
            try
            {
                intNumber = CustomParseInt(Console.ReadLine(), 0, 1000);
                Console.WriteLine("Your number is correct!");
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Enter a date in the range [1/1/2011, 31/12/2013]");
            DateTime date;
            try
            {
                date = CustomParseDate(Console.ReadLine(), new DateTime(2011, 1, 1), new DateTime(2013, 12, 31));
                Console.WriteLine("Your date is correct!");
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}