using System;

class ArrIndexMult5
{
    static void Main()
    {
        int[] numberArr = new int[20];

        for (int i = 0; i < numberArr.Length; i++)
        {
            numberArr[i] = i * 5;
            Console.WriteLine(numberArr[i]);
        }
    }
}
