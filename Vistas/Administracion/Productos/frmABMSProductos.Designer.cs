namespace Almacen.Vistas
{
    partial class frmABMSProductos
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmABMSProductos));
            dgvDatos = new DataGridView();
            splitContainer1 = new SplitContainer();
            pnlBotones = new Panel();
            btnBorrar = new Button();
            brnModificar = new Button();
            btnCrear = new Button();
            txtFiltro = new TextBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(0, 3);
            dgvDatos.Margin = new Padding(3, 2, 3, 2);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 29;
            dgvDatos.Size = new Size(610, 307);
            dgvDatos.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlBotones);
            splitContainer1.Panel1.Controls.Add(txtFiltro);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Size = new Size(610, 361);
            splitContainer1.SplitterDistance = 62;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 1;
            // 
            // pnlBotones
            // 
            pnlBotones.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlBotones.Controls.Add(btnBorrar);
            pnlBotones.Controls.Add(brnModificar);
            pnlBotones.Controls.Add(btnCrear);
            pnlBotones.Location = new Point(451, 7);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(151, 45);
            pnlBotones.TabIndex = 12;
            // 
            // btnBorrar
            // 
            btnBorrar.Image = (Image)resources.GetObject("btnBorrar.Image");
            btnBorrar.Location = new Point(103, 4);
            btnBorrar.Margin = new Padding(3, 2, 3, 2);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(41, 36);
            btnBorrar.TabIndex = 11;
            toolTip1.SetToolTip(btnBorrar, "Eliminar");
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // brnModificar
            // 
            brnModificar.Image = (Image)resources.GetObject("brnModificar.Image");
            brnModificar.Location = new Point(56, 4);
            brnModificar.Margin = new Padding(3, 2, 3, 2);
            brnModificar.Name = "brnModificar";
            brnModificar.Size = new Size(41, 36);
            brnModificar.TabIndex = 10;
            toolTip1.SetToolTip(brnModificar, "Modificar");
            brnModificar.UseVisualStyleBackColor = true;
            brnModificar.Click += btnModificar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Image = (Image)resources.GetObject("btnCrear.Image");
            btnCrear.Location = new Point(9, 4);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(41, 36);
            btnCrear.TabIndex = 9;
            toolTip1.SetToolTip(btnCrear, "Nuevo");
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(10, 24);
            txtFiltro.Margin = new Padding(3, 2, 3, 2);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(165, 23);
            txtFiltro.TabIndex = 3;
            // 
            // frmABMSProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 361);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(600, 400);
            Name = "frmABMSProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            Load += frmABMSProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDatos;
        private SplitContainer splitContainer1;
        private TextBox txtFiltro;
        private Button btnBorrar;
        private Button brnModificar;
        private Button btnCrear;
        private Panel pnlBotones;
        private ToolTip toolTip1;
    }
}