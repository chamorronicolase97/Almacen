namespace Almacen.Vistas
{
    partial class frmAMCPermiso
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
            txtCodPermiso = new TextBox();
            txtDescripcion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            panel1 = new Panel();
            lblForm = new Label();
            btnAsignar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(270, 272);
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
            btnCancelar.Location = new Point(370, 272);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCodPermiso
            // 
            txtCodPermiso.Location = new Point(151, 169);
            txtCodPermiso.Name = "txtCodPermiso";
            txtCodPermiso.Size = new Size(281, 27);
            txtCodPermiso.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(151, 204);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(281, 55);
            txtDescripcion.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 172);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 4;
            label1.Text = "Código Permiso";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 204);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 5;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 139);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(151, 135);
            txtID.Name = "txtID";
            txtID.Size = new Size(75, 27);
            txtID.TabIndex = 7;
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
            lblForm.Size = new Size(149, 46);
            lblForm.TabIndex = 0;
            lblForm.Text = "Permiso";
            // 
            // btnAsignar
            // 
            btnAsignar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAsignar.Location = new Point(21, 272);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(94, 29);
            btnAsignar.TabIndex = 14;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // frmAMCPermiso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 313);
            Controls.Add(btnAsignar);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtCodPermiso);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAMCPermiso";
            Text = "Permiso";
            Load += frmAMCPermiso_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtCodPermiso;
        private TextBox txtDescripcion;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private Panel panel1;
        private Label lblForm;
        private Button btnAsignar;
    }
}