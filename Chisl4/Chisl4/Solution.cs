using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chisl4
{
    internal class Solution
    {
        public static double[] xn;
        public static double[] answer;
        public static double[] yn;

        public static void Solve(double a, double b, Func<double, double> f, Func<double, double> p, Func<double, double> fAccurate, double alpha1, double alpha2, double beta1, double beta2, int N)
        {
            double[,] matrix = new double[N + 1, N + 1];
            double[] result = new double[N + 1];
            double h = (b - a) / N;
            xn = new double[N + 1];
            yn = new double[N + 1];

            xn[0] = a;
            yn[0] = fAccurate(a);
            result[0] = 2 * h * alpha2 + h * h * f(a+h);
            matrix[0, 0] = -2 - 2 * h * alpha1;
            matrix[0, 1] = 2 - h * h * p(a + h);
            for (int i = 1; i < N; i++)
            {
                xn[i] = a + h * i;
                yn[i] = fAccurate(xn[i]);
                matrix[i, i-1] = 1;
                matrix[i, i] = -2 - h * h * p(xn[i]);
                matrix[i, i+1] = 1;
                result[i] = h * h * f(xn[i]);
            }
            xn[N] = b;
            yn[N] = fAccurate(xn[N]);
            result[N] = 2 * h * beta2 - h * h * f(xn[N-1]);
            matrix[N, N - 1] = h * h * p(xn[N - 1]) - 2;
            matrix[N, N] = 2 - 2 * h * beta1;

            answer = Progonka(matrix, result);
        }

        public static double[] Progonka(double[,] matrix, double[] result)
        {
            int N = result.Length;
            double[] answer = new double[N];
            double[] v = new double[N];
            double[] u = new double[N];

            v[0] = matrix[0, 1] / -matrix[0, 0];
            u[0] = -result[0] / -matrix[0, 0];
            for (int i = 1; i < N - 1; i++)
            {
                v[i] = matrix[i, i + 1] / (-matrix[i, i] - matrix[i, i - 1] * v[i - 1]);
                u[i] = (matrix[i, i - 1] * u[i - 1] - result[i]) / (-matrix[i, i] - matrix[i, i-1] * v[i - 1]);
            }
            v[N - 1] = 0;
            u[N - 1] = (matrix[N - 1, N - 2] * u[N - 2] - result[N - 1]) / (-matrix[N - 1, N - 1] - matrix[N - 1, N - 2] * v[N-2]);
            
            answer[N - 1] = u[N - 1];
            for(int i = N - 2; i>= 0; i--)
                answer[i] = v[i] * answer[i+1] + u[i];

            return answer;
        }
    }
}
