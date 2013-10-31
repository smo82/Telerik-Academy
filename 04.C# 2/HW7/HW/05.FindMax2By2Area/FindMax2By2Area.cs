using System;
using System.IO;

class FindMax2By2Area
{
    static int GetAreaSum(int startPositionX, int startPositionY, int[,] elementsList)
    {
        int sum = 0;

        for (int i = startPositionX; i < startPositionX + 2; i++)
        {
            for (int j = startPositionY; j < startPositionY + 2; j++)
            {
                sum += elementsList[i, j];
            }
        }

        return sum;
    }

    static int CalcMaxSum (int [,] matrix)
    {
        int maxSum = int.MinValue;
        int maxSumX = 0;
        int maxSumY = 0;
        for (int i = 0; i <= matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j <= matrix.GetLength(1) - 2; j++)
            {
                int sum = GetAreaSum(i, j, matrix);

                if (maxSum < sum)
                {
                    maxSum = sum;
                    maxSumX = i;
                    maxSumY = j;
                }
            }
        }

        return maxSum;
    }

    static void Main()
    {
        string pathInputFile = "input.txt";

        try
        {
            StreamReader inputFile = new StreamReader(pathInputFile);

            using (inputFile)
            {
                string line = inputFile.ReadLine();
                int matrixSize = int.Parse(line);

                int[,] matrix = new int[matrixSize, matrixSize];

                line = inputFile.ReadLine();
                int rowNumber = 0;
                while (line != null)
                {
                    string[] matrixRow = line.Split(' ');

                    for (int i = 0; i < matrixRow.Length; i++)
                    {
                        matrix[rowNumber, i] = int.Parse(matrixRow[i]);
                    }

                    line = inputFile.ReadLine();
                    rowNumber++;
                }

                Console.WriteLine("The area with the max sum is: {0}", CalcMaxSum(matrix));
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("The file contains elements with incorrect format!");
        }
        catch (IOException)
        {
            Console.WriteLine("Problem with the file Input/Output!");
        }
    }
}
