/*
 * Task03
 * 
 * You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). 
 * If it is constrained to bury the cable only along certain paths, then there would be a graph representing which points are connected 
 * by those paths. But the cost of some of the paths is more expensive because they are longer. 
 * If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.
 * 
 * Example Input:
25
1 2 6
1 3 10
1 4 7
1 5 9
1 6 5
1 7 14
1 8 7
1 9 14
1 10 2
2 8 19
2 5 12
5 8 11
4 5 1
5 10 2
8 10 14
3 10 8
4 10 13
7 10 10
5 7 19
7 8 9
6 7 7
2 7 2
2 3 12
2 6 9
3 6 7
 */

using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class CableGuyMain
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please the number of paths in the network:");
        int numberOfPaths = int.Parse(Console.ReadLine());

        OrderedBag<Edge> edges = new OrderedBag<Edge>();
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        Dictionary<int, List<Node>> parentNodes = new Dictionary<int, List<Node>>();
        for (int i = 0; i < numberOfPaths; i++)
        {
            int[] pathData = ReadUserInput();
            edges.Add(new Edge(pathData[0], pathData[1], pathData[2]));

            if (!nodes.ContainsKey(pathData[0]))
            {
                nodes[pathData[0]] = new Node(pathData[0], pathData[0]);
                parentNodes.Add(pathData[0], new List<Node> { nodes[pathData[0]] });
            }

            if (!nodes.ContainsKey(pathData[1]))
            {
                nodes[pathData[1]] = new Node(pathData[1], pathData[1]);
                parentNodes.Add(pathData[1], new List<Node> { nodes[pathData[1]] });
            }
        }

        List<NewEdge> minimalSpanningTreeEdges = new List<NewEdge>();

        while (parentNodes.Count > 1)
        {
            Edge currentEdge = edges.GetFirst();
            edges.RemoveFirst();

            int firstNodeId = currentEdge.FirstNodeId;
            int secondNodeId = currentEdge.SecondNodeId;

            Node firstNode = nodes[firstNodeId];
            Node secondNode = nodes[secondNodeId];

            if (firstNode.ParentId != secondNode.ParentId)
            {
                firstNode.Neighbors.Add(secondNode);
                secondNode.Neighbors.Add(firstNode);
                SetTreeParentId(firstNode.ParentId, secondNode.ParentId, parentNodes);
                minimalSpanningTreeEdges.Add(new NewEdge(firstNode, secondNode, currentEdge.Distance));
            }
        }

        Console.WriteLine("The resulting minimal spanning tree is:");
        PrintTreeEdges(minimalSpanningTreeEdges);
    }

    private static void PrintTreeEdges(List<NewEdge> minimalSpanningTreeEdges)
    {
        for (int i = 0; i < minimalSpanningTreeEdges.Count; i++)
        {
            Console.WriteLine(minimalSpanningTreeEdges[i]);
        }
    }
    
    private static void SetTreeParentId(int firstParentNodeId, int secondParentNodeId, Dictionary<int, List<Node>> parentNodes)
    {
        List<Node> oldTree;
        int newParentNodeId;

        if (parentNodes[firstParentNodeId].Count > parentNodes[secondParentNodeId].Count)
        {
            oldTree = parentNodes[secondParentNodeId];
            parentNodes.Remove(secondParentNodeId);
            newParentNodeId = firstParentNodeId;
        }
        else
        {
            oldTree = parentNodes[firstParentNodeId];
            parentNodes.Remove(firstParentNodeId);
            newParentNodeId = secondParentNodeId;
        }

        for (int i = 0; i < oldTree.Count; i++)
        {
            oldTree[i].ParentId = newParentNodeId;
        }

        parentNodes[newParentNodeId].AddRange(oldTree);
    }
    
    private static int[] ReadUserInput()
    {
        string[] userInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] userInputParsedAsInt = new int[userInput.Length];

        for (int i = 0; i < userInput.Length; i++)
        {
            userInputParsedAsInt[i] = int.Parse(userInput[i]);
        }

        return userInputParsedAsInt;
    }
}