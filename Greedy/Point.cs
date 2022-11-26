using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class Point : System.Windows.Forms.PictureBox
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int number { get; set; }
        public bool status { set; get; }

        public bool visitStatus;

        protected Point() { }

        private Point(int x, int y)
        {
            X = x;
            Y = y;
            status = false;
            visitStatus = false;
            number = -1;
            Location = new System.Drawing.Point(X, Y);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ClientSize = new System.Drawing.Size(20, 20);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Image = new System.Drawing.Bitmap(@"img\point.png");
            Console.WriteLine(Image);
        }
        public Point(int x, int y, int n) : this (x,y)
        {
            number = n;
        }
    }
}
