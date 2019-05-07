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
}
