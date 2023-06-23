using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Chisl4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.XAxis.Title.Text = "Ось x";
            graphPane.YAxis.Title.Text = $"Ось y";
            graphPane.Title.Text = "Графики решений";
            graphPane.CurveList.Clear();
            LineItem f1 = graphPane.AddCurve("Точное решение", Solution.xn,
                Solution.yn, Color.Blue, SymbolType.None);
            LineItem f2 = graphPane.AddCurve("Численное решение", Solution.xn,
                Solution.answer, Color.Green, SymbolType.None);
            f2.Line.Width = 2;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            for(int i = 0; i < Solution.xn.Length; i++)
            {
                dataGridView1.Rows.Add(Solution.xn[i], Solution.yn[i], Solution.answer[i]);
            }

        }
    }
}
