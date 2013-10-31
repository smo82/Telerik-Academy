using System;

public class Edge : IComparable<Edge>
{
    public Edge(int firstNodeId, int secondNodeId, int distance)
    {
        this.FirstNodeId = firstNodeId;
        this.SecondNodeId = secondNodeId;
        this.Distance = distance;
    }

    public int FirstNodeId { get; private set; }
    
    public int SecondNodeId { get; private set; }

    public int Distance { get; set; }

    public int CompareTo(Edge other)
    {
        return this.Distance - other.Distance;
    }
}