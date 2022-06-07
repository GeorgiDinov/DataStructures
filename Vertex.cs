using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Vertex
    {

        private string name;

        private bool isVisited;
        public bool IsVisited { get => isVisited; set => isVisited = value; }

        private List<Vertex> adjacencyList;
        public List<Vertex> AdjacencyList { get => adjacencyList; }

        public Vertex(string name)
        {
            this.name = name;
            this.isVisited = false;
            adjacencyList = new List<Vertex>();
        }


        public void AddNeighbor(Vertex vertex)
        {
            adjacencyList.Add(vertex);  
        }



        public override string ToString()
        {
            return name;
        }

    }
}
