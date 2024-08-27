using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _001_Euclid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            int gcd = Euclid(x, y);
            label2.Text = "GCD = " + gcd;
        }

        private int Euclid(int x, int y)
        {
            if (y == 0)
                return x;
            else
                return Euclid(y, x % y);
        }
    }
}
