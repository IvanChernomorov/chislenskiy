using System;
using System.Collections.Generic;
using System.Linq;


namespace Adams
{
    internal class Adams
    {

        //Добавить получения порядка точности
        public static List<double> xValuesH { get; private set; }
        public static List<double> yValuesH { get; private set; }
        public static List<double> xValuesH2 { get; private set; }
        public static List<double> yValuesH2 { get; private set; }
        public static List<double> xAccurateValues { get; private set; }
        public static List<double> yAccurateValues { get; private set; }

        public static void Solve(Func<double, double, double> f, Func<double, double> fAccurate,
            double x0, double y0, double xN, double h)
        {
            xValuesH = new List<double>();
            yValuesH = new List<double>();
            xValuesH2 = new List<double>();
            yValuesH2 = new List<double>();
            xValuesH.Add(x0);
            yValuesH.Add(y0);
            xValuesH2.Add(x0);
            yValuesH2.Add(y0);

            AccurateSolve(fAccurate, x0, xN, h/2);

            RungeKutta(f, xValuesH, yValuesH, h);
            Adams5(f, xValuesH, yValuesH, xN, h);

            RungeKutta(f, xValuesH2, yValuesH2, h/2);
            Adams5(f, xValuesH2, yValuesH2, xN, h/2);
        }

        private static void RungeKutta(Func<double, double, double> f,
            List<double> xValues, List<double> yValues, double h)
        {
            for (int i = 0; i < 4; i++)
            {
                double k1 = h * f(xValues[i], yValues[i]);
                double k2 = h * f(xValues[i] + h / 2, yValues[i] + k1 / 2);
                double k3 = h * f(xValues[i] + h / 2, yValues[i] + k2 / 2);
                double k4 = h * f(xValues[i] + h, yValues[i] + k3);
                xValues.Add(xValues[i] + h);
                yValues.Add(yValues[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6);
            }
        }

        private static void Adams5(Func<double, double, double> f,
            List<double> xValues, List<double> yValues, double xN, double h)
        {
            while (xValues[xValues.Count - 1] <= xN - h)
            {
                double xn = xValues[xValues.Count - 1];
                double yn = yValues[yValues.Count - 1];

                double f1 = f(xn, yn);
                double f2 = f(xn - h, yValues[yValues.Count - 2]);
                double f3 = f(xn - 2 * h, yValues[yValues.Count - 3]);
                double f4 = f(xn - 3 * h, yValues[yValues.Count - 4]);
                double f5 = f(xn - 4 * h, yValues[yValues.Count - 5]);

                double xNew = xn + h;
                double yNew = yn + (h / 720) * (1901 * f1 - 2774 * f2 + 2616 * f3 - 1274 * f4 + 251 * f5);
                xValues.Add(xNew);
                yValues.Add(yNew);

                //f1 = f(xNew, yNew);
                //f2 = f(xn, yn);
                //f3 = f(xn - h, yValues[yValues.Count - 2]);
                //f4 = f(xn - 2 * h, yValues[yValues.Count - 3]);
                //f5 = f(xn - 3 * h, yValues[yValues.Count - 4]);

                //xValues.Add(xNew);
                //yValues.Add(yn + (h / 720) * (251 * f1 + 646 * f2 - 264 * f3 + 106 * f4 - 19 * f5));
            }
        }

        private static void AccurateSolve(Func<double, double> fAccurate, double x0, double xN, double h)
        {
            yAccurateValues = new List<double>();
            xAccurateValues = new List<double>();
            for(double i = x0; i <= xN; i += h)
            {
                xAccurateValues.Add(i);
                yAccurateValues.Add(fAccurate(i));
            }
        }
    }
}
