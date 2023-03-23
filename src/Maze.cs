using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Shapes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Threading;

namespace MazeSolver
{
    internal class Maze
    {
        private int width;
        private int height;
        private Node startNode;
        private string bfsPath = "";
        private string dfsPath = "";
        private int treasureCount = 0;
        private bool dfsDone = false;
        private bool bfsDone = false;

        private readonly ManualResetEventSlim pauseEvent = new ManualResetEventSlim(false);

        private List<List<string>> peta;
        private List<List<Node>> grid;
        private List<List<Rectangle>> rectangles;

        public Maze()
        {
            this.rectangles = new List<List<Rectangle>>();
            this.grid = new List<List<Node>>();
            this.peta = new List<List<string>>();

        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        { 
            get { return height; } 
            set { height = value; }
        }
        public List<List<String>> Peta
        { 
            get { return peta; }
        }
        public List<List<Rectangle>> Rectangles
        { 
            get { return rectangles; } 
        }

        public List<List<Node>> Grid
        { 
            get { return grid; } 
        }

        public string BfsPath
        {
            get { return bfsPath; }
            set { bfsPath = value; }
        }

        public string DfsPath
        {
            get { return dfsPath; }
            set { dfsPath = value; }
        }
        
        public int TreasureCount
        {
            get { return treasureCount; }
            set { treasureCount = value; }
        }
        public Node StartNode 
        { 
            get { return startNode; }
        }
        
        public bool DfsDone
        {
            get { return dfsDone; }

        }
        public bool BfsDone
        {
            get { return bfsDone; }
        }
        public void createMap(String filename)
        {
            String filePath = filename;
            this.peta.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                int row = 0;
                this.grid.Add(new List<Node>());
                string line = reader.ReadLine(); // Read the first line of the file
                this.peta.Add(new List<String>(line.Split(' '))); // Add the first line to the list of lists
                for (int col = 0; col < this.peta[row].Count; col++)
                {
                    if (this.peta[row][col] != "X")
                    {
                        bool isTreasure = false;
                        bool isMrCrab = false;
                        if (this.peta[row][col] == "K")
                        {
                            isMrCrab = true;
                        }
                        if (this.peta[row][col] == "T")
                        {
                            isTreasure = true;
                            this.TreasureCount++;
                        }
                        Node newNode = new Node(isTreasure, isMrCrab, col, row);
                        if (isMrCrab)
                        {
                            this.startNode = newNode;
                        }
                        this.grid[row].Add(newNode);
                    }
                }
                row++;
                while ((line = reader.ReadLine()) != null)
                {
                    this.grid.Add(new List<Node>());
                    this.peta.Add(new List<String>(line.Split(' '))); // Add each subsequent line to the list of lists
                    for (int col = 0; col < this.peta[row].Count; col++)
                    {
                        if (this.peta[row][col] != "X")
                        {
                            bool isTreasure = false;
                            bool isMrCrab = false;
                            if (this.peta[row][col] == "K")
                            {
                                isMrCrab = true;
                            }
                            if (this.peta[row][col] == "T")
                            {
                                isTreasure = true;
                                this.TreasureCount++;
                            }
                            Node newNode = new Node(isTreasure, isMrCrab, col, row);
                            if (isMrCrab)
                            {
                                this.startNode = newNode;
                            }
                            this.grid[row].Add(newNode);
                        }
                    }

                    row++;
                }
                if (this.Peta.Count > 0)
                {
                    this.Width = this.Peta[0].Count;
                    this.Height = this.Peta.Count;
                }
            }
        }

        public void connectNode()
        {
            for (int i = 0; i < this.grid.Count; i++)
            {
                for (int j = 0; j < this.grid[i].Count; j++)
                {
                    if (j != this.grid[i].Count - 1)
                    {
                        if (this.grid[i][j].isNeighbor(this.grid[i][j + 1]))
                        {
                            this.grid[i][j].addNeighbor(this.grid[i][j + 1]);
                        }
                    }
                    if (i != (this.grid.Count - 1))
                    {
                        for (int k = 0; k < this.grid[i+1].Count; k++)
                        {
                            if (this.grid[i][j].isNeighbor(this.grid[i + 1][k]))
                            {
                                this.grid[i][j].addNeighbor(this.grid[i + 1][k]);
                            }
                        }
                    }
                }
            }
        }

        public void BFS()
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            HashSet<Node> visitedT = new HashSet<Node>();

            queue.Enqueue(this.startNode);
            visited.Add(this.startNode);
            while (queue.Count > 0 && visitedT.Count < this.TreasureCount)
            {
                Node node = queue.Dequeue();
                visited.Add(node);
                if (this.bfsPath.Length > 0)
                    this.bfsPath += " - ";
                this.bfsPath += ("(" + node.Ordinat.ToString() + "," + node.Absis.ToString() + ")");

                if (node.Treasure && !visitedT.Contains(node))
                {
                    visitedT.Add(node);
                }
                foreach (Node neighbor in node.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public async void visualizeBFS()
        {

            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            HashSet<Node> visitedT = new HashSet<Node>();

            queue.Enqueue(this.startNode);
            visited.Add(this.startNode);
            while (queue.Count > 0 && visitedT.Count < this.TreasureCount)
            {
                Node node = queue.Dequeue();
                visited.Add(node);
                this.rectangles[node.Ordinat][node.Absis].Fill = Brushes.Blue;

                if (node.Treasure && !visitedT.Contains(node))
                {
                    visitedT.Add(node);
                }
                foreach (Node neighbor in node.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
                await Task.Delay(500);
                this.rectangles[node.Ordinat][node.Absis].Fill = Brushes.Aqua;
            }
            this.bfsDone = true;
        }

        public void DFS(Node node, HashSet<Node> visited, HashSet<Node> visitedT, int x, int y)
        {
            if (visitedT.Count == TreasureCount)
            {
                return;
            }
            if (this.DfsPath.Length > 0)
                this.dfsPath += " - ";
            visited.Add(node);
            this.dfsPath += ("(" + node.Ordinat.ToString() + "," + node.Absis.ToString() + ")");
            if (node.Treasure && !visitedT.Contains(node))
            {
                visitedT.Add(node);
            }

            foreach (Node neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(neighbor, visited, visitedT, node.Absis, node.Ordinat);
                }
            }
        }
        public async Task visualizeDFS(Node node, HashSet<Node> visited, HashSet<Node> visitedT, int x, int y)
        {
            
            if (visitedT.Count == TreasureCount)
            {
                return;
            }
            visited.Add(node);
            if (node.Treasure && !visitedT.Contains(node))
            {
                visitedT.Add(node);
            }
            rectangles[node.Ordinat][node.Absis].Fill = Brushes.Blue;
            await Task.Delay(500);
            rectangles[node.Ordinat][node.Absis].Fill = Brushes.Aqua;
            foreach (Node neighbor in node.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    await visualizeDFS(neighbor, visited, visitedT, node.Absis, node.Ordinat);
                }
            }
            this.dfsDone = true;
        }
        
    }
}
