using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Graph
    {
        private List<GraphPoint> grahpPoints;
        private List<(GraphPoint, GraphPoint)> graphEdges;
        void AddPoint(GraphPoint p)
        {
            grahpPoints.Add(p);
        }
        void AddEdge(GraphPoint p1, GraphPoint p2)
        {
            graphEdges.Add((p1, p2));
        }

    }
}
