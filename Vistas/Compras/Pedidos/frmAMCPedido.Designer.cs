namespace Almacen.Vistas
{
    partial class frmAMCPedido
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label3 = new Label();
            txtNroPedido = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            fontDialog1 = new FontDialog();
            panel1 = new Panel();
            vScrollBar1 = new VScrollBar();
            dgvDetalles = new DataGridView();
            btnAsignar = new Button();
            dtpFechaEntrega = new DateTimePicker();
            btnQuitarProveedor = new Button();
            btnConsultarProveedor = new Button();
            btnAsignarProveedor = new Button();
            txtProveedor = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(464, 269);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(552, 269);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(44, 73);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Fecha Entrega";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(53, 46);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Nro. Pedido";
            // 
            // txtNroPedido
            // 
            txtNroPedido.Anchor = AnchorStyles.Bottom;
            txtNroPedido.Enabled = false;
            txtNroPedido.Location = new Point(129, 43);
            txtNroPedido.Margin = new Padding(3, 2, 3, 2);
            txtNroPedido.Name = "txtNroPedido";
            txtNroPedido.Size = new Size(66, 23);
            txtNroPedido.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(vScrollBar1);
            panel1.Controls.Add(dgvDetalles);
            panel1.Location = new Point(41, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(544, 144);
            panel1.TabIndex = 8;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(525, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(19, 144);
            vScrollBar1.TabIndex = 1;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(0, 0);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.Size = new Size(571, 137);
            dgvDetalles.TabIndex = 0;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(464, 79);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(121, 23);
            btnAsignar.TabIndex = 9;
            btnAsignar.Text = "Añadir Producto";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.CustomFormat = "";
            dtpFechaEntrega.Format = DateTimePickerFormat.Short;
            dtpFechaEntrega.Location = new Point(129, 71);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(98, 23);
            dtpFechaEntrega.TabIndex = 10;
            // 
            // btnQuitarProveedor
            // 
            btnQuitarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarProveedor.Location = new Point(554, 39);
            btnQuitarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnQuitarProveedor.Name = "btnQuitarProveedor";
            btnQuitarProveedor.Size = new Size(31, 28);
            btnQuitarProveedor.TabIndex = 23;
            btnQuitarProveedor.UseVisualStyleBackColor = true;
            // 
            // btnConsultarProveedor
            // 
            btnConsultarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarProveedor.Location = new Point(525, 39);
            btnConsultarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnConsultarProveedor.Name = "btnConsultarProveedor";
            btnConsultarProveedor.Size = new Size(31, 28);
            btnConsultarProveedor.TabIndex = 22;
            btnConsultarProveedor.UseVisualStyleBackColor = true;
            // 
            // btnAsignarProveedor
            // 
            btnAsignarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarProveedor.Location = new Point(496, 39);
            btnAsignarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnAsignarProveedor.Name = "btnAsignarProveedor";
            btnAsignarProveedor.Size = new Size(31, 28);
            btnAsignarProveedor.TabIndex = 21;
            btnAsignarProveedor.UseVisualStyleBackColor = true;
            btnAsignarProveedor.Click += btnAsignarProveedor_Click;
            // 
            // txtProveedor
            // 
            txtProveedor.Anchor = AnchorStyles.Bottom;
            txtProveedor.Location = new Point(319, 43);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(173, 23);
            txtProveedor.TabIndex = 19;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(257, 46);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 20;
            label2.Text = "Proveedor";
            // 
            // frmAMCPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 302);
            Controls.Add(btnQuitarProveedor);
            Controls.Add(btnConsultarProveedor);
            Controls.Add(btnAsignarProveedor);
            Controls.Add(txtProveedor);
            Controls.Add(label2);
            Controls.Add(dtpFechaEntrega);
            Controls.Add(btnAsignar);
            Controls.Add(panel1);
            Controls.Add(txtNroPedido);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmAMCPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedido";
            Load += frmAMCPedido_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private Label label3;
        private TextBox txtNroPedido;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontDialog fontDialog1;
        private Panel panel1;
        private DataGridView dgvDetalles;
        private Button btnAsignar;
        private DateTimePicker dtpFechaEntrega;
        private VScrollBar vScrollBar1;
        private Button btnQuitarProveedor;
        private Button btnConsultarProveedor;
        private Button btnAsignarProveedor;
        private TextBox txtProveedor;
        private Label label2;
    }
}