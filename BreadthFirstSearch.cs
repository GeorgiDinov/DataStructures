using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BreadthFirstSearch
    {

        public void TraverseBFS(Vertex root)
        {
            Console.Write("Visiting ");
            Queue<Vertex> queue = new Queue<Vertex>();

            root.IsVisited = true;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Vertex currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");
                foreach (Vertex v in currentVertex.AdjacencyList)
                {
                    if (!v.IsVisited)
                    {
                        v.IsVisited = true;
                        queue.Enqueue(v);
                    }
                }
            }
            Console.WriteLine();

        }// end of TraverseBFS


    }
}
