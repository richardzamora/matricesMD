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
                    count++;
                    if (count < max)
                    {
                        addRows();
                    }
                }
                
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
            while (i<dgvA.Columns.Count)
            {
                int j = 0;
                while (j < dgvA.Rows.Count)
                {
                    dgvA.Rows[i].Cells[j].Value = random.Next(1,10);
                    dgvB.Rows[i].Cells[j].Value = random.Next(1, 10);
                    j++;
                }
                i++;
            }
        }
    }
}
