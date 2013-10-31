using System;
using System.Collections.Generic;

class DataTypes
{
    static void Main()
    {
        
        byte variableType;
        List<byte> listTypes = new List<byte> {1,2,3,4,5,6,7,8,9};

        do
        {
            Console.WriteLine(new String('-', 40));
            Console.WriteLine("Enter the variable type (1,2,3):");
            Console.WriteLine("1 - Int");
            Console.WriteLine("2 - Double");
            Console.WriteLine("3 - String");
            Console.WriteLine(new String('-', 40));
        }
        while ((!byte.TryParse(Console.ReadLine(), out variableType)) || (!listTypes.Contains(variableType)));

        switch (variableType)
        {
            case 1 :
                int userIntVariable = 0;
                do
                {
                    Console.WriteLine(new String('-', 40));
                    Console.WriteLine("Enter your integer variable:");
                }
                while (!int.TryParse(Console.ReadLine(), out userIntVariable));

                userIntVariable++;

                Console.WriteLine("Your new value is:{0}", userIntVariable);
                break;
            case 2 :
                double userDoubleVariable = 0;
                do
                {
                    Console.WriteLine(new String('-', 40));
                    Console.WriteLine("Enter your double variable:");
                }
                while (!double.TryParse(Console.ReadLine(), out userDoubleVariable));

                userDoubleVariable++;

                Console.WriteLine("Your new value is:{0}", userDoubleVariable);
                break;
            case 3 :
                Console.WriteLine(new String('-', 40));
                Console.WriteLine("Enter your string variable:");
                string userStringVariable = Console.ReadLine();

                userStringVariable = userStringVariable + "*";

                Console.WriteLine("Your new value is:{0}", userStringVariable);
                break;
        }
    }
}
