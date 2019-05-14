namespace Matrices
{
    partial class GUIPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvB = new System.Windows.Forms.DataGridView();
            this.dgvClasico = new System.Windows.Forms.DataGridView();
            this.dgvStrassen = new System.Windows.Forms.DataGridView();
            this.dgvWinograd = new System.Windows.Forms.DataGridView();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.btnCrearMatrices = new System.Windows.Forms.Button();
            this.btnLlenarMatrices = new System.Windows.Forms.Button();
            this.btnMulClasica = new System.Windows.Forms.Button();
            this.btnWinograd = new System.Windows.Forms.Button();
            this.btnStrassen = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrassen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinograd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvB
            // 
            this.dgvB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvB.Location = new System.Drawing.Point(398, 12);
            this.dgvB.Name = "dgvB";
            this.dgvB.Size = new System.Drawing.Size(376, 230);
            this.dgvB.TabIndex = 1;
            // 
            // dgvClasico
            // 
            this.dgvClasico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasico.Location = new System.Drawing.Point(12, 248);
            this.dgvClasico.Name = "dgvClasico";
            this.dgvClasico.Size = new System.Drawing.Size(250, 169);
            this.dgvClasico.TabIndex = 2;
            // 
            // dgvStrassen
            // 
            this.dgvStrassen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrassen.Location = new System.Drawing.Point(268, 248);
            this.dgvStrassen.Name = "dgvStrassen";
            this.dgvStrassen.Size = new System.Drawing.Size(250, 169);
            this.dgvStrassen.TabIndex = 3;
            // 
            // dgvWinograd
            // 
            this.dgvWinograd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWinograd.Location = new System.Drawing.Point(524, 248);
            this.dgvWinograd.Name = "dgvWinograd";
            this.dgvWinograd.Size = new System.Drawing.Size(250, 169);
            this.dgvWinograd.TabIndex = 4;
            // 
            // dgvA
            // 
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.Location = new System.Drawing.Point(12, 12);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(376, 230);
            this.dgvA.TabIndex = 5;
            // 
            // btnCrearMatrices
            // 
            this.btnCrearMatrices.Location = new System.Drawing.Point(349, 423);
            this.btnCrearMatrices.Name = "btnCrearMatrices";
            this.btnCrearMatrices.Size = new System.Drawing.Size(88, 35);
            this.btnCrearMatrices.TabIndex = 6;
            this.btnCrearMatrices.Text = "Crear Matrices";
            this.btnCrearMatrices.UseVisualStyleBackColor = true;
            this.btnCrearMatrices.Click += new System.EventHandler(this.btnCrearMatrices_Click);
            // 
            // btnLlenarMatrices
            // 
            this.btnLlenarMatrices.Location = new System.Drawing.Point(443, 423);
            this.btnLlenarMatrices.Name = "btnLlenarMatrices";
            this.btnLlenarMatrices.Size = new System.Drawing.Size(88, 35);
            this.btnLlenarMatrices.TabIndex = 6;
            this.btnLlenarMatrices.Text = "Llenar Matrices";
            this.btnLlenarMatrices.UseVisualStyleBackColor = true;
            this.btnLlenarMatrices.Click += new System.EventHandler(this.btnLlenarMatrices_Click);
            // 
            // btnMulClasica
            // 
            this.btnMulClasica.Location = new System.Drawing.Point(255, 464);
            this.btnMulClasica.Name = "btnMulClasica";
            this.btnMulClasica.Size = new System.Drawing.Size(88, 35);
            this.btnMulClasica.TabIndex = 6;
            this.btnMulClasica.Text = "Multiplicación Clásica";
            this.btnMulClasica.UseVisualStyleBackColor = true;
            this.btnMulClasica.Click += new System.EventHandler(this.btnMulClasica_Click);
            // 
            // btnWinograd
            // 
            this.btnWinograd.Location = new System.Drawing.Point(443, 464);
            this.btnWinograd.Name = "btnWinograd";
            this.btnWinograd.Size = new System.Drawing.Size(88, 35);
            this.btnWinograd.TabIndex = 6;
            this.btnWinograd.Text = "Multiplicación Winograd";
            this.btnWinograd.UseVisualStyleBackColor = true;
            // 
            // btnStrassen
            // 
            this.btnStrassen.Location = new System.Drawing.Point(349, 464);
            this.btnStrassen.Name = "btnStrassen";
            this.btnStrassen.Size = new System.Drawing.Size(88, 35);
            this.btnStrassen.TabIndex = 6;
            this.btnStrassen.Text = "Multiplicación Strassen";
            this.btnStrassen.UseVisualStyleBackColor = true;
            this.btnStrassen.Click += new System.EventHandler(this.btnStrassen_Click);
            // 
            // txtN
            // 
            this.txtN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtN.Location = new System.Drawing.Point(255, 426);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(88, 32);
            this.txtN.TabIndex = 7;
            // 
            // GUIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 510);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnLlenarMatrices);
            this.Controls.Add(this.btnStrassen);
            this.Controls.Add(this.btnWinograd);
            this.Controls.Add(this.btnMulClasica);
            this.Controls.Add(this.btnCrearMatrices);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.dgvWinograd);
            this.Controls.Add(this.dgvStrassen);
            this.Controls.Add(this.dgvClasico);
            this.Controls.Add(this.dgvB);
            this.Name = "GUIPrincipal";
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrassen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWinograd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvB;
        private System.Windows.Forms.DataGridView dgvClasico;
        private System.Windows.Forms.DataGridView dgvStrassen;
        private System.Windows.Forms.DataGridView dgvWinograd;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.Button btnCrearMatrices;
        private System.Windows.Forms.Button btnLlenarMatrices;
        private System.Windows.Forms.Button btnMulClasica;
        private System.Windows.Forms.Button btnWinograd;
        private System.Windows.Forms.Button btnStrassen;
        private System.Windows.Forms.TextBox txtN;
    }
}

