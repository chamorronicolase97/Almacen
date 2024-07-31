namespace Almacen.Vistas
{
    partial class frmAMCProducto
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
            txtDescripcion = new TextBox();
            txtCosto = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            txtCodBarra = new TextBox();
            label5 = new Label();
            cmbCategoria = new ComboBox();
            panel1 = new Panel();
            lblForm = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(270, 353);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(370, 353);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Bottom;
            txtDescripcion.Location = new Point(117, 177);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(281, 27);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCosto
            // 
            txtCosto.Anchor = AnchorStyles.Bottom;
            txtCosto.Location = new Point(117, 215);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(93, 27);
            txtCosto.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(31, 181);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 4;
            label1.Text = "Descripcion";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(66, 219);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 5;
            label2.Text = "Costo";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(89, 143);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Bottom;
            txtID.Enabled = false;
            txtID.Location = new Point(117, 139);
            txtID.Name = "txtID";
            txtID.Size = new Size(75, 27);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(39, 255);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 9;
            label4.Text = "Cod. Barra";
            // 
            // txtCodBarra
            // 
            txtCodBarra.Anchor = AnchorStyles.Bottom;
            txtCodBarra.Location = new Point(117, 251);
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.Size = new Size(281, 27);
            txtCodBarra.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Location = new Point(43, 295);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 10;
            label5.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Anchor = AnchorStyles.Bottom;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(117, 291);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(281, 28);
            cmbCategoria.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(lblForm);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 133);
            panel1.TabIndex = 13;
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.Dock = DockStyle.Fill;
            lblForm.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblForm.Location = new Point(0, 0);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(168, 46);
            lblForm.TabIndex = 0;
            lblForm.Text = "Producto";
            // 
            // frmAMCProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 395);
            Controls.Add(panel1);
            Controls.Add(cmbCategoria);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtCodBarra);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCosto);
            Controls.Add(txtDescripcion);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCProducto";
            Text = "Producto";
            Load += frmAMCCategoria_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtDescripcion;
        private TextBox txtCosto;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private TextBox txtCodBarra;
        private Label label5;
        private ComboBox cmbCategoria;
        private Panel panel1;
        private Label lblForm;
    }
}