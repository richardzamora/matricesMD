using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrices
{
    public partial class GUIPrincipal : Form
    {
        public GUIPrincipal()
        {
            InitializeComponent();
        }

        private void btnCrearMatrices_Click(object sender, EventArgs e)
        {
            int n;
            Boolean bN = int.TryParse(txtN.Text, out n);
            if (bN)
            {
                limpiarMatrices();
                int count = 0;
                int max = (int)Math.Pow(2, n);
                while (count < max)
                {
                    addColums();
                    addRows();
                    count++;
                }
                dgvA.AllowUserToAddRows = false;
                dgvB.AllowUserToAddRows = false;
                dgvClasico.AllowUserToAddRows = false;
                dgvStrassen.AllowUserToAddRows = false;
                dgvWinograd.AllowUserToAddRows = false;
                
            }
            else
            {
                MessageBox.Show("El valor de n no es valido");
            }
        }

        


        private void limpiarMatrices()
        {
            dgvA.Rows.Clear();
            dgvA.Columns.Clear();

            dgvB.Rows.Clear();
            dgvB.Columns.Clear();

            dgvClasico.Rows.Clear();
            dgvClasico.Columns.Clear();
            
            dgvStrassen.Rows.Clear();
            dgvStrassen.Columns.Clear();

            dgvWinograd.Rows.Clear();
            dgvWinograd.Columns.Clear();
            
        }

        private void addColums()
        {
            dgvA.Columns.Add("", "");
            dgvB.Columns.Add("", "");

            dgvClasico.Columns.Add("", "");
            dgvStrassen.Columns.Add("", "");
            dgvWinograd.Columns.Add("", "");
        }
        private void addRows()
        {
            dgvA.Rows.Add();
            dgvB.Rows.Add();

            dgvClasico.Rows.Add();
            dgvStrassen.Rows.Add();
            dgvWinograd.Rows.Add();
        }

        private void btnLlenarMatrices_Click(object sender, EventArgs e)
        {
            llenarMatrizRandom();
        }

        private void llenarMatrizRandom()
        {
            int i = 0;
            Random random = new Random();
            while (i < dgvA.Columns.Count)
            {
                int j = 0;
                while (j < dgvA.Rows.Count)
                {
                    dgvA.Rows[i].Cells[j].Value = random.Next(1, 10);
                    dgvB.Rows[i].Cells[j].Value = random.Next(1, 10);
                    j++;
                }
                i++;
            }
        }

        private void btnMulClasica_Click(object sender, EventArgs e)
        {
            int i = 0;
            while(i < dgvA.Columns.Count)
            {
                int j = 0;
                int[] rows = getRow(dgvA, i);
                while (j < dgvB.Rows.Count)
                {
                    int[] columns = getColumn(dgvB, j);
                    dgvClasico.Rows[i].Cells[j].Value = Servicios.ServiciosMatriz.multiplicacionClasica(rows, columns);
                    j++;
                }
                i++;
            }
        }

        private int[] getRow(DataGridView grilla, int pos)
        {
            int[] fila = new int[grilla.Rows.Count];

            for (int i = 0; i < fila.Length; i++)
            {   
                fila[i] = int.Parse(grilla.Rows[pos].Cells[i].Value.ToString());
            }

            return fila;
        }

        private int[] getColumn(DataGridView grilla, int pos)
        {
            int[] columna = new int[grilla.Rows.Count];

            for (int i = 0; i < columna.Length; i++)
            {
                columna[i] = int.Parse(grilla.Rows[i].Cells[pos].Value.ToString());
            }

            return columna;
        }

        private double[,] getMatiz(DataGridView grilla)
        {
            double[,] respuesta = new double[dgvB.Rows.Count, dgvA.Columns.Count];

            for(int i = 0; i < dgvB.Rows.Count; i++)
            {
                for (int j = 0; j < dgvA.Columns.Count; j++)
                {
                    respuesta[i,j] = (int) grilla.Rows[i].Cells[j].Value;
                }
            }

            return respuesta;
        }

        private int[,] getTwoRows(DataGridView grilla, int pos)
        {
            int[,] fila = new int[grilla.Rows.Count,2];

            for (int i = 0; i < fila.Length/2; i++)
            {
                fila[i,0] = int.Parse(grilla.Rows[pos].Cells[i].Value.ToString());
                fila[i, 1] = int.Parse(grilla.Rows[pos + 1].Cells[i].Value.ToString());
            }

            return fila;
        }

        private int[,] getTwoColumns(DataGridView grilla, int pos)
        {
            int[,] fila = new int[grilla.Rows.Count, 2];

            for (int i = 0; i < fila.Length/2; i++)
            {
                fila[i, 0] = int.Parse(grilla.Rows[i].Cells[pos].Value.ToString());
                fila[i, 1] = int.Parse(grilla.Rows[i].Cells[pos + 1].Value.ToString());
            }

            return fila;
        }

        private void btnStrassen_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < dgvA.Columns.Count)
            {
                int j = 0;
                int[,] rows = getTwoRows(dgvA, i);
                while (j < dgvB.Rows.Count)
                {
                    int[,] columns = getTwoColumns(dgvB, j);
                    int[,] Strassen = Servicios.ServiciosMatriz.multiplicacionStrassen(rows, columns);
                    dgvStrassen.Rows[i].Cells[j].Value = Strassen[0,0];
                    dgvStrassen.Rows[i+1].Cells[j].Value = Strassen[1, 0];
                    dgvStrassen.Rows[i].Cells[j+1].Value = Strassen[0, 1];
                    dgvStrassen.Rows[i+1].Cells[j+1].Value = Strassen[1, 1];
                    j +=2;
                }
                i+=2;
            }

        }

        private void btnWinograd_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < dgvA.Columns.Count)
            {
                int j = 0;
                int[,] rows = getTwoRows(dgvA, i);
                while (j < dgvB.Rows.Count)
                {
                    int[,] columns = getTwoColumns(dgvB, j);
                    int[,] winograd = Servicios.ServiciosMatriz.multiplicacionWinograd(rows, columns);
                    dgvWinograd.Rows[i].Cells[j].Value = winograd[0, 0];
                    dgvWinograd.Rows[i + 1].Cells[j].Value = winograd[1, 0];
                    dgvWinograd.Rows[i].Cells[j + 1].Value = winograd[0, 1];
                    dgvWinograd.Rows[i + 1].Cells[j + 1].Value = winograd[1, 1];
                    j += 2;
                }
                i += 2;
            }
        }
    }
}
