/*
 * Task01
 * 
 * Friends of Pesho:
 * Please find the task description in the folder of the solution
 */

using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;

public class PeshoFriendsMain
{
    public static void Main()
    {
        long bestDistance = long.MaxValue;

        using (StreamReader sr = new StreamReader("input.txt"))
        {
            Console.SetIn(sr);
            int[] initialRow = ReadUserInput();

            int n = initialRow[0] + 1;
            int m = initialRow[1] + 1;
            int h = initialRow[2] + 1;

            int[] hospitalsInt = ReadUserInput();

            Graph graph = new Graph();
            for (int i = 0; i < m; i++)
            {
                int[] currentPath = ReadUserInput();
                int firstEdge = currentPath[0];
                int secondEdge = currentPath[1];
                int path = currentPath[2] + 1;

                graph.AddConnection(firstEdge, secondEdge, path);
            }

            Dictionary<int, Node> hospitals = new Dictionary<int, Node>();
            for (int i = 0; i < hospitalsInt.Length; i++)
            {
                int hospitalId = hospitalsInt[i];
                Node hospitalNode = graph.Nodes[hospitalId];
                hospitals.Add(hospitalId, hospitalNode);
            }

            foreach (KeyValuePair<int, Node> hospital in hospitals)
            {
                long currentHospitalTotalDistance = GetShortestDistanceToHospital(hospital.Value, graph, hospitals);
                if (currentHospitalTotalDistance < bestDistance)
                {
                    bestDistance = currentHospitalTotalDistance;
                }
            }
        }

        Console.WriteLine(bestDistance);
    }

    private static long GetShortestDistanceToHospital(Node hospital, Graph graph, Dictionary<int, Node> hospitals)
    {
        graph.InitGraphDijkstraDistances();

        OrderedBag<Node> nextDijksrtaNode = new OrderedBag<Node>();
        Set<Node> visited = new Set<Node>();

        hospital.DijkstraDistance = 0;
        nextDijksrtaNode.Add(hospital);

        while (nextDijksrtaNode.Count > 0)
        {
            Node currentNode = nextDijksrtaNode.GetFirst();
            nextDijksrtaNode.RemoveFirst();
            visited.Add(currentNode);

            foreach (Connection connection in graph.NodeConnections[currentNode])
            {
                Node targetNode = connection.TargetNode;
                int newDijkstraDistance = currentNode.DijkstraDistance + connection.Distance;

                if (newDijkstraDistance < targetNode.DijkstraDistance)
                {
                    targetNode.DijkstraDistance = newDijkstraDistance;
                    nextDijksrtaNode.Add(targetNode);
                }
            }            
        }

        long totalDistanceHomes = 0;

        foreach (Node visitedNode in visited)
        {
            if (!hospitals.ContainsKey(visitedNode.Id))
            {
                totalDistanceHomes += visitedNode.DijkstraDistance;
            }
        }

        return totalDistanceHomes;
    }

    private static int[] ReadUserInput()
    {
        string[] userInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] userInputParsedAsInt = new int[userInput.Length];

        for (int i = 0; i < userInput.Length; i++)
        {
            userInputParsedAsInt[i] = int.Parse(userInput[i]) - 1;
        }

        return userInputParsedAsInt;
    }
}