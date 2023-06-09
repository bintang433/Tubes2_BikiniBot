
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace MazeSolver
{
    public class Node
    {
        List<Node> neighbors;
        int absis;
        int ordinat;
        bool treasure;
        bool mrCrab;
        public Node(bool isTreasure, bool isMrCrab, int absis, int ordinat)
        {
            neighbors = new List<Node>();
            treasure = isTreasure;
            mrCrab = isMrCrab;
            this.absis = absis;
            this.ordinat = ordinat;
        }
        public bool Treasure
        {
            get
            {
                return treasure;
            }
            set
            {
                treasure = value;
            }
        }
        public bool MrCrab
        {
            get
            {
                return mrCrab;
            }
            set
            {
                mrCrab = value;
            }
        }
        public List<Node> Neighbors
        {
            get
            {
                return neighbors;
            }
        }
        public int Absis
        {
            get
            {
                return absis;

            }
            set
            {
                absis = value;
            }
        }
        public int Ordinat
        {
            get
            {
                return ordinat;

            }
            set
            {
                ordinat = value;
            }
        }
        public void addNeighbor(Node newNeighbor)
        {
            if (!neighbors.Contains(newNeighbor, new NodeComparer()))
            {
                neighbors.Add(newNeighbor);
                newNeighbor.addNeighbor(this);
            }
        }



        public bool isNeighbor(Node node)
        {
            return (Math.Abs(this.Absis - node.Absis) + Math.Abs(this.Ordinat - node.Ordinat) == 1);
        }

        public string move(int x, int y)
        {
            if (x-this.Absis==1)
            {
                return "L";
            }
            else if (x - this.Absis == -1)
            {
                return "R";
            }
            else if (y - this.Ordinat == 1)
            {
                return "U";
            }
            else if (y - this.Ordinat == -1)
            {
                return "D";
            }
            else
            {
                return "";
            }
        }
    }
}