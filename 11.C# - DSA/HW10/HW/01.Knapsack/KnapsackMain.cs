/*
 * Task01
 * 
 * Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, 
 * each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and
 * weight ≤ M. The numbers N, M, Wi and Ci are integers in the range [1..500]. 
 * 
 * Example: M=10 kg, N=6, products:
 * beer – weight=3, cost=2
 * vodka – weight=8, cost=12
 * cheese – weight=4, cost=5
 * nuts – weight=1, cost=4
 * ham – weight=2, cost=3
 * whiskey – weight=8, cost=13
 * 
 * Optimal solution:
 * nuts + whiskey
 * weight = 9
 * cost = 17
 */

using System;
using System.Collections.Generic;

public class KnapsackMain
{
    public static void Main()
    {
        Console.WriteLine("Please enter M: ");
        int m = int.Parse(Console.ReadLine());

        // Product[] products = ReadProductData();

        string[,] exampleInput = new string[,] 
        {
           { "beer", "3", "2" },
           { "vodka", "8", "12" },
           { "cheese", "4", "5" },
           { "nuts", "1", "4" },
           { "ham", "2", "3" },
           { "whiskey", "8", "13" },
           { "bread", "1", "2" },
           { "watermelon", "3", "5" },
        };

        // Note: Because i copy the initial array many times i get repeating products. For that reason I index them.
        //       So nuts3 is different from nuts9 and for that reason they can be both in the knapsack
        string[,] exampleInputBig = new string[500, 3];

        for (int i = 0; i < exampleInputBig.GetLength(0); i++)
        {
            exampleInputBig[i, 0] = exampleInput[i % 6, 0] + i;
            exampleInputBig[i, 1] = exampleInput[i % 6, 1];
            exampleInputBig[i, 2] = exampleInput[i % 6, 2];
        }

        int productCount = exampleInputBig.GetLength(0);

        Product[] products = new Product[productCount];
        for (int i = 0; i < productCount; i++)
        {
            Product product = new Product(exampleInputBig[i, 0], int.Parse(exampleInputBig[i, 1]), int.Parse(exampleInputBig[i, 2]));
            products[i] = product;
        }

        Solution[,] solutions = new Solution[productCount + 1, m + 1];

        for (int i = 0; i < productCount; i++)
        {
            Product currentProduct = products[i];
            int currentProductWeight = currentProduct.Weight;
            if (currentProductWeight <= m)
            {
                if (solutions[0, currentProductWeight] == null)
                {
                    solutions[0, currentProductWeight] = new Solution(currentProduct);
                }
                else if (solutions[0, currentProductWeight].Value < currentProduct.Value)
                {
                    solutions[0, currentProductWeight] = new Solution(currentProduct);
                }
            }
        }

        for (int i = 1; i < productCount + 1; i++)
        {
            Product currentProduct = products[i - 1];

            CopySolutionsPreviousRow(solutions, i);

            for (int j = 0; j < solutions.GetLength(1); j++)
            {
                if (solutions[i - 1, j] == null)
                {
                    continue;
                }

                if (solutions[i - 1, j].Products.IndexOf(currentProduct) == -1)
                {
                    Solution newSolution = new Solution(solutions[i - 1, j]);
                    newSolution.AddProduct(currentProduct);

                    if (newSolution.Weight <= m)
                    {
                        if (solutions[i, j] == null)
                        {
                            solutions[i, j] = newSolution;
                        }
                        else if (solutions[i, j].Value < newSolution.Value)
                        {
                            solutions[i, j] = newSolution;
                        }
                    }
                }
            }
        }

        Solution bestSolution = null;

        for (int i = m; i >= 0; i--)
        {
            if (solutions[productCount, i] != null)
            {
                if (bestSolution == null)
                {
                    bestSolution = solutions[productCount, i];
                }
                else if (bestSolution.Value < solutions[productCount, i].Value)
                {
                    bestSolution = solutions[productCount, i];
                }
            }
        }

        if (bestSolution != null)
        {
            Console.WriteLine("Best solution:");
            PrintProductCollection(bestSolution.Products);
        }
        else
        {
            Console.WriteLine("No solution!");
        }
    }

    private static void CopySolutionsPreviousRow(Solution[,] solutions, int currentRow)
    {
        for (int i = 0; i < solutions.GetLength(1); i++)
        {
            solutions[currentRow, i] = solutions[currentRow - 1, i];
        }
    }

    private static void PrintProductCollection(List<Product> products)
    {
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }

    private static Product[] ReadProductData()
    {
        Console.WriteLine("Please enter N: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the products in the format 'name weight cost':");
        Product[] products = new Product[n];
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Product product = new Product(line[0], int.Parse(line[1]), int.Parse(line[2]));
            products[i] = product;
        }

        return products;
    }
}