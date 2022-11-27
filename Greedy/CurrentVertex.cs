using System.Collections.Generic;

namespace Greedy
{
    class CurrentVertex : Vertex
    {
        public List<(Vertex, Vertex, int)> pathsFromCurrentPoint { get; set; }

        public CurrentVertex(int n)
        {
            Vertex currentVertex = Graph.Vertices.Find(point => point.Id == n);
            currentVertex.VisitStatus = true;
            Id = currentVertex.Id;
            pathsFromCurrentPoint = Graph.graphEdges
                .FindAll(edge => edge.Item1.Id == currentVertex.Id
                                         || edge.Item2.Id == currentVertex.Id);
        }
    }
}
