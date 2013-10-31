using System;

class SumDigitArrays
{
    static int ReadInt(string message = "Enter N:", int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < 0) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static int[] ReadArray(int numberElements)
    {
        int[] elementsList = new int[numberElements];

        for (int i = numberElements-1; i >= 0; i--)
        {
            Console.Write("[{0}]:", i);
            while ((!int.TryParse(Console.ReadLine(), out elementsList[i])) || (elementsList[i] < 0) || (elementsList[i] > 9))
            {
                Console.Write("Wrong number. Please try again:");
            }
        }

        return elementsList;
    }

    static void PrintArray(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            Console.Write("[{0}]:", i);
            Console.WriteLine(array[i]);
        }
    }

    static int[] AddDigitArray(int [] smallerArr, int [] biggerArr)
    {
        for (int i = 0; i < smallerArr.Length; i++)
        {
            biggerArr[i] += smallerArr[i];

            int indexIncrease = 0;
            while (biggerArr[i + indexIncrease] >= 10)
            {
                int remainder = biggerArr[i + indexIncrease] / 10;
                biggerArr[i + indexIncrease] = biggerArr[i + indexIncrease] % 10;
                indexIncrease++;
                biggerArr[i + indexIncrease] += remainder;
            }
        }

        return biggerArr;
    }

    static int[] SumDigitArrs(int[] firstDigitArr, int[] secondDigitArr)
    {
        if (firstDigitArr.Length > secondDigitArr.Length)
        {
            int[] resultDigitArr = new int[firstDigitArr.Length+1];
            firstDigitArr.CopyTo(resultDigitArr, 0);
            return AddDigitArray(secondDigitArr, resultDigitArr);
        }
        else
        {
            int[] resultDigitArr = new int[secondDigitArr.Length + 1];
            secondDigitArr.CopyTo(resultDigitArr, 0);
            return AddDigitArray(firstDigitArr, resultDigitArr);
        }
    }

    static void Main()
    {
        int lengthFirstNumber = ReadInt("Enter the number of digits of your first integer: ", 10000);

        int[] firstDigitArr = new int[lengthFirstNumber];
        firstDigitArr = ReadArray(lengthFirstNumber);

        int lengthSecondNumber = ReadInt("Enter the number of digits of your second integer: ", 10000);

        int[] secondDigitArr = new int[lengthSecondNumber];
        secondDigitArr = ReadArray(lengthSecondNumber);

        int[] sumDigitArr = SumDigitArrs(firstDigitArr, secondDigitArr);

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result sum array is:");
        PrintArray(sumDigitArr);
    }
}
