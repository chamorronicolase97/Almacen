namespace Almacen.Vistas
{
    partial class frmABMSCategorias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvDatos = new DataGridView();
            splitContainer1 = new SplitContainer();
            txtFiltro = new TextBox();
            btnBorrar = new Button();
            btnModificar = new Button();
            btnCrear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(0, 3);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(800, 362);
            dgvDatos.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtFiltro);
            splitContainer1.Panel1.Controls.Add(btnBorrar);
            splitContainer1.Panel1.Controls.Add(btnModificar);
            splitContainer1.Panel1.Controls.Add(btnCrear);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 81;
            splitContainer1.TabIndex = 1;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(12, 32);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(188, 27);
            txtFiltro.TabIndex = 3;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(736, 21);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(57, 48);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "B";
            btnBorrar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(673, 21);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(57, 48);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "M";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(610, 21);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(57, 48);
            btnCrear.TabIndex = 0;
            btnCrear.Text = "C";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // frmABMSCategorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "frmABMSCategorias";
            Text = "frmABMSCategorias";
            Load += frmABMSCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDatos;
        private SplitContainer splitContainer1;
        private Button btnCrear;
        private Button btnBorrar;
        private Button btnModificar;
        private TextBox txtFiltro;
    }
}