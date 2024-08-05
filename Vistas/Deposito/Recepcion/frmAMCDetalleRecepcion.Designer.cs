namespace Almacen.Vistas
{
    partial class frmAMCDetalleRecepcion
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
            txtProducto = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtNroPedido = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            fontDialog1 = new FontDialog();
            txtProveedor = new TextBox();
            label2 = new Label();
            btnAsignarProveedor = new Button();
            btnAsignarProducto = new Button();
            txtCantidad = new TextBox();
            label4 = new Label();
            txtCostoUnitario = new TextBox();
            label5 = new Label();
            btnConsultarProducto = new Button();
            btnQuitarProducto = new Button();
            btnQuitarProveedor = new Button();
            btnConsultarProveedor = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(315, 148);
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
            btnCancelar.Location = new Point(403, 148);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtProducto
            // 
            txtProducto.Anchor = AnchorStyles.Bottom;
            txtProducto.Location = new Point(118, 52);
            txtProducto.Margin = new Padding(3, 2, 3, 2);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(173, 23);
            txtProducto.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(56, 55);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "Producto";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(42, 31);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Nro. Pedido";
            // 
            // txtNroPedido
            // 
            txtNroPedido.Anchor = AnchorStyles.Bottom;
            txtNroPedido.Enabled = false;
            txtNroPedido.Location = new Point(118, 25);
            txtNroPedido.Margin = new Padding(3, 2, 3, 2);
            txtNroPedido.Name = "txtNroPedido";
            txtNroPedido.ReadOnly = true;
            txtNroPedido.Size = new Size(66, 23);
            txtNroPedido.TabIndex = 7;
            // 
            // txtProveedor
            // 
            txtProveedor.Anchor = AnchorStyles.Bottom;
            txtProveedor.Location = new Point(118, 79);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(173, 23);
            txtProveedor.TabIndex = 8;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(52, 82);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 9;
            label2.Text = "Proveedor";
            // 
            // btnAsignarProveedor
            // 
            btnAsignarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarProveedor.Location = new Point(281, 78);
            btnAsignarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnAsignarProveedor.Name = "btnAsignarProveedor";
            btnAsignarProveedor.Size = new Size(31, 28);
            btnAsignarProveedor.TabIndex = 11;
            btnAsignarProveedor.UseVisualStyleBackColor = true;
            btnAsignarProveedor.Click += btnAsignarProveedor_Click;
            // 
            // btnAsignarProducto
            // 
            btnAsignarProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAsignarProducto.Location = new Point(281, 48);
            btnAsignarProducto.Margin = new Padding(3, 2, 3, 2);
            btnAsignarProducto.Name = "btnAsignarProducto";
            btnAsignarProducto.Size = new Size(31, 28);
            btnAsignarProducto.TabIndex = 12;
            btnAsignarProducto.UseVisualStyleBackColor = true;
            btnAsignarProducto.Click += btnAsignarProducto_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Anchor = AnchorStyles.Bottom;
            txtCantidad.Location = new Point(118, 106);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(66, 23);
            txtCantidad.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(56, 109);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 14;
            label4.Text = "Cantidad";
            // 
            // txtCostoUnitario
            // 
            txtCostoUnitario.Anchor = AnchorStyles.Bottom;
            txtCostoUnitario.Location = new Point(118, 133);
            txtCostoUnitario.Margin = new Padding(3, 2, 3, 2);
            txtCostoUnitario.Name = "txtCostoUnitario";
            txtCostoUnitario.Size = new Size(66, 23);
            txtCostoUnitario.TabIndex = 15;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Location = new Point(30, 136);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 16;
            label5.Text = "Costo Unitario";
            // 
            // btnConsultarProducto
            // 
            btnConsultarProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarProducto.Location = new Point(310, 48);
            btnConsultarProducto.Margin = new Padding(3, 2, 3, 2);
            btnConsultarProducto.Name = "btnConsultarProducto";
            btnConsultarProducto.Size = new Size(31, 28);
            btnConsultarProducto.TabIndex = 17;
            btnConsultarProducto.UseVisualStyleBackColor = true;
            btnConsultarProducto.Click += btnConsultarProducto_Click;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarProducto.Location = new Point(339, 48);
            btnQuitarProducto.Margin = new Padding(3, 2, 3, 2);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(31, 28);
            btnQuitarProducto.TabIndex = 18;
            btnQuitarProducto.UseVisualStyleBackColor = true;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // btnQuitarProveedor
            // 
            btnQuitarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitarProveedor.Location = new Point(339, 78);
            btnQuitarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnQuitarProveedor.Name = "btnQuitarProveedor";
            btnQuitarProveedor.Size = new Size(31, 28);
            btnQuitarProveedor.TabIndex = 20;
            btnQuitarProveedor.UseVisualStyleBackColor = true;
            btnQuitarProveedor.Click += btnQuitarProveedor_Click;
            // 
            // btnConsultarProveedor
            // 
            btnConsultarProveedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConsultarProveedor.Location = new Point(310, 78);
            btnConsultarProveedor.Margin = new Padding(3, 2, 3, 2);
            btnConsultarProveedor.Name = "btnConsultarProveedor";
            btnConsultarProveedor.Size = new Size(31, 28);
            btnConsultarProveedor.TabIndex = 19;
            btnConsultarProveedor.UseVisualStyleBackColor = true;
            btnConsultarProveedor.Click += btnConsultarProveedor_Click;
            // 
            // frmAMCDetalleRecepcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 181);
            Controls.Add(btnQuitarProveedor);
            Controls.Add(btnConsultarProveedor);
            Controls.Add(btnQuitarProducto);
            Controls.Add(btnConsultarProducto);
            Controls.Add(txtCostoUnitario);
            Controls.Add(label5);
            Controls.Add(txtCantidad);
            Controls.Add(label4);
            Controls.Add(btnAsignarProducto);
            Controls.Add(btnAsignarProveedor);
            Controls.Add(txtProveedor);
            Controls.Add(label2);
            Controls.Add(txtProducto);
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
            Name = "frmAMCDetalleRecepcion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetalleRecepcion";
            Load += frmAMCDetallePedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtProducto;
        private Label label1;
        private Label label3;
        private TextBox txtNroPedido;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontDialog fontDialog1;
        private TextBox txtProveedor;
        private Label label2;
        private Button btnAsignarProveedor;
        private Button btnAsignarProducto;
        private TextBox txtCantidad;
        private Label label4;
        private TextBox txtCostoUnitario;
        private Label label5;
        private Button btnConsultarProducto;
        private Button btnQuitarProducto;
        private Button btnQuitarProveedor;
        private Button btnConsultarProveedor;
    }
}