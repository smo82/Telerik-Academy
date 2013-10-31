/*
 * Task12*
 * 
 * Write a recursive program to solve the "8 Queens Puzzle" with backtracking. 
 * Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle
 */

using System;

public class EightQueensMain
{
    private static int[,] board;
    private static int solutionsCount;

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the board size (N): ");
        int n = int.Parse(Console.ReadLine());
        board = new int[n, n];

        FindSolutions(0);

        Console.WriteLine("The number of solutions is: {0}", solutionsCount);
    }

    private static void FindSolutions(int currentColumn)
    {
        if (currentColumn >= board.GetLength(0))
        {
            solutionsCount++;
            return;
        }

        for (int i = 0; i < board.GetLength(1); i++)
        {
            if (board[currentColumn, i] == 0)
            {
                board[currentColumn, i] = int.MinValue;
                MarkImpactedPositions(currentColumn, i, 1);
                FindSolutions(currentColumn + 1);
                MarkImpactedPositions(currentColumn, i, -1);
                board[currentColumn, i] = 0;
            }
        }
    }

    private static void MarkImpactedPositions(int currentColumn, int currentRow, int impact)
    {
        for (int i = currentColumn + 1; i < board.GetLength(0); i++)
        {
            board[i, currentRow] += impact;
        }

        for (int i = 1; i < Math.Min(board.GetLength(0), board.GetLength(1)); i++)
        {
            if ((currentColumn + i < board.GetLength(0)) && (currentRow - i >= 0))
            {
                board[currentColumn + i, currentRow - i] += impact;
            }

            if ((currentColumn + i < board.GetLength(0)) && (currentRow + i < board.GetLength(1)))
            {
                board[currentColumn + i, currentRow + i] += impact;
            }
        }
    }
}