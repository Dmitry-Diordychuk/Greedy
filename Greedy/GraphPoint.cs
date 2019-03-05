using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class GraphPoint : System.Windows.Forms.PictureBox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int number { get; set; }
        public bool status { set; get; }
        //CurPoint
        public bool visitStatus;
        //
        public GraphPoint() { }

        public GraphPoint(int x, int y)
        {
            X = x;
            Y = y;
            status = false;
            visitStatus = false;
            number = -1;
            this.Location = new System.Drawing.Point(X, Y);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClientSize = new System.Drawing.Size(20, 20);
            this.Image = new System.Drawing.Bitmap(@"img\button.png");
        }
        public GraphPoint(int x, int y, int n) : this (x,y)
        {
            number = n;
        }
    }
}
