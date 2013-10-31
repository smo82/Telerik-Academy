using System;

class CalculateSumFractions
{
    static void Main()
    {
        ushort n = 1000;
        
        decimal sum = 1;
        for (int i = 2; i <= n; i++)
        {
            if ((i & 1) == 1)
            {
                sum -= 1m / i;
            }
            else
            {
                sum += 1m / i;
            }
        }

        Console.WriteLine("The sum is: {0:F3}", sum);

        //Second solution
        sum = 1;
        ushort devisor = 2;
        while (1m / devisor >= 0.001m)
        {
            if ((devisor & 1) == 1)
            {
                sum -= 1m / devisor;
            }
            else
            {
                sum += 1m / devisor;
            }
            devisor++;
        }
        Console.WriteLine("The sum from the second solution is: {0:F3}", sum);
    }
}
