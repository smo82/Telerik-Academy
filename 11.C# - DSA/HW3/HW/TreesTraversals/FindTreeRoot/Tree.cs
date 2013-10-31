using System;
using System.Collections.Generic;

public class Tree : IEnumerable<TreeNode>
{
    private List<TreeNode> traversedNodes;
    private List<List<TreeNode>> paths;

    public Tree(TreeNode root)
    {
        this.Root = root;
    }

    public TreeNode Root { get; private set; }

    public IEnumerator<TreeNode> GetEnumerator()
    {
        this.traversedNodes = new List<TreeNode>();
        this.DFSTraverse(this.Root);

        foreach (TreeNode node in this.traversedNodes)
        {
            yield return node;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public List<List<TreeNode>> GetAllPosiblePaths()
    {
        this.paths = new List<List<TreeNode>>();

        this.CollectSubpaths(this.Root, new List<TreeNode>());

        return this.paths;
    }

    private void CollectSubpaths(TreeNode parentNode, List<TreeNode> currentPath)
    {
        List<TreeNode> newCurrentPath = new List<TreeNode>();
        newCurrentPath.AddRange(currentPath);
        newCurrentPath.Add(parentNode);
        this.paths.Add(newCurrentPath);

        foreach (TreeNode child in parentNode.ChildNodes)
        {
            this.CollectSubpaths(child, newCurrentPath);
        }
    }

    private void DFSTraverse(TreeNode node)
    {
        List<TreeNode> childNodes = node.ChildNodes;

        foreach (TreeNode childNode in childNodes)
        {
            this.DFSTraverse(childNode);
        }

        this.traversedNodes.Add(node);
    }
}