using System;
using System.Collections.Generic;

public class Graph
{
    public Graph()
    {
        this.Nodes = new Dictionary<int, Node>();
        this.NodeConnections = new Dictionary<Node, List<Connection>>();
    }

    public Dictionary<int, Node> Nodes { get; private set; }

    public Dictionary<Node, List<Connection>> NodeConnections { get; private set; }

    public void InitGraphDijkstraDistances()
    {
        foreach (KeyValuePair<int, Node> nodePair in this.Nodes)
        {
            nodePair.Value.DijkstraDistance = int.MaxValue;
        }
    }

    public void AddConnection(int firstNodeId, int secondNodeId, int distance)
    {
        Node firstNode;
        if (!this.Nodes.ContainsKey(firstNodeId))
        {
            firstNode = new Node(firstNodeId);
            this.Nodes.Add(firstNodeId, firstNode);
            this.NodeConnections.Add(firstNode, new List<Connection>());
        }
        else
        {
            firstNode = this.Nodes[firstNodeId];
        }
        
        Node secondNode;
        if (!this.Nodes.ContainsKey(secondNodeId))
        {
            secondNode = new Node(secondNodeId);
            this.Nodes.Add(secondNodeId, secondNode);
            this.NodeConnections.Add(secondNode, new List<Connection>());
        }
        else
        {
            secondNode = this.Nodes[secondNodeId];
        }

        this.NodeConnections[firstNode].Add(new Connection(secondNode, distance));
        this.NodeConnections[secondNode].Add(new Connection(firstNode, distance));
    }
}
