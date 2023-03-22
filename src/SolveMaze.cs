using System.Collections.Generic;
using System.Diagnostics;

class SolveMaze
{
    private Maze maze;

    public SolveMaze(Maze maze)
    {
        this.maze = maze;
    }
public void SolveDFS()
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Node startNode = new Node(maze.StartX, maze.StartY);
    Stack<Node> stack = new Stack<Node>();
    stack.Push(startNode);
    HashSet<Node> visited = new HashSet<Node>();

    int treasureCount = 0;
    int nodeCount = 0;

    while (stack.Count > 0)
    {
        Node currentNode = stack.Pop();
        nodeCount++;

        if (maze.IsTreasure(currentNode.X, currentNode.Y))
        {
            treasureCount++;
        }

        visited.Add(currentNode);

        foreach (Node neighbor in GetNeighbors(currentNode))
        {
            if (!visited.Contains(neighbor))
            {
                stack.Push(neighbor);
            }
        }

        if (treasureCount == maze.TreasureCount)
        {
            PrintSolution(currentNode, stopwatch.ElapsedMilliseconds, nodeCount, treasureCount);
            return;
        }
    }

    Console.WriteLine("No solution found.");
}

public void SolveBFS()
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Node startNode = new Node(maze.StartX, maze.StartY);
    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(startNode);
    HashSet<Node> visited = new HashSet<Node>();

    int treasureCount = 0;
    int nodeCount = 0;

    while (queue.Count > 0 && treasureCount < maze.TreasureCount)
    {
        Node currentNode = queue.Dequeue();
        nodeCount++;

        if (maze.IsTreasure(currentNode.X, currentNode.Y))
        {
            treasureCount++;
        }

        visited.Add(currentNode);

        foreach (Node neighbor in GetNeighbors(currentNode))
        {
            if (!visited.Contains(neighbor))
            {
                queue.Enqueue(neighbor);
            }
        }

        if (treasureCount == maze.TreasureCount)
        {
            PrintSolution(currentNode, stopwatch.ElapsedMilliseconds, nodeCount, treasureCount);
            return;
        }
    }

    Console.WriteLine("No solution found.");
}

private List<Node> GetNeighbors(Node node)
{
    List<Node> neighbors = new List<Node>();

    // Check atas
    if (maze.IsAccessible(node.X, node.Y - 1))
    {
        Node neighbor = new Node(node.X, node.Y - 1, node.Steps + 1, node);
        neighbors.Add(neighbor);
    }

    // Check bawah
    if (maze.IsAccessible(node.X, node.Y + 1))
    {
        Node neighbor = new Node(node.X, node.Y + 1, node.Steps + 1, node);
        neighbors.Add(neighbor);
    }

    // Check kiri
    if (maze.IsAccessible(node.X - 1, node.Y))
    {
        Node neighbor = new Node(node.X - 1, node.Y, node.Steps + 1, node);
        neighbors.Add(neighbor);
    }

    // Check kanan
    if (maze.IsAccessible(node.X + 1, node.Y))
    {
        Node neighbor = new Node(node.X + 1, node.Y, node.Steps + 1, node);
        neighbors.Add(neighbor);
    }

    return neighbors;
}

    public void PrintSolution(Node endNode, long elapsedTime, int nodeCount, int treasureCount)
    {
        Console.WriteLine("Solution found!");
        Console.WriteLine("Number of steps: " + endNode.Steps);
        Console.WriteLine("Number of nodes explored: " + nodeCount);
        Console.WriteLine("Number of treasures found: " + treasureCount);
        Console.WriteLine("Route: " + endNode.Steps + " steps, " + nodeCount + " nodes, " + treasureCount + " treasures.");

        List<Node> path = new List<Node>();
        while (endNode != null)
        {
            path.Add(endNode);
            endNode = endNode.Parent;
        }
        path.Reverse();

        Console.WriteLine("Path:");
        foreach (Node node in path)
        {
            Console.WriteLine("(" + node.X + ", " + node.Y + ")");
        }

        Console.WriteLine("Elapsed time: " + elapsedTime + " ms");
    }

}