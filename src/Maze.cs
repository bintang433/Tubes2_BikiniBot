
﻿using System;
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
using System.Diagnostics;

namespace MazeSolver { 
    ﻿class Maze
    {

        private Node startNode;
        private int treasureCount = 0;
        private int width;
        private int height;
        private double runTime;
        private string path = "";

        private List<Node> steps;

        private List<List<string>> peta;
        private List<List<Node>> grid;
        private List<List<Rectangle>> rectangles;

        public Maze()
        {
            this.rectangles = new List<List<Rectangle>>();
            this.grid = new List<List<Node>>();
            this.peta = new List<List<string>>();
            this.steps = new List<Node> ();

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

        public string Path
        {
            get { return path; }
            set { path = value; }
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

        public double RunTime
        { 
            get { return runTime;}
            set { runTime = value; }
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

        public int nodeCount()
        {
            int count = 0;
            foreach(List<Node> nodes in this.grid)
            {
                count += nodes.Count;
            }
            return count;
        }

        public void BFS()
        {
            Stopwatch stopwatch = new Stopwatch();
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            HashSet<Node> visitedT = new HashSet<Node>();

            stopwatch.Start();

            queue.Enqueue(this.startNode);
            visited.Add(this.startNode);
            this.steps.Add(this.startNode);
            while (queue.Count > 0 && visitedT.Count < this.TreasureCount)
            {
                Node node = queue.Dequeue();
                visited.Add(node);
                this.steps.Add(node);
                if (this.Path.Length > 0)
                    this.Path += " - ";
                this.Path += ("(" + node.Ordinat.ToString() + "," + node.Absis.ToString() + ")");

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
                List<Node> tempPath = this.straightenPath(this.steps);
                while (!queue.Peek().isNeighbor(tempPath[tempPath.Count - 1]) && visitedT.Count < this.TreasureCount)
                {
                    tempPath.RemoveAt(tempPath.Count-1);
                    this.steps.Add(tempPath[tempPath.Count - 1]);
                    this.Path += " - ";
                    this.Path += ("(" + tempPath[tempPath.Count - 1].Ordinat.ToString() + "," + tempPath[tempPath.Count - 1].Absis.ToString() + ")");
                }
            }
            stopwatch.Stop();
            this.runTime = stopwatch.Elapsed.TotalMilliseconds;
        }

        public async void visualizeBFS()
        {
            foreach (Node node in this.steps)
            {
                this.rectangles[node.Ordinat][node.Absis].Fill = Brushes.Blue;
                await Task.Delay(800);
                this.rectangles[node.Ordinat][node.Absis].Fill = Brushes.Aqua;
            }
            
        }

        public void DFS(Node node, HashSet<Node> visited, HashSet<Node> visitedT, int x, int y)
        {

            if (visitedT.Count == TreasureCount)
            {
                return;
            }
            if (this.Path.Length > 0)
                this.Path += " - ";
            visited.Add(node);
            this.Path += ("(" + node.Ordinat.ToString() + "," + node.Absis.ToString() + ")");
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
        }
        public List<Node> straightenPath(List<Node> nodes)
        {
            List<Node> straightPath = new List<Node>(nodes);
            HashSet<Node> uniqueElements = new HashSet<Node>();
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                Node currentElement = nodes[i];
                if (uniqueElements.Contains(currentElement))
                {
                    int j = i + 1;
                    while (j < nodes.Count && nodes[j] != currentElement)
                    {
                        uniqueElements.Remove(nodes[j]);
                        nodes.RemoveAt(j);
                    }
                    nodes.RemoveAt(j);
                }
                else
                {
                    uniqueElements.Add(currentElement);
                }
            }
            return straightPath;
        }

    }
}