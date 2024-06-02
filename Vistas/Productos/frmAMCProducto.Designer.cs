﻿namespace Almacen.Vistas
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
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(236, 193);
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
            btnCancelar.Location = new Point(324, 193);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(102, 61);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(246, 23);
            txtDescripcion.TabIndex = 2;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(102, 89);
            txtCosto.Margin = new Padding(3, 2, 3, 2);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(82, 23);
            txtCosto.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 64);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 4;
            label1.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 92);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Costo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 35);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(102, 32);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 119);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Cod. Barra";
            // 
            // txtCodBarra
            // 
            txtCodBarra.Location = new Point(102, 116);
            txtCodBarra.Margin = new Padding(3, 2, 3, 2);
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.Size = new Size(246, 23);
            txtCodBarra.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 149);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 10;
            label5.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(102, 146);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(246, 23);
            cmbCategoria.TabIndex = 11;
            // 
            // frmAMCProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 224);
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
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCProducto";
            Text = "Producto";
            Load += frmAMCCategoria_Load;
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
    }
}