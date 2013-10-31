using System;

    class CheckThirdDigit
    {
        static void Main()
        {
            Console.Write("Enter number:");
            int number = int.Parse(Console.ReadLine());

            number /= 100;

            if ((number % 10) == 7)
            {
                Console.WriteLine("The numbers third digit is 7");
            }
            else
            {
                Console.WriteLine("The numbers third digit is not 7");
            }
        }
    }
