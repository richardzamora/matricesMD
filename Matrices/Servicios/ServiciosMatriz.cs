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


        public static int[,] multiplicacionStrassen(int[,] fila, int[,] columna)
        {
            int[,] respuesta = new int[2,2];

            for (int i = 0; i < fila.Length/2; i+=2)
            {
                int a, b, c, d, e, f, g, h;

                a = fila[i, 0];
                b = fila[i+1, 0];
                c = fila[i, 1];
                d = fila[i+1, 1];

                e = columna[i, 0];
                f = columna[i, 1];
                g = columna[i+1, 0];
                h = columna[i+1, 1];

                int[,] calcTemp = calculoStrassen(a, b, c, d, e, f, g, h);
                respuesta = sumarMatrices(respuesta, calcTemp);
            }

            return respuesta;
        }

        private static int[,] sumarMatrices(int[,] mA, int[,] mB)
        {
            int[,] respuesta = new int[2, 2];

            respuesta[0, 0] = mA[0, 0] + mB[0,0];
            respuesta[0, 1] = mA[0, 1] + mB[0, 1];
            respuesta[1, 0] = mA[1, 0] + mB[1, 0];
            respuesta[1, 1] = mA[1, 1] + mB[1, 1];

            return respuesta;
        }

        private static int[,] calculoStrassen(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int[,] respuesta = new int[2, 2];

            int p1 = a * (f - h);
            int p2 = (a + b) * h;
            int p3 = (c + d) * e;
            int p4 = d * (g - e);
            int p5 = (a + d) * (e + h);
            int p6 = (b - d) * (g + h);
            int p7 = (a - c) * (e + f);

            respuesta[0, 0] = p5 + p6 + p4 - p2;
            respuesta[0, 1] = p1 + p2;
            respuesta[1, 0] = p3 + p4;
            respuesta[1, 1] = p1 - p7 - p3 + p5;

            return respuesta;
        }

        public static int[,] multiplicacionWinograd(int[,] fila, int[,] columna)
        {
            int[,] respuesta = new int[2, 2];

            for (int i = 0; i < fila.Length / 2; i += 2)
            {
                int a, b, c, d, e, f, g, h;

                a = fila[i, 0];
                b = fila[i + 1, 0];
                c = fila[i, 1];
                d = fila[i + 1, 1];

                e = columna[i, 0];
                f = columna[i, 1];
                g = columna[i + 1, 0];
                h = columna[i + 1, 1];

                int[,] calcTemp = calculoWinograd(a, b, c, d, e, f, g, h);
                respuesta = sumarMatrices(respuesta, calcTemp);
            }

            return respuesta;
        }

        private static int[,] calculoWinograd(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int[,] respuesta = new int[2, 2];

            int p1 = (c + d - a) * (h - f + e);
            int p2 = a * e;
            int p3 = b * g;
            int p4 = (a - c) * (h - f);
            int p5 = (c + d) * (f - e);
            int p6 = (b - c + a - d) * h;
            int p7 = d * (g - h + f - e);

            respuesta[0, 0] = p2 + p3;
            respuesta[0, 1] = p1 + p2 + p5 + p6;
            respuesta[1, 0] = p1 + p2 + p4 + p7;
            respuesta[1, 1] = p1 + p2 + p4 + p5;

            return respuesta;
        }
    }
}