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
        #endregion

        #region Constructor
        public Matriz(int m, int n)
        {
            if(m <= 0)
            {
                throw new ArgumentOutOfRangeException("m es menor o igual a cero");
            }
            if(n <= 0)
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

            if(b == null)
            {
                return false;
            }
            if(a.Rows != b.Rows || a.Columns != b.Columns)
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

            int N = b.Rows;
            int halfN = N / 2;

            var a11 = a.SubMatriz(0, halfN, 0, halfN);
            var a12 = a.SubMatriz(0, halfN, halfN, N);
            var a21 = a.SubMatriz(halfN, N, 0, halfN);
            var a22 = a.SubMatriz(halfN, N, halfN, N);

            var b11 = b.SubMatriz(0, halfN, 0, halfN);
            var b12 = b.SubMatriz(0, halfN, halfN, N);
            var b21 = b.SubMatriz(halfN, N, 0, halfN);
            var b22 = b.SubMatriz(halfN, N, halfN, N);

            Matriz[] m = new Matriz[]
            {
                multiplicacionPorStrassen(a11 + a22, b11 + b22),
                multiplicacionPorStrassen(a21 + a22, b11),
                multiplicacionPorStrassen(a11, b12 - b22),
                multiplicacionPorStrassen(a22, b21 - b11),
                multiplicacionPorStrassen(a11 + a12, b22),
                multiplicacionPorStrassen(a21 - a11, b11 + b12),
                multiplicacionPorStrassen(a12 - a22, b21 + b22)
            };
        
            var c11 = m[0] + m[3] - m[4] + m[6];
            var c12 = m[2] + m[4];
            var c21 = m[1] + m[3];
            var c22 = m[0] - m[1] + m[2] + m[5];

            return combinacionSubMatrices(c11, c12, c21, c22);
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