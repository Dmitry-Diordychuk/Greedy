using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class MyPictureBox : System.Windows.Forms.PictureBox
    {
        private bool status;
        public bool GetStatus
        {
            get { return status; }
        }
        public bool SetStatus
        {
            set { status = value; }
        }
        
    }
}
