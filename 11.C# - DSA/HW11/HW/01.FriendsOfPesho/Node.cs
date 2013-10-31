using System;

public class Node : IComparable<Node>
{
    public Node(int id)
    {
        this.Id = id;
    }

    public int Id { get; private set; }

    public int DijkstraDistance { get; set; }

    public int CompareTo(Node other)
    {
        return this.DijkstraDistance - other.DijkstraDistance;
    }
}