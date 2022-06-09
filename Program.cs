using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Example of the Graph we will search shortest path in
             * 
             *      5-------->(B)-------15------->(D)
             *     /           |  \               ↑ |
             *    /            |    \           /   |
             *   /             4     12       3     |
             *  /              |        \    /      |
             * /               ↓          ↓/        |
             *(A)------8----->(H)---7--->(C)        9 
             *  \             ↑  \       ↑  \       | 
             *   \          /     6    1     \      |    
             *    9       5       ↓  /        \     |
             *     \     /        (F)         11    | 
             *       ↓  /          ↑\          \    | 
             *       (E)-----4----/  \          \   | 
             *        |                 13       \  |
             *        |                   \       ↓ ↓   
             *        |                     \---->(G)  
             *         \                           ↑  
             *          -----------20-------------/
             */


            //Constructing the Graph
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");
            Vertex h = new Vertex("H");

            a.AddEdge(new Edge(5, a, b));
            a.AddEdge(new Edge(9, a, e));
            a.AddEdge(new Edge(8, a, h));

            b.AddEdge(new Edge(12, b, c));
            b.AddEdge(new Edge(15, b, d));
            b.AddEdge(new Edge(4, b, h));

            c.AddEdge(new Edge(3, c, d));
            c.AddEdge(new Edge(11, c, g));

            d.AddEdge(new Edge(9, d, g));

            e.AddEdge(new Edge(5, e, h));
            e.AddEdge(new Edge(4, e, f));
            e.AddEdge(new Edge(20, e, g));

            f.AddEdge(new Edge(1, f, c));
            f.AddEdge(new Edge(13, f, g));

            //g doesn't have outgoing connections

            h.AddEdge(new Edge(7, h, c));
            h.AddEdge(new Edge(6, h, f));

            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();
            dijkstra.ConstructShortestPathTreeFrom(a);

            dijkstra.PrintSHortestPathTo(a);
            dijkstra.PrintSHortestPathTo(b);
            dijkstra.PrintSHortestPathTo(c);
            dijkstra.PrintSHortestPathTo(d);
            dijkstra.PrintSHortestPathTo(e);
            dijkstra.PrintSHortestPathTo(f);
            dijkstra.PrintSHortestPathTo(g);
            dijkstra.PrintSHortestPathTo(h);

        }

    }
}
