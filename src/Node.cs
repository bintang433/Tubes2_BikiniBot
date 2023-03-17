using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MazeSolver.src
{
    internal class Node
    {
        List<Node> children;
        bool treasure;
        bool mrCrab;
        public Node(bool isTreasure, bool isMrCrab)
        {
            children = new List<Node>();
            treasure = isTreasure;
            mrCrab = isMrCrab;
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
        public List<Node> Children
        {
            get
            {
                return children;
            }
        }
        public void addChildren(bool isTreasure, bool isMrCrab)
        {
            Node child = new Node(isTreasure, isMrCrab);
            children.Add(child);
        }

        public bool dfs()
        {
            if (Treasure && MrCrab)
            {
                return true;
            }
            else
            {
                bool found = false;
                foreach (Node child in Children)
                {
                    found = found || child.dfs();
                    if (found)
                        break;
                }
                return found;
            }
        }

        public bool bfs()
        {
            Queue<Node> childQueue = new Queue<Node>();
            if (Treasure)
            {
                return true;
            }
            foreach (Node child in Children)
            {
                childQueue.Enqueue(child);
            }
            while (childQueue.Count != 0)
            {
                Node checkChild = childQueue.Dequeue();
                if (checkChild.Treasure)
                {
                    return true;
                }
                foreach (Node grandchild in checkChild.Children)
                {
                    childQueue.Enqueue(grandchild);
                }
            }
            return false;
        }
    }
}
