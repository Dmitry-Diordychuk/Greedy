using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Graph
    {
        static public List<GraphPoint> vertices { get; } = new List<GraphPoint>();
        static public List<(GraphPoint, GraphPoint, int)> graphEdges = new List<(GraphPoint, GraphPoint, int)>();



        class CurrentPoint
        {
            static List<GraphPoint> result = new List<GraphPoint>();
            static List<CurrentPoint> map = new List<CurrentPoint>(); 
            int numberOfThisPoint { get; set; }
            GraphPoint thisPoint;
            List<(GraphPoint, GraphPoint, int)> pathsFromCurrentPoint;
            List<GraphPoint> reachablePointsList;

            CurrentPoint(int p)
            {
                numberOfThisPoint = p;
                thisPoint = vertices[p+1];
                pathsFromCurrentPoint =
                      Graph.graphEdges.FindAll(x => x.Item1.GetHashCode() == Graph.vertices.GetHashCode());
                FindReacheblePointsList();
                map.Add(this);
            }
            private void FindReacheblePointsList()
            {
                for (int i = 0; i < pathsFromCurrentPoint.Count; i++)
                    if (pathsFromCurrentPoint[i].Item1 != thisPoint)
                        reachablePointsList.Add(pathsFromCurrentPoint[i].Item1);
                for (int i = 0; i < pathsFromCurrentPoint.Count; i++)
                    if (pathsFromCurrentPoint[i].Item2 != thisPoint)
                        reachablePointsList.Add(pathsFromCurrentPoint[i].Item2);
                reachablePointsList = reachablePointsList.Distinct().ToList();
            }

            private void DrawMap()
            {
                ;
            } 
            
        }


        public void AddVertex(GraphPoint p) => vertices.Add(p);
        public void AddEdge(GraphPoint p1, GraphPoint p2, int weight) => graphEdges.Add((p1, p2, weight));

    }
}
