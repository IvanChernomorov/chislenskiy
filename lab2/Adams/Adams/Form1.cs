using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adams.Solve(
                (x, y) => (y*y-y)/x,
                x => 1/(1+x),
                1, 0.5, 22, 1);
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adams.Solve(
                (x, y) => (y - x * Math.Exp(y / x)) / x,
                x => -x * Math.Log(Math.Log(x)),
                Math.E, 0, 10 + Math.E, 1);
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adams.Solve(
                (x, y) => (3 * x * x - y) / (Math.Sqrt(x*x+1)),
                x => 2 * x * Math.Sqrt(x * x + 1) - x * x - 2,
                0, -2, 10, 2);
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
