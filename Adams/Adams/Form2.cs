using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Adams
{
    public partial class Form2 : Form
    {
        public Form2(int index)
        {
            InitializeComponent();
            double[] yH = new double[Adams.tValuesH.Count];
            double[] yH2 = new double[Adams.tValuesH2.Count];
            double[] yAccurate = new double[Adams.tValuesH2.Count];
            for (int i = 0; i < Adams.yValuesH2.Count; i++)
            {
                yAccurate[i] = Adams.yAccurateValues[i][index];
                yH2[i] = Adams.yValuesH2[i][index];
                if(i < Adams.yValuesH.Count)
                    yH[i] = Adams.yValuesH[i][index];
            }
                
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.XAxis.Title.Text = "Ось t";
            graphPane.YAxis.Title.Text = $"Ось y{index}";
            graphPane.Title.Text = "Графики решений";
            graphPane.CurveList.Clear();
            LineItem f1 = graphPane.AddCurve("Точное решение", Adams.tAccurateValues.ToArray(),
                yAccurate, Color.Blue, SymbolType.None);
            LineItem f2 = graphPane.AddCurve("Решение методом Адамса с шагом h", Adams.tValuesH.ToArray(),
                yH, Color.Green, SymbolType.None);
            LineItem f3 = graphPane.AddCurve("Решение методом Адамса с шагом h/2", Adams.tValuesH2.ToArray(),
                yH2, Color.Red, SymbolType.None);
             f3.Line.Width = 2;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
