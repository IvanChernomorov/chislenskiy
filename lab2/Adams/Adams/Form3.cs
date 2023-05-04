using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using ZedGraph;

namespace Adams
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            dataGridView1.Rows.Add("Решение", "с шагом", "h:");
            for (int i = 0; i < Adams.xValuesH.Count; i++)
            {
                dataGridView1.Rows.Add(Adams.xValuesH[i], Adams.yValuesH[i], Adams.yAccurateValues[i * 2]);
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add("Решение", "с шагом", "h/2:");
            for (int i = 0; i < Adams.xValuesH2.Count; i++)
            {
                dataGridView1.Rows.Add(Adams.xValuesH2[i], Adams.yValuesH2[i], Adams.yAccurateValues[i]);
            }

            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.XAxis.Title.Text = "Ось X";
            graphPane.YAxis.Title.Text = "Ось Y";
            graphPane.Title.Text = "Графики решений";
            graphPane.CurveList.Clear();
            LineItem f1 = graphPane.AddCurve("Точное решение", Adams.xAccurateValues.ToArray(), 
                Adams.yAccurateValues.ToArray(), Color.Blue, SymbolType.None);
            LineItem f2 = graphPane.AddCurve("Решение методом Адамса с шагом h", Adams.xValuesH.ToArray(),
                Adams.yValuesH.ToArray(), Color.Green, SymbolType.None);
            LineItem f3 = graphPane.AddCurve("Решение методом Адамса с шагом h/2", Adams.xValuesH2.ToArray(),
                Adams.yValuesH2.ToArray(), Color.Red, SymbolType.None);
            f1.Line.Width = f2.Line.Width = f3.Line.Width = 1;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
