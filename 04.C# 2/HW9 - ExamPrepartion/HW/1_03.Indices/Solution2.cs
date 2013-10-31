using System;
using System.Text;

class Solution2
{
    ///////////////////////////////////////////////////////////////////////////////
    //This is the second (ugly solution, but it is faster and passes Test8 in time)

    static void Main()
    {
        //Console.SetIn(new System.IO.StreamReader("input.txt"));

        int n = int.Parse(Console.ReadLine());
        string[] indexArrString = Console.ReadLine().Split(' ');
        int[] indexes = new int[n];

        for (int i = 0; i < n; i++)
        {
            indexes[i] = int.Parse(indexArrString[i]);
        }

        bool[] visited = new bool[n];
        int nextIndex = indexes[0];
        visited[0] = true;
        while ((nextIndex >= 0) && (nextIndex < n) && (!visited[nextIndex]))
        {
            visited[nextIndex] = true;
            nextIndex = indexes[nextIndex];
        }

        StringBuilder result = new StringBuilder();

        bool hasCycle = false;
        if ((nextIndex >= 0) && (nextIndex < n) && (visited[nextIndex]))
        {
            hasCycle = true;
        }

        if (nextIndex == 0)
        {
            result.Append("(0");
        }
        else
        {
            result.Append("0");
        }

        int cycleIndex = nextIndex;
        nextIndex = indexes[0];
        bool passCycle = false;
        if (cycleIndex == 0)
        {
            passCycle = true;
        }
        bool end = false;
        while ((nextIndex >= 0) && (nextIndex < n) && !end)
        {
            if (hasCycle && (cycleIndex == nextIndex))
            {
                if (!passCycle)
                {
                    result.Append("(" + nextIndex);
                    passCycle = true;
                }
                else
                {
                    end = true;
                }
            }
            else if (visited[nextIndex])
            {
                result.Append(" " + nextIndex);
            }

            nextIndex = indexes[nextIndex];
        }

        if (hasCycle)
        {
            result.Append(")");
        }

        Console.WriteLine(result.ToString());
    }
}
