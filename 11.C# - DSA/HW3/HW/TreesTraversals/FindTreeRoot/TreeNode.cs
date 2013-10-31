using System;
using System.Collections.Generic;

public class TreeNode
{
    public TreeNode(int value)
    {
        this.Value = value;
        this.ChildNodes = new List<TreeNode>();
    }

    public int Value { get; private set; }

    public List<TreeNode> ChildNodes { get; private set; }

    public void AddChildNode(TreeNode childNode)
    {
        this.ChildNodes.Add(childNode);
    }

    public List<TreeNode> DFSGetSubnodesTree()
    {
        List<TreeNode> result = new List<TreeNode>() { this };
        foreach (TreeNode childNode in this.ChildNodes)
        {
            result.AddRange(childNode.DFSGetSubnodesTree());
        }

        return result;
    }
}