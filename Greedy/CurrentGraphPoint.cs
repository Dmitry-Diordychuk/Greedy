using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class CurrentGraphPoint : GraphPoint
    {
        private static int curY { get; set; }
        private static int curX { get; set; }
        public List<(GraphPoint, GraphPoint, int)> pathsFromCurrentPoint { get; set; }
        public List<GraphPoint> reachablePointsList { get; set; }

        public CurrentGraphPoint(int x, int y) : base(x, y)
        {
        }

        public CurrentGraphPoint(int n) : base (curX,curY)
        {
            curX = Graph.vertices[n + 1].X;
            curY = Graph.vertices[n + 1].Y;
            visitStatus = true;
            number = n;
            pathsFromCurrentPoint = Graph.graphEdges.FindAll(x => x.Item1.number == this.number && x.Item2.number == this.number);
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
