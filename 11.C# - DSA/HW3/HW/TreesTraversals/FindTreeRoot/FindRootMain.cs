/*
 * Task01
 * 
 * You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1).
 * Example:
 * 
 * 7
 * 2 4
 * 3 2
 * 5 0
 * 3 5
 * 5 6
 * 5 1
 * 
 * Write a program to read the tree and find:
 * a) the root node
 * b) all leaf nodes
 * c) all middle nodes
 * d) the longest path in the tree
 * e) all paths in the tree with given sum S of their nodes
 * f) all subtrees with given sum S of their nodes
 */

using System;
using System.Collections.Generic;

public class FindRootMain
{
    public static void Main(string[] args)
    {
        // a) the root node
        Tree tree = ReadTree();
        Console.Clear();
        Console.WriteLine("The root of the tree is: {0}", tree.Root.Value);

        // b) all leaf nodes
        List<TreeNode> leafNodes = GetLeafNodes(tree);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("The leaf nodes are:");
        PrintNodeList(leafNodes);

        // c) all middle nodes
        List<TreeNode> middleNodes = GetMiddleNodes(tree);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("The middle nodes are:");
        PrintNodeList(middleNodes);

        // d) the longest path in the tree
        int longestPath = GetLongestPath(tree);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("The longest path in the tree is: {0}", longestPath);

        // e) all paths in the tree with given sum S of their nodes
        int targetSum = 9;
        List<List<TreeNode>> allPathsWithSum = GetAllPathsWithSum(tree, targetSum);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("The paths with sum {0} are:", targetSum);
        PrintPathList(allPathsWithSum);

        // f) all subtrees with given sum S of their nodes
        targetSum = 6;
        List<List<TreeNode>> subtreesWithSum = GetAllSubtreesWithSum(tree, targetSum);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("The subtrees with sum {0} are:", targetSum);
        PrintPathList(subtreesWithSum);
    }

    private static List<List<TreeNode>> GetAllSubtreesWithSum(Tree tree, int targetSum)
    {
        List<List<TreeNode>> result = new List<List<TreeNode>>();

        foreach (TreeNode node in tree)
        {
            List<TreeNode> currentTreeNodes = node.DFSGetSubnodesTree();
            int currentTreeSum = CalcSumNodes(currentTreeNodes);
            if (currentTreeSum == targetSum)
            {
                result.Add(currentTreeNodes);
            }
        }

        return result;
    }

    private static List<List<TreeNode>> GetAllPathsWithSum(Tree tree, int sum)
    {
        List<List<TreeNode>> allPaths = tree.GetAllPosiblePaths();

        List<List<TreeNode>> result = new List<List<TreeNode>>();

        for (int i = 0; i < allPaths.Count; i++)
        {
            int currentPathSum = CalcSumNodes(allPaths[i]);
            if (currentPathSum == sum)
            {
                result.Add(allPaths[i]);
            }
        }

        return result;
    }

    private static int CalcSumNodes(List<TreeNode> listNodes)
    {
        int sum = 0;
        foreach (TreeNode node in listNodes)
        {
            sum += node.Value;
        }

        return sum;
    }

    private static int GetLongestPath(Tree tree)
    {
        int longestPath = 0;

        List<List<TreeNode>> allTreePaths = tree.GetAllPosiblePaths();

        foreach (List<TreeNode> path in allTreePaths)
        {
            if (path.Count > longestPath)
            {
                longestPath = path.Count;
            }
        }

        return longestPath;
    }

    private static List<TreeNode> GetMiddleNodes(Tree tree)
    {
        List<TreeNode> middleNodes = new List<TreeNode>();
        foreach (TreeNode node in tree)
        {
            if (node.ChildNodes.Count > 0)
            {
                middleNodes.Add(node);
            }
        }

        middleNodes.Remove(tree.Root);

        return middleNodes;
    }

    private static void PrintPathList(List<List<TreeNode>> paths)
    {
        foreach (List<TreeNode> path in paths)
        {
            foreach (TreeNode node in path)
            {
                Console.Write("{0} ", node.Value);
            }

            Console.WriteLine();
        }
    }

    private static void PrintNodeList(List<TreeNode> leafNodes)
    {
        foreach (TreeNode leafNode in leafNodes)
        {
            Console.WriteLine(leafNode.Value);
        }
    }

    private static List<TreeNode> GetLeafNodes(Tree tree)
    {
        List<TreeNode> leafs = new List<TreeNode>();
        foreach (TreeNode node in tree)
        {
            if (node.ChildNodes.Count == 0)
            {
                leafs.Add(node);
            }
        }

        return leafs;
    }

    private static Tree ReadTree()
    {
        Console.WriteLine("Please enter the number of pairs (N): ");
        int numberOfPairs = Functions.ReadIntInRange(1) - 1;

        Dictionary<int, TreeNode> nodes;
        List<TreeNode> childNodes;
        ReadNodes(numberOfPairs, out nodes, out childNodes);

        TreeNode root = FindRoot(nodes, childNodes);

        Tree tree = new Tree(root);
        return tree;
    }

    private static void ReadNodes(int numberOfPairs, out Dictionary<int, TreeNode> nodes, out List<TreeNode> childNodes)
    {
        nodes = new Dictionary<int, TreeNode>();
        childNodes = new List<TreeNode>();
        Console.WriteLine("Please enter the pairs:");
        for (int i = 0; i < numberOfPairs; i++)
        {
            Console.WriteLine("{0}: ", i);
            int parentValue;
            int childValue;
            ReadPairData(out parentValue, out childValue);

            TreeNode childNode = GetNodeObject(childValue, ref nodes);
            TreeNode parentNode = GetNodeObject(parentValue, ref nodes);

            parentNode.AddChildNode(childNode);
            if (!childNodes.Contains(childNode))
            {
                childNodes.Add(childNode);
            }
        }
    }

    private static TreeNode FindRoot(Dictionary<int, TreeNode> nodes, List<TreeNode> childNodes)
    {
        TreeNode root = null;
        foreach (KeyValuePair<int, TreeNode> nodeData in nodes)
        {
            TreeNode currentNode = nodeData.Value;
            if (!childNodes.Contains(currentNode))
            {
                root = currentNode;
                break;
            }
        }

        return root;
    }

    private static TreeNode GetNodeObject(int nodeValue, ref Dictionary<int, TreeNode> nodes)
    {
        TreeNode node;
        if (nodes.ContainsKey(nodeValue))
        {
            node = nodes[nodeValue];
        }
        else
        {
            node = new TreeNode(nodeValue);
            nodes.Add(nodeValue, node);
        }

        return node;
    }

    private static void ReadPairData(out int parentValue, out int childValue)
    {
        parentValue = 0;
        childValue = 0;
        while (true)
        {
            string userInput = Console.ReadLine();
            string[] pairData = userInput.Split(new char[] { ' ' });

            if (pairData.Length == 2)
            {
                bool successReadParentData = int.TryParse(pairData[0], out parentValue);
                bool successReadChildData = int.TryParse(pairData[1], out childValue);

                if (successReadParentData && successReadChildData)
                {
                    break;
                }
            }

            Console.WriteLine("Wrong input, please try again:");
        }
    }
}