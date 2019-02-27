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
        List<PictureBox> vertices = new List<PictureBox>();
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //if(e.Button = Button)
            PictureBox vertex = new PictureBox();
            vertex.Location = new Point(e.X-10,e.Y-10);
            vertex.SizeMode = PictureBoxSizeMode.StretchImage;
            vertex.ClientSize = new Size(20, 20);
            vertex.Image = new Bitmap(@"img\button.png");
            this.Controls.Add(vertex);
            vertices.Add(vertex);
        }
        void picturePoint_click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            pic.Image = new Bitmap(@"img\buttonPressed.png");
        }
    }
}
