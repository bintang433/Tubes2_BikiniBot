using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.src
{
    internal class Maze
    {
        private int length;
        private int width;
        private Node[,] grid;
        private int[,] awal;
        private int[,] akhir;
        private List<List<char>> peta = new List<List<char>>();

        public Maze(Node[,] grid, int[,] awal, int[,] akhir)
        {
            this.grid = grid;
            this.awal = awal;
            this.akhir = akhir;
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Width
        { 
            get { return width; } 
            set { width = value; }
        }
        public void setGrid(int row, int col, Node node)
        {
            grid[row, col] = node;
        }

        public void createMap(String filename)
        {
            String filePath = "../config/" + filename;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine(); // Read the first line of the file
                this.peta.Add(new List<char>(line.Split(' '))); // Add the first line to the list of lists
                while ((line = reader.ReadLine()) != null)
                {
                    this.peta.Add(new List<char>(line.Split(' '))); // Add each subsequent line to the list of lists
                }
                this.length = peta.Count;
                this.width = peta[0].Count;
            }
        }

        public void printMap()
        {
            foreach (List<char> row in peta) 
            {
                foreach(char c in row)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }

        public void solveBFS(int time)

        {

        }

        public void solveDFS(int time)
        {

        }
    }
}
