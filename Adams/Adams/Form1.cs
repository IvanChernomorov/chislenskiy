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
                (double t, Vector y) => 
                {
                    Vector f = new Vector(2);
                    f[0] = y[1] * y[1] - 2 * t * y[1] - 2 * y[1] - y[0];
                    f[1] = 2 * y[0] + 2 * t * t + Math.Exp(2 * t - 2 * y[1]);
                    return f;
                },
                t => 
                {
                    Vector y = new Vector(2);
                    y[0] = -(t*t);
                    y[1] = t;
                    return y;
                },
                0, new Vector(new[] { 0.0, 0.0}), 5, 0.25);
            Form3 form3 = new Form3();
            form3.Show();
            for (int i = 0; i < Adams.yValuesH[0].Length; i++)
            {
                Form form2 = new Form2(i);
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adams.Solve(
                (double t, Vector y) =>
                {
                    Vector f = new Vector(2);
                    f[0] = Math.Log(y[0] + 2 * Math.Pow(Math.Sin(t / 2), 2)) - y[1] / 2;
                    f[1] = (4 - y[0] * y[0]) * Math.Cos(t) - 2 * y[0] * Math.Pow(Math.Sin(t), 2) - Math.Pow(Math.Cos(t), 3);
                    return f;
                },
                t =>
                {
                    Vector y = new Vector(2);
                    y[0] = Math.Cos(t);
                    y[1] = 2 * Math.Sin(t);
                    return y;
                },
                0, new Vector(new[] { 1.0, 0.0 }), 5, 0.5);
            Form3 form3 = new Form3();
            form3.Show();
            for (int i = 0; i < Adams.yValuesH[0].Length; i++)
            {
                Form form2 = new Form2(i);
                form2.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adams.Solve(
               (double t, Vector y) =>
               {
                   Vector f = new Vector(3);
                   f[0] = 2 * y[0] - y[1] - y[2];
                   f[1] = 3 * y[0] - 2 * y[1] - 3 * y[2];
                   f[2] = -y[0] + y[1] + 2 * y[2];
                   return f;
               },
               t =>
               {
                   Vector y = new Vector(3);
                   y[0] = 2 * Math.Exp(t);
                   y[1] = Math.Exp(t);
                   y[2] = Math.Exp(t);
                   return y;
               },
               0, new Vector(new double[] { 2, 1, 1 }), 5, 0.25);
            Form3 form3 = new Form3();
            form3.Show();
            for (int i = 0; i < Adams.yValuesH[0].Length; i++)
            {
                Form form2 = new Form2(i);
                form2.Show();
            }
           
        }
    }
}
