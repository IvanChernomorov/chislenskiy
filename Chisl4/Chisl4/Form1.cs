using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chisl4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Solution.Solve(0, Math.PI/2,  x => 1, x => -1, x => 1 - Math.Sin(x), -1, 0, -1, 0, 10);
            Form2 form = new Form2();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Solution.Solve(0, 1, x => 2 * x, x => 1, x =>Math.Exp(x) - 2 * x + Math.Exp(1-x)/2, -1, 0, 1, -1, 10);
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Solution.Solve(0, Math.PI, x => 2 * x - Math.PI, x => -1, x => 2 * x + (Math.PI - 2) * Math.Cos(x) - Math.PI, -1, 0, 1, 0, 10);
            Form2 form = new Form2();
            form.Show();
        }
    }
}
