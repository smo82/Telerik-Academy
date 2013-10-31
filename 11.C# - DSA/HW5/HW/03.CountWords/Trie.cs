using System;

public class Trie
{
    public Trie()
    {
        this.Root = new TrieNode('*');
    }

    public TrieNode Root { get; private set; }

    public bool FoundWord(string word)
    {
        return this.SearchWord(word, this.Root);
    }

    public TrieNode AddWord(string word)
    {   
        return this.AddWord(word, this.Root);
    }

    private bool SearchWord(string word, TrieNode root)
    {
        char currentChar = word[0];

        TrieNode currentNode = root.GetChild(currentChar);

        if (currentNode == null)
        {
            return false;
        }

        string wordTail = word.Substring(1);

        if (wordTail == string.Empty)
        {
            return currentNode.EndWord;
        }
        else
        {
            return this.SearchWord(wordTail, currentNode);
        }
    }

    private TrieNode AddWord(string word, TrieNode root)
    {
        char currentChar = word[0];

        TrieNode currentNode = root.GetChild(currentChar);

        if (currentNode == null)
        {
            currentNode = new TrieNode(currentChar);
            currentNode.Parent = root;
            root.AddChild(currentNode);
        }

        string wordTail = word.Substring(1);

        if (wordTail == string.Empty)
        {
            currentNode.EndWord = true;
            return currentNode;
        }
        else
        {
            return this.AddWord(wordTail, currentNode);
        }
    }
}