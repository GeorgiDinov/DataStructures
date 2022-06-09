using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    //PriorityQueue class is used from DotNetty.Common.Utilities namespace
    //maybe not included in the current version I am using, test if you have it directly from System.Collections.Generic
    //PriorityQueue<Vertex, Vertex> queue = new PriorityQueue<Vertex, Vertex>(new VertexDistanceComparer());


    internal class DijkstraAlgorithm
    {
        //The algorithm constructs the shortest path to all other verices
        //So every vertex will have the minimum distance from the source / starting vertex

        //At first all vertices has the distance set to positive infinity
        //We use heap to store the vertices and poll the one with least distance, based on the Compare method
        //Check wheater the distance from the current vertex we are looking at plus the edge weight is less than the target vertex distance(it means that there is a shorter path)
        //if that is true we set the target vertex distance to be the new one, set the predecessor to be the current and put it back to the heap
        //rinse and repeat until we go trough all vertices and edges and set the min distance to every vertex with the respect of the startin vertex

        public void ConstructShortestPathTreeFrom(Vertex startingVertex)
        {
            PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>(new VertexDistanceComparer());

            startingVertex.Distance = 0d;
            queue.Enqueue(startingVertex);

            while (queue.Count > 0)
            {
                Vertex currentVertex = queue.Dequeue();
                foreach (Edge edge in currentVertex.EdgeList)
                {

                    Vertex targetVertex = edge.TargetVertex;

                    double distance = currentVertex.Distance + edge.EdgeWeight;
                    if (distance < targetVertex.Distance)
                    {
                        //bottle neck - removal will be O(n)
                        //unless something like this it is used https://github.com/sqeezy/FibonacciHeap.git
                        queue.Remove(targetVertex);// get it out to set the new distance and predecessor, and then put it back to it's new place in the heap

                        targetVertex.Distance = distance;
                        targetVertex.Predecessor = currentVertex;
                        queue.Enqueue(targetVertex);
                    }
                }
            }
        }


        public List<Vertex> GetShortestPathTo(Vertex vertex)
        {
            List<Vertex> path = new List<Vertex>();
            for (Vertex v = vertex; v != null; v = v.Predecessor)
            {
                path.Add(v);
            }
            path.Reverse();
            return path;
        }


        public void PrintSHortestPathTo(Vertex vertex)
        {
            List<Vertex> path = GetShortestPathTo(vertex);
            Console.Write("Shortest Path to " + vertex + " is " + vertex.Distance + " weight units: ");
            for (int i = 0; i < path.Count; i++)
            {
                string msg = (i < path.Count - 1) ? path.ElementAt(i) + " -> " : path.ElementAt(i) + "\n";
                Console.Write(msg);
            }
        }

    }
}
