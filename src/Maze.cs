using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Shapes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    internal class Maze
    {
        private int length;
        private int width;
        private int xAwal;
        private int xAkhir;
        private int yAwal;
        private int yAkhir;
        private List<List<string>> peta;
        private List<List<Node>> grid;
        public List<List<int>> angkas;
        public List<int> angka;

        public Maze()
        {
            this.xAwal = 0;
            this.yAwal = 0;
            this.xAkhir = 0;
            this.yAkhir = 0;
            this.peta = new List<List<string>>();

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
        public int XAwal
        {
            get { return xAwal; }
            set { xAwal = value; }
        }
        public int XAkhir
        {
            get { return xAkhir; }
            set { xAkhir = value; }
        }
        public int YAwal
        {
            get { return yAwal; }
            set { yAwal = value; }
        }
        public int YAkhir
        {
            get { return yAkhir; }
            set { yAkhir = value; }
        }
        public List<List<String>> Peta
        { 
            get { return peta; }
        }
        public void initGrid(int row, int col)
        {
            grid = new List<List<Node>>(row);
            for (int i  = 0; i < grid.Count; i++)
            {
                grid[i] = new List<Node>(col);
            }
        }
        public void setGrid(int row, int col, bool treasure, bool mrcrab)
        {
            grid[row][col] = new Node(treasure, mrcrab);
        }

        public void createMap(String filename)
        {
            String filePath = filename;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine(); // Read the first line of the file
                this.peta.Add(new List<String>(line.Split(' '))); // Add the first line to the list of lists
                while ((line = reader.ReadLine()) != null)
                {
                    this.peta.Add(new List<String>(line.Split(' '))); // Add each subsequent line to the list of lists
                }
                this.length = peta.Count;
                this.width = peta[0].Count;
            }
        }

        public void printMap()
        {
            foreach (List<String> row in peta) 
            {
                foreach(String c in row)
                {
                    Console.Write(c);
                    Console.Write(' ');
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
