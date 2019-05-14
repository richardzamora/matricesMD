using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices.Servicios
{
    class ServiciosMatriz
    {
        public static int multiplicacionClasica(int[] fila, int[] columna)
        {
            int zelda = 0;

            for (int i = 0; i < fila.Length; i++)
            {
                zelda += fila[i] * columna[i];
            }

            return zelda;
        }
    }

    public sealed class Matriz
    {
        #region Private variables y 
        public int Rows
        {
            get
            {
                return values.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return values.GetLength(1);
            }
        }

        private double[,] values;

        public double this[int row, int col]
        {
            get
            {
                return values[row, col];
            }
            set
            {
                values[row, col] = value;
            }
        }

        //
        public double[,] getValues()
        {
            return values;
        }

        public void setValues(double[,] pValues)
        {
            this.values = pValues;
        }

        #endregion

        #region Constructor
        public Matriz(int m, int n)
        {
            if (m <= 0)
            {
                throw new ArgumentOutOfRangeException("m es menor o igual a cero");
            }
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("n es menor o igual a cero");
            }

            values = new double[m, n];
        }
        public Matriz(int m) : this(m, m) { }

        public Matriz(double[,] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values == null.");
            }
            this.values = values;
        }
        #endregion

        #region methods
        public override bool Equals(object obj)
        {
            Matriz a = this, b = (Matriz)obj;

            if (b == null)
            {
                return false;
            }
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                return false;
            }

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    if (a[row, col] != b[row, col]) return false;

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Operadores
        public static Matriz operator +(Matriz a, Matriz b)
        {
            return Matriz.Add(a, b);
        }

        public static Matriz operator -(Matriz a, Matriz b)
        {
            return Matriz.Subtract(a, b);
        }
        #endregion

        #region metodos
        public static Matriz Add(Matriz a, Matriz b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Matrices no identificadas");

            Matriz result = new Matriz(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    result[row, col] = a[row, col] + b[row, col];

            return result;
        }

        public static Matriz Subtract(Matriz a, Matriz b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Matrices no identificadas");

            Matriz result = new Matriz(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
                for (int col = 0; col < a.Columns; col++)
                    result[row, col] = a[row, col] - b[row, col];

            return result;
        }

        public static Matriz multiplicacionNormal(Matriz a, Matriz b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("El número de matrices ingresadas no es la misma que b");

            Matriz result = new Matriz(a.Rows, b.Columns);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < b.Columns; col++)
                {
                    double tmp = 0;
                    for (int i = 0; i < a.Columns; i++)
                        tmp += a[row, i] * b[i, col];

                    result[row, col] = tmp;
                }
            }

            return result;
        }

        public static Matriz multiplicacionPorStrassen(Matriz a, Matriz b)
        {
            var sizes = new int[] { a.Rows, a.Columns, b.Rows, b.Columns };
            if (sizes.Distinct().Count() != 1 || (a.Rows & (a.Rows - 1)) != 0)
            {
                throw new ArgumentException("Las matrices no son cuadradas");
            }

            int N = a.Rows;

            if (N == 2)
            {
                double[,] A = a.getValues();
                double[,] B = b.getValues();

                double p1 = A[0, 0] * (B[0, 1] - B[1, 1]);
                double p2 = (A[0, 0] + A[0, 1]) * B[1, 1];
                double p3 = (A[1, 0] + A[1, 1]) * B[0, 0];
                double p4 = A[1, 1] * (B[1, 0] - B[0, 0]);
                double p5 = (A[0, 0] + A[1, 1]) * (B[0, 0] + B[1, 1]);
                double p6 = (A[0, 1] - A[1, 1]) * (B[1, 0] + B[1, 1]);
                double p7 = (A[0, 0] - A[1, 0]) * (B[0, 0] + B[0, 1]);

                double r = p5 + p6 + p4 - p2;
                double s = p1 + p2;
                double t = p3 + p4;
                double u = p1 - p7 - p3 + p5;

                double[,] C = { { r, s }, { t, u } };
                Matriz R = new Matriz(C);

                return R;
            }
            else
            {
                int halfN = N / 2;

                Matriz A = a.SubMatriz(0, halfN, 0, halfN);
                Matriz B = a.SubMatriz(0, halfN, halfN, N);
                Matriz C = a.SubMatriz(halfN, N, 0, halfN);
                Matriz D = a.SubMatriz(halfN, N, halfN, N);
                Matriz E = b.SubMatriz(0, halfN, 0, halfN);
                Matriz F = b.SubMatriz(0, halfN, halfN, N);
                Matriz G = b.SubMatriz(halfN, N, 0, halfN);
                Matriz H = b.SubMatriz(halfN, N, halfN, N);

                var p1 = multiplicacionPorStrassen(A, (F - H));
                var p2 = multiplicacionPorStrassen((A + B), H);
                var p3 = multiplicacionPorStrassen((C + D), E);
                var p4 = multiplicacionPorStrassen(D, (G - E));
                var p5 = multiplicacionPorStrassen((A + D), (E + H));
                var p6 = multiplicacionPorStrassen((B - D), (G + H));
                var p7 = multiplicacionPorStrassen((A - C), (E + F));

                var r = p5 + p6 + p4 - p2;
                var s = p1 + p2;
                var t = p3 + p4;
                var u = p1 - p3 - p7 + p5;

                return combinacionSubMatrices(r, s, t, u);
            }
        }

        public static Matriz multiplicacionPorWinograd(Matriz a, Matriz b)
        {
            return null;
        }

        private Matriz SubMatriz(int rowFrom, int rowTo, int colFrom, int colTo)
        {
            Matriz result = new Matriz(rowTo - rowFrom, colTo - colFrom);
            for (int row = rowFrom, i = 0; row < rowTo; row++, i++)
                for (int col = colFrom, j = 0; col < colTo; col++, j++)
                    result[i, j] = values[row, col];

            return result;
        }

        private static Matriz combinacionSubMatrices(Matriz a11, Matriz a12, Matriz a21, Matriz a22)
        {
            Matriz result = new Matriz(a11.Rows * 2);
            int shift = a11.Rows;
            for (int row = 0; row < a11.Rows; row++)
                for (int col = 0; col < a11.Columns; col++)
                {
                    result[row, col] = a11[row, col];
                    result[row, col + shift] = a12[row, col];
                    result[row + shift, col] = a21[row, col];
                    result[row + shift, col + shift] = a22[row, col];
                }
            return result;
        }
        #endregion
    }
}