/*
 * Task02
 * 
 * Salaries:
 * Please find the task description in the folder of the solution
 */

using System;
using System.Collections.Generic;

public class SalariesMain
{
    public static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());

        long[,] graph = new long[numberOfEmployees, numberOfEmployees];

        for (int i = 0; i < numberOfEmployees; i++)
        {
            string employeeInput = Console.ReadLine();
            for (int j = 0; j < employeeInput.Length; j++)
            {
                if (employeeInput[j] == 'Y')
                {
                    graph[i, j] = 1;
                }
            }
        }

        LinkedList<int> employeeToProcess = new LinkedList<int>();

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            bool hasBoss = false;
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                if (graph[j, i] > 0)
                {
                    hasBoss = true;
                    break;
                }
            }

            if (!hasBoss)
            {
                employeeToProcess.AddLast(i);
            }
        }

        List<int> visited = new List<int>();
        bool[] calculated = new bool[numberOfEmployees];
        long totalSalary = 0;

        while (employeeToProcess.Count > 0)
        {
            int employeeIndex = employeeToProcess.Last.Value;

            bool hasUncalculatedChild = false;
            long subordinatesStalary = 0;
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[employeeIndex, i] > 0)
                {
                    subordinatesStalary += graph[employeeIndex, i];

                    if (!visited.Contains(i))
                    {
                        employeeToProcess.AddLast(i);
                        visited.Add(i);
                        hasUncalculatedChild = true;
                    }
                    else if (!calculated[i])
                    {
                        employeeToProcess.Remove(i);
                        employeeToProcess.AddLast(i);
                        hasUncalculatedChild = true;
                    }
                }
            }

            if (subordinatesStalary == 0)
            {
                subordinatesStalary = 1;
            }

            if (!hasUncalculatedChild)
            {
                employeeToProcess.RemoveLast();

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[i, employeeIndex] > 0)
                    {
                        graph[i, employeeIndex] = subordinatesStalary;
                    }
                }

                totalSalary += subordinatesStalary;
                calculated[employeeIndex] = true;
            }
        }

        Console.WriteLine(totalSalary);
    }
}