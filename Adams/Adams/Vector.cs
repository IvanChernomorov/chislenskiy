using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Adams
{
    internal class Vector
    {
        private double[] data;
        public int Length { get; set; }
        public Vector(int dim)
        {
            this.Length = dim;
            this.data = new double[dim];
        }

        public Vector(double[] data)
        {
            this.data = data;
            this.Length = data.Length; 
        }

        public double this[int index] 
        {
            get => data[index];
            set => data[index] = value;
        }

        public static Vector operator +(Vector v1, double number)
        {
            Vector v2 = new Vector(v1.Length);
            for(int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] + number;
            }
            return v2;
        }
        public static Vector operator *(Vector v1, double number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] * number;
            }
            return v2;
        }

        public static Vector operator - (Vector v1, double number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] - number;
            }
            return v2;
        }

        public static Vector operator /(Vector v1, double number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] / number;
            }
            return v2;
        }

        public static Vector operator +(Vector v1, int number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] + number;
            }
            return v2;
        }
        public static Vector operator *(Vector v1, int number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] * number;
            }
            return v2;
        }

        public static Vector operator -(Vector v1, int number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] - number;
            }
            return v2;
        }

        public static Vector operator /(Vector v1, int number)
        {
            Vector v2 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v2[i] = v1[i] / number;
            }
            return v2;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v3[i] = v1[i] + v2[i];
            }
            return v3;
        }
        public static Vector operator *(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v3[i] = v1[i] * v2[i];
            }
            return v3;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v3[i] = v1[i] - v2[i];
            }
            return v3;
        }

        public static Vector operator /(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.Length);
            for (int i = 0; i < v1.Length; i++)
            {
                v3[i] = v1[i] / v2[i];
            }
            return v3;
        }
    }
}
