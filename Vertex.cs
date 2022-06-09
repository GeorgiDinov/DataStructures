using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Vertex
    {

        //== properties ==
        private string name;

        private bool isVisited;
        public bool IsVisited { get => isVisited; set => isVisited = value; }

        //used in BFS and DFS
        private List<Vertex> adjacencyList;
        public List<Vertex> AdjacencyList { get => adjacencyList; }

        //used for the Dijkstra shortest path
        private List<Edge> edgeList;
        public List<Edge> EdgeList { get => edgeList; set => edgeList = value; }


        //distance from the starting vertex(source)
        private double distance;
        public double Distance { get => distance; set => distance = value; }

        //the previous vertex on the shortest path
        private Vertex predecessor;
        public Vertex Predecessor { get => predecessor; set => predecessor = value; }

        // == constructors ==
        public Vertex(string name)
        {
            this.name = name;
            this.isVisited = false;
            this.adjacencyList = new List<Vertex>();
            this.edgeList = new List<Edge>();
            this.distance = Double.PositiveInfinity;// Double.MaxValue
            this.predecessor = null;
        }


        //== public methods ==
        public void AddNeighbor(Vertex vertex)
        {
            adjacencyList.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            edgeList.Add(edge);
        }

        public override string ToString()
        {
            return "(" + name + ")";
        }

    }
}
