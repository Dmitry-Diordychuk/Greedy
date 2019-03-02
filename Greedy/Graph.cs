using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Graph
    {
        private List<GraphPoint> grahpPoints = new List<GraphPoint>();
        private List<(GraphPoint, GraphPoint)> graphEdges = new List<(GraphPoint, GraphPoint)>();
        public void AddPoint(GraphPoint p)
        {
            grahpPoints.Add(p);
        }
        public void AddEdge(GraphPoint p1, GraphPoint p2, int weight)
        {
            graphEdges.Add((p1, p2));
        }

    }
}
