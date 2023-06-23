using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chis5
{
    internal class Solution
    {
        public static double[,] u;
        public static double[] x;
        public static double[] t;
        public static void Solve(double alpha, Func<double, double> phi1, Func<double, double> phi2, Func<double, double> u0, int N, int M, double T)
        {
            x = new double[M + 1];
            double xStep = 100.0 / M;
            for (int i = 0; i <= M; i++)
                x[i] = i * xStep;

            t = new double[N + 1];
            double tStep = T / N;
            for (int i = 0; i <= N; i++)
                t[i] = i * tStep;

            u = new double[N + 1, M + 1];
            for (int i = 0; i <= M; i++)
                u[0, i] = u0(x[i]);

            for (int i = 0; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    u[i+1, j] = u[i, j] + tStep * alpha / (xStep * xStep) * (u[i, j - 1] - 2 * u[i, j] + u[i, j + 1]);
                }
                u[i+1, 0] = u[i+1, 1] -xStep * phi1(t[i+1]);
                u[i+1, M] = phi2(t[i+1]);
            }

        }
    }
}
