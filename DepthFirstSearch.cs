using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DepthFirstSearch
    {


        private Stack<Vertex> stack;

        public DepthFirstSearch()
        {
            stack = new Stack<Vertex>();
        }


        public void TraverseDFS(List<Vertex> vertices)
        {
            // it may happen to have independent clusters inside our graph
            foreach (Vertex vertex in vertices)
            {
                if (!vertex.IsVisited)
                {
                    vertex.IsVisited = true;
                    DfsHelper(vertex);
                }
            }
        }

        private void DfsHelper(Vertex vertex)
        {
            Console.Write("Visiting ");
            vertex.IsVisited = true;
            stack.Push(vertex);

            while (stack.Count > 0)
            {
                Vertex currentVertex = stack.Pop();
                Console.Write(currentVertex + " ");
                foreach (Vertex v in currentVertex.AdjacencyList)
                {
                    if (!v.IsVisited)
                    {
                        v.IsVisited = true;
                        stack.Push(v);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
