/*
 * Task09
 * 
 * Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
 */

using System;
using System.Text;

public class CheckIfPathExistsMain
{
    private const string EMPTY_CELL = "0";
    private static readonly int[,] Directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

    private static int largestAreaCount;
    private static int currentCount;
    private static string[,] matrix;

    public static void Main(string[] args)
    {
        matrix = new string[,]
        {
            { "0", "0", "*", "0", "0", "0", "0" },
            { "*", "0", "*", "0", "*", "*", "0" },
            { "0", "0", "*", "0", "0", "0", "0" },
            { "0", "*", "*", "*", "*", "*", "0" },
            { "0", "*", "0", "0", "0", "0", "0" },
            { "0", "*", "0", "*", "0", "*", "0" },
        };

        Console.WriteLine("Current matrix:");
        PrintMatrix();

        FindLargestArea();
        Console.WriteLine("The largest area count is: {0}", largestAreaCount);
    }

    private static void FindLargestArea()
    {
        largestAreaCount = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == EMPTY_CELL)
                {
                    currentCount = 1;
                    matrix[i, j] = "*";
                    MarkEmptyAdjacentCells(i, j);

                    if (currentCount > largestAreaCount)
                    {
                        largestAreaCount = currentCount;
                    }
                }
            }
        }
    }

    private static void MarkEmptyAdjacentCells(int x, int y)
    {
        for (int i = 0; i < Directions.GetLength(0); i++)
        {
            int newCoordX = x + Directions[i, 0];
            int newCoordY = y + Directions[i, 1];
            if (newCoordX >= 0 && newCoordX < matrix.GetLength(0) &&
                newCoordY >= 0 && newCoordY < matrix.GetLength(1) &&
                matrix[newCoordX, newCoordY] == EMPTY_CELL)
            {
                matrix[newCoordX, newCoordY] = "*";
                currentCount++;
                MarkEmptyAdjacentCells(newCoordX, newCoordY);
            }
        }
    }

    private static void PrintMatrix()
    {
        StringBuilder matrixToPrint = new StringBuilder();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixToPrint.Append(string.Format("{0, -3} ", matrix[i, j]));
            }

            matrixToPrint.AppendLine();
        }

        Console.WriteLine(matrixToPrint.ToString());
    }
}