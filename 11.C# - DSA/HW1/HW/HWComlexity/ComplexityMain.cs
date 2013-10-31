using System;
using System.Diagnostics;

namespace HWComlexity
{
    class ComplexityMain
    {
        /*
         * Task01
         * 
         * The complexity is:
         * 1/ For the outer cycle - the cycle loops from 0 to n-1, so its complexity is: n
         * 2/ For the inner cycle - the cycle loops from 0 to n-2, so its complexity is: (n-1)
         * The total complexity is: n * (n - 1) => O(n^2)
         */
        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            return count;
        }

        /*
         * Task02
         * 
         * What is the expected running time of the following C# code? Explain why.
         * Assume the input matrix has size of n * m.
         * 
         * The complexity is:
         * 1/ For the outer cycle - the cycle loops from 0 to n, so its complexity is: n
         * 2/ For the inner cycle - the cycle is in an if-statement, which succeeds only if the first item of the given row is even.
         *                          We don't know how often this will happen, but we can presume that this will be true 50% of the time.
         *                          This means that the inner cycle will be called 50% of the time. The inner cycle itself loops from
         *                          0 to m, so its complexity is: m. This means that the complexity of the 50% if-statement together with
         *                          the inner cycle is 1/2 * m
         *                      
         * The total complexity is: n * 1/2 * m => O(n*m)
         * 
         * Time estimation: In order to use the table from the presentation, we can assume that n = m and in this case the method
         * complexity is O(n^2). 
         * In this case if n = 100 000 and m = 100 000, the estimated time is 3-4 minutes (from the table for O(n^2))
         */
        static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /*
         * Task03
         * 
         * What is the expected running time of the following C# code? Explain why.
         * Assume the input matrix has size of n * m.
         * 
         * The complexity is:
         * 1/ For the cycle - the cycle loops from 0 to m, so its complexity is: m
         * 2/ For the recursion - the bottom rule of the recursion is when row = n-2. This means the recursion will be called: n-1 times
         * 
         * On every iteration of the recursion the the loop is called once. 
         * This means that the total complexity of the method is (n-1) * m => O(n*m)
         * 
         * Time estimation: In order to use the table from the presentation, we can assume that n = m and in this case the method
         * complexity is O(n^2). 
         * In this case if n = 100 000 and m = 100 000, the estimated time is 3-4 minutes (from the table for O(n^2))
         */

        static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < matrix.GetLength(1))
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            action();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
                
        static void Main(string[] args)
        {
            //Task01
            Console.WriteLine("Task01:");
            int[] arr = new int[10000];

            DisplayExecutionTime(() =>
            {
                Compute(arr);
            });

            //Task02
            Console.WriteLine("Task02:");
            //int[,] matrix = new int[100000, 100000]; //Out of memory exception
            int[,] matrix = new int[10000, 10000];

            DisplayExecutionTime(() =>
            {
                CalcCount(matrix);
            });

            //Task03
            Console.WriteLine("Task03:");
            //Console.WriteLine(CalcSum(matrix, 0));
            //int[,] matrix2 = new int[100000, 100000]; //Out of memory exception
            int[,] matrix2 = new int[10000, 10000];

            DisplayExecutionTime(() =>
            {
                CalcSum(matrix2, 0);
            });
        }
    }
}
