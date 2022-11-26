using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Graph
    {
        public static List<Point> Vertices { get; } = new();
        public static List<(Point, Point, int)> graphEdges { get; } = new();

        public void AddVertex(Point p) => Vertices.Add(p);
        public void AddEdge(Point p1, Point p2, int weight) => graphEdges.Add((p1, p2, weight));

        public List<Point> FindPath(int a, int b)
        {

            List<Point> result = new List<Point>();
            CurrentPoint currentPoint = new CurrentPoint(a);
            int nextPointNumberLeft = -1, nextPointNumberRight = -1;
            
            while (true)
            {
                result.Add(currentPoint);
                if (currentPoint.number != b)
                {
                    try
                    {
                        nextPointNumberLeft = currentPoint.pathsFromCurrentPoint
                                                        .OrderByDescending(edge => edge.Item3)
                                                        .FirstOrDefault(edge => edge.Item1.visitStatus == false 
                                                                                        || edge.Item2.visitStatus == false)
                                                        .Item1.number;
                    }
                    catch 
                    {
                        nextPointNumberLeft = 0;
                    }
                    try
                    {
                        nextPointNumberRight = currentPoint.pathsFromCurrentPoint
                                                        .OrderByDescending(edge => edge.Item3)
                                                        .FirstOrDefault(edge => edge.Item1.visitStatus == false 
                                                                                        || edge.Item2.visitStatus == false)
                                                        .Item2.number;
                    }
                    catch
                    {
                        nextPointNumberRight = 0;
                    }
                }
                if (currentPoint.number == b)
                {
                    result.Add(currentPoint);
                    break;
                }
                if (currentPoint.number == nextPointNumberLeft)
                    currentPoint = new CurrentPoint(nextPointNumberRight);
                else if (currentPoint.number == nextPointNumberRight)
                    currentPoint = new CurrentPoint(nextPointNumberLeft);
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
