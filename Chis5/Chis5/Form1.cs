using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Chis5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Solution.Solve(1, t => 0, t => 95, x => x*x-5, 50, 50, 1);
            saveEcxel();
            
        }

        private void saveEcxel()
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook workbook = exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)workbook.ActiveSheet;
            for (int i = 2; i < Solution.x.Length + 2; i++)
                wsh.Cells[1, i] = Solution.x[i - 2];
            for (int i = 2; i < Solution.t.Length + 2; i++)
                wsh.Cells[i, 1] = Solution.t[i - 2];
            for (int i = 0; i < Solution.u.GetLength(0); i++)
                for (int j = 0; j < Solution.u.GetLength(1); j++)
                    wsh.Cells[i + 2, j + 2] = Solution.u[i, j];

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookDefault,
                    Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            workbook.Close();
            exApp.Quit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Solution.Solve(8, t => 3, t => 0, x => 100-x, 50, 50, 1);
            saveEcxel();
        }
    }
}
