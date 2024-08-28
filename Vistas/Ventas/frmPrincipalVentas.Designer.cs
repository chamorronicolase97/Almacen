namespace Almacen.Vistas.Ventas
{
    partial class frmPrincipalVentas
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
            ContainerCaja = new SplitContainer();
            subcontainerCaja = new SplitContainer();
            lblOperador = new Label();
            dataGridView1 = new DataGridView();
            dtpFecha = new DateTimePicker();
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            btnCierreParcial = new Button();
            btnArticulos = new Button();
            button3 = new Button();
            btnClientes = new Button();
            btnNotaCredito = new Button();
            btnNuevaVenta = new Button();
            groupBoxGerencial = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            textBox1 = new TextBox();
            btnCerrarCaja = new Button();
            CustomToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)ContainerCaja).BeginInit();
            ContainerCaja.Panel1.SuspendLayout();
            ContainerCaja.Panel2.SuspendLayout();
            ContainerCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)subcontainerCaja).BeginInit();
            subcontainerCaja.Panel1.SuspendLayout();
            subcontainerCaja.Panel2.SuspendLayout();
            subcontainerCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // ContainerCaja
            // 
            ContainerCaja.BorderStyle = BorderStyle.FixedSingle;
            ContainerCaja.Dock = DockStyle.Fill;
            ContainerCaja.Location = new Point(0, 0);
            ContainerCaja.Name = "ContainerCaja";
            ContainerCaja.Orientation = Orientation.Horizontal;
            // 
            // ContainerCaja.Panel1
            // 
            ContainerCaja.Panel1.Controls.Add(subcontainerCaja);
            // 
            // ContainerCaja.Panel2
            // 
            ContainerCaja.Panel2.Controls.Add(groupBox2);
            ContainerCaja.Size = new Size(800, 450);
            ContainerCaja.SplitterDistance = 357;
            ContainerCaja.TabIndex = 0;
            // 
            // subcontainerCaja
            // 
            subcontainerCaja.Dock = DockStyle.Fill;
            subcontainerCaja.Location = new Point(0, 0);
            subcontainerCaja.Name = "subcontainerCaja";
            // 
            // subcontainerCaja.Panel1
            // 
            subcontainerCaja.Panel1.Controls.Add(lblOperador);
            subcontainerCaja.Panel1.Controls.Add(dataGridView1);
            subcontainerCaja.Panel1.Controls.Add(dtpFecha);
            // 
            // subcontainerCaja.Panel2
            // 
            subcontainerCaja.Panel2.Controls.Add(groupBox1);
            subcontainerCaja.Size = new Size(798, 355);
            subcontainerCaja.SplitterDistance = 497;
            subcontainerCaja.TabIndex = 0;
            // 
            // lblOperador
            // 
            lblOperador.AutoSize = true;
            lblOperador.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblOperador.Location = new Point(136, 11);
            lblOperador.Name = "lblOperador";
            lblOperador.Size = new Size(210, 32);
            lblOperador.TabIndex = 2;
            lblOperador.Text = "Nombre Operador";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(491, 288);
            dataGridView1.TabIndex = 1;
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarFont = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(11, 11);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(109, 23);
            dtpFecha.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnCierreParcial);
            groupBox1.Controls.Add(btnArticulos);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(btnClientes);
            groupBox1.Controls.Add(btnNotaCredito);
            groupBox1.Controls.Add(btnNuevaVenta);
            groupBox1.Controls.Add(groupBoxGerencial);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 355);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Caja";
            // 
            // button2
            // 
            button2.Location = new Point(167, 282);
            button2.Name = "button2";
            button2.Size = new Size(109, 46);
            button2.TabIndex = 7;
            button2.Text = "Cuentas Corrientes";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(28, 282);
            button1.Name = "button1";
            button1.Size = new Size(109, 46);
            button1.TabIndex = 6;
            button1.Text = "Medios de Pago";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCierreParcial
            // 
            btnCierreParcial.Location = new Point(28, 139);
            btnCierreParcial.Name = "btnCierreParcial";
            btnCierreParcial.Size = new Size(109, 46);
            btnCierreParcial.TabIndex = 5;
            btnCierreParcial.Text = "Cierre Parcial";
            btnCierreParcial.UseVisualStyleBackColor = true;
            // 
            // btnArticulos
            // 
            btnArticulos.Location = new Point(28, 218);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.Size = new Size(109, 46);
            btnArticulos.TabIndex = 4;
            btnArticulos.Text = "Consultar Articulos";
            btnArticulos.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(167, 139);
            button3.Name = "button3";
            button3.Size = new Size(109, 46);
            button3.TabIndex = 3;
            button3.Text = "Ventas";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(167, 218);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(109, 46);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Consultar Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnNotaCredito
            // 
            btnNotaCredito.Location = new Point(167, 64);
            btnNotaCredito.Name = "btnNotaCredito";
            btnNotaCredito.Size = new Size(109, 46);
            btnNotaCredito.TabIndex = 1;
            btnNotaCredito.Text = "Nota Credito";
            btnNotaCredito.UseVisualStyleBackColor = true;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.BackColor = SystemColors.ActiveCaption;
            btnNuevaVenta.Location = new Point(28, 64);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(109, 46);
            btnNuevaVenta.TabIndex = 0;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.UseVisualStyleBackColor = false;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // groupBoxGerencial
            // 
            groupBoxGerencial.Location = new Point(6, 202);
            groupBoxGerencial.Name = "groupBoxGerencial";
            groupBoxGerencial.Size = new Size(280, 147);
            groupBoxGerencial.TabIndex = 8;
            groupBoxGerencial.TabStop = false;
            groupBoxGerencial.Text = "Gerencial";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(btnCerrarCaja);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(798, 87);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "General";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(290, 45);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 3;
            label1.Text = "Total";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(338, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 23);
            textBox1.TabIndex = 7;
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.BackColor = SystemColors.ActiveCaption;
            btnCerrarCaja.Location = new Point(668, 30);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(109, 46);
            btnCerrarCaja.TabIndex = 6;
            btnCerrarCaja.Text = "Cerrar Caja";
            btnCerrarCaja.UseVisualStyleBackColor = false;
            // 
            // frmPrincipalVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ContainerCaja);
            Name = "frmPrincipalVentas";
            Text = "Principal de Ventas";
            Load += frmPrincipalVentas_Load;
            ContainerCaja.Panel1.ResumeLayout(false);
            ContainerCaja.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ContainerCaja).EndInit();
            ContainerCaja.ResumeLayout(false);
            subcontainerCaja.Panel1.ResumeLayout(false);
            subcontainerCaja.Panel1.PerformLayout();
            subcontainerCaja.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)subcontainerCaja).EndInit();
            subcontainerCaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer ContainerCaja;
        private SplitContainer subcontainerCaja;
        private DataGridView dataGridView1;
        private DateTimePicker dtpFecha;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblOperador;
        private Button btnCierreParcial;
        private Button btnArticulos;
        private Button button3;
        private Button btnClientes;
        private Button btnNotaCredito;
        private Button btnNuevaVenta;
        private Label label1;
        private TextBox textBox1;
        private Button btnCerrarCaja;
        private Button button1;
        private Button button2;
        private GroupBox groupBoxGerencial;
        private ToolTip CustomToolTip;
    }
}