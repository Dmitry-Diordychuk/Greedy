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
        private readonly Graph _graph = new();
        private int _counter;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _counter++;
            Point vertex = new Point(e.X-10, e.Y - 10,_counter);
            _graph.AddVertex(vertex);

            vertex.Click += picturePoint_click;
            Controls.Add(vertex);

            DrawNumber(vertex);
        }

        private void DrawNumber(Point vertex)
        {
            Graphics g = Graphics.FromImage(vertex.Image);
            g.DrawString(vertex.number.ToString(), new Font("Microsoft Sans Serif", 30), Brushes.Black,
                new System.Drawing.Point(80, 80));
        }

        void picturePoint_click(object sender, EventArgs e)
        {
            var picture = sender as Point;
            if (picture is { status: true }) //Unselect button
            {
                picture.Image = new Bitmap(@"img\point.png");
                picture.status = false;
                DrawNumber(picture);
            }
            else //Find out if another button was selected and is waiting for connection
            {
                Point buttonThatWasFinded = Graph.Vertices.Find(x => x.status == true);
                if (buttonThatWasFinded != null) //if YES then make connection
                {
                    //Make edge
                    //Random weight
                    Random rand = new Random();
                    int weight = rand.Next(1, 100);
                    //Draw Edge and lable weight
                    DrawEdge(picture, buttonThatWasFinded, weight, Color.Black);
                    //set default status
                    buttonThatWasFinded.status = false;
                    picture.status = false;
                    buttonThatWasFinded.Image = new Bitmap(@"img\point.png");
                    //add edge in graph list
                    
                    _graph.AddEdge(picture, buttonThatWasFinded, weight);
                    DrawNumber(picture);
                    DrawNumber(buttonThatWasFinded);
                }
                else //if NO then denote this button as selected 
                {
                    picture.status = true;
                    picture.Image = new Bitmap(@"img\pointSelected.png");
                    DrawNumber(picture);
                }
            }
        }

        private void DrawEdge(Point PointA, Point PointB, int weight, Color color)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(color);
            g.DrawLine(p, PointB.X + 10, PointB.Y + 10, PointA.X + 10, PointA.Y + 10);
            //Label weight
            if (weight != -1)
            {
                int xMid = Math.Abs((PointB.X + 10) - (PointA.X + 10)) / 2;
                int yMid = Math.Abs((PointB.Y + 10) - (PointA.Y + 10)) / 2;
                System.Drawing.Point choosenPoint = new System.Drawing.Point();
                if (PointB.X > PointA.X)
                    choosenPoint.X = PointA.X + xMid - 5;
                else
                    choosenPoint.X = PointB.X + xMid - 5;
                if (PointB.Y > PointA.Y)
                    choosenPoint.Y = PointA.Y + yMid - 5;
                else
                    choosenPoint.Y = PointB.Y + yMid - 5;
                g.DrawString(weight.ToString(), new Font("Arial", 8), new SolidBrush(Color.Blue), choosenPoint);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a=0, b=0;
            List<Point> resultPoints = null;
            if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
                resultPoints = _graph.FindPath(a, b);
            else
                MessageBox.Show("Wrong input, try again");

            if (resultPoints != null)
            {
                if (resultPoints.Count > 1)
                {
                    for (int i = 0; i < resultPoints.Count - 1; i++)
                    {
                        DrawEdge(resultPoints[i], resultPoints[i + 1], -1, Color.Red);
                    }
                }
                else
                    MessageBox.Show("There is no path");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
