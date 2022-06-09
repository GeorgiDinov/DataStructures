using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // needed for the correct workings of the priority queue
    internal class VertexDistanceComparer : IComparer<Vertex>
    {
        public int Compare(Vertex v1, Vertex v2)
        {
            return v1.Distance.CompareTo(v2.Distance);
        }
    }
}
