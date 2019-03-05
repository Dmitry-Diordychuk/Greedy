using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class CurrentGraphPoint : GraphPoint
    {
        public List<(GraphPoint, GraphPoint, int)> pathsFromCurrentPoint { get; set; }
        //public List<GraphPoint> reachablePointsList { get; set; }

        public CurrentGraphPoint(int n)
        {
            GraphPoint currentVertex = Graph.vertices.Find(point => point.number == n);
            X = currentVertex.X;
            Y = currentVertex.Y;
            currentVertex.visitStatus = true;
            number = currentVertex.number;
            pathsFromCurrentPoint = Graph.graphEdges.FindAll(edge => edge.Item1.number == currentVertex.number || edge.Item2.number == currentVertex.number);
            //FindReacheblePointsList();

            //this.Location = new System.Drawing.Point(X, Y);
            //this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //this.ClientSize = new System.Drawing.Size(20, 20);
            //this.Image = new System.Drawing.Bitmap(@"img\button.png");
        }
        //private void FindReacheblePointsList()
        //{
        //    for (int i = 0; i < pathsFromCurrentPoint.Count; i++)
        //        if (pathsFromCurrentPoint[i].Item1 != this)
        //            reachablePointsList.Add(pathsFromCurrentPoint[i].Item1);
        //    for (int i = 0; i < pathsFromCurrentPoint.Count; i++)
        //        if (pathsFromCurrentPoint[i].Item2 != this)
        //            reachablePointsList.Add(pathsFromCurrentPoint[i].Item2);
        //    reachablePointsList = reachablePointsList.Distinct().ToList();
        //}


    }
}
