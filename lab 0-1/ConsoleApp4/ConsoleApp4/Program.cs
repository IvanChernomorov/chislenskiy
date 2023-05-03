using System;
using System.IO;
using System.Linq;
using System.Text;


namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix;
            double[] vector_y, vector_x, curRatios, prevRatios;
            var f = new FileStream("D:/matrix.txt", FileMode.OpenOrCreate);
            byte[] buffer = new byte[f.Length];

            f.Read(buffer, 0, buffer.Length);
            string text = Encoding.Default.GetString(buffer);
            f.Close();
            string[] lines = text.Split('\n');

            double epsilon = double.Parse(lines[0].Split()[0]);
            double delta = double.Parse(lines[0].Split()[1]);
            int dim = int.Parse(lines[1]);

            matrix = new double[dim, dim];
            for(int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                    matrix[i, j] = double.Parse(lines[i+2].Split(' ')[j]);

           // matrix = InverseMatrix(matrix);

            vector_y = new double[matrix.GetLength(0)];
            prevRatios = new double[matrix.GetLength(0)];
            curRatios = new double[matrix.GetLength(0)];
            Random rnd = new Random();

            for(int i = 0; i < vector_y.Length; i++)
            {
                vector_y[i] = rnd.NextDouble();
                prevRatios[i] = rnd.NextDouble();
            }
            while (vector_y[0] == 0)
                vector_y[0] = rnd.NextDouble();


            double sum, maxDiff;
            int count, k = 0;
            do
            {
                k++;
                sum = 0;
                count = 0;
                maxDiff = 0;

                vector_x = GetNormalizeVector(vector_y);
                vector_y = MatrixMultiply(matrix, vector_x);
                for (int i = 0; i < vector_y.Length; i++)
                {
                    if (Math.Abs(vector_x[i]) > delta)
                    {
                        curRatios[i] = vector_y[i] / vector_x[i];
                        sum += curRatios[i];
                        count++;
                        double diff = Math.Abs(curRatios[i] - prevRatios[i]);
                        if (diff > maxDiff)
                            maxDiff = diff;
                    }
                }
                prevRatios = new double[curRatios.Length];
                curRatios.CopyTo(prevRatios, 0);
            } while (maxDiff > epsilon);

            Console.WriteLine(sum/count);

            vector_y = GetNormalizeVector(vector_y);

            for (int i = 0; i < dim; i++)
                Console.Write(vector_y[i] + " ");
            Console.ReadKey();
        }

        static double[] GetNormalizeVector(double[] vector)
        {
            double norm = vector.Max(x => Math.Abs(x));
            double[] result = new double[vector.Length];
            vector.CopyTo(result, 0);
            for (int i = 0; i < result.Length; i++)
                result[i] /= norm;
            return result;
        }

        static double[] MatrixMultiply(double[,] matrix, double[] vector)
        {
            double[] result = new double[vector.Length];
            for(int i = 0; i < matrix.GetLength(0); i++)
                for(int j = 0; j < matrix.GetLength(1); j++)
                    result[i] += matrix[i, j] * vector[j];
            return result;
        }

        static double[,] InverseMatrix(double[,] matrix)
        {
            double det = GetDeterminant(matrix);
            if(det == 0)
            {
                Console.WriteLine("Матрица вырожденная!");
                Environment.Exit(0);
            }
            double[,] co_matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    co_matrix[i, j] = GetDeterminant(GetMinor(matrix, i, j)) * Math.Pow(-1, i+j);
            for(int i = 0; i < co_matrix.GetLength(0); i++)
                for(int j = 0; j <= i; j++)
                {
                    double temp = co_matrix[i, j];
                    co_matrix[i, j] = co_matrix[j, i] / det;
                    co_matrix[j, i] = temp / det;
                }
            return co_matrix;
        }

        static double GetDeterminant(double[,] matrix)
        {

            if (matrix.Length == 1)
            {
                return matrix[0, 0];
            }

            double det = 0;

            for (int j = 0; j < matrix.GetLength(0); j++)
                    det += Math.Pow(-1, j) * matrix[0, j] * GetDeterminant(GetMinor(matrix, 0, j));

            return det;
        }

        static double[,] GetMinor(double[,] matrix, int x, int y)
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if ((i != x) && (j != y))
                        result[i > x ? i - 1 : i, j > y ? j - 1 : j] = matrix[i, j];
            return result;
        }
    }
}
