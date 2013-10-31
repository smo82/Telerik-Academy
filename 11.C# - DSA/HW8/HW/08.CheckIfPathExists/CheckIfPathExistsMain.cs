/*
 * Task08
 * 
 * Modify the above program to check whether a path exists between two cells without finding all possible paths. 
 * Test it over an empty 100 x 100 matrix.
 */

using System;
using System.Text;

public class CheckIfPathExistsMain
{
    private const string EMPTY_CELL = null;
    private static readonly int[,] Directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
    
    private static bool pathExists;
    private static string[,] matrix;

    public static void Main(string[] args)
    {
        /*matrix = new string[,]{
            {"0", "0", "*", "0", "0", "0", "0"},
            {"*", "0", "*", "0", "*", "*", "0"},
            {"0", "0", "0", "0", "0", "0", "0"},
            {"0", "*", "*", "*", "*", "*", "0"},
            {"0", "*", "0", "0", "0", "0", "0"},
            {"0", "0", "0", "*", "0", "*", "0"},
        };*/

        matrix = new string[100, 100];

        Console.WriteLine("Current matrix:");
        PrintMatrix();

        Console.WriteLine(new string('*', 30));
        Console.WriteLine("Please enter the start coordinates in format: x y");
        string[] startCoordString = Console.ReadLine().Split(new char[] { ' ' });
        int[] startCoord = { int.Parse(startCoordString[0]), int.Parse(startCoordString[1]) };

        Console.WriteLine(new string('*', 30));
        Console.WriteLine("Please enter the end coordinates in format: x y");
        string[] endCoordString = Console.ReadLine().Split(new char[] { ' ' });
        int[] endCoord = { int.Parse(endCoordString[0]), int.Parse(endCoordString[1]) };

        pathExists = false;
        matrix[startCoord[0], startCoord[1]] = "1";

        FindAllPaths(1, startCoord, endCoord);
        Console.WriteLine("Does path exist: {0}", pathExists);
    }

    private static void FindAllPaths(int currentStepNumber, int[] currentCoord, int[] endCoord)
    {
        if (pathExists)
        {
            return;
        }

        if (currentCoord[0] == endCoord[0] && currentCoord[1] == endCoord[1])
        {
            pathExists = true;
            return;
        }

        for (int i = 0; i < Directions.GetLength(0); i++)
        {
            int newCoordX = currentCoord[0] + Directions[i, 0];
            int newCoordY = currentCoord[1] + Directions[i, 1];
            if (newCoordX >= 0 && newCoordX < matrix.GetLength(0) &&
                newCoordY >= 0 && newCoordY < matrix.GetLength(1) &&
                matrix[newCoordX, newCoordY] == EMPTY_CELL)
            {
                matrix[newCoordX, newCoordY] = (currentStepNumber + 1).ToString();
                FindAllPaths(currentStepNumber + 1, new[] { newCoordX, newCoordY }, endCoord);
                matrix[newCoordX, newCoordY] = EMPTY_CELL;
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