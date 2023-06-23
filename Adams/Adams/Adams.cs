using System;
using System.Collections.Generic;
using System.Linq;


namespace Adams
{
    internal class Adams
    {
        public static List<double> tValuesH { get; private set; }
        public static List<Vector> yValuesH { get; private set; }
        public static List<double> tValuesH2 { get; private set; }
        public static List<Vector> yValuesH2 { get; private set; }
        public static List<double> tAccurateValues { get; private set; }
        public static List<Vector> yAccurateValues { get; private set; }
        public static double[] differenceH { get; private set; }
        public static double[] differenceH2 { get; private set; }

        public static void Solve(Func<double, Vector, Vector> f, Func<double, Vector> fAccurate,
            double t0, Vector y0, double tN, double h)
        {
            tValuesH = new List<double>();
            yValuesH = new List<Vector>();
            tValuesH2 = new List<double>();
            yValuesH2 = new List<Vector>();
            tValuesH.Add(t0);
            yValuesH.Add(y0);
            tValuesH2.Add(t0);
            yValuesH2.Add(y0);

            AccurateSolve(fAccurate, t0, tN, h / 2);

            RungeKutta(f, tValuesH, yValuesH, h);
            Adams5(f, tValuesH, yValuesH, tN, h);

            RungeKutta(f, tValuesH2, yValuesH2, h / 2);
            Adams5(f, tValuesH2, yValuesH2, tN, h / 2);

            differenceH = new double[yValuesH[0].Length];
            differenceH2 = new double[yValuesH[0].Length];

            for (int i = 5; i < yValuesH.Count; i++)
                for(int j = 0; j < yValuesH[i].Length; j++)
                    if (Math.Abs(yValuesH[i][j] - yAccurateValues[i * 2][j]) > differenceH[j])
                        differenceH[j] = Math.Abs(yValuesH[i][j] - yAccurateValues[i * 2][j]);

            for (int i = 5; i < yValuesH2.Count; i++)
                for (int j = 0; j < yValuesH2[i].Length; j++)
                    if (Math.Abs(yValuesH2[i][j] - yAccurateValues[i][j]) > differenceH2[j])
                        differenceH2[j] = Math.Abs(yValuesH2[i][j] - yAccurateValues[i][j]);
        }

        private static void RungeKutta(Func<double, Vector, Vector> f,
            List<double> tValues, List<Vector> yValues, double h)
        {
            for (int i = 0; i < 4; i++)
            {
               Vector k1 = f(tValues[i], yValues[i]);
               Vector k2 = f(tValues[i] + h / 2, yValues[i] + (k1 * (h / 2)));
               Vector k3 = f(tValues[i] + h / 2, yValues[i] + (k2 * (h / 2)));
               Vector k4 = f(tValues[i] + h, yValues[i] + (k3 * h));
               yValues.Add(yValues[i] + (k1 + (k2 * 2) + (k3 * 2) + k4) * (h / 6));
               tValues.Add(tValues[i] + h);
            }
        }

        private static void Adams5(Func<double, Vector, Vector> f,
            List<double> tValues, List<Vector> yValues, double tN, double h)
        {
            while (tValues[tValues.Count - 1] <= tN - h)
            {
                double tn = tValues[tValues.Count - 1];
                Vector yn = yValues[yValues.Count - 1];

                Vector f1 = f(tn, yn);
                Vector f2 = f(tn - h, yValues[yValues.Count - 2]);
                Vector f3 = f(tn - 2 * h, yValues[yValues.Count - 3]);
                Vector f4 = f(tn - 3 * h, yValues[yValues.Count - 4]);
                Vector f5 = f(tn - 4 * h, yValues[yValues.Count - 5]);

                Vector yNew = yn + (f1 * 1901 -  f2 * 2774 + f3 * 2616 - f4 * 1274 + f5 * 251) * (h / 720);
                tValues.Add(tn + h);
                yValues.Add(yNew);

                for(int i = 0; i < yNew.Length; i++)
                {
                    double yA = yAccurateValues[0][1];
                }
            }
        }

        private static void AccurateSolve(Func<double, Vector> fAccurate, double t0, double tN, double h)
        {
            yAccurateValues = new List<Vector>();
            tAccurateValues = new List<double>();
            for(double i = t0; i <= tN; i += h)
            {
                tAccurateValues.Add(i);
                yAccurateValues.Add(fAccurate(i));
            }
        }
    }
}
