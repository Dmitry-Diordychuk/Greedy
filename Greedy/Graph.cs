using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Graph
    {
        public static List<Vertex> Vertices { get; } = new();
        public static List<(Vertex, Vertex, int)> graphEdges { get; } = new();

        public void AddVertex(Vertex vertex) => Vertices.Add(vertex);

        public Vertex FindVertex(int id) => Vertices.Find(v => v.Id == id);
        
        public void AddEdge(Vertex p1, Vertex p2, int weight) => graphEdges.Add((p1, p2, weight));

        public List<Vertex> FindPath(int a, int b)
        {

            List<Vertex> result = new List<Vertex>();
            CurrentVertex currentVertex = new CurrentVertex(a);
            int nextPointNumberLeft = -1, nextPointNumberRight = -1;

            while (true)
            {
                result.Add(currentVertex);
                if (currentVertex.Id != b)
                {
                    try
                    {
                        nextPointNumberLeft = currentVertex.pathsFromCurrentPoint
                                                        .OrderByDescending(edge => edge.Item3)
                                                        .FirstOrDefault(edge => edge.Item1.VisitStatus == false 
                                                                                        || edge.Item2.VisitStatus == false)
                                                        .Item1.Id;
                    }
                    catch 
                    {
                        nextPointNumberLeft = 0;
                    }
                    try
                    {
                        nextPointNumberRight = currentVertex.pathsFromCurrentPoint
                                                        .OrderByDescending(edge => edge.Item3)
                                                        .FirstOrDefault(edge => edge.Item1.VisitStatus == false 
                                                                                        || edge.Item2.VisitStatus == false)
                                                        .Item2.Id;
                    }
                    catch
                    {
                        nextPointNumberRight = 0;
                    }
                }
                if (currentVertex.Id == b)
                {
                    result.Add(currentVertex);
                    break;
                }
                if (currentVertex.Id == nextPointNumberLeft)
                    currentVertex = new CurrentVertex(nextPointNumberRight);
                else if (currentVertex.Id == nextPointNumberRight)
                    currentVertex = new CurrentVertex(nextPointNumberLeft);
                else if (nextPointNumberLeft == 0 && nextPointNumberRight == 0)
                {
                    result.Clear();
                    break;
                }   
                   
            }
            return result;
        } 
        
    }
}
