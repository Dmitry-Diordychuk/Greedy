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
        static public List<(GraphPoint, GraphPoint, int)> graphEdges { get; } = new List<(GraphPoint, GraphPoint, int)>();
        //Methods
        public void AddVertex(GraphPoint p) => vertices.Add(p);
        public void AddEdge(GraphPoint p1, GraphPoint p2, int weight) => graphEdges.Add((p1, p2, weight));
        //Algorithm
        public List<GraphPoint> FindPath(int a, int b)
        {
            List<GraphPoint> result = new List<GraphPoint>();
            CurrentGraphPoint curPoint = new CurrentGraphPoint(a);
            int nextPointNumberLeft, nextPointNumberRight;
            while (curPoint.number != b)
            {
                result.Add(curPoint);
                nextPointNumberLeft = curPoint.pathsFromCurrentPoint.OrderByDescending(edge => edge.Item3).FirstOrDefault(edge => edge.Item1.visitStatus == false || edge.Item2.visitStatus == false).Item1.number;
                nextPointNumberRight = curPoint.pathsFromCurrentPoint.OrderByDescending(edge => edge.Item3).FirstOrDefault(edge => edge.Item1.visitStatus == false || edge.Item2.visitStatus == false).Item2.number;
                if (curPoint.number == nextPointNumberLeft)
                    curPoint = new CurrentGraphPoint(nextPointNumberLeft);
                else if (curPoint.number == nextPointNumberRight)
                    curPoint = new CurrentGraphPoint(nextPointNumberRight);
                else if (nextPointNumberLeft == 0 && nextPointNumberRight == 0)
                    break;
            }
            return result;
        } 
        
    }
}
