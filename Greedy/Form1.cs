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
        int i = 0;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            i++;
            GraphPoint vertex = new GraphPoint(e.X-10, e.Y - 10);
            MyGraph.AddVertex(vertex);

            vertex.Click += new System.EventHandler(this.picturePoint_click); // += add to event
            this.Controls.Add(vertex);

            DrawNumber(vertex);
        }

        private void DrawNumber(GraphPoint vertex)
        {
            Graphics g = Graphics.FromImage(vertex.Image);
            g.DrawString(vertex.number.ToString(), new Font("Microsoft Sans Serif", 30), Brushes.Black,
                new Point(80, 80));
        }

        void picturePoint_click(object sender, EventArgs e)
        {
            var pic = sender as GraphPoint;
            if (pic.status) //Unselect button
            {
                pic.Image = new Bitmap(@"img\button.png");
                pic.status = false;
                DrawNumber(pic);
            }
            else //Find out if another button was selected and is waiting for connection
            {
                GraphPoint buttonThatWasFinded = Graph.vertices.Find(x => x.status == true);
                if (buttonThatWasFinded != null) //if YES then make connection
                {
                    //Make edge
                    //Random weight
                    Random rand = new Random();
                    int weight = rand.Next(1, 100);
                    //Draw Edge and lable weight
                    DrawEdge(pic, buttonThatWasFinded, weight, Color.Black);
                    //set default status
                    buttonThatWasFinded.status = false;
                    pic.status = false;
                    buttonThatWasFinded.Image = new Bitmap(@"img\button.png");
                    //add edge in graph list
                    MyGraph.AddEdge(new GraphPoint(pic.Location.X, pic.Location.Y), new GraphPoint(buttonThatWasFinded.Location.X, buttonThatWasFinded.Location.Y), weight);
                    DrawNumber(pic);
                    DrawNumber(buttonThatWasFinded);
                }
                else //if NO then denote this button as selected 
                {
                    pic.status = true;
                    pic.Image = new Bitmap(@"img\buttonPressed.png");
                    DrawNumber(pic);
                }
            }
        }

        private void DrawEdge(GraphPoint PointA, GraphPoint PointB, int weight, Color color)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(color);
            g.DrawLine(p, PointB.Location.X + 10, PointB.Location.Y + 10, PointA.Location.X + 10, PointA.Location.Y + 10);
            //Label weight
            int xMid = Math.Abs((PointB.Location.X + 10) - (PointA.Location.X + 10)) / 2;
            int yMid = Math.Abs((PointB.Location.Y + 10) - (PointA.Location.Y + 10)) / 2;
            Point choosenPoint = new Point();
            if (PointB.Location.X > PointA.Location.X)
                choosenPoint.X = PointA.Location.X + xMid - 5;
            else
                choosenPoint.X = PointB.Location.X + xMid - 5;
            if (PointB.Location.Y > PointA.Location.Y)
                choosenPoint.Y = PointA.Location.Y + yMid - 5;
            else
                choosenPoint.Y = PointB.Location.Y + yMid - 5;
            g.DrawString(weight.ToString(), new Font("Arial", 8), new SolidBrush(Color.Blue), choosenPoint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<GraphPoint> resultPoints = MyGraph.FindPath(1, 7);
            //if (resultPoints.Count > 1)
            //{
            //    for (int i = 0; i < resultPoints.Count - 1; i++)
            //    {
            //        Graphics g = CreateGraphics();
            //        Pen p = new Pen(Brushes.Red);
            //        g.DrawLine(p, resultPoints[i].X + 10, resultPoints[i].Y + 10,
            //                    resultPoints[i + 1].X + 10, resultPoints[i + 1].Y + 10);
            //    }
            //}
            //else
            //    MessageBox.Show("No Way");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
