using System;

public class NewEdge
{
    public NewEdge(Node firstNode, Node secondNode, int distance)
    {
        this.FirstNode = firstNode;
        this.SecondNode = secondNode;
        this.Distance = distance;
    }

    public Node FirstNode { get; private set; }

    public Node SecondNode { get; private set; }

    public int Distance { get; private set; }

    public override string ToString()
    {
        return string.Format("{0} - {1} : {2}", this.FirstNode.Id, this.SecondNode.Id, this.Distance);
    }
}