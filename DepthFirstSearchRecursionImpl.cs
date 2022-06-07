using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DepthFirstSearchRecursionImpl
    {

        public void TraverseDFS(List<Vertex> vertices)
        {
            Console.WriteLine("Visiting ");
            // it may happen to have independent clusters inside our graph
            foreach (Vertex vertex in vertices)
            {
                if (!vertex.IsVisited)
                {
                    vertex.IsVisited = true;
                    DfsHelper(vertex);
                }
            }
            Console.WriteLine();
        }

        private void DfsHelper(Vertex vertex)
        {
            Console.Write(vertex + " ");

            foreach (Vertex v in vertex.AdjacencyList)
            {
                if (!v.IsVisited)
                {
                    v.IsVisited = true;
                    DfsHelper(v);
                }
            }
        }


    }
}

