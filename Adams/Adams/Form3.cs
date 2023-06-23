using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using ZedGraph;
using System.Linq;

namespace Adams
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            for(int i = 0; i < Adams.yValuesH[0].Length; i++)
            {
                dataGridView1.Columns.Add($"column{i}0", $"y{i+1} методом Адамса");
                dataGridView1.Columns.Add($"column{i}1", $"y{i+1} точное решение");
            }

            dataGridView1.Rows.Add("Решение", "с шагом", "h:");
            int th = Adams.tValuesH.Count;
            for (int i = 0; i < th; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i + 1].Value = Adams.tValuesH[i];
                for (int j = 0; j < Adams.yValuesH[0].Length; j++)
                {
                        dataGridView1[2*j+1, i + 1].Value = Adams.yValuesH[i][j];
                        dataGridView1[2*j+2, i + 1].Value = Adams.yAccurateValues[2*i][j];
                }
            }
            dataGridView1.Rows.Add("Решение", "с шагом", "h/2:");
            for (int i = th; i < th + Adams.tValuesH2.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i + 2].Value = Adams.tValuesH2[i - th];
                for (int j = 0; j < Adams.yValuesH[0].Length; j++)
                {
                    dataGridView1[2 * j + 1, i + 2].Value = Adams.yValuesH2[i - th][j];
                    dataGridView1[2 * j + 2, i + 2].Value = Adams.yAccurateValues[i - th][j];
                }
            }

            label2.Text = "";
            label3.Text = "";
            label6.Text = "";
            for (int i = 0; i < Adams.yValuesH[0].Length; i++)
            {
                label2.Text += Math.Round(Adams.differenceH[i], 6).ToString() + "   ";
                label3.Text += Math.Round(Adams.differenceH2[i], 6).ToString() + "   ";
                label6.Text += Math.Round(Adams.differenceH[i] / Adams.differenceH2[i], 3) + "   ";
            }
            

        }

    }
}
