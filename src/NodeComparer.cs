using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class NodeComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            return x.Absis == y.Absis && x.Ordinat == y.Ordinat;
        }

        public int GetHashCode(Node obj)
        {
            return obj.Absis.GetHashCode() ^ obj.Ordinat.GetHashCode();
        }
    }
}
