using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int mx = MousePosition.X-10;
            int my = MousePosition.Y-10;
            // Create a Point object that will be used as the location of the form.
            Point tempPoint = new Point(mx, my);
            // Set the location of the form using the Point object.
            this.DesktopLocation = tempPoint;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
