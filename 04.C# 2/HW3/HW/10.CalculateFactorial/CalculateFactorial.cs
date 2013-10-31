using System;

class CalculateFactorial
{
    static int [] MultiplyDigitArrByNumber(int number, int [] array)
    {
        int resultArrLength = array.Length + Convert.ToString(number).Length;
        int[] resultArr = new int[resultArrLength];
        array.CopyTo(resultArr, 0);

        int remainder = 0;
        for (int i = 0; i < array.Length; i++)
        {
            resultArr[i] *= number;
            resultArr[i] += remainder;
            remainder = resultArr[i] / 10;
            resultArr[i] = resultArr[i] % 10;
        }

        return resultArr;
    }

    static string DigitArrayToString (int [] array)
    {
        int index = array.Length - 1;

        while ((index >= 0) && (array[index] == 0))
        {
            index--;
        }

        string result = "";
        while (index >= 0)
        {
            result += Convert.ToString(array[index]);
            index--;
        }

        return result;
    }

    static void Main()
    {
        int[] factorialAsArr = new int[] {1};

        Console.WriteLine("1:{0}",DigitArrayToString(factorialAsArr));

        for (int i = 2; i <= 100; i++)
        {
            factorialAsArr = MultiplyDigitArrByNumber(i, factorialAsArr);
            Console.WriteLine("{0}:{1}", i, DigitArrayToString(factorialAsArr));
        }
    }
}
