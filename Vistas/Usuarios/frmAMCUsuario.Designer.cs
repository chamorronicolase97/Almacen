﻿namespace Almacen.Vistas
{
    partial class frmAMCUsuario
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
            txtNomApe = new TextBox();
            txtUsuario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            txtContraseña = new TextBox();
            label5 = new Label();
            cmbGrupo = new ComboBox();
            panel1 = new Panel();
            lblForm = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(270, 328);
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
            btnCancelar.Location = new Point(370, 328);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNomApe
            // 
            txtNomApe.Location = new Point(151, 145);
            txtNomApe.Name = "txtNomApe";
            txtNomApe.Size = new Size(281, 27);
            txtNomApe.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(151, 183);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(281, 27);
            txtUsuario.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 149);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre Y Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 187);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 5;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 96);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(151, 92);
            txtID.Name = "txtID";
            txtID.Size = new Size(75, 27);
            txtID.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 223);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 9;
            label4.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(151, 219);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(281, 27);
            txtContraseña.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(98, 263);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 10;
            label5.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(151, 259);
            cmbGrupo.Margin = new Padding(3, 4, 3, 4);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(281, 28);
            cmbGrupo.TabIndex = 11;
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
            panel1.TabIndex = 12;
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.Dock = DockStyle.Fill;
            lblForm.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblForm.Location = new Point(0, 0);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(144, 46);
            lblForm.TabIndex = 0;
            lblForm.Text = "Usuario";
            // 
            // frmAMCUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 369);
            Controls.Add(panel1);
            Controls.Add(cmbGrupo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtContraseña);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            Controls.Add(txtNomApe);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCUsuario";
            Text = "Usuario";
            Load += frmAMCUsuario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtNomApe;
        private TextBox txtUsuario;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private TextBox txtContraseña;
        private Label label5;
        private ComboBox cmbGrupo;
        private Panel panel1;
        private Label lblForm;
    }
}