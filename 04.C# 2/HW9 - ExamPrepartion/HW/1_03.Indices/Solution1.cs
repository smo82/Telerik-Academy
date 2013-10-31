using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main1()
    {
        //Console.SetIn(new System.IO.StreamReader("input.txt"));

        int n = int.Parse(Console.ReadLine());
        string[] indexArrString = Console.ReadLine().Split(' ');
        int[] indexes = new int[n];

        for (int i = 0; i < n; i++)
        {
            indexes[i] = int.Parse(indexArrString[i]);
        }
        
        List<int> visited = new List<int>();
        visited.Add(0);
        int nextIndex = indexes[0];
        StringBuilder result = new StringBuilder();

        while ((nextIndex >= 0) && (nextIndex < n) && (visited.IndexOf(nextIndex) < 0))
        {
            visited.Add(nextIndex);
            nextIndex = indexes[nextIndex];            
        }


        int indexVisited = visited.IndexOf(nextIndex);
        if (indexVisited >= 0)
        {
            result.Append(String.Join(" ", visited.GetRange(0, indexVisited)));
            result.Append("(");
            result.Append(String.Join(" ", visited.GetRange(indexVisited, visited.Count - indexVisited)));
            result.Append(")");
        }
        else
        {
            result.Append(String.Join(" ", visited.ToArray()));
        }

        Console.WriteLine(result);
    }
}
