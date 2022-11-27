using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Greedy
{
    public partial class Form1 : Form
    {
        private readonly Graph _graph = new();
        private int _counter;
        private VertexView _prevView;
        private Random _rand = new Random();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _counter++;
            Vertex vertex = new Vertex { Id = _counter };
            _graph.AddVertex(vertex);

            VertexView vertexView = new VertexView(e.X, e.Y, _counter);
            vertexView.Click += picturePoint_click;
            
            Controls.Add(vertexView);
            DrawId(vertexView);
        }
        
        private void Form1_Load(object sender, EventArgs e) {}
        
        private void Form1_Paint(object sender, PaintEventArgs e) {}

        void picturePoint_click(object sender, EventArgs e)
        {
            if (sender is not VertexView view)
            {
                return;
            }

            if (_prevView == null)
            {
                view.SetSelected(true);
                _prevView = view;
                return;
            }

            Vertex currVertex = _graph.FindVertex(view.Id);
            Vertex prevVertex = _graph.FindVertex(_prevView.Id);
            
            int randomWeight = _rand.Next(1, 100);
            _graph.AddEdge(currVertex, prevVertex, randomWeight);
            
            DrawEdge(view, _prevView, randomWeight, Color.Black);
            DrawId(view);
            DrawId(_prevView);
            
            _prevView.SetSelected(false);

            _prevView = null;
        }
        
        private void DrawId(VertexView view)
        {
            Graphics graphics = CreateGraphics();
            graphics.DrawString(
                view.Id.ToString(),
                new Font("Microsoft Sans Serif", 12),
                Brushes.Red,
                new Point((int)(view.X + view.Width / 1.2f), (int)(view.Y + view.Height / 1.2f))
            );
        }

        private void DrawEdge(VertexView vA, VertexView vB, int weight, Color color)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(color);
            int vAOffsetX = vA.Width / 2;
            int vAOffsetY = vA.Height / 2;
            int vBOffsetX = vB.Width / 2;
            int vBOffsetY = vB.Height / 2;

            g.DrawLine(p, vB.X + vBOffsetX, vB.Y + vBOffsetY, vA.X + vAOffsetX, vA.Y + vAOffsetY);

            if (weight != -1)
            {
                int xMid = Math.Abs((vB.X + 10) - (vA.X + 10)) / 2;
                int yMid = Math.Abs((vB.Y + 10) - (vA.Y + 10)) / 2;
                Point chosenPoint = new Point();
                if (vB.X > vA.X)
                    chosenPoint.X = vA.X + xMid - 5;
                else
                    chosenPoint.X = vB.X + xMid - 5;
                if (vB.Y > vA.Y)
                    chosenPoint.Y = vA.Y + yMid - 5;
                else
                    chosenPoint.Y = vB.Y + yMid - 5;
                g.DrawString(weight.ToString(), new Font("Arial", 8), new SolidBrush(Color.Blue), chosenPoint);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Vertex> resultPoints = null;
            if (int.TryParse(textBox1.Text, out int a) && int.TryParse(textBox2.Text, out int b))
            {
                resultPoints = _graph.FindPath(a, b);
            }
            else
            {
                MessageBox.Show("Wrong input, try again");
            }

            if (resultPoints != null)
            {
                if (resultPoints.Count > 1)
                {
                    for (int i = 0; i < resultPoints.Count - 1; i++)
                    {
                        Control[] controlsA = Controls.Find(resultPoints[i].Id.ToString(), false);
                        Control[] controlsB = Controls.Find(resultPoints[i + 1].Id.ToString(), false);
                        
                        DrawEdge((VertexView)controlsA[0], (VertexView)controlsB[0], -1, Color.Red);
                    }
                }
                else
                    MessageBox.Show("There is no path");
            }
        }
    }
}
