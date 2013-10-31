using System;
using System.Collections.Generic;

public class TrieNode
{
    public TrieNode(char nodeChar)
    {
        this.NodeChar = nodeChar;
        this.Childs = new TrieNode[62];
    }

    public char NodeChar { get; private set; }

    public TrieNode Parent { get; set; }

    public TrieNode[] Childs { get; private set; }

    public bool EndWord { get; set; }

    public void AddChild(TrieNode child)
    {
        int indexChar = CharFunctions.CharToIndex(child.NodeChar);
        this.Childs[indexChar] = child;
        child.Parent = this;
    }

    public TrieNode GetChild(char childChar)
    {
        int indexChar = CharFunctions.CharToIndex(childChar);
        return this.Childs[indexChar];
    }
}