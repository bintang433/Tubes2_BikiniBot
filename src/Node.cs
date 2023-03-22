using System.Collections.Generic;

class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Steps { get; set; }
    public Node Parent { get; set; }
    public List<Node> Neighbors { get; }

    public bool Visited { get; set; }

    public Node(int x, int y, int steps = 0, Node parent = null!)
    {
        X = x;
        Y = y;
        Steps = steps;
        Parent = parent;
        Neighbors = new List<Node>();
        Visited = false;
    }

    public void AddNeighbor(Node neighbor)
    {
        if (neighbor == null)
        {
            return;
        }

        Neighbors.Add(neighbor);
        neighbor.Neighbors.Add(this);
    }
}