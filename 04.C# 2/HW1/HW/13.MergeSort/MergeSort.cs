using System;

class MergeSort
{
    static int [] CustomMergeSort (int [] elementsArr)
    {
        if (elementsArr.Length == 1)
        {
            return elementsArr;
        }
        else
        {
            int middle = elementsArr.Length / 2;

            int[] subArrayLeft = new int[middle];
            Array.Copy(elementsArr, 0, subArrayLeft, 0, middle);
            subArrayLeft = CustomMergeSort(subArrayLeft);

            int[] subArrayRight = new int[elementsArr.Length - middle];
            Array.Copy(elementsArr, middle, subArrayRight, 0, elementsArr.Length - middle);
            subArrayRight = CustomMergeSort(subArrayRight);

            int[] resultArr = new int[elementsArr.Length];
            int indexLeftArr = 0;
            int indexRightArr = 0;

            for (int i = 0; i < resultArr.Length; i++)
            {
                if (indexLeftArr == subArrayLeft.Length)
                {
                    resultArr[i] = subArrayRight[indexRightArr];
                    indexRightArr++;
                }
                else if (indexRightArr == subArrayRight.Length)
                {
                    resultArr[i] = subArrayLeft[indexLeftArr];
                    indexLeftArr++;
                }
                else if (subArrayLeft[indexLeftArr] < subArrayRight[indexRightArr])
                {
                    resultArr[i] = subArrayLeft[indexLeftArr];
                    indexLeftArr++;
                }
                else
                {
                    resultArr[i] = subArrayRight[indexRightArr];
                    indexRightArr++;
                }
            }
            return resultArr;
        }
    }

    static void Main()
    {
        Console.Write("Enter the length of the array:");
        int numberElements;

        while ((!int.TryParse(Console.ReadLine(), out numberElements)) || (numberElements <= 0))
        {
            Console.Write("Wrong length. Please try again:");
        }

        int[] elementsArr = new int[numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("Enter element {0}:", i);
            elementsArr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(String.Join(", ", CustomMergeSort (elementsArr)));
    }
}
