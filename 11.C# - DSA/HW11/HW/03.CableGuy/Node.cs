using System;
using System.Collections.Generic;

public class Node
{
    public Node(int id, int parentId)
    {
        this.Id = id;
        this.ParentId = parentId;
        this.Neighbors = new List<Node>();
    }

    public int Id { get; private set; }

    public int ParentId { get; set; }

    public List<Node> Neighbors { get; set; }
}