using System;

public class Connection
{
    public Connection(Node target, int distance)
    {
        this.TargetNode = target;
        this.Distance = distance;
    }

    public Node TargetNode { get; private set; }

    public int Distance { get; private set; }
}