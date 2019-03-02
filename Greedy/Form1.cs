using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greedy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graph MyGraph = new Graph();
        List<MyPictureBox> vertices = new List<MyPictureBox>();
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //if(e.Button = Button)
            MyPictureBox vertex = new MyPictureBox();
            vertex.Location = new Point(e.X - 10, e.Y - 10);
            int x = vertex.Location.X;
            int y = vertex.Location.Y;
            GraphPoint gp = new GraphPoint(x, y);
            MyGraph.AddPoint(gp);
            vertex.SizeMode = PictureBoxSizeMode.StretchImage;
            vertex.ClientSize = new Size(20, 20);
            vertex.Image = new Bitmap(@"img\button.png");
            
            vertex.Click += new System.EventHandler(this.picturePoint_click); // += прекрипить к событию
            this.Controls.Add(vertex);
            vertices.Add(vertex);
        }
        void picturePoint_click(object sender, EventArgs e)
        {
            var pic = sender as MyPictureBox;
            if (pic.GetStatus)
            {
                pic.Image = new Bitmap(@"img\button.png");
                pic.SetStatus = false;
            }
            else
            {
                MyPictureBox pb = vertices.Find(x => x.GetStatus == true);
                if (pb != null)
                {
                    //Make edge
                    //
                    Random rand = new Random();
                    int weight = rand.Next(1, 100);
                    Graphics g = CreateGraphics();
                    Pen p = new Pen(Brushes.Black);
                    g.DrawLine(p,pb.Location.X+10, pb.Location.Y+10, pic.Location.X+10, pic.Location.Y+10);
                    int xMid = Math.Abs((pb.Location.X + 10) - (pic.Location.X + 10)) / 2;
                    int yMid = Math.Abs((pb.Location.Y + 10) - (pic.Location.Y + 10)) / 2;
                    Point choosenPoint = new Point();
                    if (pb.Location.X > pic.Location.X)
                        choosenPoint.X = pic.Location.X + xMid - 5;
                    else
                        choosenPoint.X = pb.Location.X + xMid - 5;
                    if (pb.Location.Y > pic.Location.Y)
                        choosenPoint.Y = pic.Location.Y + yMid - 5;
                    else
                        choosenPoint.Y = pb.Location.Y + yMid - 5;
                    g.DrawString(weight.ToString(), new Font("Arial", 8), new SolidBrush(Color.Blue),choosenPoint);
                    pb.SetStatus = false;
                    pic.SetStatus = false;
                    pb.Image = new Bitmap(@"img\button.png");
                    MyGraph.AddEdge(new GraphPoint(pic.Location.X, pic.Location.Y), new GraphPoint(pb.Location.X, pb.Location.Y),weight);
                }
                else
                {
                    pic.SetStatus = true;
                    pic.Image = new Bitmap(@"img\buttonPressed.png");
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
